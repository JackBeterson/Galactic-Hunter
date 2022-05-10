using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] typeOfEnemys;
    public float spawnInterval;
}

public class waveSpawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private Vector2 spawnJitter;
    [SerializeField] private Text txt;
    [SerializeField] private Image img;
    [SerializeField] private Color col;
    [SerializeField] private Animator camAnimator;
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private GameObject bossBar;

    private Wave currentWave;
    private int currentWaveNumber = 0;

    private bool bossStarted = false;
    public bool canSpawn = true;
    private float nextSpawnTime;

    private void Start()
    {
        currentWave = waves[currentWaveNumber];

        canSpawn = true;

        txt.text = currentWave.waveName;
        StartCoroutine(WaveFadeout());
        Invoke("FadeoutReset", 4.5f);
    }

    void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("enemy");

        if (waves[currentWaveNumber].waveName == "Boss Wave" && totalEnemies.Length == 6 && !bossStarted)
        {
            BossWave();
        }
    }

    public void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemys[Random.Range(0, currentWave.typeOfEnemys.Length)];
            Vector2 spawnPos = transform.position;
            spawnPos += Vector2.up * spawnJitter.y * (Random.value - 0.5f);
            spawnPos += Vector2.right * spawnJitter.x * (Random.value - 0.5f);

            Instantiate(randomEnemy, spawnPos, Quaternion.identity);
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
                SpawnNextWave();
            }
        }
    }

    public void SpawnNextWave()
    {
        currentWaveNumber++;
        
        if (waves[currentWaveNumber].waveName != "Boss Wave")
        {
            canSpawn = true;

            txt.text = waves[currentWaveNumber].waveName;
            StartCoroutine(WaveFadeout());
            Invoke("FadeoutReset", 4.5f);
        }
    }

    private void BossWave()
    {
        camAnimator.Play("To Boss Fight");
        bossAnimator.Play("Start Boss Fight");
        bossBar.SetActive(true);

        bossStarted = true;

        txt.text = waves[currentWaveNumber].waveName;
        StartCoroutine(WaveFadeout());
        Invoke("FadeoutReset", 4.5f);
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
