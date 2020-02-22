using UnityEngine;

public class ObjectDataCache : MonoBehaviour {

    [System.Serializable]
    public class InteractableData
    {
        public string myName, myDesc, mySprite;
    }

    public InteractableData thisObject;
}