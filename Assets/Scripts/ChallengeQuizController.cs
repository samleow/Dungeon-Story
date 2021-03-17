using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChallengeQuizController : MonoBehaviour

{

    public Text questionText = null;
    public Text option1 = null;
    public Text option2 = null;
    public Text option3 = null;
    //public Text option4 = null;
    public Text option4 = null;

    float currentTime = 0f;
    float startingTime = 30f;

    public Text timertext = null;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        
    }

    //Update is called once per frame
    void Update()
    {
        
        timertext.color = Color.red;
        currentTime -= 1 * Time.deltaTime;
        timertext.text = currentTime.ToString("0");

        if(currentTime <= 0){
            currentTime = 0;
        }

    }
}
