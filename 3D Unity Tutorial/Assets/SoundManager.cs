using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _splat;

    public static SoundManager soundManagerInstance;
    void Awake()
    {
        soundManagerInstance = this;
    }

    public void PlaySplat()
    {
        _splat.Play();
    }
}
