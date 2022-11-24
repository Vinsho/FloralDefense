using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCounter;
    [SerializeField] TextMeshProUGUI notifications;
    [SerializeField] TextMeshProUGUI nextWaveCounter;
    [SerializeField] TextMeshProUGUI seedlingsAmount;
    [SerializeField] TextMeshProUGUI manaAmount;
    [SerializeField] TextMeshProUGUI bloodAmount;
    [SerializeField] TextMeshProUGUI goldAmount;
    [SerializeField] TextMeshProUGUI silverAmount;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject targetCanvas;
    [SerializeField] Slider playerHealthBar;
    [SerializeField] Slider castBar;
    [SerializeField] Slider xpBar;
    [SerializeField] TextMeshProUGUI xpBarText;
    [SerializeField] Canvas loseScreen;

    [SerializeField] int notificationDuration;

    private Image targetImage;
    private Slider targetHealthBar;
    private TextMeshProUGUI targetHealthText;
    private TextMeshProUGUI playerHealthText;

    void Start()
    {
        targetImage = targetCanvas.GetComponentInChildren<Image>();
        targetHealthBar = targetCanvas.GetComponentInChildren<Slider>();
        targetHealthText = targetCanvas.GetComponentInChildren<TextMeshProUGUI>();
        playerHealthText = playerHealthBar.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetWaveCount(int waveNum)
    {
        waveCounter.text = "Wave " + (waveNum + 1);
    }

    public void SendNotification(string notification)
    {
        StartCoroutine(SendNotificationRoutine(notification));
    }

    public void SetNextWaveCounter(int seconds)
    {
        int minutes = seconds / 60;
        seconds = seconds % 60;
        nextWaveCounter.text = "Next in: " + minutes + ":";

        if (seconds < 10)
        {
            nextWaveCounter.text += "0";
        }

        nextWaveCounter.text += seconds.ToString();
    }

    public void SetNewTarget(Sprite newTargetSprite)
    {
        targetCanvas.gameObject.SetActive(true);
        targetImage.sprite = newTargetSprite;
    }

    public void SetTargetHealth(float currentHealth, float maxHealth)
    {
        targetHealthBar.value = currentHealth / maxHealth;
        targetHealthText.text = System.Math.Round(currentHealth, 2) + "/" + maxHealth;

    }

    public void UnsetTarget()
    {
        targetCanvas.gameObject.SetActive(false);
    }

    public void SetPlayerHealth(float currentHealth, float maxHealth)
    {
        playerHealthBar.value = currentHealth / maxHealth;
        playerHealthText.text = System.Math.Round(currentHealth, 2) + "/" + maxHealth;
    }

    public void ToggleCastBar(bool enabled)
    {
        castBar.gameObject.SetActive(enabled);
        SetCastBar(0f);
    }

    public void SetCastBar(float value)
    {
        castBar.value = value;
    }

    public void SetResources(int seedlings, int mana, int blood)
    {
        seedlingsAmount.text = seedlings.ToString();
        manaAmount.text = mana.ToString();
        bloodAmount.text = blood.ToString();
    }

    private IEnumerator SendNotificationRoutine(string notification)
    {
        notifications.text = notification;
        yield return new WaitForSecondsRealtime(notificationDuration);
        notifications.text = "";
    }

    public void SetCoins(int amount)
    {
        goldAmount.text = (amount / 100).ToString();
        silverAmount.text = (amount % 100).ToString();
    }

    public void SetXp(int xp, int xpNeeded)
    {
        xpBar.value = (float)xp / (float)xpNeeded;
        xpBarText.text = xp + "/" + xpNeeded;
    }

    public void SetPlayerLevel(int lvl)
    {
        levelText.text = lvl.ToString();
    }

    public void ShowLoseScreen()
    {
        loseScreen.gameObject.SetActive(true);
    }
}
