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
    [SerializeField]GameObject[] DoZmiany = new GameObject[2];
    public bool change, zmieniaj;
    public bool rightOrder;
    public int tak;
    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        change = false;
        zmieniaj = false;
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
            if (Changed[0].GetComponent<Swapable>().state == 0 && Changed[1].GetComponent<Swapable>().state == 0)
            {
                DoZmiany[0] = Changed[0];
                DoZmiany[1] = Changed[1];
                zmieniaj = true;
            }
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
            first.GetComponent<Swapable>().position2 -= new Vector3(0, 0.15f, 0);
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

    [ClientRpc]
    public void ZmienDaneClientRpc()
    {
        changeOrder();
        if (zmieniaj)
        {
            zmieniaj = !Swap(DoZmiany[0], DoZmiany[1]);
        }
        if (change)
        {

            if (checkOrder())
                locki.unlocked = true;

            change = false;
        }
    }

}
