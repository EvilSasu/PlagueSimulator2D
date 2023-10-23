using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneMaster : MonoBehaviour
{
    public GameObject myCity;
    public GameObject[] arrayOfCities;

    public GameObject airplane;
    public GameObject sickAirplane;

    public List<GameObject> listOfCities;
    public ContinentData cd;

    private void Start()
    {
        myCity = transform.GetChild(0).gameObject;
        arrayOfCities = GameObject.FindGameObjectsWithTag("City");
        for (int i = 0; i < arrayOfCities.Length; i++)
        {
            if (arrayOfCities[i] != myCity)
                listOfCities.Add(arrayOfCities[i]);
        }
        cd = GetComponent<ContinentData>();
    }

    public void SimlateAirplanes()
    {
        if (GetComponent<ContinentData>().DeadPeople >= GetComponent<ContinentData>().Population)
            return;
        int tmp = UnityEngine.Random.Range(0,2);
        if(tmp == 1)
        {
            double chanceToSendSick = GetComponent<ContinentData>().SickPeople / GetComponent<ContinentData>().Population;
            GameObject simAirplane;
            GameObject cityToGo = listOfCities[UnityEngine.Random.Range(0, listOfCities.Count)];

            if(chanceToSendSick <= 0.01f)
                simAirplane = Instantiate(airplane, myCity.transform.position, Quaternion.identity);
            else
            {
                simAirplane = Instantiate(sickAirplane, myCity.transform.position, Quaternion.identity);
                simAirplane.GetComponent<AirplaneMovement>().Sick = true;
                GetComponent<ContinentData>().SickPeople = GetComponent<ContinentData>().SickPeople - 1;
            }

            simAirplane.GetComponent<AirplaneMovement>().cityToMove = cityToGo;
            simAirplane.GetComponent<AirplaneMovement>().speed = 0.1f *
                GetComponent<ContinentData>().timeMaster.GetComponent<TimeMaster>().speed;
        }
    }

}
