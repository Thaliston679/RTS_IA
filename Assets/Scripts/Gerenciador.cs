using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public float tempo = 300;
    public float meuRelogio;
    // Update is called once per frame
    void Update()
    {
        Relogio();
    }

    void Relogio()
    {
        meuRelogio += Time.deltaTime;
        if (meuRelogio > 1)
        {
            meuRelogio = 0;
            tempo--;
        }
    }
}