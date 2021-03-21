using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChallengeModeManager : MonoBehaviour

{
   public CMQuizController CMQuizController;

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
        CMQuizController.generateQuestion();

    }


}


