using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualizadorTh : MonoBehaviour
{
    public TextMeshProUGUI infoUI;

    //Onde pego as informações
    public CasaTh minhaCasa;

    void Start()
    {

    }


    void LateUpdate()
    {
        infoUI.text = $"Comida: {minhaCasa.totalComida}\nMadeira: {minhaCasa.totalMadeira}\nOuro: {minhaCasa.totalOuro}\nCasas: {minhaCasa.qtdCasas}\nPopulação: {minhaCasa.fazendeiros.Count} / {minhaCasa.qtdCasas*5}\nL: {minhaCasa.profissoes[0]} | A: {minhaCasa.profissoes[1]} | Ma: {minhaCasa.profissoes[2]} | Mi: {minhaCasa.profissoes[3]}\nFelicidade: {minhaCasa.totalVidaBoa}\nTempo: {minhaCasa.gameTimeText}";
    }
}
