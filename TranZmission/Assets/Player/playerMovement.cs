using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public Animator m_Animator;
    public SpriteRenderer sr;


    void Update()
    {
        movement();

    }

    private void movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 | v != 0)
        {
            float direction = Mathf.Atan2(v, h);
            float dx = Mathf.Cos(direction) / 10;
            float dy = Mathf.Sin(direction) / 10;
            this.transform.position = this.transform.position + new Vector3(dx, 0, dy);

            /**
             * m_Animator = player.GetComponent<Animator>();
             * m_Animator.GetBool("die") && progress > 0)
                m_Animator.SetBool("die", false);*/
            m_Animator.SetBool("Walk", true);
            m_Animator.SetFloat("Walk_Direction", sr.flipX? -h : h);
        }
        else
        {
            m_Animator.SetBool("Walk", false);
        }


    }
}
