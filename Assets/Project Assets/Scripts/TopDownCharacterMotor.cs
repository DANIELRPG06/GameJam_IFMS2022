using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownCharacterMotor : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private float velocidadeMov;
    [SerializeField]
    private float runningMultiplier = 1.5f;
    [SerializeField]
    public float maxStamina = 5f;


    public Vector2 lookDirection = new Vector2(1, 0);
    public Vector2 moveDirection = new Vector2(0, 0);

    public bool isRunning { get; private set; } = false;
    public float stamina { get; private set; } = 0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
    }

    void Update()
    {
        Vector2 velocity = moveDirection * velocidadeMov;
        if (isRunning && velocity.magnitude > 0)
        {
            velocity *= runningMultiplier;
            stamina -= Time.deltaTime;
            if (stamina <= 0)
            {
                stamina = 0;
                isRunning = false;
            }
        }
        else
        {
            stamina += Time.deltaTime;
            if (stamina >= maxStamina)
            {
                stamina = maxStamina;
            }
        }

        this.rb.velocity = velocity;
        transform.up = lookDirection;
    }

    public void SetMove(Vector2 move)
    {
        this.moveDirection = move;
    }

    public void SetLook(Vector2 look)
    {
        this.lookDirection = look;
    }

    public void SetRunning(bool running)
    {
        this.isRunning = running;
    }
}
