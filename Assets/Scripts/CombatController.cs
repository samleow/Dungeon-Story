using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;

public class CombatController : MonoBehaviour
{
    // List of questions and answer options
    //public List<QuestionSet> questions = new List<QuestionSet>();
    //int _question_current = -1;
    public GameObject QuestionMenu = null;
    [HideInInspector]
    // -1   = still doing quiz
    // 0    = fail
    // 1    = pass
    public int quiz_status = -1;
    [HideInInspector]
    public bool isBoss = false;
    public Image enemyImg = null;
    public Sprite enemyMiniBossImg = null;
    public Sprite enemyBossImg = null;
    public Image playerImg = null;

    public Sprite warriorImg = null;
    public Sprite mageImg = null;
    public Sprite rangerImg = null;

    public preloadLeaderboard test;

    GameData _gameData = null;

    public HealthBar enemy_HealthBar = null;

    // Start is called before the first frame update
    void Start()
    {
        _gameData = GameData.getInstance;
        test = GameObject.Find("script").GetComponent<preloadLeaderboard>();
        

        if(QuestionMenu.activeSelf)
            QuestionMenu.SetActive(false);

        if (_gameData.difficulty == -1)
            _gameData.difficulty = 1;
        if (_gameData.streak == -1)
            _gameData.streak = 0;
        if (_gameData.score_current == -1)
            _gameData.score_current = 0;

        // Extract questions and answer options from question bank and store into list
        //AddQuestions();

            // set enemy health based on current floor number
            // if mini-boss
        if (_gameData.floor_current < _gameData.boss_floor)
        {
            isBoss = false;
            _gameData.enemy_health_current = _gameData.minion_health_max;
            _gameData.enemy_attack = 1;
            enemy_HealthBar.SetMaxHealth(_gameData.minion_health_max);
            enemyImg.sprite = enemyMiniBossImg;
        }
        // if boss
        else
        {
            isBoss = true;
            _gameData.enemy_attack = 2;
            _gameData.enemy_health_current = _gameData.boss_health_max;
            enemy_HealthBar.SetMaxHealth(_gameData.boss_health_max);
            enemyImg.sprite = enemyBossImg;
        }
        
        if(_gameData.player_class_name == "Warrior")
        {
            playerImg.sprite = warriorImg;
        }
        else if(_gameData.player_class_name == "Mage")
        {
            playerImg.sprite = mageImg;
        }
        else
        {
            playerImg.sprite = rangerImg;
        }

        // set question number/counter
        //_question_current = 0;
        // set question set into quiz controller
        //QuestionMenu.GetComponent<QuizController>().questionSet = questions[_question_current];

        GetNewQn();

        // set qn screen on
        // can do fade in or animations before transition
        StartCoroutine(SetQnScreen(true,1));
    }

    // Update is called once per frame
    void Update()
    {

        switch (quiz_status)
        {
            // fail
            case 0:
                // deactivate quiz screen
                StartCoroutine(SetQnScreen(false, 0));

                // difficulty progression
                _gameData.streak--;
                _gameData.questions_wrong++;
                _gameData.total_questions++;
                if (_gameData.streak <= -2 && _gameData.difficulty > 1)
                {
                    _gameData.streak = 0;
                    _gameData.difficulty--;
                }

                // animate fail
                // take damage
                
                //_gameData.player_health_current -= 1;
                if(_gameData.player_health_current != 0)// to prevent negative health
                {
                    _gameData.player_health_current = _gameData.player_health_current - _gameData.enemy_attack;
                }
                
                

                // if player dies, game over
                if (_gameData.player_health_current <= 0)
                {
                    Debug.Log("Game Over! You lose!");

                    PlayerPrefs.SetString("Score", _gameData.score_current.ToString());
                    StartCoroutine(UpdateLeaderboard());
                    
                    // transition to player gameplay stats screen
                    // upload highscore etc
                    //SceneManager.LoadScene("GameOverPage");
                    StartCoroutine(PauseWhile(0.5f));

                    break;
                }

                quiz_status = -1;
                //_question_current = (_question_current+1)%questions.Count;
                // set question set into quiz controller
                //QuestionMenu.GetComponent<QuizController>().questionSet = questions[_question_current];

                GetNewQn();

                // reactivate quiz screen, start next qn
                StartCoroutine(SetQnScreen(true, 1));

                break;

            // pass
            case 1:
                // deactivate quiz screen
                StartCoroutine(SetQnScreen(false, 0));
                _gameData.questions_correct++;
                _gameData.total_questions++;
                // difficulty progression
                _gameData.streak++;
                if (_gameData.streak > 2 && _gameData.difficulty < 3)
                {
                    _gameData.difficulty++;
                    _gameData.streak = 0;
                }

                // TODO Scoring
                _gameData.score_current += _gameData.difficulty*_gameData.streak;

                // animate pass
                // deal damage
                _gameData.enemy_health_current -= _gameData.player_attack;

                // if enemy dies, battle over
                if (_gameData.enemy_health_current <= 0)
                {
                    _gameData.enemy_health_current = 0;
                    Debug.Log("Battle Over! You win!");

                    // Game over, player wins
                    // transition to player gameplay stats screen and upload highscore etc
                    if (_gameData.floor_current >= _gameData.boss_floor)
                    {
                        Debug.Log("Game Over! Victory!");
                        PlayerPrefs.SetString("Score", _gameData.score_current.ToString());
                        StartCoroutine(UpdateLeaderboard());
                        StartCoroutine(PauseVictory(0.5f));
                        //SceneManager.LoadScene("LeaderboardPage");
                    }
                    // transition to next floor
                    else
                    {
                        _gameData.floor_current++;
                        SceneManager.LoadScene("DoorPage");
                    }

                    break;
                }

                quiz_status = -1;
                //_question_current = (_question_current + 1) % questions.Count;
                // set question set into quiz controller
                //QuestionMenu.GetComponent<QuizController>().questionSet = questions[_question_current];

                GetNewQn();

                // reactivate quiz screen, start next qn
                StartCoroutine(SetQnScreen(true, 1));

                break;

            // still doing quiz
            default:
                break;
        }

    }

    // TODO implement fade in/out for question screen
    IEnumerator SetQnScreen(bool active, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (QuestionMenu)
            QuestionMenu.SetActive(active);
    }

    void GetNewQn()
    {
        if (_gameData.questions[_gameData.difficulty - 1].Count <= 0)
        {
            
            Debug.Log("Ran out of available questions!!");                            
            return;
        }

        System.Random rd = new System.Random();
        int rd_no = rd.Next(0, _gameData.questions[_gameData.difficulty - 1].Count - 1);

        QuestionMenu.GetComponent<QuizController>().questionSet = _gameData.questions[_gameData.difficulty - 1][rd_no];
        _gameData.questions[_gameData.difficulty - 1].RemoveAt(rd_no);
    }

    IEnumerator UpdateLeaderboard()
    {
        GameData _gameData = GameData.getInstance;
        string username = _gameData.user;
        int score = _gameData.score_current;

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("score", score);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/updateScore.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            string error = www.downloadHandler.text;
        }
    }

    IEnumerator PauseWhile(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("GameOverPage");
    }

    IEnumerator PauseVictory(float sec)
    {
        yield return new WaitForSeconds(sec);   
        SceneManager.LoadScene("VictoryPage");
    }

    /*void AddQuestions()
    {
        // TODO
        // temporary hardcoded qns as template after getting from qn bank
        // can use for loop to iterate through qns
        QuestionSet q1 = new QuestionSet();
        q1.question = "1 + 1 = ?";
        q1.answer = "b";
        q1.difficulty = 1;
        //q1.time_to_answer = 8;
        q1.options.Add("0");
        q1.options.Add("1");
        q1.options.Add("2");
        q1.options.Add("3");
        questions.Add(q1);
    }*/

}
