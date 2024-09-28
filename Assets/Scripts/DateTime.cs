using System;
using UnityEngine;

[Serializable]
public class DateTime 
{
    protected Days day;
    public Days Day => day;

    protected int date;
    public int Date => date;

    protected int year;
    public int Year => year;

    protected int hour;
    public int Hour => hour;

    protected int minutes;
    public int Minutes => minutes;

    protected Season season;
    public Season Season => season;

    protected int totalNumDays;
    public int TotalNumDays => totalNumDays;

    protected int totalNumWeeks;
    public int TotalNumWeeks => totalNumWeeks % 16 == 0 ? 16 : totalNumWeeks %16;

    public DateTime(int date, int season,int year, int hour, int minutes)
    {
        this.day = (Days)(date % 7);
        if (day == 0) day = (Days)7;
        this.date = date;
        this.season = (Season)season;
        this.year = year;
        this.hour = hour;
        this.minutes = minutes;
        totalNumDays = this.date + (28 * (int)this.season) + (112 * (year - 1));
        totalNumWeeks = 1 + totalNumDays / 7;
    }
    public void AdvanceMinutes(int SecondsToAdvanceBy)
    {
        if(minutes + SecondsToAdvanceBy >= 60)
        {
            minutes = (minutes + SecondsToAdvanceBy) % 60;
            this.AdvanceHour();
        }
        else
        {
            minutes += SecondsToAdvanceBy;
        }

    }
    public void AdvanceHour()
    {
        if((hour +1) == 24){
            hour = 0;
            this.AdvanceDay();
        }
        else
        {
            hour++;
        }
    }
    protected virtual void AdvanceDay()
    {
        if((day +1) > (Days)7)
        {
            day = (Days)1;
            totalNumWeeks++;
        }
        else
        {
            day++;
        }
        date++;
        if(date %29 == 0)
        {
            AdvanceSeason();
            date = 1;
        }
        totalNumDays++;
    }
    protected virtual void AdvanceSeason()
    {
        if (season == Season.Winter)
        {
            season = Season.Spring;
            this.AdvanceYear();
        }
        else season++;
    }
    protected virtual void AdvanceYear()
    {
        date = 1;
        year++;
    }
    public bool IsNight()
    {
        return hour > 18 || hour < 6;
    }
    public bool IsMorning()
    {
        return hour >= 6 || hour <= 12;
    }
    public bool IsAfternoon()
    {
        return hour > 12 || hour <= 18;
    }
    public bool IsWeekend()
    {
        return day > Days.Fri ? true : false;
    }
    public bool IsParticularDay(Days day)
    {
        return this.day == day;
    }

    public DateTime NewYearsDay(int year)
    {
        if (year == 0) year = 1;
        return new DateTime(1, 0, year, 6, 0);
    }
    public DateTime SummerSolstice(int year)
    {
        if (year == 0) year = 1;
        return new DateTime(28,1,year,6,0);
    }
    public DateTime PumpkinHarvest(int year)
    {
        if (year == 0) year = 1;
        return new DateTime(28,2,year,6,0);
    }
    
    public DateTime StartOfSeason(int season, int year)
    {
        season = Mathf.Clamp(season, 0, 3);
        if (year == 0) year = 1;

        return new DateTime(1, season, year, 6, 0);
    }

    public DateTime StartOfWinter(int year)
    {
        return StartOfSeason(3,year);
    }
    public override string ToString()
    {
        return $"Date: {DateToString()} Season: {season.ToString()} Time: {TimeToString()}" +
            $"\nTotal Days: {totalNumDays} | Total Weeks: {totalNumWeeks}";
    }
    public string DateToString()
    {
        return $"{Day} {Date} {Year.ToString("D2")}";
    }
    public string TimeToString()
    {
        int adjustedHour = 0;
        if(hour == 0)
        {
            adjustedHour = 12;
        }
        else if(hour == 24)
        {
            adjustedHour = 12;
        }
        else if(hour >= 13)
        {
            adjustedHour -= 12;
        }
        else
        {
            adjustedHour = hour;
        }
        string AmPm = hour == 0 || hour < 12 ? "AM" : "PM";
        return $"{adjustedHour.ToString("D2")}:{minutes.ToString("D2")} {AmPm}";
    }





}
