using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record_printitng : MonoBehaviour
{
    public Text this_day;   // Text отвечающий за даты на сегодня
    public Text all_time;   // Text отвечающий за всё время
    string timequit;    // время последнего выхода из игры
    // Start is called before the first frame update
    void Start()
    {
        this_day.text = this_day.text + "   " + PlayerPrefs.GetInt("today");    // запись счёта в кол-во дат совпавших сегодня
        all_time.text = all_time.text + "   " + PlayerPrefs.GetInt("record");   // запись  кол-во дат совпавших за всё время
        timequit = PlayerPrefs.GetString("Time");    // получение числа из даты, когда был совершён выход
        // сравнение числа нынешнего дня с числом последнего выхода 
        // если числа разные, то есть начался другой день, мы обнуляем кол-во дат, отвеченных за этот день
        if (DateTime.Now.ToShortDateString() != timequit)   
        {   
            Counter.score = 0;
            PlayerPrefs.SetInt("today", 0); // изменяем кол-во дат отвеченных за день на 0
            this_day.text = this_day.text + "   " + PlayerPrefs.GetInt("today");
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToShortDateString());    // при выходе из игры сохраняем дату выхода
    }

}
