using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseButton;
    public GameObject pausePanel;
    public Button resumeButton;
    public Button mainMenuButton;

    private bool isPaused = false;
    private bool canPause = true;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        if (!canPause) return;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void SetAllowPause(bool allow)
    {
        canPause = allow;
        if (!allow)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            pauseButton.SetActive(false);
        }
    }
}
