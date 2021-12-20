using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PersistentData : MonoBehaviour
{
    //[SerializeField] string playerName = "";
    //[SerializeField] int playerScore;
    public static PersistentData Instance;
    [SerializeField] string playerNameText;
    //public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        //playerName = PlayerPrefs.GetString("name");
        //DisplayName();
        //playerName = "";

        //PlayerPrefs.SetString("name", playerName);
        playerNameText = PlayerPrefs.GetString("name");

        //PlayerPrefs.SetString("name", playerName);
        //PlayerPrefs.SetString("name", playerName);
        //DisplayName();
        //playerNameText = PlayerPrefs.GetInt("name");
        // playerScore = 0;
    }

    public void DisplayName()
    {
        playerNameText = "Name: " + playerNameText;
        PlayerPrefs.SetString("name", playerNameText);
        //playerNameText = PlayerPrefs.SetString("name", playerName);
    }

    void Update()
    {

        PlayerPrefs.SetString("name", playerNameText);
        DisplayName();

    }
}