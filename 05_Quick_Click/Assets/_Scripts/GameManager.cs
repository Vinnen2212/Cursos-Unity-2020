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
    public List<GameObject> lifesList;
    float waitTime = 1.5f;

    public TextMeshProUGUI textScore;
    private int score;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titlePanel;
    public int lifes = 4;

    void Start()
    {
        ShowMaxScore();
    }
    
/// <summary>
/// Metodo que inicial el juego, con la dificultad seleccionada cambiando el estado del juego.
/// </summary>
/// <param name="difficulty"> Dificultad seleccionada </param>
    public void StartGame(int difficulty)
    {
        lifes -= difficulty;
        waitTime /= difficulty;
        for (int i = 0; i < lifes; i++)
        {
            lifesList[i].SetActive(true);
        }
        titlePanel.SetActive(false);
        gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
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

    private const string MaxScore = "Max_Score";
/// <summary>
/// Muestra la puntuacion maxima guardada en playerprefs
/// </summary>
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MaxScore , 0);
        textScore.text = "Max. Score: \n" + maxScore;
    }
/// <summary>
/// Si la puntuacion maxima se ha superado guarda la nueva puntuacion. 
/// </summary>
    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MaxScore, 0);

        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MaxScore, score);
        }
    }
/// <summary>
/// Metodo para activar el texto de Game Over
/// </summary>
    public void GameOver()
    {
        lifes--;
        Image heartImage = lifesList[lifes].GetComponent<Image>();
        var tempColor = heartImage.color;
        tempColor.a = 0.3f;
        heartImage.color = tempColor;
        if (lifes <= 0)
        {
            SetMaxScore();
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            gameState = GameState.gameOver;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
