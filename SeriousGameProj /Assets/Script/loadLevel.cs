using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadLevel : MonoBehaviour{

    SpriteRenderer[] spriteRendereres;
    float counter = 0;

    // Start is called before the first frame update
    void Start(){
        
        Transform list = GameObject.Find("SceneObjects").GetComponent<Transform>();
        spriteRendereres = new SpriteRenderer[list.childCount];
        for(int i = 0; i < list.childCount; i++){
            spriteRendereres[i] = list.GetChild(i).GetComponent<SpriteRenderer>();
        }

        foreach(SpriteRenderer a in spriteRendereres){
            a.color = new Color(a.color.r,a.color.g,a.color.b,0);
        }
    }

    // Update is called once per frame
    void Update(){
        
    }

    void FixedUpdate(){
        if(counter<=1.5){
            foreach(SpriteRenderer a in spriteRendereres){
            a.color = new Color(a.color.r,a.color.g,a.color.b,counter);
        }
        counter+= .05f;
        }
    }
}
