using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int totalMadeira = 0;
    public int totalComida = 0;
    public GameObject meuFazendeiro;

    //Info
    public GameObject floresta;
    public GameObject carne;
    public List<GameObject> fazendeiros;
    
    //Relogio
    private float tempoCarne = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(totalComida >= 250)
        {
            CriarFazendeiro();
        }

        Consumo();
    }

    void CriarFazendeiro()
    {
        if(totalComida >= 50)
        {
            GameObject meuF = Instantiate(meuFazendeiro, transform.position, Quaternion.identity);
            meuF.GetComponent<Fazendeiro>().floresta = floresta;
            meuF.GetComponent<Fazendeiro>().carne = carne;
            meuF.GetComponent<Fazendeiro>().casa = this.gameObject;
            totalComida -= 50;
            fazendeiros.Add(meuF);
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
    }
}
