using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    WaveManager myWaveManager;
    FlowerManager myFlowerManager;
    GUI myGUI;
    Player player;
    float nextWaveCounter;
    bool started = false;


    void Start()
    {
        nextWaveCounter = 0f;
        player = FindObjectOfType<Player>();
        myWaveManager = FindObjectOfType<WaveManager>();
        myFlowerManager = FindObjectOfType<FlowerManager>();
        myGUI = FindObjectOfType<GUI>();
        StartNextWave();
    }

    void Update()
    {
        started = true;
        if (!player.attributes.IsDead(false) && started)
        {
            DecreaseNextWaveCounter();
        }
    }

    void DecreaseNextWaveCounter()
    {
        nextWaveCounter -= Time.deltaTime;
        if (nextWaveCounter < 0)
        {
            StartNextWave();
        }
        myGUI.SetNextWaveCounter((int)nextWaveCounter);
    }

    public void StartNextWave()
    {
        myWaveManager.LoadNextWave();
        myFlowerManager.IncreaseFlowersAge();
        nextWaveCounter = myWaveManager.waveDuration;
        started = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
