using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject item;

    void Start()
    {
        //finds the GameObject with the tag "Player"
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
    }

    //this activates when the player collides with an object that is in trigger mode
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks for the player tag
        if (other.CompareTag("Player"))
        {

            //repeats the process the number of inventory slots avaleable
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                //checks if the inventory selected is full or not
                if (inventory.isFull[i] == false)
                {
                    //makes the inventory slot currently selected (full)
                    inventory.isFull[i] = true;
                    //this instantiates/creates the sprite in the inventory box
                    GameObject obj=Instantiate(item, inventory.slots[i].transform, false);
                    //this destroys the item that collided with the player
                    Destroy(gameObject);
                    //breaks the process for it to not repeat forever
                    break;
                }
            }
        }
    }
}
