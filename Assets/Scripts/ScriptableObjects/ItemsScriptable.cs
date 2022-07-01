using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Resources")]
public class ItemsScriptable : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;
    public int amount;
    public int id;
    [TextArea]
    public string description;
    public Sprite sprite;
}
