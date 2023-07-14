using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Define a data structure for each clothing option
    [System.Serializable]
    public class ClothingOption
    {
        public string name;
        public Sprite sprite;
        public int price;
    }

    public GameObject shopUI; // Reference to the shop UI canvas
    public SpriteRenderer bodyPart; // Reference to the sprite renderer of the body part
    public List<ClothingOption> options = new List<ClothingOption>(); // List of clothing options

    private int currentOption = 0;

    private void Start()
    {
        // Set the initial sprite
        SetOption(currentOption);
    }

    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0;
        }
        SetOption(currentOption);
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }
        SetOption(currentOption);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the shop UI canvas when the player enters the trigger
            shopUI.SetActive(true);
        }
    }

    private void SetOption(int optionIndex)
    {
        ClothingOption option = options[optionIndex];
        bodyPart.sprite = option.sprite;

        // TODO: Update the UI to display the price of the current option
        // You can access the price using option.price and update the shop UI accordingly
    }
}
