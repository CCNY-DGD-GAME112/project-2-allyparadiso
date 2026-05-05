using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI healthText;
    public int kills;
    public int maxHealth = 10;
    public int currentHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        kills = 0;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        UpdateKillCount();
        UpdateHealth();
    }


    public void SubtractHealth()
    {
        currentHealth--;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthText.text = "HP: " + currentHealth.ToString();
    }

    public void AddKill()
    {
        kills++;
        UpdateKillCount();
    }

    void UpdateKillCount()
    {
        killCountText.text = "Kills: " + kills.ToString();
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("FinalScore", kills);
        SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
