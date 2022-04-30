using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] itemstoSpawn;
    [SerializeField] Transform spawnLocation;
    [SerializeField] float spawnTimer = 2.0f;

    private Vector3 startPosition;
    private bool isGameRunning = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        SetupPool();
        StartCoroutine(SpawnObject());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnObject());
    }

    private void SetupPool()
    {
        for(int i = 0; i<itemstoSpawn.Length; i++)
        {
            itemstoSpawn[i].transform.position = startPosition;
            itemstoSpawn[i].SetActive(false);
        }
    }

    IEnumerator SpawnObject()
    {
        while(isGameRunning)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i<itemstoSpawn.Length; i++)
        {
            if(itemstoSpawn[i].activeInHierarchy == false)
            {
                itemstoSpawn[i].transform.position = startPosition;
                itemstoSpawn[i].SetActive(true);
                return;
            }
        }
    }

    public void GameStateChanged()
    {
        isGameRunning = !isGameRunning;
    }

}
