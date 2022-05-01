using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] itemsToSpawn;
    [SerializeField] Transform spawnLocation;
    [SerializeField] float spawnTimer = 2.0f;
    [SerializeField] float maxObjectSpeed = 2.0f;
    [SerializeField] float minObjectSpeed = 0.5f;

    private Vector3 startPosition;
    private bool isGameRunning = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Awake()
    {
        startPosition = transform.position;
        SetupPool();
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
        for(int i = 0; i< itemsToSpawn.Length; i++)
        {
            itemsToSpawn[i].transform.position = startPosition;
            itemsToSpawn[i].SetActive(false);
        }
    }

    IEnumerator SpawnObject()
    {
        while(true)
        {
            if (isGameRunning)
            {
                EnableObjectInPool();
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i< itemsToSpawn.Length; i++)
        {
            if(itemsToSpawn[i].activeInHierarchy == false)
            {
                itemsToSpawn[i].transform.position = startPosition;
                itemsToSpawn[i].GetComponent<ObjectFaller>().SetFallSpeed(Random.Range(minObjectSpeed, maxObjectSpeed));
                itemsToSpawn[i].SetActive(true);
                return;
            }
        }
    }

    public void GameStateChanged()
    {
        isGameRunning = !isGameRunning;
    }

    public void DisableAllCurrentSpawns()
    {
        for(int i = 0; i<itemsToSpawn.Length; i++)
        {
            if(itemsToSpawn[i].activeInHierarchy == true)
            {
                itemsToSpawn[i].SetActive(false);
            }
        }
        return;
    }

}
