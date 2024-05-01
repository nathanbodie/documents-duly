using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    //GameObject Passport = GameObject.Find("PassportScriptable");
    public GameObject gameOver;

    // 0 - 2 = knaveria, 3 - 5 = milia, 6 - 8 = witha
    [SerializeField] Sprite[] passportImages;
    [SerializeField] SpriteRenderer spriteRenderer;

    public Character current = null;
    Character char1 = new Character { allowed = true, country = "Knaveria", bodyType = "pyramidbuff" };
    Character char2 = new Character { allowed = false, country = "Knaveria", bodyType = "pyramidbuff" };
    Character char3 = new Character { allowed = false, country = "Milia", bodyType = "cubechunk" };
    Character char4 = new Character { allowed = false, country = "Withambian", bodyType = "spheretiny" };
    Character char5 = new Character { allowed = true, country = "Milia", bodyType = "cubechunk" };
    Character char6 = new Character { allowed = true, country = "Withambian", bodyType = "spheretiny" };
    List<Character> characters = new List<Character>();


    public void loadCharacter()
    {
        current = characters.ElementAt(UnityEngine.Random.Range(0, characters.Count()));
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
        loadCharacter();
    }

    public void OnGreenButtonPress()
    {
        if (current.allowed == true)
        {
            loadCharacter();
        }
        else
        {
            // Display gameover.
        }
    }

    public void OnRedButtonPress()
    {
        if (current.allowed == false)
        {
            loadCharacter();
        }
        else
        {
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
                int ran = UnityEngine.Random.Range(1, 3);
                spriteRenderer.sprite = passportImages[start + ran];
            }
        }

        else if (current.country.Equals("Milia") == true)
        {
            start = 3;
            if (current.allowed == true)
            {
                spriteRenderer.sprite = passportImages[start];
            }
            else
            {
                int ran = UnityEngine.Random.Range(1, 3);
                Debug.Log(ran);
                spriteRenderer.sprite = passportImages[start + ran];
            }
        }

        else if (current.country.Equals("Withambian") == true)
        {
            start = 6;
            Debug.Log("Goes here");
            if (current.allowed == true)
            {
                spriteRenderer.sprite = passportImages[start];
            }
            else
            {
                int ran = UnityEngine.Random.Range(1, 3);
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