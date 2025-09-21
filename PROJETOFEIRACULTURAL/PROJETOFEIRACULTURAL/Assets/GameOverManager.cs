using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; 

    public void DisplayScore(float score)
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = "Sua Pontuação: " + Mathf.FloorToInt(score).ToString();
            Debug.Log("Score exibido: " + score);
        }
        else
        {
            Debug.LogWarning("finalScoreText não foi atribuído no nspector");
        }
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
