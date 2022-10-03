using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisionC : MonoBehaviour
{
    [SerializeField] private int chaveQtd = 0;
    // Start is called before the first frame update

    

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coletavel")
        {
            chaveQtd = chaveQtd + 1;
            Destroy(collision.gameObject);
        }
    }

}
