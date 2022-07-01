using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOnEnable : MonoBehaviour
{
    private DialgueHandler dialgue;

    private void OnEnable()
    {
        dialgue = GetComponent<DialgueHandler>();
        dialgue.StartDialogue();
    }
}
