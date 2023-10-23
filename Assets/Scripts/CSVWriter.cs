using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour
{
    public GameObject wholeData;

    private string filePath;
    private string delimiter = ",";

    void Start()
    {
        // Utwórz œcie¿kê do pliku CSV
        string fileName = "data_" + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
        filePath = Path.Combine(Application.dataPath+"/Dane", fileName);

        // Utwórz plik CSV, jeœli jeszcze nie istnieje
        if (!File.Exists(filePath))
        {
            Debug.Log("Creating file");
            File.WriteAllText(filePath, "Day" + delimiter + "SickPopAll" + delimiter + "DeadPopAll"
                + delimiter + "NASickPop" + delimiter + "NADeadPop" + delimiter + "SASickPop" + delimiter + "SADeadPop"
                + delimiter + "EUSickPop" + delimiter + "EUDeadPop" + delimiter + "AISickPop" + delimiter + "AIDeadPop"
                + delimiter + "AFSickPop" + delimiter + "AFDeadPop" + delimiter + "AUSickPop" + delimiter + "AUDeadPop" + "\n");
        }
    }

    public void WriteCSV()
    {
        // Dodaj dane do pliku CSV
        Debug.Log("Saved");

        int day = wholeData.GetComponent<WholeData>().TimeMaster.GetComponent<TimeMaster>().day;
        double sickPopAll = wholeData.GetComponent<WholeData>().wholeSickPop;
        double deadPopAll = wholeData.GetComponent<WholeData>().wholeDeadPop;
        double NASickPop = wholeData.GetComponent<WholeData>().listOfContinents[0].GetComponent<ContinentData>().SickPeople;
        double NADeadPop = wholeData.GetComponent<WholeData>().listOfContinents[0].GetComponent<ContinentData>().DeadPeople;
        double SASickPop = wholeData.GetComponent<WholeData>().listOfContinents[1].GetComponent<ContinentData>().SickPeople;
        double SADeadPop = wholeData.GetComponent<WholeData>().listOfContinents[1].GetComponent<ContinentData>().DeadPeople;
        double AISickPop = wholeData.GetComponent<WholeData>().listOfContinents[2].GetComponent<ContinentData>().SickPeople;
        double AIDeadPop = wholeData.GetComponent<WholeData>().listOfContinents[2].GetComponent<ContinentData>().DeadPeople;
        double AFSickPop = wholeData.GetComponent<WholeData>().listOfContinents[3].GetComponent<ContinentData>().SickPeople;
        double AFDeadPop = wholeData.GetComponent<WholeData>().listOfContinents[3].GetComponent<ContinentData>().DeadPeople;
        double EUSickPop = wholeData.GetComponent<WholeData>().listOfContinents[4].GetComponent<ContinentData>().SickPeople;
        double EUDeadPop = wholeData.GetComponent<WholeData>().listOfContinents[4].GetComponent<ContinentData>().DeadPeople;
        double AUSickPop = wholeData.GetComponent<WholeData>().listOfContinents[5].GetComponent<ContinentData>().SickPeople;
        double AUDeadPop = wholeData.GetComponent<WholeData>().listOfContinents[5].GetComponent<ContinentData>().DeadPeople;

        string line = day.ToString() + delimiter + Math.Round(sickPopAll).ToString() + delimiter + Math.Round(deadPopAll).ToString()
            + delimiter + Math.Round(NASickPop).ToString() + delimiter + Math.Round(NADeadPop).ToString()
            + delimiter + Math.Round(SASickPop).ToString() + delimiter + Math.Round(SADeadPop).ToString()
            + delimiter + Math.Round(EUSickPop).ToString() + delimiter + Math.Round(EUDeadPop).ToString()
            + delimiter + Math.Round(AISickPop).ToString() + delimiter + Math.Round(AIDeadPop).ToString()
            + delimiter + Math.Round(AFSickPop).ToString() + delimiter + Math.Round(AFDeadPop).ToString() 
            + delimiter + Math.Round(AUSickPop).ToString() + delimiter + Math.Round(AUDeadPop).ToString() + "\n";

        File.AppendAllText(filePath, line);
    }
}
