using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModePopUpScript : MonoBehaviour
{
    // Declare gameobject variable
    public GameObject dungeonPopup;
    public GameObject challengePopup;
    
    // open Dungeon popup Window
    public void openDungeonPopup()
    {
        dungeonPopup.SetActive(true);
    }

    // open challenge popup window
    public void openChallengePopup()
    {
        challengePopup.SetActive(true);
    }
    
    // close dungeon popup window 
    public void closeDungeonPopup()
    {
        dungeonPopup.SetActive(false);
    }

    // close challenge popup window
    public void closeChallengePopup()
    {
        challengePopup.SetActive(false);
    }
   
}
