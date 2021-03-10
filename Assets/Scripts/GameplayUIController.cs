using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public Text player_health = null;
    public Text player_attack = null;
    public Text enemy_health = null;
    public Text floor = null;

    public GameObject buffCanvas = null;
    public Text buff = null;

    GameData _gameData = null;

    // Start is called before the first frame update
    void Start()
    {
        _gameData = GameData.getInstance;

        if (buffCanvas!=null)
            buffCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player_health.text = _gameData.player_health_current.ToString();
        player_attack.text = _gameData.player_attack.ToString();

        if(enemy_health != null)
            enemy_health.text = _gameData.enemy_health_current.ToString();
        if (floor != null)
            floor.text = _gameData.floor_current.ToString();
    }

    public void SelectAttackBuff()
    {
        buff.text = "Attack + 1";
        _gameData.player_attack++;
        _gameData.floor_current++;
        buffCanvas.SetActive(true);
        StartCoroutine(SetBuffScreen(false,1));
    }

    public void SelectHeal()
    {
        buff.text = "Health + 1";
        _gameData.player_health_current++;
        _gameData.player_health_max++;
        _gameData.floor_current++;
        buffCanvas.SetActive(true);
        StartCoroutine(SetBuffScreen(false, 1));
    }

    public void SelectCombat()
    {
        SceneManager.LoadScene("BattlePage");
    }

    // TODO implement fade in/out for buff pop up
    IEnumerator SetBuffScreen(bool active, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (buffCanvas)
            buffCanvas.SetActive(active);
    }
}
