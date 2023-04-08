using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public Material[] materials;
    public GameObject[] Locations;
    private int currentCamera = 0;
    



    // Start is called  the first frame update
    void Start()
    {
        foreach (GameObject go in Locations)
        {
            go.GetComponent<Renderer>().material = materials[0];
        }
        Locations[currentCamera].GetComponent<Renderer>().material = materials[1];
    }

    // Update is called once per frame

    public void Next()
    {
        if (currentCamera != (Locations.Length - 1))
        {
            Locations[currentCamera].GetComponent<Renderer>().material = materials[0];
            Locations[++currentCamera].GetComponent<Renderer>().material = materials[1];
        }
    }

    public void Previous()
    {
        if (currentCamera != 0)
        {
            Locations[currentCamera].GetComponent<Renderer>().material = materials[0];
            Locations[--currentCamera].GetComponent<Renderer>().material = materials[1];

        }
    }
}

