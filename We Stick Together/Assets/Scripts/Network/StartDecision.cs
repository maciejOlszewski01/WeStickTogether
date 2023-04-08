using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class StartDecision : MonoBehaviour
{
    private void Awake()
    {

        if (NetworkManagerUI.flagH == 1)
        {
            NetworkManager.Singleton.StartHost();
        }
        else if (NetworkManagerUI.flagJ == 1)
        {
            NetworkManager.Singleton.StartClient();
        }

    }
}
