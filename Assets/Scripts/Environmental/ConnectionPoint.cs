using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoint : MonoBehaviour, Interactable
{

    [SerializeField]
    private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool changing;
    public int colorNumber;
    public bool Interact(Interactor interactor)
    {
        
        changing= true;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        colorNumber = -1;
        changing = false;
        gameObject.SetActive(false);
    }




}
