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

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tomato Died");
            SoundManager.soundManagerInstance.PlaySplat();
            Vector3 direction = (transform.position - _originalLocation).normalized;
            Vector3 collisionNormal = collision.contacts[0].normal;
            Debug.Log(collisionNormal);
            Instantiate(_splatDecal, transform.position, Quaternion.Euler(direction));
            Destroy(gameObject);
        }
    }
}
