using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Load next level if enter trigger
        if (other.gameObject.name == "Player")
        {
            GameManager.instance.currentScene -= 1;
        }
    }

}
