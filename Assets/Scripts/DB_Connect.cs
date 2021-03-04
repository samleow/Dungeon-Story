using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DB_Connect : MonoBehaviour
{
    // Start is called before the first frame update

    //Initialize values
    Text textField;

    public void Start()
    {
    }
    public void clearTextBoxes()
    {
        GameObject.Find("general_error_text").GetComponent<Text>().text = "";
        GameObject.Find("pw_error_text").GetComponent<Text>().text = "";
        GameObject.Find("username_error_text").GetComponent<Text>().text = "";
        GameObject.Find("email_error_text").GetComponent<Text>().text = "";
    }
    public void onClick() {
        //Debug.Log("Clicked");
        InputField userField = GameObject.Find("create_username").GetComponent<InputField>();
        InputField pwField = GameObject.Find("create_pw").GetComponent<InputField>();
        InputField cfm_pwField = GameObject.Find("cfm_pw").GetComponent<InputField>();
        InputField emailField = GameObject.Find("create_email").GetComponent<InputField>();
        string username = userField.text;
        string password = pwField.text;
        string cfnPW = cfm_pwField.text;
        string email = emailField.text;
        
        if (!cfnPW.Equals(password))
        {
            clearTextBoxes();
            textField = GameObject.Find("pw_error_text").GetComponent<Text>();
            textField.text = "Passwords do not match!";
        }
        else if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(email))
        {
            StartCoroutine(Upload(username,password,email));
           /* StartCoroutine(GetRequest("http://valerianlow123.000webhostapp.com/account_reg.php?"+
                                      "username="+username + "&password="+password));*/
        }
        else
        {
            clearTextBoxes();
            textField = GameObject.Find("general_error_text").GetComponent<Text>();
            textField.text = "No empty fields allowed!";
        }
        
    }
    IEnumerator Upload(string user, string pw, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", user);
        form.AddField("password", pw);
        form.AddField("email", email);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/account_reg.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string error= www.downloadHandler.text;
            if (error.Equals(email)){
                clearTextBoxes();
                textField = GameObject.Find("email_error_text").GetComponent<Text>();
                textField.text = "Email has already been used!";
            }
            if (error.Equals(user)){
                clearTextBoxes();
                textField = GameObject.Find("username_error_text").GetComponent<Text>();
                textField.text = "Username has already been used!";
            }
        }
    }
}
