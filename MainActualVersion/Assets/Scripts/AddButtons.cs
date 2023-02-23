using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class AddButtons : MonoBehaviour
{   
    [SerializeField]
    public Transform puzzleField;
    [SerializeField]
    public GameObject btn;
    public static int DateK;                    // кол-во кнопок, которые будут на экране игры
    public int Changer = 0;                        //рандомно генерируемое число для обмена значений массива ButtonsContent
    public string Buffer;                     //строка для обмена значений массива ButtonsContent
    public static int[] RandomNums = new int[5];      //массив для рандомных значений для забивания строками массива BUttonContent
    public static string[] DatesMain;
    public static string[] EventsMain;
    public Font krasivo;   
    void Start()
    {   
        DateK = Counter.counter*2;  
        System.Random TheBestRandomizer = new System.Random(); // объявляем переменную класса Random для случайных чисел
        string[] ButtonsContent = new string[DateK];            
        TextAsset Dates = (TextAsset)Resources.Load("Dates", typeof(TextAsset));   //помещение файла в текст ассет, затем в строку, затем деление и помещение в массив строк
        DatesMain = Dates.text.Split(new char[] { '\n' });

        TextAsset Events = (TextAsset)Resources.Load("Events", typeof(TextAsset)); //то же самое
        EventsMain = Events.text.Split(new char[] { '\n' });

        for (int o = 0; o < 377; o++)                               //убираю символы а
        {
            DatesMain[o]=DatesMain[o].Replace("\r", "");
            EventsMain[o]=EventsMain[o].Replace("\r", "");
        }
        for (int x=0; x<Counter.counter; x++)   // Заполняем RandomNums, исключая совпадения
        {   //выбираем случайное число в диапазоне двух значений, в зависимости от периода
            RandomNums[x] = TheBestRandomizer.Next(Limits_by_Period.Instance.low_lim, Limits_by_Period.Instance.high_lim);   
            //исключаем совпадения при работе random
            for (int i=0; i<x; i++)
            {
                if (RandomNums[x] == RandomNums[i])
                {
                while (RandomNums[x] == RandomNums[i])
                RandomNums[x] = TheBestRandomizer.Next(Limits_by_Period.Instance.low_lim, Limits_by_Period.Instance.high_lim);
                }
            }
            
        }
        for (int NumbersEvents = 0; NumbersEvents < Counter.counter; NumbersEvents++)      //этот цикл забивает датами и событиями массив зачений кнопок
        {
           
            ButtonsContent[NumbersEvents] = EventsMain[RandomNums[NumbersEvents]];
            ButtonsContent[NumbersEvents + Counter.counter] = DatesMain[RandomNums[NumbersEvents]];
        }

         for (int i = DateK - 1; i > 1; i--) //этот цикл случайным образом перемешивает значения кнопок
         {
             Changer = TheBestRandomizer.Next(i);  //генерируем случайное число больше или равно нуля меньше или равно i и назовем его Changer
             Buffer = ButtonsContent[i];
             ButtonsContent[i] = ButtonsContent[Changer]; //меняем местами ButtonsContens[i] и  ButtonsContens[Changer];
             ButtonsContent[Changer] = Buffer;
         }

        for (int x = 0; x < DateK; x++)
        {
                GameObject button = Instantiate(btn);
                button.name = Convert.ToString(x);
                button.transform.SetParent(puzzleField, false);  
                button.GetComponentInChildren<Text>().text = ButtonsContent[x];  // заполнение тектом кнопок
            button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
                button.GetComponentInChildren<Text>().resizeTextMaxSize = 48;   
                button.GetComponentInChildren<Text>().resizeTextMinSize = 32;     // размер шрифта на экране игры
                button.GetComponentInChildren<Text>().fontStyle = FontStyle.Bold; // стиль текста жирный
                button.GetComponentInChildren<Text>().font = krasivo;        // меняем шрифт 
                button.transform.Find("Text").gameObject.SetActive(false);
         }

        
    }
    
}
