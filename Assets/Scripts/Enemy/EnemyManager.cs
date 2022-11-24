using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] float timeBetweenSpawns = 0.5f;

    List<GameObject> enemies = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnCreatures(WaveSO wave){
        for (int i=0; i<wave.creatureAmount; i++){
            yield return new WaitForSecondsRealtime(timeBetweenSpawns);
            SpawnEnemy(wave.creature);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab){
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint);
        enemies.Add(enemy);
    }

    public void DestroyEnemy(GameObject enemy){
        enemies.Remove(enemy);
        Destroy(enemy);
    }

    public bool NoEnemyAlive(){
        if(enemies.Count == 0){
            return true;
        }
        return false;
    }

    public GameObject GetClosestEnemy(Vector3 position){
        float closestDistance = 1000f;
        GameObject closestEnemy = enemies[0];

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(position, enemy.transform.position);
            if(distance < closestDistance){
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}
