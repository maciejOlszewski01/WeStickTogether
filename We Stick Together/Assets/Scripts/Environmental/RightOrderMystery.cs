using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RightOrderMystery : MonoBehaviour
{

    [SerializeField] List<GameObject> RightOrder = new List<GameObject>();
    [SerializeField] List<GameObject> ActualOrder = new List<GameObject>();
    public bool change;
    // Start is called before the first frame update
    void Start()
    {
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {

            if (checkOrder())
             

            change = false;
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
    public void changeOrder(GameObject object1 ,GameObject object2)
    {
        int index1 = ActualOrder.FindIndex(x => x.GetInstanceID() == object1.GetInstanceID());
        int index2 = ActualOrder.FindIndex(x => x.GetInstanceID() == object2.GetInstanceID());
        ActualOrder[index1] = object2;
        ActualOrder[index2] = object1;
        change = true;

    }


}
