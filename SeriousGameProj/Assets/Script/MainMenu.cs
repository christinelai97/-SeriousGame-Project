using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    bool invisible = false; 
    bool buttonPressed = false;
    GameObject PauseMenu;
    void Start(){
            PauseMenu = GameObject.Find("PauseMenu");
    }
    void FixedUpdate(){
           
    }
    public void OnPress(){
        GameObject.Destroy(PauseMenu);
        SceneManager.LoadScene("MainMenu");
    }

}
