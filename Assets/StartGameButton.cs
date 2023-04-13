using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartScreen;
    public Canvas aktualny;
    public Canvas nastepny;
    public void StartGame()
    {
        aktualny.GameObject().SetActive(false);
        nastepny.GameObject().SetActive(true);
        //SceneManager.LoadScene(gameStartScreen);
        //SetActiveScene(gameStartScreen); // Sprobowac uzyc w nastepnej klatce
    }


}
