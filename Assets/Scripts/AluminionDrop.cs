using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AluminionDrop : MonoBehaviour, IInteract
{
    [SerializeField] private ItemsScriptable aluminum;
    private AudioSource audioSource;
    private bool hasPlay = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ActivateObject()
    {
        if (!hasPlay)
        {
            audioSource.Play();
            hasPlay = true;
        }
        InventorySystem.Instance.Add(aluminum);
        Destroy(gameObject, 0.1f);
    }
}
