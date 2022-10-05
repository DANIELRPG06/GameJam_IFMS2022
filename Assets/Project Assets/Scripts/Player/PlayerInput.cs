using UnityEngine;

[RequireComponent(typeof(TopDownCharacterMotor))]
public class PlayerInput : MonoBehaviour
{
    public Animator anim;

    private TopDownCharacterMotor motor;
    private GameManager gameManager;

    private void Start()
    {
        motor = GetComponent<TopDownCharacterMotor>();
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }

    //update
    private void Update()
    {
        if (gameManager.isMapOpen)
        {
            return;
        }
        //movimento
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direcao = new Vector2(horizontal, vertical);
        this.motor.SetMove(direcao);

        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("taAndando", true);
        }
        else
        {
            anim.SetBool("taAndando", false);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("taAndando", true);
        }
        else
        {
            anim.SetBool("taAndando", false);
        }

        

        // olha pro cursor
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );
        this.motor.SetLook(direction);

        if (Input.GetButtonDown("Sprint"))
        {
            this.motor.SetRunning(true);
            anim.SetBool("taCorrendo", true);
        }
        if (Input.GetButtonUp("Sprint"))
        {
            this.motor.SetRunning(false);
            anim.SetBool("taCorrendo", false);
        }
    }

}