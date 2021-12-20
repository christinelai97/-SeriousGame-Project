using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIncrementScore : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(AddPoints);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        Player.GetComponent<ScoreTracker>().IncrementScore();
    }
}
