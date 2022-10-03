using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodLabel : MonoBehaviour
{
    [SerializeField] private RuntimeData _runtimeData;

    // Update is called once per frame
    void Update()
    { 
        GetComponent<TextMeshProUGUI>().text = _runtimeData.CurrentFoodMousedOver;
    }
}
