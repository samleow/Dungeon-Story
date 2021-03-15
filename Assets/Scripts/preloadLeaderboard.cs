using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;

public class preloadLeaderboard : MonoBehaviour
{
    GameData _gameData = GameData.getInstance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLeaderboard());
        StartCoroutine(loadReport());
    }

    IEnumerator loadLeaderboard()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://valerianlow123.000webhostapp.com/getLeaderboard.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string[] nameScores = www.downloadHandler.text.Split(' ');
            //string path = "Assets/Resources/leaderboard.txt";

            //Write some text to the test.txt file
            //StreamWriter writer = new StreamWriter(path, false);
            for (int i = 0; i < nameScores.Length; i++){
                _gameData.score.Add(nameScores[i]);
               // writer.WriteLine(nameScores[i]);
                if(nameScores[i].Equals(PlayerPrefs.GetString("Name")))
                {
                    PlayerPrefs.SetInt("Rank", i / 2);
                    PlayerPrefs.SetString("Score", nameScores[i + 1]);
                }
            }
            //writer.Close();
        }
    }

    IEnumerator loadReport()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://valerianlow123.000webhostapp.com/generateSummaryReport.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string[] report = www.downloadHandler.text.Split(',');
            string path = "Assets/Resources/report.txt";

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, false);
            for (int i = 0; i < report.Length; i++)
            {
                writer.WriteLine(report[i]);
            }
            writer.Close();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
