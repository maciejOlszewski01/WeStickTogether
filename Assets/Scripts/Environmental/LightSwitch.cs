using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightSwitch : MonoBehaviour, Interactable,HoldingInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Light[] swiatla;
    [SerializeField] private GameObject[] doWylaczenia;

    private bool change = false;
    public string InteractionPrompt => _prompt;

    public bool stateChange => false;

    public bool Interact(Interactor interactor)
    {
        foreach(Light l in swiatla)
        {
            l.range = 5;
        }
        foreach (GameObject l in doWylaczenia)
        {
            l.layer =  0;
        }
        change = true;
        return true;
    }

    public bool NotInteracting(Interactor interactor)
    {
        if(change = true)
        {
            foreach(Light l in swiatla)
            {
                l.range = 0;
            }
            change= false;
            
            foreach (GameObject l in doWylaczenia)
            {
                l.layer = 6;
            }
        }
        return true;
    }

    // Start is called before the first frame update
    private void Update()
    {
        
    }

    // Update is called once per frame

}
