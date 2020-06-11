using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSc : MonoBehaviour
{
    
    public void changeScene()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void startNewGame()
    {
        currentRound.round = 0;
        PlayerPrefs.DeleteKey("Round");
        SceneManager.LoadScene("Main Game");
    }


}
