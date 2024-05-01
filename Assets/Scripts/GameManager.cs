using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEditor.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // Game objects to control.
    public GameObject gameOver;
    public GameObject restart;
    public GameObject greenButton;
    public GameObject redButton;

    // Text.
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    // 0 - 2 = knaveria, 3 - 5 = milia, 6 - 8 = witha
    [SerializeField] Sprite[] passportImages;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Characters.
    public Character current = null;
    Character char1 = new Character { allowed = true, country = "Knaveria", bodyType = "pyramidbuff" };
    Character char2 = new Character { allowed = false, country = "Knaveria", bodyType = "pyramidbuff" };
    Character char3 = new Character { allowed = false, country = "Milia", bodyType = "cubechunk" };
    Character char4 = new Character { allowed = false, country = "Withambian", bodyType = "spheretiny" };
    Character char5 = new Character { allowed = true, country = "Milia", bodyType = "cubechunk" };
    Character char6 = new Character { allowed = true, country = "Withambian", bodyType = "spheretiny" };
    List<Character> characters = new List<Character>();

    // Keep track of scores.
    public int score = 0;
    public int highScore = 0;


    public void loadCharacter()
    {
        current = characters.ElementAt(UnityEngine.Random.Range(0, characters.Count()));
        scoreText.text = "Score: " + (score.ToString());
        highScoreText.text = "High: " + (score.ToString());

        PrintPassport();
    }

    public void OnStartButtonPress()
    {
        characters.Add(char1);
        characters.Add(char2);
        characters.Add(char3);
        characters.Add(char4);
        characters.Add(char5);
        characters.Add(char6);
        score = 0;
        gameOver.SetActive(false);
        loadCharacter();
    }

    public void OnGreenButtonPress()
    {
        if (current.allowed == true)
        {
            score++;
            if (highScore < score)
            {
                highScore++;
            }
            loadCharacter();
        }
        else
        {
            gameOver.SetActive(true);
            restart.SetActive(true);
            greenButton.SetActive(false);
            redButton.SetActive(false);
            // Display gameover.
        }
    }

    public void OnRedButtonPress()
    {
        if (current.allowed == false)
        {
            score++;
            if (highScore < score)
            {
                highScore++;
            }
            loadCharacter();
        }
        else
        {
            gameOver.SetActive(true);
            restart.SetActive(true);
            greenButton.SetActive(false);
            redButton.SetActive(false);

            // Display gameover.
        }
    }


    public void PrintPassport()
    {
        int start = 0;
        if (current.country.Equals("Knaveria") == true)
        {
            start = 0;
            if (current.allowed == true)
            {
                spriteRenderer.sprite = passportImages[start];
            }
            else
            {
                int ran = UnityEngine.Random.Range(1, 11);
                spriteRenderer.sprite = passportImages[start + ran];
            }
        }

        else if (current.country.Equals("Milia") == true)
        {
            start = 11;
            if (current.allowed == true)
            {
                spriteRenderer.sprite = passportImages[start];
            }
            else
            {
                int ran = UnityEngine.Random.Range(1, 11);
                spriteRenderer.sprite = passportImages[start + ran];
            }
        }

        else if (current.country.Equals("Withambian") == true)
        {
            start = 22;
            if (current.allowed == true)
            {
                spriteRenderer.sprite = passportImages[start];
            }
            else
            {
                int ran = UnityEngine.Random.Range(1, 11);
                spriteRenderer.sprite = passportImages[start + ran];
            }
        }
    }
}

public class Character
{
    public bool allowed;
    public string country;
    public string bodyType;
}