using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {
    private Inventory inventory;
    public GameObject item;//item needed to destroy gameobject
    public bool isdestroyed;

    public Inventory Inventory;

    public GameObject obj;//item in player inventory

    public GameObject SpawnedItem;
    void Awake()
    {
        Inventory= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void OnEnable() {
        
        obj = Inventory.slots[Inventory.selectedslot].transform.GetChild(0).gameObject;
        string ItemName = (item.name + " (Inventory)").ToLower();
        if (obj!=null && obj.name.ToLower() == ItemName)
        {
            SpawnObj();
        }
        else
        {
            this.enabled = false;
        }
    }
    void SpawnObj()
    {
        GameObject Obj = Instantiate(SpawnedItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
        this.enabled = false;
    }
}
