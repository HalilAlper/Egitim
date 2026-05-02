using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public List<Coin> coins;

    public float tekrarAktiveEtSaniye = 5f;

    private void Start()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].coinSystem = this;
        }
    }

    private void Update()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            if (coins[i].gameObject.activeSelf)
            {
                continue;
            }

            coins[i].beklenen += Time.deltaTime;

            if (coins[i].beklenen > tekrarAktiveEtSaniye)
            {
                coins[i].gameObject.SetActive(true);
            }
        }
    }

    public void CoiniDeaktiveEt(Coin coin)
    {
        coin.beklenen = 0f;
        coin.gameObject.SetActive(false);
    }
}
