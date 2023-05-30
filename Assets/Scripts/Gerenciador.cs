using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public string gameTimeText;
    private float gameTime = 0;

    void Update()
    {
        Relogio();
    }

    void Relogio()
    {
        gameTime += Time.deltaTime * 1000f;
        int minutes = (int)(gameTime / 60000);
        int seconds = (int)((gameTime / 1000) % 60);
        gameTimeText = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}