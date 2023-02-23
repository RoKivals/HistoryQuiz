using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    public Sprite[] IMG_list; // это массив изображений
    public Image backGround; // это панель, которая будет использоваться в качестве BCGD
    

    void Start()
    {
        backGround.sprite = IMG_list[Counter.num_img]; // передаём глобальную переменную, которой присвоили рандомное значение в диапазоне кол-ва картинок
    }
    
}
