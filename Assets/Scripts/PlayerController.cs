using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

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
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        sr.flipX = rb2d.velocity.x < 0;
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
        }
        
    }
}
