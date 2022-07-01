using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    public List<ItemsScriptable> Items = new();

    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject itemPrefab;
    private int amount;
    private void Awake()
    {
        Instance = this;
    }

    public void Add(ItemsScriptable Item)
    {
        Items.Add(Item);
        ListItems();
    }
    public void Remove(ItemsScriptable Item)
    {
        Items.Remove(Item);
        ListItems();
    }

    public void ListItems()
    {
        foreach(Transform item in itemContent)
        {
            Destroy(item.gameObject); 
        }

        List<ItemsScriptable> uniqueList = Items.Distinct().ToList();

        foreach(ItemsScriptable item in uniqueList)
        {
            GameObject obj = Instantiate(itemPrefab, itemContent);
            obj.GetComponentsInChildren<Image>()[1].sprite = item.sprite;
            obj.GetComponentInChildren<TMP_Text>().text = $"( {AmountInList(item)})" + item.itemName;
        }
    }

    public int AmountInList(ItemsScriptable item)
    {
        int suma= 0;
        for(int i = 0; i < Items.Count; i++)
        {
            if(Items[i] == item)
            {
                suma++;
            }
        }
        return suma;
    }
}
