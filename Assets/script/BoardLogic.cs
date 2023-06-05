using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// player 0: o
// player 1: x

public class BoardLogic : MonoBehaviour
{
    public GameObject square;
    public TMP_Text currentPlayerText;
    private SquareLogic[,] squareObjects = new SquareLogic[3, 3];
    private int currentPlayer = 1;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        // Instantiate the squares and set their positions
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                GameObject cell = Instantiate(square, transform);
                cell.transform.position = new Vector3(row - 1, col - 1, 0);

                SquareLogic squareScript = cell.GetComponent<SquareLogic>();
                if (squareScript != null)
                {
                    squareScript.SetPosition(row, col);
                }

                squareObjects[row, col] = squareScript;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.gameOver)
            UpdateText();
    }

    public void MakeMove(SquareLogic square)
    {
        if (square.IsEmpty())
        {
            square.SetPlayer(currentPlayer);

            squareObjects[square.row, square.col] = square;

            currentPlayer = (currentPlayer == 1) ? 0 : 1;

            int winningPlayer = CheckWhichPlayerWon();

            if (winningPlayer == 1)
            {
                currentPlayerText.text = "X Won!";
                gameOver = true;
            }
            else if (winningPlayer == 0)
            {
                currentPlayerText.text = "O Won!";
                gameOver = true;
            }
            else if (winningPlayer == -2)
            {
                currentPlayerText.text = "Tie";
                gameOver = true;
            }
        }
        //PrintBoard();
    }

    public void UpdateText()
    {
        if (currentPlayer == 1)
        {
            currentPlayerText.text = "Current Player: X";
        }
        else if (currentPlayer == 0)
        {
            currentPlayerText.text = "Current Player: O";
        }
        else
        {
            currentPlayerText.text = "Pick Player";
        }
    }

    public int CheckWhichPlayerWon()
    {
        // Check rows
        for (int row = 0; row < 3; row++)
        {
            if (squareObjects[row, 0].GetPlayer() != -1 &&
                squareObjects[row, 0].GetPlayer() == squareObjects[row, 1].GetPlayer() &&
                squareObjects[row, 0].GetPlayer() == squareObjects[row, 2].GetPlayer())
            {
                return squareObjects[row, 0].GetPlayer(); // Return the player who won
            }
        }

        // Check columns
        for (int column = 0; column < 3; column++)
        {
            if (squareObjects[0, column].GetPlayer() != -1 &&
                squareObjects[0, column].GetPlayer() == squareObjects[1, column].GetPlayer() &&
                squareObjects[0, column].GetPlayer() == squareObjects[2, column].GetPlayer())
            {
                // A player has won
                return squareObjects[0, column].GetPlayer();
            }
        }

        // Check diagonals
        if (squareObjects[0, 0].GetPlayer() != -1 &&
            squareObjects[0, 0].GetPlayer() == squareObjects[1, 1].GetPlayer() &&
            squareObjects[0, 0].GetPlayer() == squareObjects[2, 2].GetPlayer())
        {
            // A player has won
            return squareObjects[0, 0].GetPlayer();
        }
        if (squareObjects[2, 0].GetPlayer() != -1 &&
            squareObjects[2, 0].GetPlayer() == squareObjects[1, 1].GetPlayer() &&
            squareObjects[2, 0].GetPlayer() == squareObjects[0, 2].GetPlayer())
        {
            // A player has won
            return squareObjects[2, 0].GetPlayer();
        }
        bool isFull = true;
        for (int column = 0; column < 3; column++)
        {
            for (int row = 0; row < 3; row++)
            {
                if (squareObjects[row, column].GetPlayer() == -1)
                {
                    isFull = false;
                }

            }
        }
        if (isFull)
            return -2;


        // No winner yet
        return -1;
    }

    public void PrintBoard()
    {
        string boardString = "";
        for (int col = 2; col >= 0; col--)
        {
            for (int row = 0; row < 3; row++)
            {
                int player = squareObjects[row, col].GetPlayer();
                string symbol = (player == 1) ? "X" : (player == 0) ? "O" : "-";
                boardString += symbol + " ";
            }
            boardString += "\n";
        }
        Debug.Log("Current Board State:\n" + boardString);
    }


}
