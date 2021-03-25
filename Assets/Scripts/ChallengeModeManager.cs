using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;

public class ChallengeModeManager : MonoBehaviour

{
   public CMQuizController CMQuizController;

    public Canvas startCanvas = null;
    public Canvas gameplayCanvas = null;
    public Canvas gameEndCanvas = null;
    public Button startButton = null;

     public ToggleGroup difficultySetting;
     public Toggle difficulty1;
     public Toggle difficulty2;
     public Toggle difficulty3;
    

    public Button playAgainButton = null;

    public Text scoreText = null;

    public Text timertext = null;
    float currentTime = 0f;
    float startingTime = 15f;

    public int score = 0;
    public int questionNum = 0;

    public int player2score = 0;
    public int player2questionNum = 0;



    // Start is called before the first frame update
    void Start()
    {

        startCanvas.enabled = true;
        gameplayCanvas.enabled = false;
        gameEndCanvas.enabled = false;
        startButton.onClick.AddListener(gameplayCanvasEnable);
        // Option1Button.onClick.AddListener(delegate{CMQuizController.CheckAnswer("a");});
        // Option2Button.onClick.AddListener(delegate{CMQuizController.CheckAnswer("b");});
        // Option3Button.onClick.AddListener(delegate{CMQuizController.CheckAnswer("c");});


        //Timer Settings
        // for future difficulty settings
        //this.currentTime = 0f; 
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

        if(currentTime == 0){
            gameplayCanvas.enabled = false;
            gameEndCanvas.enabled = true;
            gameEndCanvasEnable();
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

    void gameEndCanvasEnable(){
        //Debug.Log(CMQuizController.getScore());
        this.score = CMQuizController.getScore();
        this.questionNum = CMQuizController.getQuestionNum();
        scoreText.text = string.Format("Score: {0}/{1}", this.score, this.questionNum);


    }

    void playAgain(){
        SceneManager.LoadScene("ChallengeMode");
    }

    public void timeDifficulty(){
    if(difficulty1.isOn == true){
        this.startingTime = 15f;
    }
    else if(difficulty2.isOn == true){
        this.startingTime = 30f;
    }
    else if(difficulty3.isOn == true){
        this.startingTime = 60f;
    }
    currentTime = startingTime;
    Debug.Log(startingTime);
}

    void playertwoEnable(){

    }

}


