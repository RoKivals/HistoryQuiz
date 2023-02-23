using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;


public class GameController : MonoBehaviour
{
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    public int CountGuesses, CountCorrectGuesses, gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    public string firstGuessText;
    public string secondGuessText;
    public string[] EventsDatesMain;
    public TextAsset EventsDates;
    public string sum, sumReverse;
    public int Equality = 0;
    
    
    void Awake ()
    {
        TextAsset EventsDates = (TextAsset)Resources.Load("EventsDates", typeof(TextAsset));
        EventsDatesMain = EventsDates.text.Split(new char[] { '\n' });
    }
    void Start()
    {
        
        

        for (int o = 0; o < 377 ; o++)                                           //убираем переносы строк из строк
        {
            EventsDatesMain[o]=EventsDatesMain[o].Replace("\r", "");
        }   
        GetButtons();
        AddListeners();
        gameGuesses = Counter.counter;
    }

   
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for(int i=0; i<objects.Length;i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
        }
    }
  
    void AddListeners()
    {
        foreach (Button btn in btns)
        { btn.onClick.AddListener(()=>PickAPuzzle()); }
    }
    public void PickAPuzzle()
    {
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessText = btns[firstGuessIndex].transform.Find("Text").gameObject.GetComponent<Text>().text;
            btns[firstGuessIndex].transform.Find("Text").gameObject.SetActive(true);
   
            // Debug.Log(firstGuessText);

        }
       else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessText = btns[secondGuessIndex].transform.Find("Text").gameObject.GetComponent<Text>().text;
            btns[secondGuessIndex].transform.Find("Text").gameObject.SetActive(true);
            sum = firstGuessText + secondGuessText;
            sumReverse = secondGuessText + firstGuessText;
            CountGuesses++;
           // Debug.Log(secondGuessText);
            for (int i = 0; i < AddButtons.RandomNums.Length; i++)
            {
                if (sumReverse.Equals(EventsDatesMain[AddButtons.RandomNums[i]]) || sum.Equals(EventsDatesMain[AddButtons.RandomNums[i]]))
                {
                    Equality = 1;
                    CountCorrectGuesses++;
                    Counter.score++;
                    Counter.record++;
                }
            }
                    StartCoroutine(CheckIfThePuzzleMatch());
        }
    }
    IEnumerator CheckIfThePuzzleMatch()
    {
        if (Equality == 1)
            {
                yield return new WaitForSeconds(.5f);
                btns[firstGuessIndex].interactable = false;
                btns[secondGuessIndex].interactable = false;
               // Debug.Log("match");
                Equality = 0;
            }   
            
        else
            {
                yield return new WaitForSeconds(2.5f);
                btns[firstGuessIndex].transform.Find("Text").gameObject.SetActive(false);
                btns[secondGuessIndex].transform.Find("Text").gameObject.SetActive(false);   
            
        }
            firstGuess =  false;
            secondGuess = false;
        if (CountCorrectGuesses == gameGuesses)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("FinishScreen");
            PlayerPrefs.SetInt("record", Counter.record);
            PlayerPrefs.SetInt("today", Counter.score);
            //  Debug.Log("Game Finished");
        }

    }
}
