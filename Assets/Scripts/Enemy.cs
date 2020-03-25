using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public SpriteRenderer sr;
    private Animator Ani;
    private Transform tf;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        Ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "InvisibileBarrier")
        {
            //sr.flipX
        }
    }
    void Die()
    {
        Ani.Play("EnemyDeath");
        //if (Ani.Play("EnemyDeath"))
    }
    public void MoveForward()
    {
        transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
        Ani.Play("EnemyWalk");
    }
}
