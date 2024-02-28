using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // void OnTriggerEnter2D(Collider2D collision){
    //     if(collision.tag == "Enemy"){
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Boss"){
            collision.GetComponent<Boss>().TakeDamage(10);
        }
    }
}
