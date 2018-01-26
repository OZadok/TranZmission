using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour {

    public SpriteRenderer body;
    public SpriteRenderer gun;

    private float lastBodyDirection = 1;

    private void FixedUpdate()
    {
        float wh = Input.GetAxis("WeaponHorizontal");
        if (lastBodyDirection*wh < 0)
        {
            body.flipX = wh < 0;
            lastBodyDirection = wh;
            gun.flipY = body.flipX;
        }
       
    }
}
