using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private float _rotationSpeed = 180f;

    [SerializeField] private GameObject _parentQuiz;
    [SerializeField] private RuntimeData _runtimeData;
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
       _runtimeData.CurrentFoodMousedOver = name;
    }

    private void OnMouseOver()
    {
        transform.Find("FoodMesh").RotateAround(transform.position, Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        transform.Find("Spot Light").gameObject.SetActive(false);
        _runtimeData.CurrentFoodMousedOver = "";
    }

    private void OnMouseDown()
    {
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk)
        {
            StartCoroutine(_parentQuiz.GetComponent<FoodQuiz>().FoodSelected(gameObject));
            _runtimeData.CurrentFoodMousedOver = "";
        }
    }
}
