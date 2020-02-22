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

	
	//// Update is called once per frame
	//void Update () {
 //       if (GetComponentInChildren<SpriteRenderer>().sprite == null || GetComponentInChildren<SpriteRenderer>().sprite.name != thisObject.mySprite)
 //       {
 //           GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + thisObject.mySprite);
 //       }
	//}
}