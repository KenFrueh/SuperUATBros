using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentScene = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Tried to create a second manager");
        }
    }
    //Play button
    public void PlayButton(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);

    }
    //Load new level
    public void LoadLevel(int indexToLoad)
    {
        SceneManager.LoadScene(indexToLoad);
        currentScene = 1;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: currentScene + 2);
    }
}
