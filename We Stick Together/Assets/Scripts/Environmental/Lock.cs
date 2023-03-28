using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, Interactable
{


    [SerializeField] private string _prompt;


    public string InteractionPrompt => _prompt;
    public bool unlocked;

    public bool Interact(Interactor interactor)
    {
        if (interactor.hasKey == true)
        {
            unlocked = true;
        }
        return true;
    }



}

