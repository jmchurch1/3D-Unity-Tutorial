using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private RuntimeData _runtimeData;

    private void Awake()
    {
        _runtimeData.CurrentFoodMousedOver = "";
        _runtimeData.CurrentGameplayState = GameplayState.inDialog;
    }
}
