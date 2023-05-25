using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int TotalMadeira = 100;
    public int TotalComida = 500;
    public int TotalbarraDeouro = 0;
    public int QtdCasas = 1;
    public int TotalVidaBoa = 0;

    //tipos
    public int trabalhadorCarne;
    public int trabalhadorMadeira;
    public int trabalhadorVidaboa;
    public int trabralhadorMineiro;


    //Relogio
    private float tempoCarne = 0;
    private float tempoMadeira = 0;
    private int nivelFazenda = 0;

    //Dados Fazendeiros
    public GameObject MeuFazendeiro;
    public List<GameObject> Fazendeiros;

    //Informações dos Locais
    public GameObject Floresta;
    public GameObject Carne;
    public GameObject Lazer;
    public GameObject Ouro;

    private void Start()
    {

        AlterarPosicaoFloresta();
        AlterarPosicaoCarne();
        //0 - madeira
        //1 - carne
        //2 - vag
        //3 - ouro
        CriarFazendeiro(1);
        CriarFazendeiro(1);
        CriarFazendeiro(0);
        CriarFazendeiro(3);
        CriarFazendeiro(0);


    }

    private void Update()
    {
        if (TotalComida > Fazendeiros.Count * 10 + 300)
        {
            CriarFazendeiro(1);
            CriarFazendeiro(1);
            CriarFazendeiro(1);
            CriarFazendeiro(0);
            CriarFazendeiro(2);
        }
        if (TotalMadeira > 150)
        {
            CriarCasa();
        }
        Consumo();
        AtualizarFazendeiros();
    }

    void CriarFazendeiro(int escolhetipo)
    {
        //Limite de População
        if ((QtdCasas * 5) > Fazendeiros.Count)
        {
            //Limite de Comida
            if (TotalComida > 50)
            {
                GameObject MeuF = Instantiate(MeuFazendeiro, transform.position, Quaternion.identity);
                MeuF.GetComponent<Fazendeiro>().Floresta = Floresta;
                MeuF.GetComponent<Fazendeiro>().Carne = Carne;
                MeuF.GetComponent<Fazendeiro>().Lazer = Lazer;
                MeuF.GetComponent<Fazendeiro>().Ouro = Ouro;
                MeuF.GetComponent<Fazendeiro>().Casa = this.gameObject;
                TotalComida -= 50;
                Fazendeiros.Add(MeuF);
                MeuF.GetComponent<Fazendeiro>().DefinirFuncao(escolhetipo);
                DescobreTipos();
            }
        }
    }

    void CriarCasa()
    {
        if (TotalMadeira > 100)
        {
            TotalMadeira = TotalMadeira - 100;
            QtdCasas++;
        }
    }

    void Consumo()
    {
        tempoCarne += Time.deltaTime;
        if (tempoCarne > 5)
        {
            tempoCarne = 0;
            TotalComida = TotalComida - Fazendeiros.Count;
            if (TotalComida < 0)
            {
                Debug.Log("Morreu De Fome!!!!");
                Time.timeScale = 0;
            }
        }

        tempoMadeira += Time.deltaTime;
        if (tempoMadeira > 10)
        {
            tempoMadeira = 0;
            TotalMadeira = TotalMadeira - Fazendeiros.Count;
            if (TotalMadeira < 0)
            {
                Debug.Log("Morreu De Fome!!!!");
                Time.timeScale = 0;
            }
        }
    }


    public void ReceberAvisoMaraja()
    {
        TotalVidaBoa++;
    }

    void AlterarPosicaoFloresta()
    {
        float posX = Random.Range(10, 40);
        float posZ = Random.Range(10, 40);
        int sentido = Random.Range(1, 10);
        if (sentido > 5)
        {
            //muda
            posX = posX * -1;
        }
        else
        {
            //não muda
            //posX = posX;
        }

        Floresta.transform.position = new Vector3(posX, 0, posZ);
    }

    void AlterarPosicaoCarne()
    {
        float posX = Random.Range(10, 40);
        float posZ = Random.Range(10, 40);
        int sentido = Random.Range(1, 10);
        if (sentido > 5)
        {
            //muda
            posZ = posZ * -1;
        }
        else
        {
            //não muda
            //posX = posX;
        }

        Carne.transform.position = new Vector3(posX, 0, posZ);
    }


    void AtualizarFazendeiros()
    {
        int custo = (nivelFazenda * 250) + 250;
        if (TotalbarraDeouro > custo)
        {
            TotalbarraDeouro = TotalbarraDeouro - custo;
            nivelFazenda++;
            for (int i = 0; i < Fazendeiros.Count; i++)
            {
                Fazendeiros[i].GetComponent<Fazendeiro>().AumentaNivel(nivelFazenda);

            }
        }

    }


    //Descobre Quem Faz O que
    void DescobreTipos()
    {
        trabalhadorCarne = 0;
        trabalhadorMadeira = 0;
        trabalhadorVidaboa = 0;
        trabralhadorMineiro = 0;
        for (int i = 0; i < Fazendeiros.Count; i++)
        {
            if (Fazendeiros[i].GetComponent<Fazendeiro>().InformaTipo() == 0)
            {
                trabalhadorMadeira++;
            }
            if (Fazendeiros[i].GetComponent<Fazendeiro>().InformaTipo() == 1)
            {
                trabalhadorCarne++;
            }
            if (Fazendeiros[i].GetComponent<Fazendeiro>().InformaTipo() == 2)
            {
                trabalhadorVidaboa++;
            }
            if (Fazendeiros[i].GetComponent<Fazendeiro>().InformaTipo() == 3)
            {
                trabralhadorMineiro++;
            }

        }
    }

}