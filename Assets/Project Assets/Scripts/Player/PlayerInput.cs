using UnityEngine;

[RequireComponent(typeof(TopDownCharacterMotor))]
public class PlayerInput : MonoBehaviour
{
    private TopDownCharacterMotor motor;
    private GameManager gameManager;

    private void Start()
    {
        motor = GetComponent<TopDownCharacterMotor>();
        gameManager = FindObjectOfType<GameManager>();

    }

    //update
    private void Update()
    {
        if (gameManager.isMapOpen || gameManager.isGamePaused)
        {
            return;
        }
        //movimento
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direcao = new Vector2(horizontal, vertical);
        this.motor.SetMove(direcao);

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
        }
        if (Input.GetButtonUp("Sprint"))
        {
            this.motor.SetRunning(false);
        }
    }
}