using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forceBoss : MonoBehaviour
{
    public Button door1, door2;
    GameData _gameData = GameData.getInstance;
    Color newColor = Color.gray;
    ColorBlock cb;
      

    // Start is called before the first frame update
    void Start()
    {
        cb = door1.colors;
        cb.disabledColor = newColor;

    }

    // Update is called once per frame
    void Update()
    {
        if (_gameData.floor_current == 4)
        {
            door1.interactable = false;
            door1.colors = cb;
            door2.interactable = false;
            door2.colors = cb;
        }
    }
}
