using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] Sprite[] passportImages;
    [SerializeField] SpriteRenderer spriteRenderer;
    int randomNumber;
    void Start()
    {
        //ThrowTheDice();
    }


    public void ThrowTheDice()
    {
        randomNumber = Random.Range(1, passportImages.Length + 1);
        spriteRenderer.sprite = passportImages[randomNumber - 1];
        print(randomNumber);
    }
}