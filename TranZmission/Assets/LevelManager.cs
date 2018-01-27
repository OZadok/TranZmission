using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text scoreTxt;
    private static int points;

    private void Awake()
    {
        points = 0;
    }

    private void FixedUpdate()
    {
        scoreTxt.text = points.ToString();
    }

    public static void addPoint()
    {
        points++;
    }
}
