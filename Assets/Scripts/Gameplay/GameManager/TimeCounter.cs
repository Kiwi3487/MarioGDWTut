using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for using Text component

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private GameObject timeDisplay;
    public int timeCount = 300; // Starting time in seconds
    private float timeElapsed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 1.0f)
        {
            timeCount--;
            timeElapsed = 0.0f;
        }

        if (timeCount < 0)
        {
            timeCount = 0; // Clamp the timer to 0
        }

        // Update the timeDisplay using NumberDisplayDefinition
        timeDisplay.GetComponent<NumberDisplayDefinition>()._numericValue = timeCount.ToString();
    }
}