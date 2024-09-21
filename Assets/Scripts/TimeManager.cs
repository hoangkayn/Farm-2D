using System;
using UnityEngine;

public class TimeManager : BaseMono
{
    protected static TimeManager instance;
    public static TimeManager Instance => instance;
   
    // Số lượng ngày trong một mùa
    public const int daysPerSeason = 28;

    // Các biến lưu trữ thời gian trong game
    public int currentDay = 1;
    public int currentSeason = 1; // Mùa xuân = 1, mùa hè = 2, mùa thu = 3, mùa đông = 4
    public int currentYear = 1;

    // Các sự kiện để thông báo khi ngày mới bắt đầu (có thể để cập nhật các hệ thống khác như cây trồng)
    public event Action OnNewDay;
   

    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Hàm được gọi khi người chơi đi ngủ, chuyển sang ngày mới
    public void GoToNextDay()
    {
        // Tăng số ngày
        currentDay++;

        // Nếu vượt quá số ngày trong mùa, chuyển sang mùa mới
        if (currentDay > daysPerSeason)
        {
            currentDay = 1;
            currentSeason++;

            // Nếu vượt quá 4 mùa, chuyển sang năm mới
            if (currentSeason > 4)
            {
                currentSeason = 1;
                currentYear++;
            }
        }

        // Gọi sự kiện thông báo đã sang ngày mới
        OnNewDay?.Invoke();
    }

    // Đặt lại thời gian (dùng khi load game)
    public void SetTime(int day, int season, int year)
    {
        currentDay = day;
        currentSeason = season;
        currentYear = year;
    }

    // Hàm để lấy tên mùa hiện tại (dùng cho UI)
    public string GetSeasonName()
    {
        switch (currentSeason)
        {
            case 1: return "Spring";
            case 2: return "Summer";
            case 3: return "Fall";
            case 4: return "Winter";
            default: return "Unknown";
        }
    }

    // Hàm để trả về ngày hiện tại theo format "Ngày X, Mùa Y, Năm Z"
    public string GetFormattedDate()
    {
        return $"Day {currentDay}, {GetSeasonName()}, Year {currentYear}";
    }
}
