using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    public void PlayGame()
    {
        if (buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);

        Invoke(nameof(LoadGameScene), 0.15f);
    }

    public void ExitGame()
    {
        if (buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);

        Invoke(nameof(QuitGame), 0.15f);
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}