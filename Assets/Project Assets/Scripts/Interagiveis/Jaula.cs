using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Jaula: MonoBehaviour, IInteragivel
{
    [SerializeField]
    private Animator jaulaAnim;
    
    public bool Interagir(Player player)
    {
        if (player.chaveQtd > 0)
        {
            player.DecrementaChave();
            player.DaPontos(100);
            
            jaulaAnim.SetTrigger("abrir");

            return true;
        }
        return false;
    }

    public bool PrecisaInput()
    {
        return true;
    }
}