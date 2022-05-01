using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlocks : MonoBehaviour
{
    [SerializeField] GameObject[] coins;

    public void ReenableCoins()
    {
        for(int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bounds")
        {
            ReenableCoins();
        }
        else
        {
            return;
        }
    }
}
