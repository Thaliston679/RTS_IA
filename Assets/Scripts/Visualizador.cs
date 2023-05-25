using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Visualizador : MonoBehaviour
{
    public TMP_Text populacao;
    public TMP_Text comida;
    public TMP_Text madeira;
    public TMP_Text barraDeouro;
    public TMP_Text lazer;
    public TMP_Text tipo;
    public TMP_Text tempo;
    //Onde Eu pego as informações
    public Casa MinhaCasa;
    public Gerenciador MeuGerenciador;

    // Update is called once per frame
    void Update()
    {
        populacao.text = "População: " + MinhaCasa.Fazendeiros.Count + "/" + (MinhaCasa.QtdCasas * 5);
        comida.text = "Comida: " + MinhaCasa.TotalComida;
        madeira.text = "Madeira: " + MinhaCasa.TotalMadeira;
        barraDeouro.text = "Ouro: " + MinhaCasa.TotalbarraDeouro;
        lazer.text = "Lazer: " + MinhaCasa.TotalVidaBoa;
        tipo.text = "M:" + MinhaCasa.trabalhadorMadeira + "//C:" + MinhaCasa.trabalhadorCarne + "//VB: " + MinhaCasa.trabalhadorVidaboa+ "//MI: "+MinhaCasa.trabralhadorMineiro;
        tempo.text ="Tempo: "+MeuGerenciador.tempo+"seg"; 
    }
}