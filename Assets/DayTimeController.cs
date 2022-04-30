using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    //the SerialzedField and floats that list all the Rendering stuff and the floats the dictates the current time and day
    //The rate of change for the day can be 
    const float secondsInDay = 86400f;
    const float phaseLength = 900f; // 15 minutes

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white; 

    float time;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f; // in seconds

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;

    List<TimeAgent> agents;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }

    private void Start()
    {
        time = startAtTime;
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }

    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

    //determines how many hours have passed in game
    float Hours
    {
        get { return time / 3600f; }
    }
    //determines how many minutes have passed in game
    float Minutes
    {
        get { return time % 3600f / 60f; }
    }
    //this is the time that determines the current time and if over the current day based on seconds it adds another day then sets the time to 0 
    //the tileScale is used to determine how fast or slow the days go by
    private void Update()
    {
        time += Time.deltaTime * timeScale;

        TimeValueCalculation();

        DayLight();

        if (time > secondsInDay)
        {
            NextDay();
        }

        TimeAgents();
    }



    //This is all used for the render using the time to determine the time of day and the associated color for the time of day

    private void TimeValueCalculation()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00" + ":" + mm.ToString("00"));
    }

    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
    }

    int oldPhase =  0; 
    private void TimeAgents()
    {
        int currentPhase = (int)(time / phaseLength);
        
        if(oldPhase != currentPhase)
        {
            oldPhase = currentPhase;
            for (int x = 0; x < agents.Count; x++)
            {
                agents[x].Invoke();
            }
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
