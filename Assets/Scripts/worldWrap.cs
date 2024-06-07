using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class worldWrap : MonoBehaviour
{
    private Rigidbody2D rb;
    public float threshold = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        float right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)).x;
        float left = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

        float top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottom = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        if(objectPos.x<0)
        {
            transform.position = new Vector2(right - threshold, transform.position.y);

        }
        else if (objectPos.x > Screen.width)
        {
            transform.position = new Vector2(left + threshold, transform.position.y);

        }
        else if (objectPos.y < 0)
        {
            transform.position = new Vector2(transform.position.x, top - threshold);
        }

        else if (objectPos.y > Screen.height)
        {
            transform.position = new Vector2(transform.position.x, bottom + threshold);
        }


    }
}
