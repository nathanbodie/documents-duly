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

    // 0 - 10 = knaveria, 11 - 21 = milia, 22 - 33 = witha
    [SerializeField] Sprite[] passportImages;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Character selection.
    public Character current = null;

    // Models used.
    public GameObject cubeBuff1;
    public GameObject cubeChunk2;
    public GameObject cubeTiny1;
    public GameObject pyramidBuff1;
    public GameObject prymaidChunk1;
    public GameObject pyramidTiny2;
    public GameObject sphereBuff1;
    public GameObject sphereChunk1;
    public GameObject sphereTiny1;

    // Keep track of scores.
    public int score = 0;
    public int highScore;

    // List of all data types.
    public List<String> countries = null;
    public List<GameObject> bodies = null;

    // Audio stuff.
    public AudioSource SFsource;
    public AudioClip pass;
    public AudioClip fail;

    // Initialize the lists.
    public void Start()
    { 
        countries = new List<String>() { "Knaveria", "Milia", "Withambian" };
        bodies = new List<GameObject>() { cubeBuff1, cubeChunk2, cubeTiny1, pyramidBuff1, prymaidChunk1, pyramidTiny2, sphereBuff1, sphereChunk1, sphereTiny1 };
    }

    // Load a new character.
    public void loadCharacter()
    {
        // Set if person can enter.
        int temp = Random.Range(0, 2);
        bool cAllow = false;
        if (temp > 0)
        {
            cAllow = true;
        }

        // Pick from lists.
        String cCountry = countries[Random.Range(0, countries.Count())];
        GameObject cBodyType = bodies[Random.Range(0, bodies.Count())];

        // Set current character equal.
        current = new Character { allowed = cAllow, country = cCountry, bodyType = cBodyType };

        // Scores.
        scoreText.text = "Score: " + (score.ToString());
        highScoreText.text = "High: " + (score.ToString());

        // Get the passport and character printed.
        PrintPassport();
    }

    // After start button pressed.
    public void OnStartButtonPress()
    {

        // Reset all and load new character.
        score = 0;
        gameOver.SetActive(false);
        loadCharacter();
    }


    // Green button to allow someone to enter.
    public void OnGreenButtonPress()
    {

        // If character can enter, add and create new character.
        if (current.allowed == true)
        {
            score++;
            if (highScore < score)
            {
                highScore++;
            }
            current.bodyType.SetActive(false);
            SFsource.clip = pass;
            SFsource.Play();
            loadCharacter();
        }
        
        // Otherwise remove old one and show restart button.
        // AKA game over.
        else
        {
            SFsource.clip = fail;
            SFsource.Play();
            gameOver.SetActive(true);
            restart.SetActive(true);
            greenButton.SetActive(false);
            redButton.SetActive(false);
            current.bodyType.SetActive(false);
        }
    }

    // Red button to deny someone
    // (Used same code as previous, except allowed = false.
    public void OnRedButtonPress()
    {
        if (current.allowed == false)
        {
            score++;
            if (highScore < score)
            {
                highScore++;
            }
            current.bodyType.SetActive(false);
            SFsource.clip = pass;
            SFsource.Play();
            loadCharacter();
        }
        else
        {
            SFsource.clip = fail;
            SFsource.Play();
            gameOver.SetActive(true);
            restart.SetActive(true);
            greenButton.SetActive(false);
            redButton.SetActive(false);
            current.bodyType.SetActive(false);

        }

    }

    // Print the character and passport.
    public void PrintPassport()
    {
        current.bodyType.SetActive(true);
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


// Character object to make things easier.
public class Character
{
    public bool allowed;
    public string country;
    public GameObject bodyType;
}