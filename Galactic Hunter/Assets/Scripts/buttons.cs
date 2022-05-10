using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    private transition trans;

    private void Start()
    {
        trans = GameObject.Find("Pixel Fadeout").GetComponent<transition>();
    }

    public void Difficulty(float health)
    {
        GameObject.Find("Game Manager").GetComponent<gameManager>().difficulty = health;

        StartCoroutine(trans.LoadLevel(1));
    }

    public void RestartGame()
    {
        StartCoroutine(trans.LoadLevel(1));
    }

    public void Menu()
    {
        StartCoroutine(trans.LoadLevel(0));
    }

    public void Loss()
    {
        StartCoroutine(trans.WinLoss(2));
    }

    public void Win()
    {
        StartCoroutine(trans.WinLoss(3));
    }
}
