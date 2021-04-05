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
   public LoadCMQuestions LoadCMQuestions;

    public List<QuestionSet> CMQuestionSet = new List<QuestionSet>();
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
    public float currentTime = 0f;
    public float startingTime = 15f;

    public int score = 0;
    public int questionNum = 0;

    public int player2score = 0;
    public int player2questionNum = 0;

    public int player1score =0;
    public int player1questionNum =0;



    // Start is called before the first frame update
    void Start()
    {

        startCanvas.enabled = true;
        startCanvasP2.enabled = false;
        gameplayCanvas.enabled = false;
        gameEndCanvas.enabled = false;
        startButton.onClick.AddListener(gameplayCanvasEnable);
        startButtonP2.onClick.AddListener(gameplayCanvasEnable);
        CMQuestionSet = LoadCMQuestions.GetQuestionBank();

        
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

        gameplayCanvas.enabled = false;

        this.player2score = CMQuizController.getScore();
        this.player2questionNum = CMQuizController.getQuestionNum();

        int baseTotalQuestion;

        if(player1questionNum>=player2questionNum){
            baseTotalQuestion = player1questionNum;
        }
        else{
            baseTotalQuestion = player2questionNum;
        }

        int player1accuracy = accuracyCalculator(player1score,baseTotalQuestion);
        int player2accuracy = accuracyCalculator(player2score,baseTotalQuestion);

        if(player1accuracy<0){
           scoreText.text = string.Format("P1 Accuracy: 0%"); 
        }
        if(player2accuracy<0){
            scoreTextPlayer2.text = string.Format("P2 Accuracy: 0%");
        }
        else{
            scoreText.text = string.Format("P1 Accuracy: " + player1accuracy + "%");
            scoreTextPlayer2.text = string.Format("P2 Accuracy: " + player2accuracy + "%");
        }


        if(player1accuracy == player2accuracy){
            winnerName.text = "GAME DRAW!";
        }
        else if(player1accuracy < player2accuracy){
            winnerName.text = "Player 2 WINS!";
        }
        else {
            winnerName.text = "Player 1 Wins!";
        }

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
        CMQuizController.setScore(0);
        CMQuizController.setQuestionNum(0);
    }

    public int accuracyCalculator(int score, int questionnum){

        float fscore = (float)score;
        float fquestionnum = (float)questionnum;

        
        int accuracy = (int)Math.Round((double)(100 * fscore) / fquestionnum);

        return accuracy;
    }
}


