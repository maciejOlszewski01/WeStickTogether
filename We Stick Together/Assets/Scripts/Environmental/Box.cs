using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, Interactable, MovableHeavy
{

    [SerializeField] private string _prompt;
    [SerializeField] private AudioSource audioBox= null;
    [SerializeField] private GameObject waypoint;
    [SerializeField] private float DELAY = 0;
    public Lock tak;

    private float aaaaa = 0;
    public string InteractionPrompt => _prompt;

    [SerializeField] public float speed;


    public bool Interact(Interactor interactor)
    {
        if (tak.unlocked)
        {
            if (aaaaa >= 1 || aaaaa == 0)
            {
                audioBox.PlayDelayed(DELAY);
                aaaaa = 0;
            }
            move();
            aaaaa += 0.0042137f;
        }
        return true;
    }

    public void move() {
        
        Vector3 movement = waypoint.transform.position;
        //movement.Normalize();
        transform.position = Vector3.MoveTowards(transform.position,movement, speed * Time.deltaTime);
    }
}
