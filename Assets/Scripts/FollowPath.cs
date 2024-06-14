using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject[] paths;
    private GameObject path;
    public float moveSpeed = 3f;

    private Vector3 goTO;
    private Rigidbody2D rb;

    private bool inPos = false;
    private bool goZero = false;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private int lastChildIndex;
    private int currIndex;





    void Start()
    {
        path = paths[Random.Range(0, paths.Length)];

        rb = gameObject.GetComponent<Rigidbody2D>();
        lastChildIndex = path.transform.childCount - 1;
        startPoint = path.transform.GetChild(0).transform.position;
        endPoint = path.transform.GetChild(lastChildIndex).transform.position;

        float dis1 = Vector3.Distance(transform.position, startPoint);
        float dis2 = Vector3.Distance(transform.position, endPoint);

        if (dis1 < dis2)
        {
            goTO = path.transform.GetChild(0).transform.position;
            goZero = false;
        }
        else { goTO = path.transform.GetChild(lastChildIndex).transform.position; goZero = true;  }

    }

    private void FixedUpdate()
    {   
        if(Vector3.Distance(transform.position,goTO) <= 0.005) inPos = true;

        if(!inPos)
        { 
            Vector3 nextPos = Vector3.MoveTowards(transform.position,goTO,moveSpeed*Time.deltaTime);
            rb.MovePosition(nextPos);
            //print(Vector3.Distance(transform.position, goTO));
        }
        else
        {   
            if (goZero) 
            {
                Vector3 nextPos = Vector3.MoveTowards(transform.position, path.transform.GetChild(currIndex - 1).transform.position, moveSpeed * Time.deltaTime);
                rb.MovePosition(nextPos);
                if (Vector3.Distance(transform.position, path.transform.GetChild(currIndex - 1).transform.position)<0.005)
                {
                    if (currIndex == 1) goZero = false;

                    currIndex--;
                }
            }
            else
            {
                Vector3 nextPos = Vector3.MoveTowards(transform.position, path.transform.GetChild(currIndex + 1).transform.position, moveSpeed * Time.deltaTime);
                rb.MovePosition(nextPos);
                if (Vector3.Distance(transform.position, path.transform.GetChild(currIndex + 1).transform.position) < 0.005) 
                { 
                    if (currIndex == lastChildIndex     - 1) goZero = true;

                    currIndex++;
                }
            }
        }
    }
}
