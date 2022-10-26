using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    private Aviao aviao;
    private Pontuacao pontuacao;
    private InterfaceGameOver interfaceGameOver;

    protected virtual void Start()
    {
        this.aviao = GameObject.FindObjectOfType<Aviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.pontuacao.SalvarRecorde();
        this.interfaceGameOver.MostrarInterface();
    }

    public virtual void ReiniciarJogo()
    {
        this.interfaceGameOver.EsconderInterface();
        Time.timeScale = 1;
        this.aviao.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.Reiniciar();
    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
