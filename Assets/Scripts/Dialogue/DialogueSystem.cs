using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;
    [SerializeField] private GameObject textBox;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image;

    [SerializeField] private Sprite[] sprite = new Sprite[3];
    public bool isReading = false;
    private void Awake()
    {
        Instance = this;
    }

    //Player image[0], station image [1], robot image[2]

    public void ShowDialogue(string newText, Speakers speaker)
    {
        EnableDialogueBox();

        if(speaker == Speakers.Player)
        {
            image.sprite = sprite[0];
        }else if(speaker== Speakers.Station)
        {
            image.sprite = sprite[1];
        }else if(speaker == Speakers.Robot)
        {
            image.sprite = sprite[2];
        }
        text.text = newText;
    }

    public void DisableDialogueBox()
    {
        textBox.SetActive(false);
        PlayerInput.canMove = true;
    }
    public void EnableDialogueBox()
    {
        textBox.SetActive(true);
        PlayerInput.canMove = false;
    }
}
