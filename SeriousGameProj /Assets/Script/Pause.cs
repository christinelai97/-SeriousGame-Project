using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour{
     GameObject PauseMenu;
     SpriteRenderer[] spriteRendereres;
     public static bool active = false; 
     

    bool invisible = false; 
    bool buttonPressed = false;

    Transform list;
    void Awake(){
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start(){
        PauseMenu = GameObject.Find("PauseMenu");
        PauseMenu.transform.GetChild(0).gameObject.SetActive(false);

    
        list = GameObject.Find("SceneObjects").GetComponent<Transform>();
        spriteRendereres = new SpriteRenderer[list.childCount];
        for(int i = 0; i < list.childCount; i++){
            spriteRendereres[i] = list.GetChild(i).GetComponent<SpriteRenderer>();
        }

        
    }

    // Update is called once per frame
    void Update(){
       readPause();
    }

    public void readPause(){
        if(Input.GetKeyDown("escape")){
            if (active) {
                foreach(SpriteRenderer a in spriteRendereres){
                a.color = new Color(a.color.r,a.color.g,a.color.b,1f);
               }
                PauseMenu.transform.GetChild(0).gameObject.SetActive(false);
                Time.timeScale = 1;
                active = false; 
            }
            else {
                PauseMenu.transform.GetChild(0).gameObject.SetActive(true);
                active = true;
                foreach(SpriteRenderer a in spriteRendereres){
                a.color = new Color(a.color.r,a.color.g,a.color.b,.3f);
               }
                Time.timeScale = 0;

            }
        }
    }

    public void resume(){
        active = false; 
        PauseMenu.transform.GetChild(0).gameObject.SetActive(false);
            foreach(SpriteRenderer a in spriteRendereres){
                a.color = new Color(a.color.r,a.color.g,a.color.b,1f);
               }
               Time.timeScale = 1;
    }

    public void mainMenu(){
        GameObject.Destroy(PauseMenu);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
