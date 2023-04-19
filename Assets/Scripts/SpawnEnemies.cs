using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnSpots;
    [SerializeField] private GameObject Enemyprefabs;
    private float SpawnTime = 1f;
    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InitializeEnemyPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = Instantiate(Enemyprefabs);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int RandomIndex = Random.Range(0, SpawnSpots.Length);
            Vector3 SpawnPos = SpawnSpots[RandomIndex].transform.position;
            SpawnEnemyMark(SpawnPos);
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    void SpawnEnemyMark(Vector3 enemy)
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemyObj = enemyPool.Dequeue();
            enemyObj.transform.position = enemy;
            enemyObj.SetActive(true);
        }
        else
        {
            GameObject enemyObj = Instantiate(Enemyprefabs);
            enemyObj.transform.position = enemy;
            enemyPool.Enqueue(enemyObj);
        }
    }
}
