using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Play);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Play()
    {
        Time.timeScale = 1f;
    }
}
