using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Runtime Data")]
public class RuntimeData : ScriptableObject
{
    public string CurrentFoodMousedOver;

    public GameplayState CurrentGameplayState;
}
