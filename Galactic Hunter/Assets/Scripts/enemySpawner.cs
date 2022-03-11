using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawner : MonoBehaviour
{
    //Wave
    [SerializeField] private Text txt;
    [SerializeField] private Image img;
    [SerializeField] private Color col;
    private float wave = 4f;
    private float waveTimer = 10f;
    private float wIntervals = 10f;

    [SerializeField] private Animator camAnimator;
    [SerializeField] private Animator bossAnimator;
    private bool bossFightStarted = false;

    //Spawn Enemy
    private bool spawnStarted = true;
    private float spawnTimer = 4f;
    private float sIntervals = 4f;
    public float numEnemys = 0f;
    public Vector2 spawnJitter;
    public GameObject enemy;

    void Update()
    {
        if (!bossFightStarted)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else if (spawnStarted && spawnTimer <= 0)
            {
                Spawn();
            }

            if (waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
            }
            else if (waveTimer <= 0)
            {
                EndWave();

                if (numEnemys == 0)
                {
                    StartWave();
                }
            }
        }
    }

    private void EndWave()
    {
        spawnStarted = false;
    }

    private void StartWave()
    {
        waveTimer = wIntervals;
        wave += 1;
        txt.text = ("WAVE " + wave.ToString());
        spawnStarted = true;
        StartCoroutine(WaveFadeout());
        Invoke("FadeoutReset", 4.5f);

        if (wave == 5)
        {
            BossWave();
        }
    }

    private void Spawn()
    {
        spawnTimer = sIntervals;
        Vector2 spawnPos = transform.position;
        spawnPos += Vector2.up * spawnJitter.y * (Random.value - 0.5f);
        spawnPos += Vector2.right * spawnJitter.x * (Random.value - 0.5f);
        Instantiate(enemy, spawnPos, transform.rotation);
        numEnemys += 1;
    }

    public void EnemyDead()
    {
        numEnemys -= 1;
    } 

    private void BossWave()
    {
        bossFightStarted = true;
        txt.text = ("BOSS WAVE");
        camAnimator.Play("To Boss Fight");
        bossAnimator.Play("Start Boss Fight");
    }

    private void FadeoutReset()
    {
        StopCoroutine(WaveFadeout());
        img.color = new Color(1f, 1f, 1f, 0f);
        txt.color = col * new Color(1f, 1f, 1f, 0f);
    }

    IEnumerator WaveFadeout()
    {
        for (int i = 0; i < 3f; i++)
        {
            img.color = Color.white;
            txt.color = col;
            yield return new WaitForSeconds(1f);
            img.color = new Color(1f, 1f, 1f, .5f);
            txt.color = col * new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(.5f);
        }
    }
}
