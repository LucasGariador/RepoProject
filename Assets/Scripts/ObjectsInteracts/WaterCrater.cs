using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCrater : MonoBehaviour, IInteract
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume;

    private int waterAmount = 2;
    public void ActivateObject()
    {
        if (waterAmount > 0)
        {
            GetComponent<InstantiateItems>().SpawnObjects(spawnPoint.position);
            AudioSystem.Instance.audioSource.volume = volume;
            AudioSystem.Instance.PlaySound(clip);
        }
        else if(waterAmount == 0)
        {
            GetComponent<DialgueHandler>().StartDialogue();
        }
        waterAmount--;
    }
}