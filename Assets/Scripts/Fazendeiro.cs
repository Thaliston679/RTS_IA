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
    public int madeira;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destino = floresta;
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
        else if (destino == casa)
        {
            destino = floresta;
            casa.GetComponent<Casa>().totalMadeira += madeira;
            madeira = 0;
        }
    }
}
