using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMove : MonoBehaviour
{


    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float velocidadeMov;





    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direcao = new Vector2(horizontal, vertical);
        this.rb.velocity = direcao * this.velocidadeMov;

        // olha pro cursor
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );
        transform.up = direction;

    }
}
