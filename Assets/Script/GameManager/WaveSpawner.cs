using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public int CountCall=10;
    public int BossCount;
    public GameObject [] _boss;
    public Text _waveText;
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocation;
    public int spawnIndex;

    public int waveDuration;
    public double waveTimer;
    public double spawnInterval;
    public double spawnTimer;

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
        _waveText.text = currWave.ToString();
        _waveText.text = Mathf.Round(currWave).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTimer <= 0 && DataHolder.StartGame==true)
        {
            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, Quaternion.identity); // spawn first enemy in our list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;


                if (spawnIndex + 1 <= spawnLocation.Length - 1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            else
            {
                waveTimer = 0; // if no enemies remain, end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

        if (waveTimer <= 0 && DataHolder.StartGame == true) // spawnedEnemies.Count <= 0
        {
            currWave++;
            GenerateWave();
            _waveText.text = Mathf.Round(currWave).ToString();

        }
    }

    public void GenerateWave()
    {
        
        waveValue = currWave * 10;
        GenerateEnemies();
        if (currWave== CountCall) 
        {
            GenerateBoss();
            CountCall += 10;
            BossCount++;
        }
        spawnInterval = 2;

        waveTimer = waveDuration; // wave duration is read only
    }
    public void GenerateBoss()
    {
        Instantiate(_boss[BossCount],spawnLocation[Random.Range(0,spawnLocation.Length)]);
    }

    public void GenerateEnemies()
    {
        // Create a temporary list of enemies to generate
        // 
        // in a loop grab a random enemy 
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost.

        // repeat... 

        //  -> if we have no points left, leave the loop

        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
