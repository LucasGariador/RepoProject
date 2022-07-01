using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour , IInteract
{
    [SerializeField] private ItemsScriptable[] itemArray;
    [SerializeField] private GameObject creationMenu;
    [SerializeField] private GameObject radar;
    [SerializeField] private GameObject inventory;

    [SerializeField] private GameObject suitDialogue;

    public void ActivateObject()
    {
        ActivateCreationMenu();
        GetComponent<DialgueHandler>().destroyOnFinish = false;
    }

    private void Update()
    {
        if (!GetComponent<OxigenSource>().isIn) {
            creationMenu.SetActive(false);
        }
    }

    public void CreateRadar()
    {
        //Comp Electronicos ID = 2, piezas ID =3
        if (FindAndRemove(FindItem(2), 1) && FindAndRemove(FindItem(3), 1))
        {
            PlayerInput.radarAvailable = true;
            radar.SetActive(true);
        }
        else
        {
            NotEnoughMaterials();
        }
    }

    public void CreateBioBateria()
    {
        //bio componente id = 5
        if (FindAndRemove(FindItem(5), 2) && FindAndRemove(FindItem(2), 1))
        {
            // bio bateria id = 6
            InventorySystem.Instance.Add(FindItem(6));
        }
        else
        {
            NotEnoughMaterials();
        }
    }

    public void CreateUpgradeSuit()
    {
        //Propileno id = 4
        if (FindAndRemove(FindItem(4), 3))
        {
            OxygenSystem.hasUpgradeSuit = true;
            suitDialogue.SetActive(true);
        }
        else
        {
            NotEnoughMaterials();
        }
    }

    public void CreateExtractioTool()
    {
        // aluminio id = 7, tool id = 8
        if (FindAndRemove(FindItem(6), 1) && FindAndRemove(FindItem(2), 1) && FindAndRemove(FindItem(7), 2) && FindAndRemove(FindItem(3), 1))
        {
            //Herramienta
            InventorySystem.Instance.Add(FindItem(8));
            PlayerInput.toolAvaible = true;
        }
        else
        {
            NotEnoughMaterials();
        }
    }

    public void CreateComunication()
    {
        if (FindAndRemove(FindItem(8), 1) && FindAndRemove(FindItem(9), 5))
        {
            Debug.Log("Survive");
        }
        else
        {
            NotEnoughMaterials();
        }
    }

    private bool FindAndRemove(ItemsScriptable item, int amount)
    {
        bool removed = false;
        if(InventorySystem.Instance.AmountInList(item) >= amount)
        {
            for(int i = 0; i < amount; i++)
            {
                InventorySystem.Instance.Remove(item);
            }
            removed = true;
        }
        return removed;
    }

    private ItemsScriptable FindItem(int id)
    {
        for (int i = 0; i < itemArray.Length; i++)
        {
            if(itemArray[i].id == id)
            {
                return itemArray[i];
            }
        }
        return null;
    }

    private void ActivateCreationMenu()
    {
        creationMenu.SetActive(!creationMenu.activeSelf);
        inventory.SetActive(true);
    }

    private void NotEnoughMaterials() => GetComponent<DialgueHandler>().StartDialogue();
}
