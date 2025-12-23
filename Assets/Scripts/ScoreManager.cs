using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

        // Подписка на смену сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (!isCounting) return;

        // Счёт идёт только на игровой сцене
        if (SceneManager.GetActiveScene().name == "SampleScene")
            AddPoints(Time.deltaTime * scorePerSecond);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Если вернулись в главное меню — останавливаем счёт
        if (scene.name == "MainMenu")
        {
            isCounting = false;
            SaveHighScore();
        }
        else if (scene.name == "SampleScene")
        {
			ResetScore();
            isCounting = true;
        }

        // После смены сцены пробуем найти новые UI элементы
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();
        highScoreText = GameObject.Find("HighScoreText")?.GetComponent<TMP_Text>();
        UpdateScoreUI();
        UpdateHighScoreUI();
    }

    public void AddPoints(float points)
    {
        score += points;
        if (score < 0) score = 0;
        if (score > highScore)
		{
			highScore = Mathf.RoundToInt(score);
			PlayerPrefs.SetInt("HighScore", highScore);
			PlayerPrefs.Save();
			UpdateHighScoreUI();
		}
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
