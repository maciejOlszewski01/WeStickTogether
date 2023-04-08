using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przycisk : MonoBehaviour, Interactable
{

    [SerializeField] private string _prompt;
    [SerializeField] private bool forward;
    public GameObject monitor;
    public GameObject map;

    public string InteractionPrompt => _prompt;


    public bool Interact(Interactor interactor)
    {
        GetComponent<Animator>().Play("PrzyciskWciskanie");
        if (forward == true)
        {
            monitor.GetComponent<ScreenControls>().Next();
            map.GetComponent<MapDisplay>().Next();
        } else
        {
            monitor.GetComponent<ScreenControls>().Previous();
            map.GetComponent<MapDisplay>().Previous();
        }
        return true;
    }

   
    
}
