using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Jaula: MonoBehaviour, IInteragivel
{
    public bool Interagir(Player player)
    {
        if (player.chaveQtd > 0)
        {
            player.DecrementaChave();
            player.DaPontos(100);
            //TODO animacao e tal
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    public bool PrecisaInput()
    {
        return true;
    }
}