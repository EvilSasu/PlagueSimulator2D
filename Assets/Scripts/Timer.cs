using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float startingTime;

    public bool isEnded = true;

    private IEnumerator CountTime()
    {
        do
        {
            currentTime -= Time.deltaTime;
            yield return null;
        } while (currentTime > 0f);

        isEnded = true;
    }

    public void StartTimer(float timeToWait)
    {
        isEnded = false;
        startingTime = timeToWait;
        currentTime = startingTime;
        if (isEnded == false)
        {
            StartCoroutine(CountTime());
        }
    }
}
