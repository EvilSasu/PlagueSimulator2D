using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueSimulation : MonoBehaviour
{
    public GameObject Continent;
    public GameObject Plague;

    public ContinentData continentData;
    public PlagueData plagueData;

    public GameObject timer;
    public TimeMaster timeMaster;

    private void Start()
    {
        Continent = this.gameObject;
        continentData = Continent.GetComponent<ContinentData>();
        plagueData = Plague.GetComponent<PlagueData>();
    }

    public void Simulate()
    {
        if(continentData.SickPeople > 0)
        {
            if(continentData.Temperature < plagueData.MaxTemp && continentData.Temperature > plagueData.MinTemp)
            {
                if (continentData.Moisture < plagueData.MaxMoisture && continentData.Temperature > plagueData.MinMoisture)
                {
                    double amountOfNewSickPepole = 0;
                    double amountOfNewDeadPepole = 0;

                    if (continentData.HealthyPeople > 0)
                    {
                        amountOfNewSickPepole = continentData.SickPeople * (0.02 * plagueData.Contagious);
                        double rChange = Random.Range(75, 125) * 0.01f;
                        amountOfNewSickPepole = amountOfNewSickPepole * rChange;
                        continentData.SickPeople += amountOfNewSickPepole;
                        continentData.listOfPeopleThatGetSick.Add((int)amountOfNewSickPepole);
                        continentData.HealthyPeople -= amountOfNewSickPepole;
                    }

                    if (continentData.SickPeople > 0)
                    {
                        amountOfNewDeadPepole = continentData.SickPeople * plagueData.Lethality * 0.01;
                        continentData.DeadPeople += amountOfNewDeadPepole;
                        continentData.SickPeople -= amountOfNewDeadPepole;
                        if(continentData.DeadPeople <= continentData.Population)
                        {
                            if(continentData.i < continentData.listOfPeopleThatGetSick.Count)
                                continentData.i++;
                            if (continentData.firstSickDay + plagueData.TimeToCure <= timeMaster.day && continentData.i < continentData.listOfPeopleThatGetSick.Count)
                            {
                                continentData.SickPeople = continentData.SickPeople - continentData.listOfPeopleThatGetSick[continentData.i] / 2;
                                continentData.HealthyPeople = continentData.HealthyPeople + System.Math.Round(continentData.listOfPeopleThatGetSick[continentData.i] / 2);
                            }
                        }                 
                    }
                }
            }       
        }      
    }

}
