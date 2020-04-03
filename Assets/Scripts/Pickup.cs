using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Points value
    public int points;
    //get audio clip
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Reward with points
            GameManager.instance.playerScore += points;
            //Play coin sound
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            //destroying object
            Destroy(this.gameObject);
        }
    }
}
