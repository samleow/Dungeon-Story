using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using UnityEngine.EventSystems;
using UnityEditor;

public class checkWorldLock : MonoBehaviour
{
    Text text1, text2, text3;
    Button btn1, btn2,btn3,unlock1,unlock2;
    Color newColor = Color.gray;
    GameData _gameData = GameData.getInstance;
    public GameObject msgBox;
    //public Button unlockBtn2;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("TitlePage") || SceneManager.GetActiveScene().name.Equals("AdminPage"))
        {
            StartCoroutine(checkWorldLocked());
        }

        if (SceneManager.GetActiveScene().name.Equals("WorldPage"))
        {
            unlock1 = GameObject.Find("unlock").GetComponent<Button>();
            unlock1.gameObject.SetActive(false);
            text1 = GameObject.Find("world1Text").GetComponent<Text>();
            text2 = GameObject.Find("world2Text").GetComponent<Text>();
            btn1 = GameObject.Find("World1").GetComponent<Button>();
            btn2 = GameObject.Find("World2").GetComponent<Button>();
            displayWorlds();
        }

        if (SceneManager.GetActiveScene().name.Equals("SectionPage"))
        {
            unlock1 = GameObject.Find("unlock1").GetComponent<Button>();
            unlock2= GameObject.Find("unlock2").GetComponent<Button>();
            unlock1.gameObject.SetActive(false);
            unlock2.gameObject.SetActive(false);
            text1 = GameObject.Find("section1").GetComponent<Text>();
            text2 = GameObject.Find("section2").GetComponent<Text>();
            text3 = GameObject.Find("section3").GetComponent<Text>();
            btn1 = GameObject.Find("Section 1 Button").GetComponent<Button>();
            btn2 = GameObject.Find("Section 2 Button").GetComponent<Button>();
            btn3 = GameObject.Find("Section 3 Button").GetComponent<Button>();
            displaySections();
        }
    }

    public void checkSections()
    {
        if (EventSystem.current.currentSelectedGameObject.name.Equals("World1"))
        {
            _gameData.currWorld = text1.text;
        }
        else if (EventSystem.current.currentSelectedGameObject.name.Equals("World2"))
        {
            _gameData.currWorld = text2.text;
        }

        StartCoroutine(checkSectionsLocked(0.5f,changeScene));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator checkWorldLocked()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://valerianlow123.000webhostapp.com/lockWorld.php");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            _gameData.worldLocked = www.downloadHandler.text.Split(',', '\n').ToList();
        }
    }

    IEnumerator checkSectionsLocked(float time, Action doAction)
    {
        WWWForm form = new WWWForm();
        form.AddField("currWorld", _gameData.currWorld);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/lockSections.php",form);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            UnityEngine.Debug.Log(www.downloadHandler.text);
            _gameData.sectionLocked = www.downloadHandler.text.Split(',', '\n').ToList();
            doAction();
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene("SectionPage");
    }

    void displayWorlds()
    {
        ColorBlock cb = btn2.colors;
        cb.disabledColor = newColor;

        text1.text = _gameData.worldLocked[0];

        if (_gameData.worldLocked[3].Equals("true"))
        {
            
            text2.text = "LOCKED";
            //btn2.name = "LOCKED";
            btn2.interactable = false;
            btn2.colors = cb;
        }
        else
        {
            text2.text = _gameData.worldLocked[2];
            //btn2.name = _gameData.worldLocked[2];
        }
        if (_gameData.admin == true && text2.text.Equals("LOCKED"))
        {
            unlock1.gameObject.SetActive(true);
        }
    }

    void displaySections()
    {
        ColorBlock cb = btn2.colors;
        cb.disabledColor = newColor;

        text1.text = _gameData.sectionLocked[1];
        if (_gameData.sectionLocked[5].Equals("true"))
        {
            text2.text = "LOCKED";
            btn2.interactable = false;
            btn2.colors = cb;
        }
        else
        {
            text2.text = _gameData.sectionLocked[4];
        }
        if (_gameData.sectionLocked[8].Equals("true"))
        {
            text3.text = "LOCKED";
            btn3.interactable = false;
            btn3.colors = cb;
        }
        else
        {
            text3.text = _gameData.sectionLocked[7];
        }
        if (_gameData.admin == true)
        {
            if (text2.text.Equals("LOCKED"))
            {
                unlock1.gameObject.SetActive(true);
            }
            if (text3.text.Equals("LOCKED"))
            {
                unlock2.gameObject.SetActive(true);
            }
        }
       
    }

    public void unlockWorld()
    {
        if (EventSystem.current.currentSelectedGameObject.name.Equals("unlock"))
        {
            _gameData.currWorld = _gameData.worldLocked[2];
            StartCoroutine(unlockWorld(0.5f, reloadScene));
        }
    }

    IEnumerator unlockWorld(float time, Action doAction)
    {
        WWWForm form = new WWWForm();
        form.AddField("currWorld", _gameData.currWorld);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/unlockWorld.php", form);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            UnityEngine.Debug.Log(www.downloadHandler.text);
            doAction();
        }
    }

    public void unlockSection()
    {
        if (EventSystem.current.currentSelectedGameObject.name.Equals("unlock1"))
        {
            _gameData.currSect = _gameData.sectionLocked[4];
            StartCoroutine(unlockSection(0.5f, reloadScene));
        }
        else if (EventSystem.current.currentSelectedGameObject.name.Equals("unlock2"))
        {
            _gameData.currSect = _gameData.sectionLocked[7];
            StartCoroutine(unlockSection(0.5f, reloadScene));
        }
    }

    IEnumerator unlockSection(float time, Action doAction)
    {
        WWWForm form = new WWWForm();
        form.AddField("currWorld", _gameData.currWorld);
        form.AddField("currSect", _gameData.currSect);
        UnityWebRequest www = UnityWebRequest.Post("http://valerianlow123.000webhostapp.com/unlockSection.php", form);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            UnityEngine.Debug.Log(www.downloadHandler.text);
            doAction();
        }
    }

    void reloadScene()
    {
        msgBox.SetActive(true);
    }
}
