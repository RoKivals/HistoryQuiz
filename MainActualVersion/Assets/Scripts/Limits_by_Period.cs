using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Limits_by_Period : MonoBehaviour
{
    public static Limits_by_Period Instance { get; private set; }   // объявление синглтона (разрешение на доступ к данным скрипта из любого другого)
    public int low_lim = 0; // нижняя граница номера события 
    public int high_lim = 377;  // верхняя граница номера события
    public Dropdown period;     // переменная типа DropDown (выпадающий список)
    public void Awake() // функция, выполняющаяся при инициализации скрипта (при его первой работе)
    {
        Instance = this;    // относится к объявлению синглтона, на что будет ссылаться синглтон (this - указатель на данный скрипт)
        period.value = Counter.per_change;  // значение, принимаемое Dropdown по умолчанию
        Period_Changed(Counter.per_change); // выставление границ по умолчанию
    }

    // Функция, отвечающая за смену границ, в зависимости от выбранного периода
    public void Period_Changed(int index)   // в index передаётся значение DropDown, при его изменении 
    {
        switch (index)
        {   // случай по умолчанию (Все даты)
            case 0: 
                low_lim = 0;
                high_lim = 377;
                Counter.per_change = 0;
                break;
            // период "Древняя Русь"
            case 1:
                low_lim  = 5;
                high_lim = 26;
                Counter.per_change = 1;
                break;
            // период "Средневековая Русь"
            case 2:
                low_lim = 27;
                high_lim = 66;
                Counter.per_change = 2;
                break;
            // период "Россия периода Смуты"
            case 3:
                low_lim = 67;
                high_lim = 76;
                Counter.per_change = 3;
                break;
            // период "Россия при Романовых"
            case 4:
                low_lim = 77;
                high_lim = 186;
                Counter.per_change = 4;
                break;
            // период "Советская Россия"
            case 5:
                low_lim = 187;
                high_lim = 348;
                Counter.per_change = 5;
                break;
            // период "Россия в XXI веке"
            case 6:
                low_lim = 349;
                high_lim = 377;
                Counter.per_change = 6;
                break;
        }
        
    }
}
