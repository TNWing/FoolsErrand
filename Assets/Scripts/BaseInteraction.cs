using UnityEngine;

public class BaseInteraction : MonoBehaviour {
    public string Scriptname;
    void OnEnable()
    {
        (GetComponent(Scriptname) as MonoBehaviour).enabled = true;
        this.enabled = false;
    }
    //so the flow is this: player presses spacebar->gameobject is spawned->gameobject's "interaction" script activates "base interaction" script->this script activates another script
    //an alternative way to do this would be to ditch this script entirely and create new layers/tags and have objects have children gameobjects where the scripts are attached
}
