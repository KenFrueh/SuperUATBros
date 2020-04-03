using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform tf;
    public float bulletSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Always move forward
        tf.position += tf.right * bulletSpeed * Time.deltaTime;
    }
    public void OnCollisionEnter2D(Collision2D otherObject)//Colliding with an object 
    {
        if (otherObject.gameObject.tag == "Enemy")
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }
    }
}
