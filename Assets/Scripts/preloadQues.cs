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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadQues()
    {
        StartCoroutine(loadQuestions());
    }

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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
