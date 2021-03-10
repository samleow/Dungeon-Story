using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Diagnostics;

public class loadQues : MonoBehaviour
{
    // Start is called before the first frame update
   
   
    

    void Start()
    {
        Text texts;
        var questions = new List<string>();
        var options = new List<List<string>>();
        var choices = new List<string>();
        var answers = new ArrayList();
        var difficulty = new ArrayList();
        int randomNumber = 0;
        int points = 0;
        int count = 0;
        Text option1,option2,option3;
        Button Option_1, Option_2, Option_3;

        System.Random rnd = new System.Random();

        // Read from preloaded questions
        string path = "Assets/Resources/questions.txt";
        string line;
        //Read the text from directly from the question.txt file
        StreamReader reader = new StreamReader(path);
        while((line = reader.ReadLine()) != null)
        {
            questions.Add(line);          
            
            for (int i = 0; i < 3; i++)
            {
                choices.Add(reader.ReadLine());
            }
            options.Add(choices);
            choices = new List<string>();
            answers.Add(reader.ReadLine());
            difficulty.Add(reader.ReadLine());
            
        }        
        reader.Close();

        randomNumber = rnd.Next(0, questions.Count - 1);
        texts = GameObject.Find("Questions").GetComponent<Text>();
        texts.text = questions[randomNumber].ToString();
        questions.RemoveAt(randomNumber);
        option1 = GameObject.Find("Option1").GetComponent<Text>();
        option2 = GameObject.Find("Option2").GetComponent<Text>();
        option3 = GameObject.Find("Option3").GetComponent<Text>();
        Option_1 = GameObject.Find("Option_1").GetComponent<Button>();
        Option_1.onClick.AddListener(ansA);
        Option_2 = GameObject.Find("Option_2").GetComponent<Button>();
        Option_2.onClick.AddListener(ansB);
        Option_3 = GameObject.Find("Option_3").GetComponent<Button>();
        Option_3.onClick.AddListener(ansC);

        option1.text = "A) " + options[randomNumber][0].ToString();

        option2.text = "B) " + options[randomNumber][1].ToString();

        option3.text = "C) " + options[randomNumber][2].ToString();
        options.RemoveAt(randomNumber);

        void ansA()
        {
            if (answers[randomNumber].ToString().Equals("a"))
            {
                UnityEngine.Debug.Log("Correct");
            }
            else
            {
                UnityEngine.Debug.Log("Wrong");
            }
            if (count < 3)
            {
                randomNumber = rnd.Next(0, questions.Count - 1);
                texts = GameObject.Find("Questions").GetComponent<Text>();
                texts.text = questions[randomNumber].ToString();
                questions.RemoveAt(randomNumber);
       
                option1.text = "A) " + options[randomNumber][0].ToString();
       
                option2.text = "B) " + options[randomNumber][1].ToString();
       
                option3.text = "C) " + options[randomNumber][2].ToString();

                options.RemoveAt(randomNumber);
                count++;
            }
            else
            {
                UnityEngine.Debug.Log("End");
            }
        }

        void ansB()
        {
            if (answers[randomNumber].ToString().Equals("b"))
            {
                UnityEngine.Debug.Log("Correct");
            }
            else
            {
                UnityEngine.Debug.Log("Wrong");
            }
            if (count < 3)
            {
                randomNumber = rnd.Next(0, questions.Count - 1);
                texts = GameObject.Find("Questions").GetComponent<Text>();
                texts.text = questions[randomNumber].ToString();
                questions.RemoveAt(randomNumber);
    
                option1.text = "A) " + options[randomNumber][0].ToString();
          
                option2.text = "B) " + options[randomNumber][1].ToString();
      
                option3.text = "C) " + options[randomNumber][2].ToString();

                options.RemoveAt(randomNumber);
                count++;
 
            }
            else
            {
                UnityEngine.Debug.Log("End");
            }
        }

        void ansC()
        {
            if (answers[randomNumber].ToString().Equals("c"))
            {
                UnityEngine.Debug.Log("Correct");
            }
            else
            {
                UnityEngine.Debug.Log("Wrong");
            }
            if (count < 3)
            {
                randomNumber = rnd.Next(0, questions.Count - 1);
                texts = GameObject.Find("Questions").GetComponent<Text>();
                texts.text = questions[randomNumber].ToString();
                questions.RemoveAt(randomNumber);
               
                option1.text = "A) " + options[randomNumber][0].ToString();
             
                option2.text = "B) " + options[randomNumber][1].ToString();
            
                option3.text = "C) " + options[randomNumber][2].ToString();
      
                options.RemoveAt(randomNumber);   
                count++;

            }
            else
            {
                UnityEngine.Debug.Log("End");
            }
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
