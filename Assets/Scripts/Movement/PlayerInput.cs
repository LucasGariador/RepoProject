using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private ParticleSystem onClick;
    [SerializeField] private LayerMask layerMask;
    [HideInInspector]public static bool canMove = true;

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject miniMap;

    public static bool radarAvailable = false;
    public static bool toolAvaible = false;
    
    void Update()
    {
        if (canMove)
        {
            SendDestination();
        }
        ActiveUI();
    }

    private void ActiveUI()
    {
        if (Input.GetKeyDown(KeyCode.M) && radarAvailable)
        {
            miniMap.SetActive(!miniMap.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(!inventory.activeSelf);
            InventorySystem.Instance.ListItems();
        }
    }

    private void SendDestination() 
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20f, layerMask))
            {
                GetComponent<Mover>().SetActorDestination(hit.point);
                onClick.transform.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
                onClick.Play();
            }
        }
    }
}
