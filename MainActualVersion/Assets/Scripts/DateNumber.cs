using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DateNumber : MonoBehaviour
{ 
    public Text Num;    // поле, отображающее кол-во дат
    public Button Pl;   // кнопка " + "
    public Button Mi;   // кнопка " - "
    // выставляем ограничения при запуске скрипта (при каждом открытии начального экрана)
    void Start()
    {   if (Counter.counter == 5)   
            Pl.interactable = false;    // отключаем кнопку " + ", если кол-во равно 5
        if (Counter.counter == 2)
            Mi.interactable = false;    // отключаем кнопку " - ", если кол-во равно 2
        Num.text = Counter.counter.ToString(); // прописываем кол-во из глобальной переменной
    }
        
    void Update()
    {  
        if (Counter.counter <5 && Counter.counter > 2) // ограничитель для работы + и -
        {
            Pl.interactable = true;
            Mi.interactable = true;
        }
    }
    public void Minus ()    // работа нажатия на кнопку " - " 
    {   
        if (Counter.counter > 2)
            Counter.counter--;
        if (Counter.counter == 2)
            Mi.interactable = false;
        Num.text = Counter.counter.ToString();  // вывод значения в кол-во
    }
    public void Plus () // работа нажатия на кнопку " + " 
    {
        if (Counter.counter < 5)
            Counter.counter++;
        if (Counter.counter == 5)
            Pl.interactable = false;
        Num.text = Counter.counter.ToString();  // вывод значения в кол-во
    }
    
}
