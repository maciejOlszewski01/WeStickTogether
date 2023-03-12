using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, Interactable, MovableHeavy
{

    [SerializeField] private string _prompt;
    [SerializeField] private GameObject waypoint;
    public string InteractionPrompt => _prompt;

    [SerializeField] public float speed;


    public bool Interact(Interactor interactor)
    {
        move();
        return true;
    }

    public void move() {
        
        Vector3 movement = waypoint.transform.position;
        //movement.Normalize();
        transform.position = Vector3.MoveTowards(transform.position,movement, speed * Time.deltaTime);
    }
}
