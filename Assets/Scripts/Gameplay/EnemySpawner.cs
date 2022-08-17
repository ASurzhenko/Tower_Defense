using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Wave_SO[] wave_SO;
    [SerializeField] Transform spawnPoint;
    List<GameObject> enemies = new List<GameObject>(); 
    int currentWaveIndex;
    float waveTimer;
    bool stopTimer = true;
    GameObject lastEnemy;
    public void StartSpawn()
    {
        stopTimer = false;
        InvokeRepeating("Spawn", 2, 2);
    }
    private void OnEnable() {
        UIManager.OnGameOver += () => CancelInvoke("Spawn");
    }
    private void OnDisable() {
        UIManager.OnGameOver -= () => CancelInvoke("Spawn");
    }
    void Update()
    {
        if (stopTimer) return;
        
        waveTimer += Time.deltaTime;
        if(waveTimer > wave_SO[currentWaveIndex].Duration)
        {
            if(currentWaveIndex + 1 < wave_SO.Length)
            {
                currentWaveIndex++;
                waveTimer = 0;
            }
            else
            {
                stopTimer = true;
                CancelInvoke("Spawn");
                StartCoroutine(WaitForTheLastEnemy());
            }
        }
    }
    IEnumerator WaitForTheLastEnemy()
    {
        if(lastEnemy != null)
        {
            yield return new WaitUntil(() => !lastEnemy.activeInHierarchy);
            yield return new WaitForSeconds(0.5f);
            if(PData.PlayerHealth > 0)
                UIManager.Instance.ShowWinPanel();
        }
    }
    void Spawn()
    {
        UIManager.Instance.ShowWaveText(currentWaveIndex + 1, wave_SO.Length);
        EnemyFactory factory = GetFactory(wave_SO[currentWaveIndex]);
        GameObject enemy = GetEnemyFromPool(factory); 
        enemy.GetComponent<Enemy>().SetUp(factory.GetEnemy());
        lastEnemy = enemy;
    }
    GameObject GetEnemyFromPool(EnemyFactory factory)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(!enemies[i].activeInHierarchy && enemies[i].GetComponent<Enemy>().Id == factory.GetEnemy().GetEnemyPrefab().GetComponent<Enemy>().Id)
            {
                enemies[i].transform.position = spawnPoint.position;
                enemies[i].SetActive(true);
                return enemies[i];
            }
        }

        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(0, 180, 0, 1);

        GameObject enemy = Instantiate(factory.GetEnemy().GetEnemyPrefab(), spawnPoint.position, newQuaternion);
        enemies.Add(enemy);
        return enemy;
    }

    private static EnemyFactory GetFactory(Wave_SO wave)
    {
        return new CurrentEnemyFactory(wave);
    }
}
