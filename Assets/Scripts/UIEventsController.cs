using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEventsController : MonoBehaviour
{
    public GameObject warriorPartical = null;
    public GameObject magePartical = null;
    public GameObject barbarianPartical = null;

    public GameObject descriptionCanvas = null;
    public Text characterName = null;
    public Text attack = null;
    public Text health = null;

    /*public void activateWarrior()
    {
        warriorPartical.SetActive(true);
        magePartical.SetActive(false);
        barbarianPartical.SetActive(false);
    }

    public void activateMage()
    {
        warriorPartical.SetActive(false);
        magePartical.SetActive(true);
        barbarianPartical.SetActive(false);
    }

    public void activateRanger()
    {
        warriorPartical.SetActive(false);
        magePartical.SetActive(false);
        barbarianPartical.SetActive(true);
    }*/

    public void activateCharacter(Character character)
    {
        characterName.text = character.class_name;
        attack.text = character.attack.ToString();
        health.text = character.health_max.ToString();
        descriptionCanvas.SetActive(true);

        if (character.class_name.Equals("Warrior"))
        {
            warriorPartical.SetActive(true);
            magePartical.SetActive(false);
            barbarianPartical.SetActive(false);
        }
        else if (character.class_name.Equals("Mage"))
        {
            warriorPartical.SetActive(false);
            magePartical.SetActive(true);
            barbarianPartical.SetActive(false);
        }
        else if (character.class_name.Equals("Barbarian"))
        {
            warriorPartical.SetActive(false);
            magePartical.SetActive(false);
            barbarianPartical.SetActive(true);
        }
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

        descriptionCanvas.SetActive(false);
    }

    // Select door
    public void SelectDoor(int door)
    {
        GameData.getInstance.room_current = door;
    }
}
