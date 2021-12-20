using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
   
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private Button button;
    private bool playerInRange;
    private int counter = 0;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        button.gameObject.SetActive(false);

    }
    private void Start()
    {
        button.onClick.AddListener(ClickCounter);
    }


    private void Update()
    {
        if (playerInRange)
        {
            if (counter == 0)
            {
                visualCue.SetActive(true);
                button.gameObject.SetActive(true);
         
            }
        }
        else
        {
            visualCue.SetActive(false);
            button.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {

            playerInRange = true;


        }

       
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            playerInRange = false;

        }
        
    }
    private void ClickCounter()
    {
        counter++;
        button.gameObject.SetActive(false);
        visualCue.SetActive(false);
        Time.timeScale = 0f;
    }

}
