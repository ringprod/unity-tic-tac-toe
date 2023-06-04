using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#if false
public class TicTacToeLogic : MonoBehaviour
{
    public TMP_Text currentPlayerText;

    private int currentPlayer = 1;

    private bool hasPlayerPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (currentPlayer == 1)
        {
            currentPlayerText.text = "Current Player: " + "X";
        }
        else if (currentPlayer == 0)
        {
        currentPlayerText.text = "Current Player: " + "O";
        }
        else
        {
            currentPlayerText.text = "Pick Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayer == 1)
        {
            currentPlayerText.text = "Current Player: " + "X";
        }
        else if (currentPlayer == 0)
        {
            currentPlayerText.text = "Current Player: " + "O";
        }
        else
        {
            currentPlayerText.text = "Pick Player";
        }
    }
}
#endif