using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text scoreTxt;
    private static int points;
    public Text damageTxt;
    public Text speedTxt;
    public GameObject player;

    private void Awake()
    {
        points = 0;
    }

    private void FixedUpdate()
    {
        scoreTxt.text = points.ToString();
        damageTxt.text = ((int)(player.GetComponent<PlayerBehavior>().get_strength_damage())).ToString();
        speedTxt.text = ((int)(player.GetComponent<PlayerBehavior>().get_agility_attack_speed())).ToString();
    }

    public static void addPoint()
    {
        points += 10;
    }


}
