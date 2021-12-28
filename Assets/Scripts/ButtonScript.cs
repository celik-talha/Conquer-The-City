using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void endToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void endToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void menuToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
