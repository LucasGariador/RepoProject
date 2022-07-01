using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItems : MonoBehaviour
{
    [SerializeField] private List<ItemsScriptable> itemsPrefabs = new List<ItemsScriptable>();
    
    public void SpawnObjects(Vector3 pos)
    {
        foreach(var item in itemsPrefabs)
        {
            Instantiate(item.itemPrefab, pos, Quaternion.identity);
        }
    }
}
