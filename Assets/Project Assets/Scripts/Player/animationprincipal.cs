using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationprincipal : MonoBehaviour
{
    public Animator anim;
    private TopDownCharacterMotor motor;
    void Start()
    {
        anim = GetComponent<Animator>();
        motor = GetComponent<TopDownCharacterMotor>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(motor.moveDirection.magnitude > 0)
        {
            anim.SetBool("taAndando", true);
        }
        else
        {
            anim.SetBool("taAndando", false);
        }
        
        if(motor.isRunning)
        {
            anim.SetBool("taCorrendo", true);
        }
        else
        {
            anim.SetBool("taCorrendo", false);
        }
    }
}
