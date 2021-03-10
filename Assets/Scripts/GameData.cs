

public class GameData
{
    #region Singleton Framework

    private static GameData _instance = null;

    private GameData() {  }

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

    public int world_selected =         -1;
    public int stage_selected =         -1;

    public int room_current =           -1;
    public int floor_current =          -1;
    public int score_current =          -1;

    public int boss_floor =             4;
    public int enemy_health_current =   10;
    public int minion_health_max =      10;
    public int boss_health_max =        20;

    public int player_health_max =      -1;
    public int player_health_current =  -1;
    public int player_attack = -1;
    public string player_class_name =   "-";
    public string player_description =  "-";

    #endregion


}
