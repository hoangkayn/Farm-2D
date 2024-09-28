using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ClockManager : BaseMono
{
    public RectTransform clockFace;
    public TextMeshProUGUI date, time, season, week;
    public Image weatherSprite;
    public Sprite[] weatherSprites;
    protected float startingRot;
    public Light sunLight;
    public float nightIntensity;
    public float dayIntensity;
    public AnimationCurve dayNightCurve;

    protected override void Awake()
    {
        base.Awake();
        startingRot = clockFace.localEulerAngles.z;

    }
    protected override void OnEnable()
    {
        base.OnEnable();
        TimeManager.onDateTimeChanged += UpdateDataTime;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        TimeManager.onDateTimeChanged -= UpdateDataTime;
    }
     protected void UpdateDataTime(DateTime dateTime)
    {
        date.text = dateTime.DateToString();
        time.text = dateTime.TimeToString();
        season.text = dateTime.Season.ToString();
       // week.text = $"WK:{dateTime.CurrentWeek.ToString()}";
     //   weatherSprite.sprite = weatherSprites[(int) ]
    }


}
