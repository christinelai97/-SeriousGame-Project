using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testing : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private bool PlayerSpeakingFirst;

    [SerializeField] private TextMeshProUGUI playerDialougeText;
    [SerializeField] private TextMeshProUGUI nPCDialougeText;

    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject nPCContinueButton;

    [Header("Animation Controllers")]
    [SerializeField] private Animator playerSpeechBubbleAnimator;
    [SerializeField] private Animator nPCSpeechBubbleAnimator;

    [Header("Dialouge Sentences")]
    [TextArea]
    [SerializeField] private string[] playerDialougeSentences;
    [TextArea]
    [SerializeField] private string[] nPCDialougeSentences;

    

    private Movement playerMovementScript;
    private MovementAI aIMovement;
    private bool dialougeStarted;
    private int playerIndex;
    private int nPCIndex;

    private float speechBubbleAnimationDelay = 0.6f;
    private int hell;
    

     private void Start()
     {

         playerMovementScript = FindObjectOfType<Movement>();

         aIMovement = FindObjectOfType<MovementAI>();

       
     }
     public void TriggerStartDialouge()
     {
         StartCoroutine(StartDialouge());
     }

     private void Update ()
     {
         
        if (playerContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TriggerContinueNPCDialouge();
            }
        }

        if (nPCContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TriggerContinuePlayerDialouge();
            }
        }

     }

    

    

     public IEnumerator StartDialouge()
     {

        playerMovementScript.ToggleInteraction();
        aIMovement.ToggleInteraction();
         if (PlayerSpeakingFirst)
          {
              playerSpeechBubbleAnimator.SetTrigger("Open");
              yield return new WaitForSeconds(speechBubbleAnimationDelay);
              StartCoroutine(TypePlayerDialouge());
          }
          else
          {
              nPCSpeechBubbleAnimator.SetTrigger("Open");
              yield return new WaitForSeconds(speechBubbleAnimationDelay);
              StartCoroutine(TypeNPCDialouge());
          }
      }

	  private IEnumerator TypePlayerDialouge()
      {
          foreach (char letter in playerDialougeSentences[playerIndex].ToCharArray())
          {
              playerDialougeText.text += letter;
              yield return new WaitForSeconds(typingSpeed);
           }

        playerContinueButton.SetActive(true);
      }

      private IEnumerator TypeNPCDialouge()
      {
          foreach (char letter in nPCDialougeSentences[nPCIndex].ToCharArray())
          {
              nPCDialougeText.text += letter;
              yield return new WaitForSeconds(typingSpeed);
          }

          nPCContinueButton.SetActive(true);


      }

      private IEnumerator ContinuePlayerDialouge()
      {
        nPCDialougeText.text = string.Empty;

        nPCSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        playerDialougeText.text = string.Empty;

        playerSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay); 


        
        
        if(dialougeStarted){
            playerIndex++;
        }
        else
        {
        dialougeStarted = true; 
        }

        StartCoroutine(TypePlayerDialouge());

        

      }

      private IEnumerator ContinueNPCDialouge()
      {
          
        playerDialougeText.text = string.Empty;

        playerSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        nPCDialougeText.text = string.Empty;

        nPCSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        if(dialougeStarted)
         {
            nPCIndex++;
         }
         else{
             dialougeStarted = true;
            }
            StartCoroutine(TypeNPCDialouge());

          


      }
      public void TriggerContinuePlayerDialouge(){

          nPCContinueButton.SetActive(false);

          if (playerIndex >= playerDialougeSentences.Length - 1)
        {
            nPCDialougeText.text = string.Empty;

            nPCSpeechBubbleAnimator.SetTrigger("Close");
            aIMovement.ToggleInteraction();
            playerMovementScript.ToggleInteraction();

        }
        else
          StartCoroutine(ContinuePlayerDialouge());
      }
      public void TriggerContinueNPCDialouge()
      {
          playerContinueButton.SetActive(false);

          if (nPCIndex >= nPCDialougeSentences.Length - 1)
        {
            playerDialougeText.text = string.Empty;

            playerSpeechBubbleAnimator.SetTrigger("Close");
            playerMovementScript.ToggleInteraction();
            aIMovement.ToggleInteraction();

        }
        else
          StartCoroutine(ContinueNPCDialouge());
      }

    

    



}
