using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour{
    bool invisible = false; 
    bool buttonPressed = false;
    CanvasGroup c;

    void Start(){
           c = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
    }
    void FixedUpdate(){
        if(buttonPressed){
        if(c.alpha!=0) c.alpha -= .05f;
        else invisible = true;

        if(invisible)  SceneManager.LoadScene("Level 1");
        }

        
    }
    
    public void OnPress(){
        buttonPressed = true; 
    }
}
