using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int totalMadeira = 100;
    public int totalComida = 500;
    public GameObject meuFazendeiro;
    public int qtdCasas = 1;
    public int totalVidaBoa = 0;

    //Info
    public GameObject floresta;
    public GameObject carne;
    public GameObject lazer;
    public List<GameObject> fazendeiros;
    
    //Relogio
    private float tempoCarne = 0;
    private float tempoMadeira = 0;

    //Controle
    int ultimoTipoCriado = 0;

    private void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            CriarFazendeiro(0);
        }
        for (int i = 0; i < 2; i++)
        {
            CriarFazendeiro(1);
        }
        CriarFazendeiro(2);
    }

    private void Update()
    {
        if(totalComida >= 250 + fazendeiros.Count * 2)
        {
            CriarFazendeiro(VerificarNecessidade(Random.Range(0, 1)));
        }

        Consumo();

        CriarCasa();
    }

    void CriarFazendeiro(int escolheTipo)
    {
        if(totalComida >= 50 && (qtdCasas * 5) > fazendeiros.Count)
        {
            GameObject meuF = Instantiate(meuFazendeiro, transform.position, Quaternion.identity);
            Fazendeiro fazendeiro = meuF.GetComponent<Fazendeiro>();
            fazendeiro.floresta = floresta;
            fazendeiro.carne = carne;
            fazendeiro.lazer = lazer;
            fazendeiro.casa = this.gameObject;
            totalComida -= 50;
            fazendeiros.Add(meuF);
            fazendeiro.DefinirTipo(escolheTipo);
            fazendeiro.meuTipo = escolheTipo;
        }
    }

    void CriarCasa()
    {
        if(totalMadeira > 250 && fazendeiros.Count == (qtdCasas * 5))
        {
            totalMadeira -= 100;
            qtdCasas++;
        }
    }

    void Consumo()
    {
        tempoCarne += Time.deltaTime;

        if(tempoCarne > 5)
        {
            tempoCarne = 0;
            totalComida -= fazendeiros.Count;

            if(totalComida < 0)
            {
                Debug.Log("Morreu de fome!");
                Time.timeScale = 0;
            }
        }

        tempoMadeira += Time.deltaTime;

        if (tempoMadeira > 10)
        {
            tempoMadeira = 0;
            totalMadeira -= fazendeiros.Count;

            if (totalMadeira < 0)
            {
                Debug.Log("Morreu de frio!");
                Time.timeScale = 0;
            }
        }
    }

    public void ReceberAvisoMaraja()
    {
        totalVidaBoa++;
    }

    public void SetTimeScale(float value)
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = value;
        }
    }

    public int VerificarNecessidade(int value)
    {
        int tipo = value;

        if (totalMadeira < totalComida * 1.5f)
        {
            tipo = 0;
        }

        if (totalComida < totalMadeira * 1.5f)
        {
            tipo = 1;
        }

        if (totalComida > fazendeiros.Count * 20 && totalMadeira > fazendeiros.Count * 20 && ultimoTipoCriado != 2)
        {
            tipo = 2;
        }
        ultimoTipoCriado = tipo;
        return tipo;
    }

    public int ControleDeCrise(int value)
    {
        int tipo = value;
        bool crise = false;

        if (totalMadeira < fazendeiros.Count * 5)
        {
            if(value == 1)
            {
                tipo = 0;
                crise = true;
                Debug.Log("Crise de Madeira");
            }
        }
        if (totalMadeira > fazendeiros.Count * 30 && !crise)
        {
            if (value == 0)
            {
                tipo = 1;
                Debug.Log("Abundância de Madeira");
            }
        }


        if (totalComida < fazendeiros.Count * 10)
        {
            if (value == 0)
            {
                tipo = 1;
                crise = true;
                Debug.Log("Crise de Comida");
            }
        }
        if (totalComida > fazendeiros.Count * 30 && !crise)
        {
            if (value == 1)
            {
                tipo = 0;
                Debug.Log("Abundância de Comida");
            }
        }

        return tipo;
    }
}
