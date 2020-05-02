using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameControl : MonoBehaviour {
    public GameObject[] Inventory = new GameObject[5];
    public GameObject ConfirmationObj;
    public static GameControl control;
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}
