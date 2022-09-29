using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue _currentDialogue;

    private int _currentSlideIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowSlide();
        LoadAvatar();
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
                gameObject.GetComponent<Canvas>().enabled = false;
            }
        }
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
