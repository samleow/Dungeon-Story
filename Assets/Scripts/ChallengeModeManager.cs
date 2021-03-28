using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class ChallengeModeManager : MonoBehaviour

{
   public CMQuizController CMQuizController;

    public Canvas startCanvas = null;
    public Canvas gameplayCanvas = null;
    
    public Canvas startCanvasP2 = null;

    public Canvas gameEndCanvas = null;
    public Button startButton = null;
    public Button startButtonP2 = null;

    public int turn = 1;

    

     public ToggleGroup difficultySetting;
     public Toggle difficulty1;
     public Toggle difficulty2;
     public Toggle difficulty3;
    

    public Button playAgainButton = null;

    public Text scoreText = null;
    public Text scoreTextPlayer2 = null;

    public Text winnerName = null;

    public Text timertext = null;
    float currentTime = 0f;
    float startingTime = 15f;

    int score = 0;
    int questionNum = 0;

    int player2score = 0;
    int player2questionNum = 0;

    int player1score =0;
    int player1questionNum =0;



    // Start is called before the first frame update
    void Start()
    {

        startCanvas.enabled = true;
        startCanvasP2.enabled = false;
        gameplayCanvas.enabled = false;
        gameEndCanvas.enabled = false;
        startButton.onClick.AddListener(gameplayCanvasEnable);
        startButtonP2.onClick.AddListener(gameplayCanvasEnable);
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
            if(turn == 1){
                gameplayCanvas.enabled = false;
                turn = 2;
                startCanvasP2.enabled = true;
                playertwoEnable();
            }
            else if(turn == 2){
                gameEndCanvas.enabled = true;
                gameEndCanvasEnable();
            }
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
        if(turn == 1){
            Debug.Log(turn);
            startCanvas.enabled = false;
        }
        else if(turn == 2){
            Debug.Log(turn);
            startCanvasP2.enabled = false;
        }

        gameplayCanvas.enabled = true;
        CMQuizController.generateQuestion();
    }

    void gameEndCanvasEnable(){
        //Debug.Log(CMQuizController.getScore());
        gameplayCanvas.enabled = false;
       // Debug.Log("Player 2 Score" + player2score);
       // Debug.Log("Player 2 questionnum" + player2questionNum);
        this.player2score = CMQuizController.getScore();
        this.player2questionNum = CMQuizController.getQuestionNum();

        int player1accuracy = accuracyCalculator(player1score,player1questionNum);
        int player2accuracy = accuracyCalculator(player2score,player2questionNum);
       // Debug.Log("P1 accuracy: " + player1accuracy);
       // Debug.Log("p2 accuracy: "+ player2accuracy);

        scoreText.text = string.Format("P1 Accuracy: " + player1accuracy + "%");
        scoreTextPlayer2.text = string.Format("P2 Accuracy: " + player2accuracy + "%");

        if(player1accuracy < player2accuracy){
            winnerName.text = "Player 2 WINS!";
        }
        else {
            winnerName.text = "Player 1 Wins!";
        }

       // Debug.Log(string.Format("PlayerOneScore: {0}/{1}", this.player1score, this.player1questionNum));
       // Debug.Log(string.Format("PlayerTwoScore: {0}/{1}", this.player2score, this.player2questionNum));




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
        this.currentTime = startingTime;
        this.player1score = CMQuizController.getScore();
        this.player1questionNum = CMQuizController.getQuestionNum();
        //Debug.Log("Player 1 Score: " +player1score);
        //Debug.Log("Player 1 questionNum: " + player1questionNum);
        CMQuizController.setScore(0);
        CMQuizController.setQuestionNum(0);
    }

    int accuracyCalculator(int score, int questionnum){

        float fscore = (float)score;
        float fquestionnum = (float)questionnum;

      //  Debug.Log("accuracy calcuator score: " + fscore);
      //  Debug.Log("accuracy calcuator questinonum: " + fquestionnum);
        
        int accuracy = (int)Math.Round((double)(100 * fscore) / fquestionnum);

      //  Debug.Log("Accuracy of: " + accuracy);
        return accuracy;
    }
}


