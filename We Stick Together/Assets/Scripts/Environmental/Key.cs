using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Key : NetworkBehaviour, Interactable , Pickable
{
    [SerializeField] private string _prompt;
    //Wydaje mi si� �e mo�na przypisa� klucz do danego zamka tworz�c to i w iteratorze tablice obiekt�w pickable
    //i to by by� swoistego rodzaju ekwipunek tylko trudny skrypt wiec na p�xniej to zostawiam
    //[SerializeField] private Lock lock1;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {

        interactor.hasKey = true;
        KeyInteractionServerRpc();


        return true;
    }

    public bool Deactivate()
    {
        gameObject.SetActive(false);
        return true;
    }

    [ServerRpc(RequireOwnership = false)]
    public void KeyInteractionServerRpc()
    {
        KeyInteractionClientRpc();

    }
    [ClientRpc]
    public void KeyInteractionClientRpc()
    {
        Deactivate();
    }

}
