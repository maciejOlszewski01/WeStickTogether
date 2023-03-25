using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Drzwi : NetworkBehaviour, Interactable
{
    [SerializeField] private string _prompt;
    [SerializeField] private AudioSource audioDrzwi = null;
    [SerializeField] private float DELAY = 0;

    [SerializeField] private Animator animator;
    private bool Otwieranie, Zamykanie;
    [SerializeField] private Lock lock1;
    [SerializeField] BoxCollider m_Collider;

    // Use this for initialization
    public override void OnNetworkSpawn()
    {
            Otwieranie = false;
            Zamykanie = false;
        

    }

    public string InteractionPrompt => _prompt;


    //Tutaj wydaje mi siê ¿e mo¿na zredukowaæ liczbê operacji i zmiennych do zoptymalizowania
    public bool Interact(Interactor interactor)
    {
        
        DoorInteractionServerRpc();
        return true;
        
        
        if (lock1 == null || lock1.unlocked == true) {
            if (Otwieranie == false) {
                animator.SetBool("Otwierane", true);
                animator.SetBool("Zamykane", false);
                Otwieranie = true;
                Zamykanie = false;

                audioDrzwi.PlayDelayed(DELAY);


            } else
            {
                animator.SetBool("Otwierane", false);
                animator.SetBool("Zamykane", true);
                Zamykanie = true;
                Otwieranie = false;

                audioDrzwi.PlayDelayed(DELAY);


            }

            return true;
        }
        return false;
        
    }
    
    [ServerRpc(RequireOwnership = false)]
    public void DoorInteractionServerRpc() {
        DoorInteractionClientRpc();
    
    }
    [ClientRpc]
    public void DoorInteractionClientRpc() {

        if (lock1 == null || lock1.unlocked == true)
        {
            if (Otwieranie == false)
            {
                animator.SetBool("Otwierane", true);
                animator.SetBool("Zamykane", false);
                Otwieranie = true;
                Zamykanie = false;

                audioDrzwi.PlayDelayed(DELAY);


            }
            else
            {
                animator.SetBool("Otwierane", false);
                animator.SetBool("Zamykane", true);
                Zamykanie = true;
                Otwieranie = false;

                audioDrzwi.PlayDelayed(DELAY);


            }

           // return true;
        }
       // return false;
    }
    
    
}
