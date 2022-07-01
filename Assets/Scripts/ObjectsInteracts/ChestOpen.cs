using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour, IInteract
{
    private Animation _animation;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 1f;
    [SerializeField] private Transform spawnPoint;
    private void Start()
    {
        _animation = GetComponent<Animation>();
    }
    public void ActivateObject()
    {
        AudioSystem.Instance.PlaySound(clip);
        AudioSystem.Instance.audioSource.volume = volume;
        _animation.Play();
        gameObject.GetComponent<InstantiateItems>().SpawnObjects(spawnPoint.position);
        Destroy(gameObject, .5f);
    }
}