using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    float score = 0;
    public static GameManager inst;


    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] NewPlatforms newPlatforms;
    [SerializeField] EnemySpawn enemySpawn;
    [SerializeField] HealthSpawn healthSpawn;

    [SerializeField] GameObject planePrefab;
    [SerializeField] GameObject enemyPrefab;

    public void Update()
    {
        score += 1 * Time.deltaTime;
        scoreText.text = new string("Score:") + ((int)score).ToString();

        if (score > 10 && score < 20)
        {
            newPlatforms.SpawnTimer = 8;
            playerHealth.EnemyDamage = 2;
            playerHealth.Healing = 4;
            enemyPrefab.GetComponent<EnemyHealth>().BulletDamage = 4;
            enemySpawn.spawnFrequency = 1f;
            enemySpawn.maxEnemies = 3;
            healthSpawn.spawnFrequency = 6f;
            planePrefab.GetComponent<DestroyPlane>().Timer = 12f;
            enemyPrefab.GetComponent<zombie>().speed = 6f;
        }
        if (score > 20 && score < 30)
        {
            newPlatforms.SpawnTimer = 6f;
            playerHealth.EnemyDamage = 3;
            playerHealth.Healing = 3;
            enemyPrefab.GetComponent<EnemyHealth>().BulletDamage = 4;
            enemySpawn.spawnFrequency = 1f;
            enemySpawn.maxEnemies = 4;
            healthSpawn.spawnFrequency = 7f;
            planePrefab.GetComponent<DestroyPlane>().Timer = 9f;
            enemyPrefab.GetComponent<zombie>().speed = 7f;
        }
        if (score > 30)
        {
            newPlatforms.SpawnTimer = 4f;
            playerHealth.EnemyDamage = 5;
            playerHealth.Healing = 2;
            enemyPrefab.GetComponent<EnemyHealth>().BulletDamage = 4;
            enemySpawn.spawnFrequency = 1f;
            enemySpawn.maxEnemies = 5;
            healthSpawn.spawnFrequency = 10f;
            planePrefab.GetComponent<DestroyPlane>().Timer = 6f;
            enemyPrefab.GetComponent<zombie>().speed = 8f;
        }
    }
    
    private void Awake()
    {
        inst = this;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
