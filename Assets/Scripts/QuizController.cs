using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class QuizController : MonoBehaviour
{
    public QuestionSet questionSet = null;
    public Text questionText = null;
    public Text option1 = null;
    public Text option2 = null;
    public Text option3 = null;
    //public Text option4 = null;
    public Text timer = null;
    public GameObject timer_obj = null;
    public CombatController combatController = null;

    //private int _selected_ans = -1;
    private float _normTime = 0f;
    private bool _quiz_started = false;

    // time for each boss question (in seconds)
    private float _qnTime = 20f;

    void OnEnable()
    {
        _quiz_started = true;
        Debug.Log("Quiz Started!");
        if (questionSet == null)
        {
            Debug.Log("Quiz Controller does not have question set! Check Combat Controller!");
        }
        else
        {
            // Set the questions and options in UI
            SetUI();
            // Set normalized time back to 0
            _normTime = 0f;
            // Set selected ans back
            //_selected_ans = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if enemy is Boss
        if (combatController.isBoss)
        {
            // if time ran out, send fail to combat controller
            if (TimeRanOut() && _quiz_started)
            {
                // fail
                Debug.Log("Time's up!");
                combatController.quiz_status = 0;
                _quiz_started = false;
            }
        }
    }

    void SetUI()
    {
        questionText.text = questionSet.question;
        option1.text = questionSet.options[0];
        option2.text = questionSet.options[1];
        option3.text = questionSet.options[2];
        //option4.text = questionSet.options[3];

        if (combatController.isBoss)
            timer_obj.SetActive(false);
        else
        {
            timer_obj.SetActive(false);
            timer.text = _qnTime.ToString("0.00");
        }
    }

    // possible to change into coroutine
    bool TimeRanOut()
    {
        _normTime += Time.deltaTime;

        timer.text = (_qnTime - _normTime).ToString("0.00");

        if (_normTime >= _qnTime)
        {
            timer.text = "0.00";
            return true;
        }
        return false;
    }

    #region UI functions

    // for option buttons
    public void SelectedOption(string option)
    {
        // TODO

        // can do feedback/animation for pass/fail/no option etc. before closing

        // if answer correctly before time ran out, send pass to combat controller
        if (option == questionSet.answer)
        {
            // pass
            Debug.Log("Pass!");
            StartCoroutine(updateReport("correct", questionSet.QID));
            combatController.quiz_status = 1;
            return;
        }
        // if answer wrongly, send fail to combat controller
        else
        {
            // fail
            Debug.Log("Fail!");
            StartCoroutine(updateReport("wrong", questionSet.QID));
            combatController.quiz_status = 0;
            return;
        }
    }

    IEnumerator updateReport(string correct_Or_Wrong, int QID)
    {
        WWWForm form = new WWWForm();
        form.AddField("answer", correct_Or_Wrong);
        form.AddField("QID", QID);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/updateReport.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
    /*public void PressedConfirm()
    {
        // TODO

        // can do feedback/animation for pass/fail/no option etc. before closing

        // if answer correctly before time ran out, send pass to combat controller
        if (_selected_ans == questionSet.answer)
        {
            // pass
            Debug.Log("Pass!");

            combatController.quiz_status = 1;
            return;
        }

        // if answer wrongly, send fail to combat controller
        if (_selected_ans != -1)
        {
            // fail
            Debug.Log("Fail!");

            combatController.quiz_status = 0;
            return;
        }

        // if no option selected
        Debug.Log("No option selected!");
    }*/

    #endregion

}
