using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Sprite_Manager : MonoBehaviour {

    public SpriteRenderer As;
    public SpriteRenderer Ac;
    public SpriteRenderer Sc;
    public SpriteRenderer Sa;
    public SpriteRenderer Ca;
    public SpriteRenderer Cs;

    private SpriteRenderer sprt;
    private ZombieBehavior zb;

    public Sprite getSprite()
    {
        return sprt.sprite;
    }

    // Use this for initialization
    void Start () {
        sprt = this.GetComponent<SpriteRenderer>();
        zb = this.transform.parent.GetComponent<ZombieBehavior>();
        sprt.sprite = As.sprite;
	}
	

	void FixedUpdate () {
        float a = zb.getAgility();
        float s = zb.getStrength();
        float c = zb.getCunning();
        if (a > c & a > s & s > c)
        {
            sprt.sprite = As.sprite;
        }
        else if (a > c & a > s & c > s)
        {
            sprt.sprite = Ac.sprite;
        }
        else if (s > a & s > c & c > a)
        {
            sprt.sprite = Sc.sprite;
        }
        else if (s > a & s > c & a > c)
        {
            sprt.sprite = Sa.sprite;
        }
        else if (c > a & c > s & a > s)
        {
            sprt.sprite = Ca.sprite;
        }
        else if (c > a & c > s & s > a)
        {
            sprt.sprite = Cs.sprite;
        }

    }
}
