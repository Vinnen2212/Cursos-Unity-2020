using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading, 
        inGame,
        gameOver
    }



    public static GameState gameState;
    
    public List<GameObject> targetPrefab;
    bool inGame = true;
    float waitTime = 1f;

    public TextMeshProUGUI textScore;
    private int score;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(waitTime);
            int index = Random.Range(0, targetPrefab.Count);
            Instantiate(targetPrefab[index]);
        }
    }

    /// <summary>
    /// Añade puntos a la puntuacion global y la muestra en pantalla.
    /// </summary>
    /// <param name="scoreToAdd"> int puntuacion a añadir </param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score < 0)
        {
            score = 0;
        }
        textScore.text = "Score: \n" + score;
        
    }
/// <summary>
/// Metodo para activar el texto de Game Over
/// </summary>
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameState = GameState.gameOver;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
