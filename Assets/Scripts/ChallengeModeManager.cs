using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChallengeModeManager : MonoBehaviour

{
    public QuestionSet questionSet = null;
    public Text questionText = null;
    public Text option1 = null;
    public Text option2 = null;
    public Text option3 = null;
    //public Text option4 = null;
   // public Text option4 = null;

    public Canvas startCanvas = null;
    public Canvas gameplayCanvas = null;
    public Canvas gameEndCanvas = null;
    public Button startButton = null;



    public Text timertext = null;
    float currentTime = 0f;
    float startingTime = 30f;



    // Start is called before the first frame update
    void Start()
    {

        
        startCanvas.enabled = true;
        gameplayCanvas.enabled = false;
        gameEndCanvas.enabled = false;
        startButton.onClick.AddListener(gameplayCanvasEnable);

        //Timer Settings
        // for future difficulty settings
        // currentTime = 0f; 
        // startingTime = 30f; 
        
        currentTime = startingTime;
        timertext.color = Color.red;

        
    }
    

    //Update is called once per frame
    void Update()
    {
        if(gameplayCanvas.enabled == true){
            timer();
        }

    }

    void timer(){
        currentTime -= 1 * Time.deltaTime;
        timertext.text = currentTime.ToString("0");

        if(currentTime <= 0){
            currentTime = 0;
        }
    }

    void gameplayCanvasEnable(){
        startCanvas.enabled = false;
        gameplayCanvas.enabled = true;

        if (questionSet==null){
                Debug.Log("Quiz Controller does not have question set!");
            }
            else{
                setquestions();
            }   
        
        
    }

    void setquestions(){
        questionText.text = questionSet.question;
        option1.text = questionSet.options[0];
        option2.text = questionSet.options[1];
        option3.text = questionSet.options[2];
    }

    public void SelectedOption(string option)
    {
        // TODO

        // can do feedback/animation for pass/fail/no option etc. before closing

        // if answer correctly before time ran out, send pass to combat controller
        if (option == questionSet.answer)
        {
            // pass
            Debug.Log("Pass!");
            return;
        }
        else
        {
            // fail
            Debug.Log("Fail!");
            return;
        }
    }
}


