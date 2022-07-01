using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialgueHandler : MonoBehaviour
{
    [SerializeField] private DialoguesScriptable dialogue;
    [HideInInspector]public bool activeDialogue = false;
    [HideInInspector] public bool destroyOnFinish = true;
    private int line = 0;

    private void Update()
    {
        if(activeDialogue && line < dialogue.dialogue.Length)
        {
            DialogueDisplayer();
        }

        if (Input.GetKeyDown(KeyCode.Space) && activeDialogue)
        {
            line++;
        }

        
        if(line >= dialogue.dialogue.Length)
        {
            DialogueSystem.Instance.DisableDialogueBox();
            if (destroyOnFinish)
            {
                Destroy(this);
            }
            else
            {
                line = 0;
                activeDialogue = false;
            }
        }
    }
    private void DialogueDisplayer()
    {
        DialogueSystem.Instance.ShowDialogue(dialogue.dialogue[line], dialogue.speakers[line]);
    }

    public void StartDialogue()
    {
        activeDialogue = true;
    }
}