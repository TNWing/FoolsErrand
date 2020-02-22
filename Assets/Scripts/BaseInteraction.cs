using UnityEngine;

public class BaseInteraction : MonoBehaviour {
    public string Scriptname;
    void OnEnable()
    {
        (GetComponent(Scriptname) as MonoBehaviour).enabled = true;
        this.enabled = false;
    }
}
