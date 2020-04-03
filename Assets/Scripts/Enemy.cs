using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    private bool movingRight = true;
    public SpriteRenderer sr;
    private Animator Ani;
    private Transform tf;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        Ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();

    }
    void OnDestroy()
    {
        Ani.Play("EnemyDeath");
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        GameManager.instance.Enemies -= 1;
        if(GameManager.instance.Enemies > 0)
        {
            GameManager.instance.ERespawn();
        }
        else
        {
            GameManager.instance.GameOver();
        }
    }
    public void MoveForward()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(tf.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        Ani.Play("EnemyWalk");
    }
}
