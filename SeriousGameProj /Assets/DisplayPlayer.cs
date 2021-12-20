using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DisplayPlayer : MonoBehaviour
{

    public TMP_Text Text;
  
    public TMP_InputField display;

    void Start()
    {
        Text.text = PlayerPrefs.GetString("user_name");
    }

    public void Create()
    {
        Text.text = display.text;
        PlayerPrefs.SetString("user_name", Text.text);
        int score = 0;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    public void GetString()
    {
        PlayerPrefs.GetString("Thank you for playing the game", Text.text);
    }
}
