using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log("Tomato Died");
            SoundManager.soundManagerInstance.PlaySplat();
            Destroy(gameObject);
        }
    }
}
