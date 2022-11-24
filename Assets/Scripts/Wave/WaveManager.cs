using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<WaveSO> waves = new List<WaveSO>();
    public int waveDuration = 30;

    WaveSO currentWave;
    EnemyManager myEnemyManager;
    GUI myGUI;
    int currentWaveIndex;

    private void Start()
    {
        currentWaveIndex = 0;
    }

    // Start is called before the first frame update
    void Awake()
    {
        myEnemyManager = FindObjectOfType<EnemyManager>();
        myGUI = FindObjectOfType<GUI>();
    }

    public void LoadNextWave()
    {
        currentWave = waves[currentWaveIndex];
        StartCoroutine(myEnemyManager.SpawnCreatures(currentWave));
        myGUI.SetWaveCount(currentWaveIndex);
        currentWaveIndex++;
    }
}
