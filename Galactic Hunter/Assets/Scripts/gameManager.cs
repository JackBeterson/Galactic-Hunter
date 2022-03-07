using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public void RestartLevel()
    {
        Debug.Log("restar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
