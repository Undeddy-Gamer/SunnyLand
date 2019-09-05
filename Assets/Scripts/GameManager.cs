using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public int score = 0; //ScorKeeping

    public void AddScore(int scoreToAdd)
    {
        // Increase score value by incoming score
        score += scoreToAdd;
        // Update UI Here
        UIManager.Instance.UpdateScore(score);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        // Loads the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PrevLevel()
    {
        // Loads the previous level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ChangeLevel(int index)
    {
        // Loads the previous level
        SceneManager.LoadScene(index);
    }


    private void Update()
    {
        // For Debugging
        UIManager.Instance.UpdateScore(score);
    }



}