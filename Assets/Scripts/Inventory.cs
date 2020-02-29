using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    Transform Inv;
    KeyCode[] keys = new KeyCode[5];
    public int selectedslot;

    public Color defaultcolor, selectedcolor;
    void Start()
    {
        Inv = GameObject.Find("Inventory").transform;
        Inv.GetChild(0).gameObject.GetComponent<Image>().color = selectedcolor;
        
        keys[0] = KeyCode.Alpha1;
        keys[1] = KeyCode.Alpha2;
        keys[2] = KeyCode.Alpha3;
        keys[3] = KeyCode.Alpha4;
        keys[4] = KeyCode.Alpha5;
    }
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                if (selectedslot == i)
                {
                    selectedslot = 9;
                    Inv.GetChild(i).gameObject.GetComponent<Image>().color = defaultcolor;
                }
                else
                {
                    selectedslot = i;
                    var obj = Inv.GetChild(i).gameObject;
                    obj.GetComponent<Image>().color = selectedcolor;
                    for (int c = 0; c < 5; c++)
                    {
                        if (c != i)
                        {
                            var slot = Inv.GetChild(c).gameObject;
                            slot.GetComponent<Image>().color = defaultcolor;
                        }
                    }
                }
                break;
            }
        }
    }
    
}
