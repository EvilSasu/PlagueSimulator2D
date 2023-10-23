using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ContinentData : MonoBehaviour
{
    public Color color;
    public double Moisture;
    public double Temperature;
    public double Population;
    public double HealthyPeople;
    public double SickPeople;
    public double DeadPeople;

    public int firstSickDay = 0;

    public List<double> listOfPeopleThatGetSick;

    public GameObject MenuMaster;
    public GameObject timeMaster;
    public PlagueData plague;

    private bool isMenuActivated = false;
    private bool wasThereFirstSickDay = false;
    
    private double colorVal;
    public int i = 0;
    private void Start()
    {
        Population = HealthyPeople;    
    }

    void Update()
    {
        if (SickPeople >= 1)
        {
            CalculateSickAndDeadAndHealthyPeople();
        }
            

        if (isMenuActivated)
            TransformDataToMenu();

        if (MenuMaster.GetComponent<MenuMaster>().continentMenu.activeSelf == true)
            if (Input.GetButtonDown("Fire2"))
            {
                MenuMaster.GetComponent<MenuMaster>().continentMenu.SetActive(false);
                isMenuActivated = false;
            }

        if(SickPeople > 0 && wasThereFirstSickDay == false)
        {
            firstSickDay = timeMaster.GetComponent<TimeMaster>().day;
            wasThereFirstSickDay = true;
            listOfPeopleThatGetSick.Add(1);
        }
               
    }

    void CalculateSickAndDeadAndHealthyPeople()
    {
        CalculateHealthyPeople();
        CalculateSickPeople();
        CalculateDeadPeople();

        CalculateColor();
    }

    void CalculateColor()
    {
        double tmp = 1 - (DeadPeople / Population);
        colorVal = tmp * 255;
        int finalColorVal = Convert.ToInt32(colorVal);
        if (finalColorVal < 0)
            finalColorVal = 0;
        color = new Color(finalColorVal, finalColorVal, finalColorVal);
        GetComponent<SpriteRenderer>().color = color;
    }

    void CalculateHealthyPeople()
    {
        if (HealthyPeople <= 1)
            HealthyPeople = 0;
    }

    void CalculateDeadPeople()
    {
        if (DeadPeople > Population)
        {
            DeadPeople = Population;
            SickPeople = 0;
        }       
    }

    void CalculateSickPeople()
    {
        if (SickPeople > Population)
            SickPeople = Population;
        if (SickPeople <= 0.99f)
            SickPeople = 0;
    }

    private void OnMouseDown()
    {
        TransformDataToMenu();
    }

    private void TransformDataToMenu()
    {
        if (MenuMaster.GetComponent<MenuMaster>().menu.activeSelf == false)
        {
            isMenuActivated = true;
            MenuMaster.GetComponent<MenuMaster>().continentMenu.SetActive(true);
            MenuMaster.GetComponent<MenuMaster>().image.sprite = GetComponent<SpriteRenderer>().sprite;
            MenuMaster.GetComponent<MenuMaster>().TemperatureText.GetComponent<TMP_Text>().text = "Temp. " + Temperature;
            MenuMaster.GetComponent<MenuMaster>().MoistureText.GetComponent<TMP_Text>().text = "Moisture. " + Moisture;
            MenuMaster.GetComponent<MenuMaster>().PopulationText.GetComponent<TMP_Text>().text = Population.ToString();
            MenuMaster.GetComponent<MenuMaster>().HealthyPeopleText.GetComponent<TMP_Text>().text = Math.Round(HealthyPeople).ToString();
            MenuMaster.GetComponent<MenuMaster>().SickPeopleText.GetComponent<TMP_Text>().text = Math.Round(SickPeople).ToString();
            MenuMaster.GetComponent<MenuMaster>().DeadPeopleText.GetComponent<TMP_Text>().text = Math.Round(DeadPeople).ToString();
        }
    }
}
