using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnDelay = 2f;
    float delay;
    public List<GameObject> enemies;
    [NonSerialized]
    public GameObject player;
    public bool isPaused = false;
    public Image pauseScreen;
    void Start()
    {
        Time.timeScale = 1f;
        delay = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
        FindAnyObjectByType<AudioManager>().Play("BGM", 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) ResumeGame();
            else if(!isPaused) PauseGame();
            isPaused = !isPaused;
        }
    }

    public void SpawnEnemy()
    {
        Vector2 newPos = new Vector2(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
        enemies.Add(Instantiate(enemy, newPos, Quaternion.identity));


    }
    public GameObject GetClosestEnemy()
    {
        float mindist = Mathf.Infinity;
        GameObject closest = enemies[0];
        foreach(GameObject enemey in enemies) 
        {
            Vector2 distance = (enemey.transform.position - player.transform.position);
            if (distance.sqrMagnitude < mindist)
            {
                mindist = distance.sqrMagnitude;
                closest = enemey;
            }
        }

        return closest;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
