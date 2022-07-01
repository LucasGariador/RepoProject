using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreationBehivior : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    public ItemsScriptable itemsScriptable;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(0, jumpForce/2), jumpForce, Random.Range(0, jumpForce/2)), ForceMode.Impulse);
    }
}
