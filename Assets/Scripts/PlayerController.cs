using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator ani;
    public GameObject bulletPrefab;
    public Transform FirePoint;

    public float speed = 5.0f;
    public float jumpForce = 200.0f;
    public Transform groundPoint;
    public bool isGrounded = false;
    

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {//Moving on the screen
        float xMovement = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        if (xMovement > 0)
        {
            sr.flipX = false;
            ani.Play("PlayerWalk");
        }
        else if (xMovement < 0)
        {
            sr.flipX = true;
            ani.Play("PlayerWalk");
        }
        else
        {
            ani.Play("PlayerIdle");
        }
        //Detect if player is on ground
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 1f);
        if (hitInfo.collider != null)
        {
            Debug.Log("Is Landed");
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Debug.Log("Jumping");
            rb2d.AddForce(Vector2.up * jumpForce);
            ani.Play("PlayerJump");
        }
        //Shooting
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("I shoot");
            Shoot();
        }
    }
    void Shoot()//Shooting function
    {
        ani.Play("PlayerShoot");
        Instantiate(original: bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {//Destroying on collision with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            GameManager.instance.playerScore += 10;
        }
    }
    void OnDestroy()
    {
        //Losing a life on destroy
        GameManager.instance.Lives -= 1;
        if (GameManager.instance.Lives > 0)
        {
            GameManager.instance.Respawn();
        }
        else
        {//Display Game over
            Debug.Log("Game Over");
            GameManager.instance.GameOver();
        }
    }
}
