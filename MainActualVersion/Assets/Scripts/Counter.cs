using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Counter // класс для хранения глобальных переменных, которые видны всем скриптам в любой сцене игры
{
    public static int counter = 3; // глобальная переменная для кол-ва дат
    public static int num_img = Random.Range(0, 13);  // глобальная переменная для номера картинки фона
    public static int score = PlayerPrefs.GetInt("today"); // счёт текущего дня
    public static int record = PlayerPrefs.GetInt("record"); // рекорд за всё время
    public static int per_change = 0; // переменная для сохранения значения DropDown(выбор периода)
};
