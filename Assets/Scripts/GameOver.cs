using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreDisplay.text = "Score: " + finalScore.ToString();
    }
}
