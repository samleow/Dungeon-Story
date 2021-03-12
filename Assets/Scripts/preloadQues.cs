using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class preloadQues : MonoBehaviour
{
    GameData _gameData = GameData.getInstance;
    List<string> choices = new List<string>();
    
    public void loadQues()
    {
        StartCoroutine(loadQuestions());
    }

    IEnumerator loadQuestions()
    {
        int diff1, diff2, diff3;
        string[] questionBank;
        UnityWebRequest www = UnityWebRequest.Get("http://valerianlow123.000webhostapp.com/getQuestions.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            questionBank = www.downloadHandler.text.Split(',', '\n');
            
            // iterator may go past list length if database data not following format
            int i = 0;

            diff1 = int.Parse(questionBank[i]);
            diff2 = int.Parse(questionBank[++i]);
            diff3 = int.Parse(questionBank[++i]);

            int j = 0;
            while (j < diff1)
            {
                QuestionSet qs = new QuestionSet();
                qs.question = questionBank[++i];
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.answer = questionBank[++i];
                qs.difficulty = 1;
                _gameData.questions[0].Add(qs);
                j++;
            }
            j = 0;
            while (j < diff2)
            {
                QuestionSet qs = new QuestionSet();
                qs.question = questionBank[++i];
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.answer = questionBank[++i];
                qs.difficulty = 2;
                _gameData.questions[1].Add(qs);
                j++;
            }
            j = 0;
            while (j < diff3)
            {
                QuestionSet qs = new QuestionSet();
                qs.question = questionBank[++i];
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.options.Add(questionBank[++i]);
                qs.answer = questionBank[++i];
                qs.difficulty = 3;
                _gameData.questions[2].Add(qs);
                j++;
            }

            SceneManager.LoadScene("CharacterPage");
        }
        
    }

/*
    IEnumerator loadQuestions()
    {
        int diff1, diff2, diff3;
        UnityWebRequest www = UnityWebRequest.Get("http://valerianlow123.000webhostapp.com/getQuestions.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string[] questionBank = www.downloadHandler.text.Split(',', '\n');
            string path = "Assets/Resources/questions.txt";

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, false);
            for (int i = 0; i < questionBank.Length; i++)
            {
                writer.WriteLine(questionBank[i]);
            }
            writer.Close();
        }

        string path2 = "Assets/Resources/questions.txt";

        //Read the text from directly from the question.txt file
        StreamReader reader = new StreamReader(path2);
        diff1 = int.Parse(reader.ReadLine());
        diff2 = int.Parse(reader.ReadLine());
        diff3 = int.Parse(reader.ReadLine());

        while (diff1 > 0)
        {
            _gameData.questions_difficulty_1.Add(reader.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                choices.Add(reader.ReadLine());
            }
            _gameData.options_difficulty_1.Add(choices);
            choices = new List<string>();
            _gameData.answers_difficulty_1.Add(reader.ReadLine());
            diff1--;
            //_gameData.difficulty.Add(reader.ReadLine());
        }
        while (diff2 > 0)
        {
            _gameData.questions_difficulty_2.Add(reader.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                choices.Add(reader.ReadLine());
            }
            _gameData.options_difficulty_2.Add(choices);
            choices = new List<string>();
            _gameData.answers_difficulty_2.Add(reader.ReadLine());
            diff2--;
            //_gameData.difficulty.Add(reader.ReadLine());
        }
        while (diff3 > 0)
        {
            _gameData.questions_difficulty_3.Add(reader.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                choices.Add(reader.ReadLine());
            }
            _gameData.options_difficulty_3.Add(choices);
            choices = new List<string>();
            _gameData.answers_difficulty_3.Add(reader.ReadLine());
            diff3--;
            //_gameData.difficulty.Add(reader.ReadLine());
        }
        _gameData.options_storage.Add(_gameData.options_difficulty_1);
        _gameData.options_storage.Add(_gameData.options_difficulty_2);
        _gameData.options_storage.Add(_gameData.options_difficulty_3);
        _gameData.questions_storage.Add(_gameData.questions_difficulty_1);
        _gameData.questions_storage.Add(_gameData.questions_difficulty_2);
        _gameData.questions_storage.Add(_gameData.questions_difficulty_3);
        _gameData.answers_storage.Add(_gameData.answers_difficulty_1);
        _gameData.answers_storage.Add(_gameData.answers_difficulty_2);
        _gameData.answers_storage.Add(_gameData.answers_difficulty_3);

        reader.Close();

        SceneManager.LoadScene("CharacterPage");
    }*/

}
