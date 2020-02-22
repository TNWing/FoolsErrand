using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {
    private Inventory inventory;
    public GameObject item;//item needed to destroy gameobject
    public bool isdestroyed;

    public Inventory Inventory;

    public GameObject obj;//item in player inventory
    void Awake()
    {

        Inventory= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void OnEnable() {
        obj = Inventory.slots[Inventory.selectedslot].transform.GetChild(0).gameObject;
        if (!obj && obj.name==item.name)
        {
            SpawnObj();
        }
    }
    void SpawnObj()
    {
        GameObject Obj = Instantiate(item, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
