using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ListofItems : MonoBehaviour {
    public TMP_Dropdown Text;
    public GameControl GC;//access the inventory system
	void OnEnable () {
        //Text.AddOptions();
	}
    void OnDisable()
    {
        Text.ClearOptions();
    }
}
