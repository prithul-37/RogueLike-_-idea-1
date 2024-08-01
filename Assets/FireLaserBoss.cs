using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;

public class FireLaserBoss : MonoBehaviour
{
    RaycastHit2D hit;
    LayerMask mask;
    LineRenderer lineRenderer;
    public GameObject hitEffect;
    void Start()
    {
         mask = LayerMask.GetMask("Player");
         lineRenderer = GetComponent<LineRenderer>();

    }
    void Update()
    {       
        hit = Physics2D.Raycast(transform.position,new Vector3(0,1,0),100,mask);

        if (hit.collider != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            var effect = Instantiate(hitEffect, hit.point, Quaternion.identity);
            
        }

        else {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position+new Vector3(0,100,0));
        }
        
    }
}
