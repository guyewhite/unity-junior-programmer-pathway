using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

  public List<GameObject> targets;
  public GameObject[] targets2;

  public TextMeshProUGUI gameOverText;

  public bool isGameActive;

  public Button restartButton;

  private GameManager gameManager;

  // UI
  private int score;
  public TextMeshProUGUI scoreText;
  public GameObject titleScreen;

  private float spawnRate = 1.0f;
  // Start is called before the first frame update
  void Start()
  {
    

  }

  // Update is called once per frame
  void Update()
  {

  }

  IEnumerator SpawnTarget()
  {
    while (isGameActive)
    {
      yield return new WaitForSeconds(spawnRate);
      int index = Random.Range(0, targets.Count);
      Instantiate(targets[index]);
    }
  }

  public void UpdateScore(int scoreToAdd)
  {
    score += scoreToAdd;
    scoreText.text = "Score: " + score;
  }

  public void GameOver()
  {
    restartButton.gameObject.SetActive(true);
    gameOverText.gameObject.SetActive(true);
    isGameActive = false;
  }

  private void OnTriggerEnter(Collider other)
  {
    Destroy(gameObject);
    if (!gameObject.CompareTag("Bad"))
    {
      gameManager.GameOver();
    }
  }

  public void RestartGame()
  {
    // Reload the current scene
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void StartGame(int difficulty)
  {

    // Set Game as Active
    isGameActive = true;

    StartCoroutine(SpawnTarget());

    // UI
    score = 0;
    UpdateScore(0);
    spawnRate = spawnRate / difficulty;

    titleScreen.gameObject.SetActive(false);
  }
}
