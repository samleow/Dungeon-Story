using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class preloadQues : MonoBehaviour
{
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
        SceneManager.LoadScene("CharacterPage");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
