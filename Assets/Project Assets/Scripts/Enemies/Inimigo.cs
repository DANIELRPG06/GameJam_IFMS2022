using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    
    private Transform alvo;

    [SerializeField]
    private float raioVisao;

    [SerializeField]
    private LayerMask layerAreaVisao;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private float distanciaMinima;

    // Update is called once per frame
    void Update()
    {
        ProcurarJogador();
        if(this.alvo != null)
        {
            Vector2 posicaoAlvo = this.alvo.position;
            Vector2 posicaoAtual = this.transform.position;

            float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
            if (distancia >= this.distanciaMinima)
            {
                Vector2 direcao = posicaoAlvo - posicaoAtual;
                direcao = direcao.normalized;

                this.rigidbody.velocity = (this.velocidadeMovimento * direcao);


            }
           
        }
        else
        {
            this.rigidbody.velocity = Vector2.zero;
        }
       
s        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
        if(this.alvo != null)
        {
            Gizmos.DrawLine(this.transform.position, this.alvo.position);
        }
    }
    private void ProcurarJogador()
    {
     Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
        if(colisor != null)
        {
            Vector2 posicaoAtual = this.transform.position;
            Vector2 posicaoAlvo = colisor.transform.position;
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao);
            if(hit.transform != null)
            {
                if (hit.transform.CompareTag(""))
                {
                    this.alvo = hit.transform;
                }
                else
                {
                    this.alvo = null;
                }
            }
            else
            {
                this.alvo = null;
            }

            
        }
        else
        {
            this.alvo = null;
        }
        

        
    }
}
