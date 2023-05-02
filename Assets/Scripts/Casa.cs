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
        if(totalComida >= 250)
        {
            CriarFazendeiro(Random.Range(0,1));
        }

        Consumo();

        CriarCasa();
    }

    void CriarFazendeiro(int escolheTipo)
    {
        if(totalComida >= 50 && (qtdCasas * 5) > fazendeiros.Count)
        {
            GameObject meuF = Instantiate(meuFazendeiro, transform.position, Quaternion.identity);
            meuF.GetComponent<Fazendeiro>().floresta = floresta;
            meuF.GetComponent<Fazendeiro>().carne = carne;
            meuF.GetComponent<Fazendeiro>().lazer = lazer;
            meuF.GetComponent<Fazendeiro>().casa = this.gameObject;
            totalComida -= 50;
            fazendeiros.Add(meuF);
            meuF.GetComponent<Fazendeiro>().DefinirTipo(escolheTipo);
        }
    }

    void CriarCasa()
    {
        if(totalMadeira > 100)
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
        Time.timeScale = value;
    }
}
