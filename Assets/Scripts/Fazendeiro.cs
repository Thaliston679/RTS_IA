using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendeiro : MonoBehaviour
{
    private NavMeshAgent Agente;
    public GameObject Destino;
    public GameObject Casa;
    public GameObject Floresta;
    public GameObject Carne;
    public GameObject Lazer;
    public GameObject Ouro;

    public int madeira;
    public int comida;
    public int barraDeouro;
    public bool loteria = false;
    private int LimiteCarga = 10;
    private int nivel = 0;

    public enum S_tipo { Lenhador, Agricultor, Minerador, Maraja };
    public S_tipo MeuTipo;

    private float tempoLazer = 0;

    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        Destino = Casa;
    }

    public void DefinirFuncao(int meuT)
    {
        if (loteria == false)
        {
            switch (meuT)
            {
                case 0:
                    //Coleta Madeira
                    MeuTipo = S_tipo.Lenhador;
                    break;
                case 1:
                    //Coleta Comida
                    MeuTipo = S_tipo.Agricultor;
                    break;
                case 2:
                    MeuTipo = S_tipo.Maraja;
                    break;
                case 3:
                    MeuTipo = S_tipo.Minerador;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (loteria == true)
        {
            AvisarCasa();
        }
        else
        {
            Agente.SetDestination(Destino.transform.position);
            if (Vector3.Distance(transform.position, Destino.transform.position) < 4)
            {
                MudarDestino();
            }
        }

    }

    public void AumentaNivel(int novoNivel)
    {
        nivel = novoNivel;
    }
    public int RetornaNivel()
    {
        return nivel;
    }
    void MudarDestino()
    {
        int carregando = LimiteCarga + (nivel * 2);
        if (Destino == Floresta)
        {
            madeira = carregando;
            Destino = Casa;

        }
        else if (Destino == Ouro)
        {
            barraDeouro = carregando;
            Destino = Casa;

        }
        else if (Destino == Carne)
        {
            comida = carregando;
            Destino = Casa;
        }
        else if (Destino == Casa)
        {
            Casa.GetComponent<Casa>().TotalMadeira += madeira;
            Casa.GetComponent<Casa>().TotalComida += comida;
            Casa.GetComponent<Casa>().TotalbarraDeouro += barraDeouro;
            madeira = 0;
            comida = 0;
            barraDeouro = 0;
            if (MeuTipo == S_tipo.Lenhador)
            {
                Destino = Floresta;
            }
            if (MeuTipo == S_tipo.Agricultor)
            {
                Destino = Carne;
            }
            if (MeuTipo == S_tipo.Minerador)
            {
                Destino = Ouro;
            }
            if (MeuTipo == S_tipo.Maraja)
            {
                Destino = Lazer;
            }
        }
        else if (Destino == Lazer)
        {
            //Agora só vive como maraja;
            loteria = true;
        }

    }


    void AvisarCasa()
    {
        tempoLazer += Time.deltaTime;
        if (tempoLazer >= 10)
        {
            Casa.GetComponent<Casa>().ReceberAvisoMaraja();
            tempoLazer = 0;
        }
    }

    public int InformaTipo()
    {
        if (MeuTipo == S_tipo.Lenhador)
        {
            return 0;
        }
        else if (MeuTipo == S_tipo.Agricultor)
        {
            return 1;
        }
        else if (MeuTipo == S_tipo.Maraja)
        {
            return 2;
        }
        else if (MeuTipo == S_tipo.Minerador)
        {
            return 3;
        }
        else
        {
            return -1;
        }
    }
}