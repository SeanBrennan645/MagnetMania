using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointValue = 50;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Increase player score");
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
