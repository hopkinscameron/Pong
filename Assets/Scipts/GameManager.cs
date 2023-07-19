using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;
    private int aiScore = 0;

    private TextMeshProUGUI playerScoreText;
    private TextMeshProUGUI aiScoreText;

    void Start()
    {
        this.playerScoreText = GameObject.Find("Player Score").GetComponent<TextMeshProUGUI>();
        this.aiScoreText = GameObject.Find("AI Score").GetComponent<TextMeshProUGUI>();
    }

    public void playerScored()
    {
        this.playerScore++;
        this.playerScoreText.text = this.playerScore.ToString();
    }

    public void aiScored()
    {
        this.aiScore++;
        this.aiScoreText.text = this.aiScore.ToString();
    }
}
