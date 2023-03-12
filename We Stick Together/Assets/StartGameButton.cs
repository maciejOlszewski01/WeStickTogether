using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScreen);
        //SetActiveScene(gameStartScreen); // Sprobowac uzyc w nastepnej klatce
    }


}
