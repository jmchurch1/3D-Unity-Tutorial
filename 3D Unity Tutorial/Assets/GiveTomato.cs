using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveTomato : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GiveTomato();
            Destroy(gameObject);
        }
    }
}
