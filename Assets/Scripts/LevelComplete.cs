using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject gameCompleteUI;
    public GameObject gameOverUI;
    bool gameComplete = false;
    void Start()
    {

    }

    public void GameOver()
    {
        gameComplete = true;
        gameOverUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameCompleteUI.SetActive(true);
            gameComplete = true;
        }
    }

    private void Update()
    {
        if (gameComplete && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
