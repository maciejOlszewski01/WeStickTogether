using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConnectWiresMiniGame : MonoBehaviour
{
    // Start is called before the first frame updat

    [SerializeField] int size;
    [SerializeField] GameObject[] ConnectionPoiont1 = new GameObject[10];
    [SerializeField] GameObject[] ConnectionPoiont2 = new GameObject[10];
    [SerializeField] GameObject[][] ConnectionPoionts = new GameObject[2][];
    [SerializeField] GameObject[,] ConnectionsRightOrder = new GameObject[10,2];
    [SerializeField] GameObject[,] ConnectionsActualOrder = new GameObject[10, 2];
    [SerializeField] Mesh Wire;
    [SerializeField] Material[] Colours = new Material [10];
    public bool rozwiazana;
    void Start()
    {
        rozwiazana = false;
        ConnectionPoionts[0] = ConnectionPoiont1;
        ConnectionPoionts[1] = ConnectionPoiont2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame) {
        
        StartGame();
        }
        if (chceckConnections())
        {
            rozwiazana = chceckSolution();
        }
    }

    void StartGame()
    {
        for (int i = 0; i < 2; i++) {
            List<int> alredyTaken = new List<int>();
            for (int j = 0; j < size; j++) {
                int materialNumber =Random.Range(0, size);
                while(alredyTaken.Contains(materialNumber))
                {
                    materialNumber = Random.Range(0, size);
                }
                alredyTaken.Add(materialNumber);
                ConnectionPoionts[i][j].GetComponent<Renderer>().material = Colours[materialNumber];
                ConnectionPoionts[i][j].SetActive(true);
                ConnectionsRightOrder[materialNumber, i] = ConnectionPoionts[i][j];
                ConnectionPoionts[i][j].GetComponent<ConnectionPoint>().colorNumber = materialNumber;


            }
        
        }

    }

    bool chceckSolution()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (ConnectionsRightOrder[j, i] != ConnectionsActualOrder[j, i])
                {
                    return false;
                }
            }
        }
        return true;
    }

    bool chceckConnections()
    {
        List<GameObject> Changed = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < size; j++)
            {
                
                if (ConnectionPoionts[i][j].GetComponent<ConnectionPoint>().changing)
                {
                    Changed.Add(ConnectionPoionts[i][j]);
                    int colorNumber = ConnectionPoionts[i][j].GetComponent<ConnectionPoint>().colorNumber;
                    ConnectionsActualOrder[colorNumber, i]= ConnectionPoionts[i][j];
                }
            }
        }

        if (Changed.Count == 2)
        {

            
            Changed[0].GetComponent<ConnectionPoint>().changing = false;
            Changed[1].GetComponent<ConnectionPoint>().changing = false;
            
            Changed.Clear();
            return true;
        }
        return false;
    }

}
