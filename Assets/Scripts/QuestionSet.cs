using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSet
{
    public string question = "";
    public List<string> options = new List<string>();
    public string answer = "";
    public int difficulty = -1;
    // in seconds
    //public int time_to_answer = -1;

    public QuestionSet() { }
}
