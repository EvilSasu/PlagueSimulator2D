using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WholeData : MonoBehaviour
{
    public List<GameObject> listOfContinents;
    public GameObject plague;
    public GameObject TimeMaster;

    public double wholeSickPop = 0;
    public double wholeDeadPop = 0;

    public void CalWholePop()
    {
        wholeSickPop = 0;
        wholeDeadPop = 0;

        foreach(GameObject con in listOfContinents)
        {
            wholeSickPop += Math.Round(con.GetComponent<ContinentData>().SickPeople);
            wholeDeadPop += Math.Round(con.GetComponent<ContinentData>().DeadPeople);
        }
    }

}
