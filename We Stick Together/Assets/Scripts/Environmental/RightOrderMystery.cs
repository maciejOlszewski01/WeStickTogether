using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class RightOrderMystery : NetworkBehaviour
{

    [SerializeField] List<GameObject> RightOrder = new List<GameObject>();
    [SerializeField] List<GameObject> ActualOrder = new List<GameObject>();
    [SerializeField] Lock locki;
    public bool change;
    public bool rightOrder;
    public int tak;
    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsServer)
        {
            ZmienDaneClientRpc();
        }
        
    }



    public bool checkOrder()
    {
        bool IsInRightOrder = true;
        
        for (int i = 0; i < RightOrder.Count; i++)
        {
            if (RightOrder[i].GetInstanceID() != ActualOrder[i].GetInstanceID())
                IsInRightOrder= false;
        }
        return IsInRightOrder;
    }

    //To mo¿e lagowaæ mocno
    public void changeOrder()
    {
        List<GameObject> Changed = new List<GameObject>();
        foreach (GameObject go in ActualOrder)
        {
            if (go.GetComponent<Swapable>().zmieniam)
            {
                Changed.Add(go);
            }
        }
        
        if (Changed.Count == 2)
        {
            int index1 = ActualOrder.FindIndex(x => x.GetInstanceID() == Changed[0].GetInstanceID());
            int index2 = ActualOrder.FindIndex(x => x.GetInstanceID() == Changed[1].GetInstanceID());
            ActualOrder[index1] = Changed[1];
            ActualOrder[index2] = Changed[0];
            Changed[0].GetComponent<Swapable>().zmieniam = false;
            Changed[1].GetComponent<Swapable>().zmieniam = false;
            change = true;
            Changed.Clear();
        }
    }
    [ClientRpc]
    public void ZmienDaneClientRpc()
    {
        changeOrder();
        if (change)
        {

            if (checkOrder())
                locki.unlocked = true;

            change = false;
        }
    }

}
