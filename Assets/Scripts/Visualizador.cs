using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Visualizador : MonoBehaviour
{
    public TextMeshProUGUI infoUI;

    //Onde pego as informações
    public Casa minhaCasa;

    void Start()
    {

    }


    void LateUpdate()
    {
        infoUI.text = $"Comida: {minhaCasa.totalComida}\nMadeira: {minhaCasa.totalMadeira}\nCasas: {minhaCasa.qtdCasas}\nPopulação: {minhaCasa.fazendeiros.Count} / {minhaCasa.qtdCasas*5}\nL: {minhaCasa.profissoes[0]} | A: {minhaCasa.profissoes[1]} | M: {minhaCasa.profissoes[2]}\nFelicidade: {minhaCasa.totalVidaBoa}\nTempo: {minhaCasa.gameTimeText}";
    }
}
