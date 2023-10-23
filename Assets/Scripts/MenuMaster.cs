using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuMaster : MonoBehaviour
{
    public GameObject plague;
    public GameObject menu;

    public Slider MaxTempSlider;
    public Slider MinTempSlider;
    public Slider MinMoistureSlider;
    public Slider MaxMoistureSlider;

    public Slider TimeToCureSlider;
    public Slider LethalitySlider;
    public Slider ContagiousSlider;

    public GameObject MaxTempText;
    public GameObject MinTempText;
    public GameObject MaxMoistureText;
    public GameObject MinMoistureText;

    public GameObject TimeToCureText;
    public GameObject LethalityText;
    public GameObject ContagiousText;

    public int targetFrameRate = 60;

    public GameObject continentMenu;
    public Image image;
    public GameObject MoistureText;
    public GameObject TemperatureText;
    public GameObject PopulationText;
    public GameObject HealthyPeopleText;
    public GameObject SickPeopleText;
    public GameObject DeadPeopleText;

    private void Start()
    {
        SetValuesFromSlidersToPlague();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    private void Update()
    {
        if(menu.activeSelf == true)
            SetValuesFromSlidersToPlague();
    }

    public void SetValuesFromSlidersToPlague()
    {
        plague.GetComponent<PlagueData>().MaxTemp = MaxTempSlider.value;
        plague.GetComponent<PlagueData>().MinTemp = MinTempSlider.value;
        plague.GetComponent<PlagueData>().MaxMoisture = MaxMoistureSlider.value;
        plague.GetComponent<PlagueData>().MinMoisture = MinMoistureSlider.value;
        plague.GetComponent<PlagueData>().TimeToCure = TimeToCureSlider.value;
        plague.GetComponent<PlagueData>().Lethality = LethalitySlider.value;
        plague.GetComponent<PlagueData>().Contagious = ContagiousSlider.value;

        SetValuesFromSlidersToText();
    }

    public void SetValuesFromSlidersToText()
    {
        MaxTempText.GetComponent<TMP_Text>().text = MaxTempSlider.value.ToString();
        MinTempText.GetComponent<TMP_Text>().text = MinTempSlider.value.ToString();
        MaxMoistureText.GetComponent<TMP_Text>().text = MaxMoistureSlider.value.ToString();
        MinMoistureText.GetComponent<TMP_Text>().text = MinMoistureSlider.value.ToString();
        TimeToCureText.GetComponent<TMP_Text>().text = TimeToCureSlider.value.ToString();
        LethalityText.GetComponent<TMP_Text>().text = LethalitySlider.value.ToString();
        ContagiousText.GetComponent<TMP_Text>().text = ContagiousSlider.value.ToString();
    }

}
