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
    public int madeira;
    public int comida;

    public enum S_tipo { Lenhador, Agricultor };
    public S_tipo MeuTipo;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destino = casa;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destino.transform.position);
        if(Vector3.Distance(transform.position, destino.transform.position) < 4)
        {
            MudarDestino();
        }        
    }

    public void DefinirTipo(int meuT)
    {
        switch (meuT)
        {
            case 0:
                MeuTipo = S_tipo.Lenhador;
                break;
            case 1:
                MeuTipo = S_tipo.Agricultor;
                break;
        }
    }

    void MudarDestino()
    {
        if (destino == floresta)
        {
            destino = casa;
            madeira = 10;
        }
        else if (destino == carne)
        {
            destino = casa;
            comida = 10;
        }
        else if (destino == casa)
        {
            casa.GetComponent<Casa>().totalMadeira += madeira;
            casa.GetComponent<Casa>().totalComida += comida;
            madeira = 0;
            comida = 0;

            if(MeuTipo == S_tipo.Lenhador)
            {
                destino = floresta;
            }
            if (MeuTipo == S_tipo.Agricultor)
            {
                destino = carne;
            }
        }
    }
}
