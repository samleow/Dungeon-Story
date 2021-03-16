using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventsController : MonoBehaviour
{
    public GameObject warriorPartical = null;
    public GameObject magePartical = null;
    public GameObject rangerPartical = null;

    public void activateWarrior()
    {
        warriorPartical.SetActive(true);
        magePartical.SetActive(false);
        rangerPartical.SetActive(false);
    }

    public void activateMage()
    {
        warriorPartical.SetActive(false);
        magePartical.SetActive(true);
        rangerPartical.SetActive(false);
    }

    public void activateRanger()
    {
        warriorPartical.SetActive(false);
        magePartical.SetActive(false);
        rangerPartical.SetActive(true);
    }

    // Load Scene
    public void LoadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    // Exit application
    public void ExitApplication()
    {
        Application.Quit();
    }

    // Select world
    public void SelectWorld(int world)
    {
        GameData.getInstance.world_selected = world;
    }

    // Select stage
    public void SelectStage(int stage)
    {
        GameData.getInstance.stage_selected = stage;
    }

    // Select Character
    public void SelectCharacter(Character character)
    {
        GameData gd = GameData.getInstance;
        gd.player_health_max = character.health_max;
        gd.player_health_current = character.health_current;
        gd.player_attack = character.attack;
        gd.player_class_name = character.class_name;
        gd.player_description = character.description;

        gd.floor_current = 1;
        gd.score_current = 0;
    }

    // Select door
    public void SelectDoor(int door)
    {
        GameData.getInstance.room_current = door;
    }
}
