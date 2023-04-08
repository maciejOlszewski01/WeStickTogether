using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{

    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    public int gameStartScreen;
    public static int flagH = 0;
    public static int flagJ = 0;
    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            flagH = 1;
            SceneManager.LoadScene(gameStartScreen);
            /*NetworkManager.Singleton.StartHost();
            hostButton.gameObject.SetActive(false);
            clientButton.gameObject.SetActive(false);*/
        });
        clientButton.onClick.AddListener(() =>
        {

            flagJ = 1;
            SceneManager.LoadScene(gameStartScreen);
            /*
            NetworkManager.Singleton.StartClient();
            hostButton.gameObject.SetActive(false);
            clientButton.gameObject.SetActive(false);
            */
        });
    }
}
