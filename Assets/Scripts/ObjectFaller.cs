using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFaller : MonoBehaviour
{
    [SerializeField] float fallSpeed = 1.0f;

    void Update()
    {
        transform.position += transform.up * -fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bounds")
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
