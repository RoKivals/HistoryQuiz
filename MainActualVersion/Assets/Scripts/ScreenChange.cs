using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChange : MonoBehaviour
{
    public void ScreenChanger()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game"); // загружаем основную сцену игры
    }
    public void StartScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScreen");  // загружаем стартовый экран
        PlayerPrefs.SetInt("record", Counter.record);   // сохраняем в файлах игры кол-во дат за всё время
        PlayerPrefs.SetInt("today", Counter.score);     // сохраняем в файлах игры кол-во дат за сегодня
        System.GC.Collect();    // принудительный запуск сбора накопившегося мусора для его очистки
    }
}
