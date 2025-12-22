using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    [Header("Score Settings")]
    [SerializeField] private float scorePerSecond = 1f;

    private float score;
    private int highScore;
    private bool isCounting = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        UpdateScoreUI();
        UpdateHighScoreUI();
    }

    private void Update()
    {
        if (!isCounting) return;

        AddPoints(Time.deltaTime * scorePerSecond);
    }

    public void AddPoints(float points)
    {
        score += points;
        if (score < 0) score = 0;

        UpdateScoreUI();
    }

    public void ResetScore()
    {
        score = 0;
        isCounting = true;
        UpdateScoreUI();
    }

    public void SaveHighScore()
    {
        int currentScore = Mathf.RoundToInt(score);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {Mathf.RoundToInt(score)}";
    }

    private void UpdateHighScoreUI()
    {
        if (highScoreText != null)
            highScoreText.text = $"High Score: {highScore}";
    }

    public float GetScore() => score;
    public int GetHighScore() => highScore;
}

