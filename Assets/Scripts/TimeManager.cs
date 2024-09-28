using System;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : BaseMono
{
    protected static TimeManager instance;
    public static TimeManager Instance => instance;
    [Range(1, 28)]
    public int dateInMonth;
    [Range(1, 4)]
    public int season;
    [Range(1, 99)]
    public int year;
    [Range(0, 24)]
    public int hour;
    [Range(0, 6)]
    public int minutes;
    protected DateTime dateTime;

    [Header("Tick Settings")]
    public int tickMinutesIncreased = 10;
    public float timeBetweenTicks = 1;
    private float currentTimeBetweenTicks = 0;

    public static UnityAction<DateTime> onDateTimeChanged;


    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        this.dateTime = new DateTime(dateInMonth, season - 1, year, hour, minutes * 10);
    }
    protected override void Start()
    {
        base.Start();
        onDateTimeChanged.Invoke(dateTime);
    }
    protected virtual void Update()
    {
        currentTimeBetweenTicks += Time.deltaTime;
        if(currentTimeBetweenTicks >= timeBetweenTicks)
        {
            currentTimeBetweenTicks = 0;
            this.Tick();
        }
    }
    protected virtual void Tick()
    {
        this.AdvanceTime();
    }
    protected virtual void AdvanceTime()
    {
        dateTime.AdvanceMinutes(tickMinutesIncreased);
        onDateTimeChanged.Invoke(dateTime);
    }
   

}
