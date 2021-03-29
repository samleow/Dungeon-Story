using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeBattleDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject A = GameObject.FindGameObjectWithTag("battletheme");
        Destroy(A);
    }
}
