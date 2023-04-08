using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControls : MonoBehaviour
{

    public Texture[] textures;
    private int currentCamera = 0;

    // Start is called  the first frame update
    void Start()
    {
        
        GetComponent<Renderer>().material.mainTexture = textures[currentCamera];
        
    }

    // Update is called once per frame

    public void Next()
    {
        if (currentCamera != (textures.Length - 1))
        {
            GetComponent<Renderer>().material.mainTexture = textures[++currentCamera];
        }
    }

    public void Previous()
    {
        if (currentCamera != 0)
        {
            GetComponent<Renderer>().material.mainTexture = textures[--currentCamera];
        }
    }
}
