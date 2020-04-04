using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour
{
    public Image TextBox;
    public GameObject Text;
    public PlayerInteraction move;
    public ObjectDataCache ObjectData;
    private Inventory inventory;
    public GameObject item;

    void OnEnable()
    {
        Text = GameObject.Find("Text");
        TextBox = GameObject.Find("TextBox").GetComponent<Image>();
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        OnText();
        GetItem();
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
                Destroy(gameObject);
                break;
            }
        }
        this.enabled = false;
    }

    void OnText()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                ObjectData = GetComponent<ObjectDataCache>();
                Text.GetComponent<TextMeshProUGUI>().text = ObjectData.thisObject.myName + "\n" + ObjectData.thisObject.myDesc;
                TextBox.enabled = true;
                move.CanMove = false;
            }
        }

    }
}
