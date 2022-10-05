using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationprincipal : MonoBehaviour
{
    public Rigidbody2D ribi;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ribi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direc = new Vector2(horizontal, vertical);

        if(Input.GetAxis("Horizontal") != 0)
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

        if (Input.GetButtonDown("Sprint"))
        {
            anim.SetBool("taCorrendo", true);
        }
        if (Input.GetButtonUp("Sprint"))
        {
            anim.SetBool("taCorrendo", false);
        }
    }
}
