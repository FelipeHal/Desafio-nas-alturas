using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;
    [SerializeField]
    private GameObject manualDeInstrucoes;
    private float cronometro;
    private ControleDeDificuldade controleDeDificuldade;
    private bool parado;

    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
    }

    private void Start()
    {
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.parado)
        {
            return;
        }

        this.cronometro -= Time.deltaTime;
        if (this.cronometro < 0)
        {
            GameObject.Instantiate(manualDeInstrucoes, this.transform.position, Quaternion.identity);
            this.cronometro = Mathf.Lerp(this.tempoParaGerarFacil, this.tempoParaGerarDificil, this.controleDeDificuldade.Dificuldade);
        }
    }

    public void Parar()
    {
        this.parado = true;
    }

    public void Recomecar()
    {
        this.parado = false;
    }
}
