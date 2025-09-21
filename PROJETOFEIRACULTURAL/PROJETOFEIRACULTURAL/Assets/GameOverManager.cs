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
            finalScoreText.text = "Sua Pontua��o: " + Mathf.FloorToInt(score).ToString();
            Debug.Log("Score exibido: " + score);
        }
        else
        {
            Debug.LogWarning("finalScoreText n�o foi atribu�do no nspector");
        }
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
