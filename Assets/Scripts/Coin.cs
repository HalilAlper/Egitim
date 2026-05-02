using System;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [HideInInspector] public float beklenen = 0f;
    [HideInInspector] public CoinSystem coinSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OyuncuKontrolcusu oyuncu = other.gameObject.GetComponent<OyuncuKontrolcusu>();
            oyuncu.coin++;

            coinSystem.CoiniDeaktiveEt(this);
            //gameObject.SetActive(false);
        }
    }
}
