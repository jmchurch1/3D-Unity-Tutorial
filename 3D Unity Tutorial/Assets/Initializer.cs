using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private RuntimeData _runtimeData;
    [SerializeField] private Dialogue _startingDialogue;

    private void Awake()
    {
        _runtimeData.CurrentFoodMousedOver = "";
        _runtimeData.CurrentGameplayState = GameplayState.inDialog;
    }

    private void Start()
    {
        GameEvents.InvokeDialogInitiated(_startingDialogue);
    }
}
