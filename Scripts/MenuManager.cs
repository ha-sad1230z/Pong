using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI References")]
    public Image titleImage;
    public Button playButton;
    public Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}