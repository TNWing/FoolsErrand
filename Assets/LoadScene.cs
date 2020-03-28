using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {

    public int currentscene;
    private void Awake()
    {
        currentscene = SceneManager.GetActiveScene().buildIndex;
    }
    public void Load(){
        SceneManager.LoadScene(currentscene+1);
    }
}
