using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Validate_Login : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textField;
    GameData _gameData = GameData.getInstance;
    public checkWorldLock checkWorldLock;

    void Start()
    {
        
    }
    public void ValidateLogin()
    {
        //Debug.Log("Clicked");
        
        InputField userField = GameObject.Find("login_username").GetComponent<InputField>();
        InputField pwField = GameObject.Find("login_password").GetComponent<InputField>();
        string username = userField.text;
        string password = pwField.text;

        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            StartCoroutine(checkWorldLock.checkWorldLocked());
            StartCoroutine(Upload(username, password));
        }
        else
        {
            textField = GameObject.Find("error_text").GetComponent<Text>();
            textField.text = "No empty fields allowed!";
        }

    }
    IEnumerator Upload(string user, string pw)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", user);
        form.AddField("password", pw);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/login.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string error = www.downloadHandler.text;
            if (error.Equals("Admin"))
            {
                //PlayerPrefs.SetString("Name", user);
                _gameData.user = user;
                _gameData.admin = true;
                SceneManager.LoadScene("AdminPage");
            }
            else if(error.Equals("Student"))
            {
                _gameData.user = user;
                _gameData.admin = false;
                SceneManager.LoadScene("TitlePage");
            }
        
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
