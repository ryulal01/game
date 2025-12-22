using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best Score: " + bestScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); // Game
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited"); // видно в Editor
    }
}
