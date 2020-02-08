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
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<SpriteRenderer>().sprite == null || GetComponent<SpriteRenderer>().sprite.name != thisObject.mySprite)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + thisObject.mySprite);
        }
	}
}