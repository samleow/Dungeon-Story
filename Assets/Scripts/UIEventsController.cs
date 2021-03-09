using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventsController : MonoBehaviour
{
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
        GameData.getInstance.player_char = character;
    }

    // Select door
    public void SelectDoor(int door)
    {
        GameData.getInstance.room_current = door;
    }
}
