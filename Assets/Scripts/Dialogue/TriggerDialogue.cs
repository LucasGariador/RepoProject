using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    private DialgueHandler dialgueHandler;
    void Start()
    {
        dialgueHandler = GetComponent<DialgueHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            dialgueHandler.StartDialogue();
        }
    }

}
