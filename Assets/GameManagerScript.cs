using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameOverText;
    private bool gameOverFlag = false;
    public AudioSource hitAudioSource;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    int gameTimer = 0;
    public GameObject bombParticle;
    public bool IsGameOver()
    {
        return gameOverFlag;
    }

    public void Hit(Vector3 position)
    {
        score += 1;
        Instantiate(bombParticle, position, Quaternion.identity);
        hitAudioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE" + score;

        if(gameOverFlag == true)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    void FixedUpdate()
    {
        gameTimer++;
        int max = 50 - gameTimer / 100;
        int r = Random.Range(0, max);
        if(r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            if(gameOverFlag == true )
            {
                return;
            }
            Instantiate(enemy, new Vector3(x, 0.0f, 15), Quaternion.identity);
        }
    }

    public void GameOverStart()
    {
        gameOverFlag = true;
        gameOverText.SetActive(true);
    }
}
