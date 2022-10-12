using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Jaula : MonoBehaviour, IInteragivel
{
    [SerializeField]
    private Animator jaulaAnim;

    public bool Interagir(Player player)
    {
        if (player.chaveQtd <= 0)
            return false;

        player.DecrementaChave();
        player.DaPontos(100);

        jaulaAnim.SetTrigger("abrir");

        return true;
    }

    public bool PrecisaInput()
    {
        return true;
    }

    public string GetDescricao(Player player)
    {
        if (player.chaveQtd > 0)
        {
            return "Pressione E para libertar";
        }

        return "Você precisa de uma chave";
    }
}