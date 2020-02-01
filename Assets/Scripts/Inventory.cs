using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //this says if the current inventory space is occupied or not.
    public bool[] isFull;

    //this is the amount of slots the inventory has.
    public GameObject[] slots;
}
