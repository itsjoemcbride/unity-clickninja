using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    public float spawnRate = 1.0f;
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    public bool isGameActive = false;
    [SerializeField] private GameObject titleScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(spawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
    }

    IEnumerator spawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, 4);
            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreText.text = "Score: " + (score += scoreToAdd);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
