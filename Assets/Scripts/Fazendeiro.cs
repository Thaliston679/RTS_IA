using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendeiro : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject destino;
    public GameObject casa;
    public GameObject floresta;
    public GameObject carne;
    public GameObject lazer;
    public int madeira;
    public int comida;
    public bool loteria = false;

    public enum S_tipo { Lenhador, Agricultor, Maraja };
    public S_tipo MeuTipo;

    private float tempoLazer = 0;

    //Controle
    public float irParaDestino = 0;
    public bool andando = true;
    //Agricultor = 7.721033
    //Lenhador = 11.43567
    //Maraja = 3.824313
    public int meuTipo;

    void Start()
    {
        andando = true;
        agent = GetComponent<NavMeshAgent>();
        destino = casa;
    }

    // Update is called once per frame
    void Update()
    {
        if (loteria)
        {
            AvisarCasaVidaBoa();
        }
        else
        {
            agent.SetDestination(destino.transform.position);
            if (Vector3.Distance(transform.position, destino.transform.position) < 4)
            {
                MudarDestino();
            }
        }

        if (andando) irParaDestino += Time.deltaTime;
    }

    public void DefinirTipo(int meuT)
    {
        if (!loteria)
        {
            switch (meuT)
            {
                case 0:
                    MeuTipo = S_tipo.Lenhador;
                    break;
                case 1:
                    MeuTipo = S_tipo.Agricultor;
                    break;
                case 2:
                    MeuTipo = S_tipo.Maraja;
                    break;
            }
        }
    }

    void MudarDestino()
    {
        if (destino == floresta)
        {
            destino = casa;
            madeira = 10;
            andando = false;
        }
        else if (destino == carne)
        {
            destino = casa;
            comida = 10;
            andando = false;
        }
        else if (destino == lazer)
        {
            destino = casa;
            loteria = true;
            andando = false;
        }
        else if (destino == casa)
        {
            casa.GetComponent<Casa>().totalMadeira += madeira;
            casa.GetComponent<Casa>().totalComida += comida;
            madeira = 0;
            comida = 0;

            VerificaProfissao();

            if(MeuTipo == S_tipo.Lenhador)
            {
                destino = floresta;
            }
            if (MeuTipo == S_tipo.Agricultor)
            {
                destino = carne;
            }
            if (MeuTipo == S_tipo.Maraja)
            {
                destino = lazer;
            }
        }
    }

    void AvisarCasaVidaBoa()
    {
        tempoLazer += Time.deltaTime;
        if (tempoLazer >= 10)
        {
            tempoLazer = 0;
            casa.GetComponent<Casa>().ReceberAvisoMaraja();
        }
    }

    void VerificaProfissao()
    {
        if(meuTipo != 2) DefinirTipo(casa.GetComponent<Casa>().ControleDeCrise(meuTipo));
    }
}
