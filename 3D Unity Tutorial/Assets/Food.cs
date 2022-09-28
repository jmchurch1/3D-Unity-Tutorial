using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private float _rotationSpeed = 180f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Entered");
        transform.Find("Spot Light").gameObject.SetActive(true);
    }

    private void OnMouseOver()
    {
        transform.Find("FoodMesh").Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        transform.Find("Spot Light").gameObject.SetActive(false);
    }
}
