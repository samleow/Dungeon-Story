using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class loadQues : MonoBehaviour
{
    // Start is called before the first frame update

    GameData _gameData = GameData.getInstance;
    List<string> choices = new List<string>();

    void Start()
    {
        Text texts;
        int randomNumber = 0;
        int points = 0;
        int count = 1;
        Text option1,option2,option3;
        Button Option_1, Option_2, Option_3;

        System.Random rnd = new System.Random();
        if (!PlayerPrefs.HasKey("visited"))
        {
            string path = "Assets/Resources/questions.txt";
            string line;

            //Read the text from directly from the question.txt file
            StreamReader reader = new StreamReader(path);
            while ((line = reader.ReadLine()) != null)
            {
                _gameData.questions.Add(line);

                for (int i = 0; i < 3; i++)
                {
                    choices.Add(reader.ReadLine());
                }
                _gameData.options.Add(choices);
                choices = new List<string>();
                _gameData.answers.Add(reader.ReadLine());
                _gameData.difficulty.Add(reader.ReadLine());
            }
            reader.Close();
        }
        PlayerPrefs.SetInt("visited", 1);
        
        // Read from preloaded questions
        PlayerPrefs.DeleteKey("visited");

        randomNumber = rnd.Next(0, _gameData.questions.Count - 1);
        texts = GameObject.Find("Questions").GetComponent<Text>();
        texts.text = _gameData.questions[randomNumber].ToString();

        _gameData.questions.RemoveAt(randomNumber);

        option1 = GameObject.Find("Option1").GetComponent<Text>();
        option2 = GameObject.Find("Option2").GetComponent<Text>();
        option3 = GameObject.Find("Option3").GetComponent<Text>();
        Option_1 = GameObject.Find("Option_1").GetComponent<Button>();
        Option_1.onClick.AddListener(ansA);
        Option_2 = GameObject.Find("Option_2").GetComponent<Button>();
        Option_2.onClick.AddListener(ansB);
        Option_3 = GameObject.Find("Option_3").GetComponent<Button>();
        Option_3.onClick.AddListener(ansC);

        option1.text = "A) " + _gameData.options[randomNumber][0].ToString();

        option2.text = "B) " + _gameData.options[randomNumber][1].ToString();

        option3.text = "C) " + _gameData.options[randomNumber][2].ToString();

        _gameData.options.RemoveAt(randomNumber);

        void ansA()
        {
            if (_gameData.answers[randomNumber].ToString().Equals("a"))
            {
                UnityEngine.Debug.Log("Correct");
            }
            else
            {
                UnityEngine.Debug.Log("Wrong");
            }
            UnityEngine.Debug.Log(_gameData.questions.Count);
            if (count < 3)
            {
                randomNumber = rnd.Next(0, _gameData.questions.Count - 1);
                texts = GameObject.Find("Questions").GetComponent<Text>();
                texts.text = _gameData.questions[randomNumber].ToString();
                _gameData.questions.RemoveAt(randomNumber);
       
                option1.text = "A) " + _gameData.options[randomNumber][0].ToString();
       
                option2.text = "B) " + _gameData.options[randomNumber][1].ToString();
       
                option3.text = "C) " + _gameData.options[randomNumber][2].ToString();

                _gameData.options.RemoveAt(randomNumber);
                count++;
            }
            else
            {
                SceneManager.LoadScene("DoorPage");
            }
        }

        void ansB()
        {
            if (_gameData.answers[randomNumber].ToString().Equals("b"))
            {
                UnityEngine.Debug.Log("Correct");
            }
            else
            {
                UnityEngine.Debug.Log("Wrong");
            }
            UnityEngine.Debug.Log(_gameData.questions.Count);
            if (count < 3)
            {
                randomNumber = rnd.Next(0, _gameData.questions.Count - 1);
                texts = GameObject.Find("Questions").GetComponent<Text>();
                texts.text = _gameData.questions[randomNumber].ToString();
                _gameData.questions.RemoveAt(randomNumber);
    
                option1.text = "A) " + _gameData.options[randomNumber][0].ToString();
          
                option2.text = "B) " + _gameData.options[randomNumber][1].ToString();
      
                option3.text = "C) " + _gameData.options[randomNumber][2].ToString();

                _gameData.options.RemoveAt(randomNumber);
                count++;
 
            }
            else
            {
                SceneManager.LoadScene("DoorPage");
            }
        }

        void ansC()
        {
            if (_gameData.answers[randomNumber].ToString().Equals("c"))
            {
                UnityEngine.Debug.Log("Correct");
            }
            else
            {
                UnityEngine.Debug.Log("Wrong");
            }
            UnityEngine.Debug.Log(_gameData.questions.Count);
            if (count < 3)
            {
                randomNumber = rnd.Next(0, _gameData.questions.Count - 1);
                texts = GameObject.Find("Questions").GetComponent<Text>();
                texts.text = _gameData.questions[randomNumber].ToString();
                _gameData.questions.RemoveAt(randomNumber);
               
                option1.text = "A) " + _gameData.options[randomNumber][0].ToString();
             
                option2.text = "B) " + _gameData.options[randomNumber][1].ToString();
            
                option3.text = "C) " + _gameData.options[randomNumber][2].ToString();

                _gameData.options.RemoveAt(randomNumber);   
                count++;

            }
            else
            {
                SceneManager.LoadScene("DoorPage");
            }
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
