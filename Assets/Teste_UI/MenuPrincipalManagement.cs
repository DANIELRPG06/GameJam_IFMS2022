using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManagement : MonoBehaviour
{

    [SerializeField] private string nomeDoLeveldoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLeveldoJogo);
    }

    public void AbrirOpções()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpções()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairdoJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();

    }

}
