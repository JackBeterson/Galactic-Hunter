using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawner : MonoBehaviour
{
    //Wave
    [SerializeField] private Text txt;
    private float wave = 1f;
    private float waveTimer = 10f;
    private float wIntervals = 10f;

    //Spawn Enemy
    private bool spawnStarted = true;
    private float spawnTimer = 4f;
    private float sIntervals = 4f;
    public float numEnemys = 0f;
    public Vector2 spawnJitter;
    public GameObject enemy;

    void Start()
    {
        
    }

    void Update()
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

    private void EndWave()
    {
        spawnStarted = false;
    }

    private void StartWave()
    {
        waveTimer = wIntervals;
        wave += 1;
        txt.text = wave.ToString();
        spawnStarted = true;
        Debug.Log("start");
        
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
        GetComponent<enemySpawner>().enabled = false;
    }
}
