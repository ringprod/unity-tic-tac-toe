using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
