using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public int currentScene = 0;
    public int playerScore = 0;
    public int Lives = 3;
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public int Enemies = 5;
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
    public void MenuButton(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
    //Load new level
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }//Load level 2
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }//Game over scene
    public void GameOver()
    {
        if(Lives == 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 3);
        }
        else if(Enemies == 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 3);
        }
    }//respawning the players
    public void Respawn()
    {
        if (Lives > 0)
        {
            Instantiate(PlayerPrefab);
        }
    }
    public void ERespawn()
    {
        if (Enemies > 0)
        {
            Instantiate(EnemyPrefab);
        }
    }    
}
