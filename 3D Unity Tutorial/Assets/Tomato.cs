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
        StartCoroutine(nameof(ToggleTrigger));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tomato Died");
            SoundManager.soundManagerInstance.PlaySplat();
            Vector3 collisionNormal = collision.contacts[0].normal;
            Quaternion quatNormal = Quaternion.LookRotation(collisionNormal, Vector3.up);
            quatNormal *= Quaternion.Euler(90, 0, 0);
            Instantiate(_splatDecal, transform.position, quatNormal);
            Destroy(gameObject);
        }
    }
    
    IEnumerator ToggleTrigger()
    {
        yield return new WaitForSeconds(.03f);
        gameObject.GetComponent<MeshCollider>().isTrigger = false;
    }
}
