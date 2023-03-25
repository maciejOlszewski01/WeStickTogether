using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
public class Interactor : NetworkBehaviour
{


    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private Transform _interactionPoint2;
    [SerializeField] private float _interactionPointRadius;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private GUIFaceCamera interactionPrompt;
    

    //czy ma klucz
    public bool hasKey;
    private readonly Collider[] _coliders = new Collider[3];
    private GameObject[] objectsToSwap = new GameObject[2];
    private int _numFound;
    public Note ActiveCanvas = null;
    private int objectsReadytoSwap;
    private Interactable interactable;


    void Start()
    {
        objectsReadytoSwap = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (ActiveCanvas == null)
        {
            if (Keyboard.current.qKey.IsPressed())
                _numFound = Physics.OverlapCapsuleNonAlloc(_interactionPoint.position, _interactionPoint2.position, 0.01f, _coliders, _interactableMask);
            else
                _numFound = Physics.OverlapCapsuleNonAlloc(_interactionPoint.position, _interactionPoint2.position, _interactionPointRadius, _coliders, _interactableMask);
            if (_numFound > 0)
            {
                var interactable = _coliders[0].GetComponent<Interactable>();


                if (interactable != null)
                {
                    if (!interactionPrompt.IsDisplayed) interactionPrompt.SetUp(interactable.InteractionPrompt);
                }

                if (_coliders[0].GetComponent<MovableHeavy>() != null)
                {
                    if (Keyboard.current.eKey.isPressed)
                    {
                        interactable.Interact(this);

                    }
                }
                else if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    //interakcjaServerRpc(_coliders[0]);
                    
                    interactable.Interact(this);
                    //do przeobienia chyba
                    if (_coliders[0].GetComponent<Swapable>() != null)
                    {
                        //Debug.Log("Widze obiekty");
                        objectsToSwap[objectsReadytoSwap] = _coliders[0].gameObject;
                        objectsReadytoSwap++;
                    }
                    else if (Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        //do przeobienia chyba
                        if (_coliders[0].GetComponent<Note>() != null)
                        {
                            //Debug.Log("Widze obiekty");
                            ActiveCanvas = _coliders[0].gameObject.GetComponent<Note>();
                        }
                    }
                }


            }
            else
            {
                if (interactable != null) interactable = null;
                if (interactionPrompt.IsDisplayed) interactionPrompt.Close();
            }
            if (objectsToSwap[0] != null && objectsToSwap[1] != null)
            {

                bool zrobione = Swap(objectsToSwap[0], objectsToSwap[1]);


                if (zrobione == true)

                {

                    objectsToSwap[0] = null;
                    objectsToSwap[1] = null;
                    objectsReadytoSwap = 0;
                }

            }
        }
        else
        {
            if (interactionPrompt.IsDisplayed) interactionPrompt.Close();
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                ActiveCanvas.Interact(this);
                ActiveCanvas = null;
            }
        }
    }

    private bool Swap(GameObject first, GameObject second)
    {
        int speed = 1;


        Vector3 start = first.GetComponent<Swapable>().position;
        Vector3 start2 = second.GetComponent<Swapable>().position;

        if (first.GetComponent<Swapable>().state == 0)
        {
            first.GetComponent<Swapable>().position2 = start;
            second.GetComponent<Swapable>().position2 = start2;
            first.GetComponent<Swapable>().position2 += new Vector3(0, 0.15f, 0);
            second.GetComponent<Swapable>().position2 += new Vector3(0, 0.3f, 0);
            first.GetComponent<Swapable>().state = 1;
        }

        if (first.GetComponent<Swapable>().state == 1)
        {


            first.GetComponent<Transform>().position = Vector3.MoveTowards(first.GetComponent<Transform>().position, first.GetComponent<Swapable>().position2, speed * Time.deltaTime);
            second.GetComponent<Transform>().position = Vector3.MoveTowards(second.GetComponent<Transform>().position, second.GetComponent<Swapable>().position2, speed * Time.deltaTime);

            if (first.GetComponent<Swapable>().position2 == first.GetComponent<Transform>().position && second.GetComponent<Swapable>().position2 == second.GetComponent<Transform>().position)
            {
                first.GetComponent<Swapable>().state = 2;

            }
            else
                return false;
        }



        if (first.GetComponent<Swapable>().state == 2)
        {
            first.GetComponent<Swapable>().position2 = second.GetComponent<Swapable>().position;
            first.GetComponent<Swapable>().position2 += new Vector3(0, 0.15f, 0);
            second.GetComponent<Swapable>().position2 = first.GetComponent<Swapable>().position;
            second.GetComponent<Swapable>().position2 += new Vector3(0, 0.3f, 0);
            first.GetComponent<Swapable>().state = 3;
        }

        if (first.GetComponent<Swapable>().state == 3)
        {


            first.GetComponent<Transform>().position = Vector3.MoveTowards(first.GetComponent<Transform>().position, first.GetComponent<Swapable>().position2, speed * Time.deltaTime);
            second.GetComponent<Transform>().position = Vector3.MoveTowards(second.GetComponent<Transform>().position, second.GetComponent<Swapable>().position2, speed * Time.deltaTime);

            if (first.GetComponent<Swapable>().position2 == first.GetComponent<Transform>().position && second.GetComponent<Swapable>().position2 == second.GetComponent<Transform>().position)
            {
                first.GetComponent<Swapable>().state = 4;

            }
            else
                return false;
        }
        if (first.GetComponent<Swapable>().state == 4)
        {
            first.GetComponent<Swapable>().position2 -= new Vector3(0,0.15f, 0);
            second.GetComponent<Swapable>().position2 -= new Vector3(0, 0.3f, 0);
            first.GetComponent<Swapable>().state = 5;
        }
        if (first.GetComponent<Swapable>().state == 5)
        {
            first.GetComponent<Transform>().position = Vector3.MoveTowards(first.GetComponent<Transform>().position, first.GetComponent<Swapable>().position2, speed * Time.deltaTime);
            second.GetComponent<Transform>().position = Vector3.MoveTowards(second.GetComponent<Transform>().position, second.GetComponent<Swapable>().position2, speed * Time.deltaTime);
            if (first.GetComponent<Swapable>().position2 == first.GetComponent<Transform>().position && second.GetComponent<Swapable>().position2 == second.GetComponent<Transform>().position)
            {
                first.GetComponent<Swapable>().state = 0;
                first.GetComponent<Swapable>().position = first.GetComponent<Transform>().position;
                second.GetComponent<Swapable>().position = second.GetComponent<Transform>().position;

                return true;
            }
        }
        return false;
    }
    /*
    [ServerRpc(RequireOwnership = false)]
    public void interakcjaServerRpc(Collider interactable)
    {
        interakcjaClientRpc(interactable);
    }
    [ClientRpc]
    public void interakcjaClientRpc(Collider interactable)
    {
        interactable.GetComponent<Interactable>().Interact(this);
    }
    */
}
