using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Note : MonoBehaviour , Interactable
{
    [SerializeField] private string _prompt;
    [SerializeField] public Canvas UI;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (UI.isActiveAndEnabled)
        UI.gameObject.SetActive(false);
        else
        UI.gameObject.SetActive(true);
        return true;
    }

}
