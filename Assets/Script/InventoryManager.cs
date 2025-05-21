using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<ItemData> InventoryList = new List<ItemData>();

    public void Additem(ItemData item)
    {
        InventoryList.Add(item);
    }

    public int GetItemAmount(ItemData data)
    {
        int amount = 0;
        foreach (ItemData item in InventoryList)
        {
            if (item == data)
                amount++;
        }
        return amount;
    }
}
