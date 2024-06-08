using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage = 20;
    public float lifeTime = 4.0f;
    public GameObject hitAnimationObj;

    void Start()
    {
        StartCoroutine(DestroyObject());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemy>().Damage(damage);
            Instantiate(hitAnimationObj,new Vector3(transform.position.x,transform.position.y,-.2f),Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyObject()
    {
        WaitForSeconds wait = new WaitForSeconds((float)1.0f);
        yield return wait;
        Destroy(gameObject); 
    }
}
