using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;
    public float ringSpeed = 3f;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public GameObject gameOverPanel;

    public AudioSource audioSource;
    public AudioClip successSound;
    public AudioClip missSound;
    public AudioClip gameOverSound;

    public GameObject successParticlesPrefab;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();

        if(gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void AddScore()
    {
        score++;

        if (score %5 == 0)
        {
            ringSpeed += 0.5f;
        }
        if (successSound != null)
            audioSource.PlayOneShot(successSound);
        CameraShake.Instance.Shake(0.08f, 0.04f);

        UpdateUI();

    }

    public void LoseLife()
    {
        lives--;

        if (missSound != null)
            audioSource.PlayOneShot(missSound);

        NeedleController needle = FindFirstObjectByType<NeedleController>();

        if (needle != null)
        {
            StartCoroutine(needle.FlashHit());
        }

        CameraShake.Instance.Shake(0.12f, 0.08f);

        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverSound != null)
            audioSource.PlayOneShot(gameOverSound);
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    public void SpawnSuccessParticles(Vector3 position)
    {
        if (successParticlesPrefab != null)
        {
            Destroy(Instantiate(successParticlesPrefab, position, Quaternion.identity), 1f);
        }
    }
}
