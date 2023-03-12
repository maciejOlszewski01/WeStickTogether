using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour , Interactable , Pickable
{
    [SerializeField] private string _prompt;
    //Wydaje mi siê ¿e mo¿na przypisaæ klucz do danego zamka tworz¹c to i w iteratorze tablice obiektów pickable
    //i to by by³ swoistego rodzaju ekwipunek tylko trudny skrypt wiec na póxniej to zostawiam
    //[SerializeField] private Lock lock1;

    public string InteractionPrompt => _prompt;


    void Start()
    {
       
    }
    public bool Interact(Interactor interactor)
    {
        interactor.hasKey = true;

        Deactivate();
        return true;
    }

    public bool Deactivate()
    {
        gameObject.SetActive(false);
        return true;
    }

}
