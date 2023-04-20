using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, Interactable,HoldingInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Light[] swiatla;
    private bool change = false;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        foreach(Light l in swiatla)
        {
            l.range = 5;
        }
        return true;
    }

    // Start is called before the first frame update
    private void Update()
    {
        
    }

    // Update is called once per frame

}
