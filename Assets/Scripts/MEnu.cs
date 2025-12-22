using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Panel PauseMenu
    private bool isPaused;

    void Start()
    {
        Time.timeScale = 1f;              // на всякий случай
        pauseMenuUI.SetActive(false);     // скрыто при старте сцены
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Кнопка Continue (из паузы)
    public void ContinueGame()
    {
        Resume();
        SceneManager.LoadScene("SampleScene");
    }

    // Кнопка Main Menu (из паузы)
    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("ManeMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
