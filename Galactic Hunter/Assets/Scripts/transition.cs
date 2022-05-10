using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    private Animator animator;
    private Camera sceneCam;
    private GameObject canvas;
    
    void Start()
    {
        canvas = GameObject.Find("Pixel Fadeout");
        animator = canvas.GetComponent<Animator>();

        sceneCam = FindObjectOfType<Camera>();
        canvas.GetComponent<Canvas>().worldCamera = sceneCam;
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        canvas = GameObject.Find("Pixel Fadeout");
        animator = canvas.GetComponent<Animator>();

        animator.Play("CrossFade_Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }

    public IEnumerator WinLoss(int levelIndex)
    {
        canvas = GameObject.Find("Pixel Fadeout");
        animator = canvas.GetComponent<Animator>();

        yield return new WaitForSeconds(1f);

        animator.Play("CrossFade_Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}
