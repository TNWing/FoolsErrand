using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBat : MonoBehaviour {

    public HasBatTutorial finalpart;
    public EndTutorial finalpart2;
    public Inventory inventory;
    public GameObject item;
    void OnEnable()
	{
        inventory= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        finalpart = GameObject.Find("GameControl").GetComponent<HasBatTutorial>();
		finalpart2 = GameObject.Find("Closet (Tutorial2)").GetComponent<EndTutorial>();
		finalpart.HasBat = true;
		finalpart2.HasBat = true;
        GameObject obj = Instantiate(item, inventory.slots[0].transform, false);
        inventory.isFull[0] = true;
        obj.name = obj.name.Replace("(Clone)", "").Trim();
        Destroy(transform.parent.gameObject);
    }
}
