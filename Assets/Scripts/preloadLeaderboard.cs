using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;

public class preloadLeaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLeaderboard());
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
            string path = "Assets/Resources/leaderboard.txt";

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, false);
            for (int i = 0; i < nameScores.Length - 1; i++){
                writer.WriteLine(nameScores[i]);
            }
            writer.Close();
        }
    }
            // Update is called once per frame
     void Update()
    {
        
    }
}
