using System.Collections;
using System.Collections.Generic;

public class GameData
{
    #region Singleton Framework

    private static GameData _instance = null;

    private GameData()
    {
        // Initialising questions with 3 different difficulties
        // 1 list for 1 difficulty
        // Eg. questions[0] == difficulty 1
        questions.Add(new List<QuestionSet>());
        questions.Add(new List<QuestionSet>());
        questions.Add(new List<QuestionSet>());
    }

    public static GameData getInstance
    {
        get
        {
            if (_instance == null)
                _instance = new GameData();

            return _instance;
        }
    }

    #endregion

    #region Game Data Variables
    public bool admin = false;
    public string user =                "";
    public int rank = -1;

    public string currWorld = "";
    public string currSect = "";

    public int world_selected =         -1;
    public int stage_selected =         -1;

    public int room_current =           -1;
    public int floor_current =          -1;
    public int score_current =          -1;
    public int high_score =             -1;

    public int boss_floor =             4;
    public int enemy_health_current =   10;
    public int enemy_attack =           -1;
    public int minion_health_max =      10;
    public int boss_health_max =        20;
    


    public int player_health_max =      -1;
    public int player_health_current =  -1;
    public int player_attack = -1;
    public string player_class_name =   "-";
    public string player_description =  "-";

    public int questions_correct = 0;
    public int questions_wrong = 0;
    public int total_questions = 0;

    #region Not Used

    public List<List<string>> options_difficulty_1 = new List<List<string>>();
    public List<List<string>> options_difficulty_2 = new List<List<string>>();
    public List<List<string>> options_difficulty_3 = new List<List<string>>();

    public List<List<List<string>>> options_storage = new List<List<List<string>>>();

    public List<string> questions_difficulty_1 = new List<string>();
    public List<string> questions_difficulty_2 = new List<string>();
    public List<string> questions_difficulty_3 = new List<string>();

    public List<List<string>> questions_storage = new List<List<string>>();

    public ArrayList answers_difficulty_1 = new ArrayList();
    public ArrayList answers_difficulty_2 = new ArrayList();
    public ArrayList answers_difficulty_3 = new ArrayList();

    public List<ArrayList> answers_storage = new List<ArrayList>();

    #endregion

    //public ArrayList answers = new ArrayList();
    //public ArrayList difficulty = new ArrayList();

    public List<List<QuestionSet>> questions = new List<List<QuestionSet>>();
    public List<string> score = new List<string>();
    public List<string> report = new List<string>();

    public QuestionSet currEditQues = new QuestionSet();

    public List<string> worldLocked= new List<string>();
    public List<string> sectionLocked = new List<string>();

    public int currQID = -1;
    public int currI = -1;
    public int currJ = -1;

    public int difficulty = -1;
    public int streak = -1;

    #endregion


}
