using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, Interactable,HoldingInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Light[] swiatla;
    private bool change = false;
    public string InteractionPrompt => _prompt;

    public bool stateChange => false;

    public bool Interact(Interactor interactor)
    {
        foreach(Light l in swiatla)
        {
            l.range = 5;
        }
        change= true;
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
        }
        return true;
    }

    // Start is called before the first frame update
    private void Update()
    {
        
    }

    // Update is called once per frame

}
