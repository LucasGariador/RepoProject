using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class UpdateAnimations : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    [SerializeField] private AudioClip[] steps;
    private AudioSource audioSource;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ChangeAnimations();
    }

    private void ChangeAnimations()
    {
        animator.SetFloat("Walk", navMeshAgent.velocity.magnitude);
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return steps[Random.Range(0, steps.Length)];
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }
}