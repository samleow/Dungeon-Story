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
    public Text enemy_attack = null;
    public Text floor = null;

    //health bar
    public HealthBar player_HealthBar = null;
    public HealthBar enemy_HealthBar = null;
    private float player_SlowHP = -1;
    private float enemy_SlowHP = -1;
    private float player_slowTime = 0;
    private float enemy_slowTime = 0;

    public GameObject buffCanvas = null;
    public SpriteRenderer buffSprite = null;

    public Sprite buffATK = null;
    public Sprite heal = null;
    public Text buff = null;

    GameData _gameData = null;

    // Start is called before the first frame update
    void Start()
    {
        _gameData = GameData.getInstance;

        // DoorPage will be equal to null
        // BattlePage will NOT equal to null
        if(player_HealthBar!=null)
        {
            player_HealthBar.SetMaxHealth(_gameData.player_health_max);
            player_SlowHP = _gameData.player_health_max;
        }

        if(enemy_HealthBar!=null)
        {
            // minion or boss max health
            enemy_HealthBar.SetMaxHealth(_gameData.enemy_health_current);
            enemy_SlowHP = _gameData.enemy_health_current;
        }



        if (buffCanvas!=null)
            buffCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // DoorPage will be equal to null
        // BattlePage will NOT equal to null
        if(player_HealthBar!=null)
        {
            if(player_SlowHP != _gameData.player_health_current)
            {
                
                player_SlowHP = Mathf.Lerp(player_SlowHP,_gameData.player_health_current, player_slowTime);
                //Debug.Log(player_SlowHP);
                player_HealthBar.SetHealth(player_SlowHP);
                // increase the decimal point for the float for slower HP decrease
                player_slowTime += 0.000000001f + Time.deltaTime;
            }
            else
            {
                // reset time
                player_slowTime = 0;
            }
            
        }

        if(enemy_HealthBar!=null)
        {
            if(enemy_SlowHP != _gameData.enemy_health_current)
            {
                enemy_SlowHP = Mathf.Lerp(enemy_SlowHP,_gameData.enemy_health_current, enemy_slowTime);
                enemy_HealthBar.SetHealth(enemy_SlowHP);
                // increase the decimal point for the float for slower HP decrease
                enemy_slowTime += 0.000000001f + Time.deltaTime;
            }
            else
            {
                // reset time
                enemy_slowTime = 0;
            }
            
        }


        //Debug.Log(_gameData.player_health_current);
        player_health.text = _gameData.player_health_current.ToString();
        player_attack.text = _gameData.player_attack.ToString();

        // DoorPage will be equal to null
        // BattlePage will NOT equal to null
        if(enemy_attack!=null)
        {
            enemy_attack.text = _gameData.enemy_attack.ToString();
        }


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
        //heal.SetActive(false);
        //buffATK.SetActive(true);
        buffSprite.sprite = buffATK;
        buffCanvas.SetActive(true);
        StartCoroutine(SetBuffScreen(false,1));
    }

    public void SelectHeal()
    {
        buff.text = "Health + 1";
        _gameData.player_health_current++;
        _gameData.player_health_max++;
        _gameData.floor_current++;
        //buffATK.SetActive(false);
        //heal.SetActive(true);
        buffCanvas.SetActive(true);
        buffSprite.sprite = heal;
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
