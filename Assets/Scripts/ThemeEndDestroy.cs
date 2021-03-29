using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeEndDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject A = GameObject.FindGameObjectWithTag("endtheme");
        Destroy(A);
    }
}
