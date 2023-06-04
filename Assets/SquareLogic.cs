using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLogic : MonoBehaviour
{
    //private GameObject board;
    private BoardLogic boardLogic;
    private SpriteRenderer spriteRenderer;

    private int player = -1;

    public int row;
    public int col;

    public GameObject x;
    public GameObject o;

    private Color SelectedColor = new Color(86f / 255f, 227f / 255f, 213f / 255f);
    private Color UnselectedColor = new Color(12f / 255f, 161f / 255f, 146f / 255f);

    // Start is called before the first frame update
    void Start()
    {
        GameObject board = GameObject.Find("board");
        spriteRenderer = GetComponent<SpriteRenderer>();
        boardLogic = board.GetComponent<BoardLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boardLogic.gameOver)
            spriteRenderer.color = UnselectedColor;
    }

    private void OnMouseUp()
    {
        if (!boardLogic.gameOver)
            boardLogic.MakeMove(this);
    }

    private void OnMouseEnter()
    {
        if (!boardLogic.gameOver)
            spriteRenderer.color = SelectedColor;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = UnselectedColor;
    }

    public void SetPosition(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public bool IsEmpty()
    {
        return this.player == -1;
    }

    public void SetPlayer(int p)
    {
        if (p == 1)
        {
            Instantiate(x, transform);
        }
        else if (p == 0)
        {
            Instantiate(o, transform);
        }
        this.player = p;
    }

    public int GetPlayer()
    {
        return this.player;
    }
}
