using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private int damage;
    public float lifeTime = 4.0f;
    public GameObject hitAnimationObj;
    private GameObject player;

    void Start()
    {
        StartCoroutine(DestroyObject());
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            
            damage = player.GetComponent<player>().damage;
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
