using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodQuiz : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    [SerializeField] private Dialogue _correctChoiceDialogue;
    [SerializeField] private Dialogue _incorrectChoiceDialogue;

    [SerializeField] private GameObject _correctFood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameEvents.InvokeDialogInitiated(_dialogue);
    }

    public IEnumerator FoodSelected(GameObject food)
    {
        yield return new WaitForEndOfFrame();
        if (food == _correctFood)
            GameEvents.InvokeDialogInitiated(_correctChoiceDialogue);
        else 
            GameEvents.InvokeDialogInitiated(_incorrectChoiceDialogue);
        
        Destroy(food);
    }
}
