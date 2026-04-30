using TMPro;

using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI killCountText;
    public int kills = 0;

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
    private void Update()
    {
        UpdateKillCount();
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
}
