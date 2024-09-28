using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : BaseMono
{
    [Header("=== WeatherManager ===")]
    [SerializeField] private int ticksBetweenWeather = 10;
    [SerializeField] protected int weatherQueueSize = 5;
    protected int currentWeatherTick = 0;
    [SerializeField] protected Weather currentWeather;
    public Weather CurrentWeather => currentWeather;
    private Queue<Weather> weatherQueue;

    [Header("==== Weather VFX ===")]
    [SerializeField] ParticleSystem rainParticle;
    [SerializeField] ParticleSystem snowParticle;
    [SerializeField] ParticleSystem lightParticle;
    [SerializeField] ParticleSystem cloudParticle;

    [Header("=== Debug Options ===")]
    public bool forceRain = false;
    public static Action<Weather, Queue<Weather>> OnWeatherChange;

    protected override void Start()
    {
        base.Start();
        rainParticle.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        snowParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        lightParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        cloudParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        this.FillWeatherQueue();
        this.ChangeWeather();

    }
    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.OnTick += Tick;

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.OnTick -= Tick;
    }
    protected virtual void Tick()
    {
        currentWeatherTick++;
        if(currentWeatherTick >= ticksBetweenWeather)
        {
            currentWeatherTick = 0;
            this.ChangeWeather();
        }

    }
    protected virtual void FillWeatherQueue()
    {
        weatherQueue = new Queue<Weather>();
        for(int i = 0;i< weatherQueueSize; i++)
        {
            Weather tempWeather = GetRandomWeather();
            weatherQueue.Enqueue(tempWeather);
            Debug.Log($"Weather is {tempWeather} at index {i}");
        }
    }
   protected virtual Weather GetRandomWeather()
    {
        int randomWeather = 0;
        if (!forceRain) randomWeather = UnityEngine.Random.Range(0, (int)Weather.WEATHER_MAX);
        else randomWeather = 2;
        return (Weather)randomWeather;
    }
    protected virtual void ChangeWeather()
    {
        currentWeather = weatherQueue.Dequeue();
        weatherQueue.Enqueue(GetRandomWeather());
        OnWeatherChange.Invoke(currentWeather, weatherQueue);
        switch (currentWeather)
        {
            case Weather.Sunny:
                rainParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                snowParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                lightParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                cloudParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                break;
            case Weather.Cloudy:
                rainParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                snowParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                lightParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                cloudParticle.Play();
                break;
            case Weather.Rain:
                rainParticle.Play();
                snowParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                lightParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                cloudParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                break;
            case Weather.Snow:

                rainParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                snowParticle.Play();
                lightParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                cloudParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                break;
            case Weather.Lighning:
                rainParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                snowParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                lightParticle.Play();
                cloudParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                break;
        }
    }

}
