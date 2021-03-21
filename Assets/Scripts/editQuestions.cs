using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Net;

public class editQuestions : MonoBehaviour
{
    public Text textField;
    GameData _gameData = GameData.getInstance;
    public GameObject msgBox,msgBox2,msgBox3;
    preloadQues script2;
    void Start()
    {
        script2 = GameObject.FindObjectOfType<preloadQues>();
    }

    public void confirmationBox()
    {
        msgBox2.SetActive(true);
    }
    public void addQuestions()
    {
        InputField quesField = GameObject.Find("Question").GetComponent<InputField>();
        InputField option1Field = GameObject.Find("Option1").GetComponent<InputField>();
        InputField option2Field = GameObject.Find("Option2").GetComponent<InputField>();
        InputField option3Field = GameObject.Find("Option3").GetComponent<InputField>();
        InputField answerField = GameObject.Find("Answer").GetComponent<InputField>();
        InputField difficultyField = GameObject.Find("Difficulty").GetComponent<InputField>();
        string question = quesField.text;
        string option1 = option1Field.text;
        string option2 = option2Field.text;
        string option3 = option3Field.text;
        string answer = answerField.text;
        string difficulty = difficultyField.text;

        if (!string.IsNullOrWhiteSpace(question) && !string.IsNullOrWhiteSpace(option1) && !string.IsNullOrWhiteSpace(option2) && 
            !string.IsNullOrWhiteSpace(option3) && !string.IsNullOrWhiteSpace(answer) && !string.IsNullOrWhiteSpace(difficulty))
        {
            if ((Regex.IsMatch(question, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(option1, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(option2, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) ||
                Regex.IsMatch(option3, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(answer, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(difficulty, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase)))
            {
                textField = GameObject.Find("Error").GetComponent<Text>();
                textField.text = "TextField cannot contain special characters!";
            }
            else if (!(answer.Equals("a") || answer.Equals("b") || answer.Equals("c")))
            {
                textField = GameObject.Find("Error").GetComponent<Text>();
                textField.text = "Answer can only be a, b or c";
            }
            else if (!(difficulty.Equals("1") || difficulty.Equals("2") || difficulty.Equals("3")))
            {
                textField = GameObject.Find("Error").GetComponent<Text>();
                textField.text = "Difficulty can only be 1, 2 or 3";
            }
            else
            {
                StartCoroutine(Upload(question, option1, option2, option3, answer, difficulty));
            }
        }
        else
        {
            textField = GameObject.Find("Error").GetComponent<Text>();
            textField.text = "No empty fields allowed!";           
        }
    }

    public void updateQuestions()
    {
        InputField quesField = GameObject.Find("Question").GetComponent<InputField>();
        InputField option1Field = GameObject.Find("option1").GetComponent<InputField>();
        InputField option2Field = GameObject.Find("option2").GetComponent<InputField>();
        InputField option3Field = GameObject.Find("option3").GetComponent<InputField>();
        InputField answerField = GameObject.Find("answer").GetComponent<InputField>();
        InputField difficultyField = GameObject.Find("difficulty").GetComponent<InputField>();
        string question = quesField.text;
        string option1 = option1Field.text;
        string option2 = option2Field.text;
        string option3 = option3Field.text;
        string answer = answerField.text;
        string difficulty = difficultyField.text;

        if (!string.IsNullOrWhiteSpace(question) && !string.IsNullOrWhiteSpace(option1) && !string.IsNullOrWhiteSpace(option2) &&
            !string.IsNullOrWhiteSpace(option3) && !string.IsNullOrWhiteSpace(answer) && !string.IsNullOrWhiteSpace(difficulty))
        {
            if ((Regex.IsMatch(question, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(option1, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(option2, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) ||
                Regex.IsMatch(option3, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(answer, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase) || Regex.IsMatch(difficulty, "[^a-zA-Z0-9? ]", RegexOptions.IgnoreCase)))
            {
                textField = GameObject.Find("Error").GetComponent<Text>();
                textField.text = "TextField cannot contain special characters!";
            }
            else if (!(answer.Equals("a") || answer.Equals("b") || answer.Equals("c")))
            {
                textField = GameObject.Find("Error").GetComponent<Text>();
                textField.text = "Answer can only be a, b or c";
            }
            else if (!(difficulty.Equals("1") || difficulty.Equals("2") || difficulty.Equals("3")))
            {
                textField = GameObject.Find("Error").GetComponent<Text>();
                textField.text = "Difficulty can only be 1, 2 or 3";
            }
            else
            {
                StartCoroutine(updateQues(question, option1, option2, option3, answer, difficulty,_gameData.currQID));
            }
        }
        else
        {
            textField = GameObject.Find("Error").GetComponent<Text>();
            textField.text = "No empty fields allowed!";
        }
    }

    public void deleteQuestions()
    {
        msgBox2.SetActive(false);
        StartCoroutine(deleteQues(_gameData.currQID));
        _gameData.questions[_gameData.currI].RemoveAt(_gameData.currJ);
    }

    IEnumerator Upload(string question, string option1, string option2, string option3, string answer,string difficulty)
    {
        WWWForm form = new WWWForm();
        form.AddField("question", question);
        form.AddField("option1", option1);
        form.AddField("option2", option2);
        form.AddField("option3", option3);
        form.AddField("answer", answer);
        form.AddField("difficulty", int.Parse(difficulty));
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/addQues.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string error = www.downloadHandler.text;
            //PlayerPrefs.SetString("Name", user);
            //_gameData.user = user;
            UnityEngine.Debug.Log(error);
            UnityEngine.Debug.Log("Question Added!");
            script2.reloadQues();
            msgBox.SetActive(true);
            //SceneManager.LoadScene("EditQuestionsPage");         
        }
    }

    IEnumerator updateQues(string question, string option1, string option2, string option3, string answer, string difficulty, int qid)
    {
        WWWForm form = new WWWForm();
        form.AddField("question", question);
        form.AddField("option1", option1);
        form.AddField("option2", option2);
        form.AddField("option3", option3);
        form.AddField("answer", answer);
        form.AddField("difficulty", int.Parse(difficulty));
        form.AddField("QID", qid);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/updateQues.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string error = www.downloadHandler.text;
            //PlayerPrefs.SetString("Name", user);
            //_gameData.user = user;
            UnityEngine.Debug.Log(error);
            UnityEngine.Debug.Log("Question Updated!");
            script2.reloadQues();
            //SceneManager.LoadScene("EditQuestionsPage");
            msgBox.SetActive(true);
        }
    }

    IEnumerator deleteQues(int qid)
    {
        WWWForm form = new WWWForm();
        form.AddField("QID", qid);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/delQues.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string error = www.downloadHandler.text;
            //PlayerPrefs.SetString("Name", user);
            //_gameData.user = user;
            UnityEngine.Debug.Log(error);
            UnityEngine.Debug.Log("Question Deleted!");
            script2.reloadQues();
            //SceneManager.LoadScene("EditQuestionsPage");
            msgBox3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
