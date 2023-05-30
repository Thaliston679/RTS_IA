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
    public Gerenciador gerenciador;

    void LateUpdate()
    {
        infoUI.text = $"População: {minhaCasa.Fazendeiros.Count} / {minhaCasa.QtdCasas * 5}\nComida: {minhaCasa.TotalComida}\nMadeira: {minhaCasa.TotalMadeira}\nOuro: {minhaCasa.TotalbarraDeouro}\nFelicidade: {minhaCasa.TotalVidaBoa}\nMa: {minhaCasa.trabalhadorMadeira} | Ca: {minhaCasa.trabalhadorCarne} | VB: {minhaCasa.trabalhadorVidaboa} | Mi: {minhaCasa.trabralhadorMineiro}\nTempo: {gerenciador.gameTimeText}";
    }
}