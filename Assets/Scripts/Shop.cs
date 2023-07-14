using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI; // Reference to the shop UI canvas
    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;
    [Header("Sprites to Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    private int CurrentOption = 0;
    public void NextOption()
    {
        CurrentOption++;
        if(CurrentOption >= options.Count)
        {
            CurrentOption = 0;
        }
        bodyPart.sprite = options[CurrentOption];
    }
    public void PreviusOption()
    {
        CurrentOption--;
        if (CurrentOption <= 0)
        {
            CurrentOption = options.Count -1;
        }
        bodyPart.sprite = options[CurrentOption];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the shop UI canvas when the player enters the trigger
            shopUI.SetActive(true);
        }
    }
}
