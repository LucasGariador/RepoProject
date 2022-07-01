using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OxigenSource : MonoBehaviour
{
    private AudioSource audioSource;
    public bool isIn = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OxygenSystem oxygenSystem = other.GetComponent<OxygenSystem>();
            oxygenSystem.currentOxygenTanks = oxygenSystem.maxOxygenTanks;
            oxygenSystem.currentOxygenLevel = oxygenSystem.maxOxygenLevel;
            audioSource.Play();
            isIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isIn = false;
        }
    }
}
