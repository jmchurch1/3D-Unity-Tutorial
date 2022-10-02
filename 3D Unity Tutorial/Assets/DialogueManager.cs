using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Dialogue _currentDialogue;

    private int _currentSlideIndex = 0;

    [SerializeField] private RuntimeData _runtimeData;

    private void Awake()
    {
        GameEvents.DialogFinished += OnDialogFinished;
        GameEvents.DialogInitiated += OnDialogInitiated;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentSlideIndex < _currentDialogue.DialogSlides.Length - 1)
            {
                _currentSlideIndex++;
                ShowSlide();
            }
            else
            {
                GameEvents.InvokeDialogFinished();
            }
        }
    }

    void OnDialogInitiated(object sender, DialogueEventArgs args)
    {
        _currentDialogue = args.dialogPayload;
        _currentSlideIndex = 0;
        ShowSlide();
        LoadAvatar();
        GetComponent<Canvas>().enabled = true;
        _runtimeData.CurrentGameplayState = GameplayState.inDialog;
    }
    void OnDialogFinished(object sender, EventArgs args)
    {
        GetComponent<Canvas>().enabled = false;
        _runtimeData.CurrentGameplayState = GameplayState.FreeWalk;
    }

    void ShowSlide()
    {
        GameObject textObj = transform.Find("DialogText").gameObject;
        TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
        textComponent.text = _currentDialogue.DialogSlides[_currentSlideIndex];
    }

    void LoadAvatar()
    {
        GameObject avatarObj = transform.Find("Avatar").gameObject;
        RawImage imageComponent = avatarObj.GetComponent<RawImage>();
        imageComponent.texture = _currentDialogue.NPCAvatar;
    }
}
