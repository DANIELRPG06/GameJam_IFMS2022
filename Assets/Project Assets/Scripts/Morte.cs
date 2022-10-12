using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Inimigo")
        {
            SceneManager.LoadScene("Fail");
        }
    }
}
