using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public Text scoreLeftText;
    public Text scoreRightText;
    public GameObject gameOverPanel;
    public Image gameEnd;
    
    [Header("Winner Images")]
    public GameObject player1WinImg;
    public GameObject player2WinImg;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hitPaddleClip;
    public AudioClip hitWallClip;
    public AudioClip scorePointClip;
    public AudioClip winSoundClip;

    private int scoreLeft = 0;
    private int scoreRight = 0;
    public int maxScore = 5;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
        gameOverPanel.SetActive(false);
    }
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip);
    }

    public void AddScoreLeft()
    {
        scoreLeft++;
        PlaySound(scorePointClip);
        UpdateScoreUI();
        CheckGameOver();
    }

    public void AddScoreRight()
    {
        scoreRight++;
        PlaySound(scorePointClip);
        UpdateScoreUI();
        CheckGameOver();
    }

    void UpdateScoreUI()
    {
        scoreLeftText.text = scoreLeft.ToString();
        scoreRightText.text = scoreRight.ToString();
    }

    void CheckGameOver()
    {
        if (scoreLeft >= maxScore)
        {
            GameOver(true);
        }
        else if (scoreRight >= maxScore)
        {
            GameOver(false);
        }
        else
        {
            FindObjectOfType<Ball>().LaunchBall();
        }
    }
    void GameOver(bool leftPlayerWin)
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.transform.SetAsLastSibling();
        FindObjectOfType<PauseManager>()?.SetAllowPause(false);
        FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (leftPlayerWin)
        {
            player1WinImg.SetActive(true);
            player2WinImg.SetActive(false);
        }
        else
        {
            player1WinImg.SetActive(false);
            player2WinImg.SetActive(true);
        }
        Time.timeScale = 0f;
        PlaySound(winSoundClip);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}