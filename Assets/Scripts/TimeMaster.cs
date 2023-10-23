using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeMaster : MonoBehaviour
{
    public int day;
    public GameObject DayText;
    public GameObject timer;
    public List<GameObject> continents;
    public GameObject wholeData;
    //public GameObject CSVWriter;
    public int speed = 1;
    private string text;

    private bool stoped = false;

    void Start()
    {
        day = 1;
        text = "Day: " + day;
        DayText.GetComponent<TMP_Text>().text = text;
        timer.GetComponent<Timer>().StartTimer(5 / speed);
        StopTime();
    }


    void Update()
    {
        if (!stoped)
        {
            if (timer.GetComponent<Timer>().isEnded == true)
            {
                day++;
                text = "Day: " + day;
                foreach (GameObject con in continents)
                {
                    con.GetComponent<PlagueSimulation>().Simulate();
                    con.GetComponent<AirPlaneMaster>().SimlateAirplanes();
                    con.GetComponent<AirPlaneMaster>().SimlateAirplanes();
                }
                wholeData.GetComponent<WholeData>().CalWholePop();
                if (wholeData.GetComponent<WholeData>().wholeSickPop == 0)
                    StopTime();
                //CSVWriter.GetComponent<CSVWriter>().WriteCSV();
                DayText.GetComponent<TMP_Text>().text = text;
                timer.GetComponent<Timer>().StartTimer(6 / speed);
            }
        }     
    }

    public void StopTime()
    {
        stoped = true;
    }

    public void SetNormalSpeedTime()
    {
        stoped = false;
        speed = 3;
    }

    public void SetDobuleSpeedTime()
    {
        stoped = false;
        speed *= 2;
    }
}
