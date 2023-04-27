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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destino = floresta;
        int tipo = Random.Range(0, 10);
        if(tipo < 5)
        {
            destino = floresta;
        }
        else
        {
            destino = carne;
        }
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
            int tipo = Random.Range(0, 10);
            if (tipo < 5)
            {
                destino = floresta;
            }
            else
            {
                destino = carne;
            }
        }
    }
}
