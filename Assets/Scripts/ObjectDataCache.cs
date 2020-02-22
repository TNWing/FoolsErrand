using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataCache : MonoBehaviour {

    [System.Serializable]
    public class InteractableData
    {
        public string myName, myDesc, mySprite;
    }

    public InteractableData thisObject;

    // Use this for initialization
    void Start () {
		
	}
}