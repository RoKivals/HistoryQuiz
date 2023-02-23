using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Writer : MonoBehaviour
{
    public Text Teext;  // объявляем переменную типа Text, куда выведем итоги игры

    void Start()
    {
        string Events; // строка, которая будет содержать в себе событие с датой
        for (int i = 0; i<Counter.counter; i++)
        {   // по очереди передаём строке значения даты и события
            Events = AddButtons.DatesMain[AddButtons.RandomNums[i]] + " - " + AddButtons.EventsMain[AddButtons.RandomNums[i]] + '\n';
            //выводим эту строку на экран
            Teext.text+= Events;
        }
      
    }
    
}
