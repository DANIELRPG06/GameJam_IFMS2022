using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Chave : MonoBehaviour, IInteragivel
{

    public bool Interagir(Player player)
    {
        player.IncrementaChave();
        Destroy(gameObject);
        return true;
    }

    public bool PrecisaInput()
    {
        return false;
    }
    
}