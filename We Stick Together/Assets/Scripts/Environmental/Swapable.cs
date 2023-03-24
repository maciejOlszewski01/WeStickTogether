using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapable : MonoBehaviour, Interactable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject waypoint;

    public bool zmieniam;
    public int state;
    public float x, y, z;
    public Vector3 position;
    public Vector3 position2;

    public string InteractionPrompt => _prompt;

    void Start()
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
}
