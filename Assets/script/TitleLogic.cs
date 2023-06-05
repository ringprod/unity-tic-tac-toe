using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleLogic : MonoBehaviour
{
    public TMP_Text title;
    public float timeRemaining = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            if (timeRemaining < 29.5 && timeRemaining > 28.5)
                title.text = "Tic-Tac-Toe!";
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            title.text = "Tic-Tac-Toes!";
            timeRemaining = 30;
            Debug.Log("Done");
        }
    }
}
