using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class CloseUp : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public int HowClose;





    void Update()
    {
        if (Keyboard.current.qKey.IsPressed())
        {

            camera.fieldOfView = HowClose;
        }else
        {
            camera.fieldOfView = 60;
        }
    }




}
