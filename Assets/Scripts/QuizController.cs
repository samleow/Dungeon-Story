using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public QuestionSet questionSet = null;
    public Text questionText = null;
    public Text option1 = null;
    public Text option2 = null;
    public Text option3 = null;
    public Text option4 = null;
    public Text timer = null;

    private int selected_ans = -1;
    private float normTime = 0f;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (questionSet == null)
        {
            Debug.Log("Quiz Controller does not have question set! Check Combat Controller!");
        }
        else
        {
            // Set the questions and options in UI
            SetUI();
            // Set normalized time back to 0
            normTime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO

        // if time ran out, send fail to combat controller
        if (TimeRanOut())
        {
            // fail
            Debug.Log("Time's up!");
        }
    }

    void SetUI()
    {
        questionText.text = questionSet.question;
        option1.text = questionSet.options[0];
        option2.text = questionSet.options[1];
        option3.text = questionSet.options[2];
        option4.text = questionSet.options[3];

        timer.text = questionSet.time_to_answer.ToString("0.00");
    }

    // possible to change into coroutine
    bool TimeRanOut()
    {
        normTime += Time.deltaTime;

        timer.text = (questionSet.time_to_answer - normTime).ToString("0.00");

        if (normTime >= questionSet.time_to_answer)
        {
            timer.text = "0.00";
            return true;
        }
        return false;
    }

    #region UI functions

    // for option buttons
    public void SelectedOption(int option)
    {
        selected_ans = option;
    }

    public void PressedConfirm()
    {
        // TODO

        // if answer correctly before time ran out, send pass to combat controller
        if (selected_ans == questionSet.answer)
        {
            // pass
            Debug.Log("Pass!");
            return;
        }

        // if answer wrongly, send fail to combat controller
        if (selected_ans != -1)
        {
            // fail
            Debug.Log("Fail!");
            return;
        }

        // if no option selected
        Debug.Log("No option selected!");
    }

    #endregion

}
