using UnityEngine;

[RequireComponent(typeof(Animator), typeof(TopDownCharacterMotor))]
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
        anim.SetBool("taAndando", motor.moveDirection.magnitude > 0);
        anim.SetBool("taCorrendo", motor.isRunning);
    }
}
