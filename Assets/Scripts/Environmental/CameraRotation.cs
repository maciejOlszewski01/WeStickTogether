using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    float from, to;

    // Update is called once per frame
    private void Start()
    {
        from = GetComponent<Transform>().rotation.y - from;
        to = GetComponent<Transform>().rotation.y + from;
    }
    void Update()
    {
        
    }
}
