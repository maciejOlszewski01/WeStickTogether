using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Swapable : NetworkBehaviour, Interactable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject waypoint;

    public bool zmieniam;
    public int state;
    public float x, y, z;
    public Vector3 position;
    public Vector3 position2;

    public string InteractionPrompt => _prompt;

    public override void OnNetworkSpawn()
    {
        state = 0;
        x = GetComponent<Transform>().position.x;
        y = GetComponent<Transform>().position.y;
        z = GetComponent<Transform>().position.z;
        position = new Vector3(x, y, z);
        zmieniam = false;
    }
    public bool Interact(Interactor interactor)
    {
        zmieniam = true;
        return true;
    }
    [ServerRpc(RequireOwnership = false)]
    public void SwapInteractionServerRpc()
    {
        SwapInteractionClientRpc();

    }
    [ClientRpc]
    public void SwapInteractionClientRpc()
    {
        zmieniam = true;
    }
}
