using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Sprite[] livesSprites;
    [SerializeField] private Image livesImg;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + 0;
        gameOverText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore;

    }

    public void UpdateLives(int currentLives)
    {
        livesImg.sprite = livesSprites[currentLives];
        if (currentLives == 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

  
}
