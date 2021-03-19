using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour
{
    GameData _gameData = GameData.getInstance;
    public void onClick()
    {
        if (!_gameData.admin)
        {
            SceneManager.LoadScene("PlayModePage");
        }
        else
        {
            SceneManager.LoadScene("adminPage");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
