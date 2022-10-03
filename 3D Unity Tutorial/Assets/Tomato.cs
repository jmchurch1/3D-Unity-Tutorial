using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    [SerializeField] private GameObject _splatDecal;

    private Vector3 _originalLocation;

    private void Start()
    {
        _originalLocation = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log("Tomato Died");
            SoundManager.soundManagerInstance.PlaySplat();
            Vector3 direction = (transform.position - _originalLocation).normalized;
            Instantiate(_splatDecal, transform.position + 1.05f*direction, Quaternion.Euler(direction));
            Destroy(gameObject);
        }
    }
}
