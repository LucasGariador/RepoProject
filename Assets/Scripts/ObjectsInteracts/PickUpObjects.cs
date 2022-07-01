using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Item"))
        {
            if(other.GetComponent<ItemCreationBehivior>().itemsScriptable.id == 1)
            {
                GetComponent<OxygenSystem>().maxOxygenTanks++;
                Destroy(other.gameObject);
            }
            else
            {
                InventorySystem.Instance.Add(other.GetComponent<ItemCreationBehivior>().itemsScriptable);
                Destroy(other.gameObject);
            }
        }
    }
}
