﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeBattleDontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("battletheme");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

}