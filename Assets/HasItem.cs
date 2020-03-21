using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasItem : MonoBehaviour {
    public bool itemgotten;
    public Inventory inventory;
    public GameObject item;

    void OnEnable()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if (!itemgotten)
        {
            GetItem();
        }
        
    }
    void GetItem()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                GameObject obj = Instantiate(item, inventory.slots[i].transform, false);
                obj.name = obj.name.Replace("(Clone)", "").Trim();
                itemgotten = true;
                break;
            }
        }
        this.enabled = false;
    }
}
