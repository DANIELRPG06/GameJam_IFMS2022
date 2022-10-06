using UnityEngine;

public class Player : MonoBehaviour
{
    public int chaveQtd { get; private set; } = 0;
    public int pontos { get; private set; } = 0;


    public IInteragivel interagivelPerto { get; private set; }
    private void Update()
    {
        if (Input.GetButtonDown("Interact") && interagivelPerto != null)
        {
            if (interagivelPerto.Interagir(this))
            {
                interagivelPerto = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteragivel interagivel = collision.gameObject.GetComponent<IInteragivel>();
        if (interagivel != null)
        {
            if (interagivel.PrecisaInput())
            {
                interagivelPerto = interagivel;
            }
            else
            {
                interagivel.Interagir(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteragivel interagivel = collision.gameObject.GetComponent<IInteragivel>();
        if (interagivel == interagivelPerto)
        {
            interagivelPerto = null;
        }
    }

    public void IncrementaChave()
    {
        chaveQtd++;
    }

    public void DecrementaChave()
    {
        chaveQtd--;
    }

    public void DaPontos(int pontos)
    {
        this.pontos += pontos;
    }
}