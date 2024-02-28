using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int bossHP = 100;
    public Animator animator;
    public Slider bossHealthBar;



    // Start is called before the first frame update
    void Start()
    {
        bossHealthBar.value = bossHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(1f,1f);
        }
        else
        {
            transform.localScale = new Vector2 (-1f,1f);
        }
    }


    public void TakeDamage(int damageAmount)
    {
        bossHP -= damageAmount;
        bossHealthBar.value = bossHP;
        if (bossHP > 0)
        {
            animator.SetTrigger("damage");
        }
        else
        {
            animator.SetTrigger("dead");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            Time.timeScale = 0;
            PlayerManager.isGameWin = true;
        }
    }
}
