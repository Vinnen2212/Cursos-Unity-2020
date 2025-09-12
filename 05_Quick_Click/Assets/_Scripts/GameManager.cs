using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefab;
    bool inGame = true;
    float waitTime = 1f;

    public TextMeshProUGUI textScore;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (inGame)
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
}
