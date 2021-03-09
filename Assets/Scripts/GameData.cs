

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

    public int world_selected =     -1;
    public int stage_selected =     -1;

    public int room_current =       -1;
    public int floor_current =      -1;
    public int score_current =      -1;

    public Character player_char =  null;

    #endregion

}
