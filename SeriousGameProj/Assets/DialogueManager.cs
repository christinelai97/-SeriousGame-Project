using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeManager : MonoBehaviour {

    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private bool PlayerSpeakingFirst;

    [SerializeField] private TextMeshProUGUI playerDialougeText;
    [SerializeField] private TextMeshProUGUI nPCDialougeText;

    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject nPCContinueButton;

    [Header("Dialouge Sentences")]
    [TextArea]
    [SerializeField] private string[] playerDialougeSentences;
    [TextArea]
    [SerializeField] private string[] nPCDialougeSentences;

    private Movement playerMovemntScript;

    private bool dialougeStarted;

    private int playerIndex;
    private int nPCIndex;
    private int hell;

     private void Start()
     {

         StartDialouge();
       
     }

    

    

     public void StartDialouge()
     {


         if (PlayerSpeakingFirst)
          {
              StartCoroutine(TypePlayerDialouge());
          }
          else
          {
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

        
      }

      private IEnumerator TypeNPCDialouge()
      {
          foreach (char letter in nPCDialougeSentences[nPCIndex].ToCharArray())
          {
              nPCDialougeText.text += letter;
              yield return new WaitForSeconds(typingSpeed);
          }


      }

    

    



}
