using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    [System.Serializable]
    public class ClothingOption
    {
        public string name;
        public Sprite sprite;
        public int price = 100;
    }
    public void Update()
    {
      //  Money.text = playerCoins.ToString();
    }

    public GameObject shopUI; // Reference to the shop UI canvas
    public GameObject clothingOptionPanel; // Reference to the clothing option UI panel
    public Image clothingImage; // Reference to the image element for displaying the selected clothing
    public Text priceText; // Reference to the text element for displaying the price
    //public Text Money;
    public TextMeshProUGUI Money;

    public List<ClothingOption> options = new List<ClothingOption>(); // List of clothing options

    public int playerCoins = 100; // Initial player coins
    public GameObject playerClothing; // Reference to the player's clothing object (e.g., a GameObject with a SpriteRenderer)

    private int currentOption = 0;

    private void Start()
    {
        // Set the initial sprite and price in the UI panel
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
        if (currentOption < 0)
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
            //shopUI.SetActive(true);
        }
    }

    private void SetOption(int optionIndex)
    {
        ClothingOption option = options[optionIndex];

        // Update the UI panel with the selected clothing option and its price
        clothingImage.sprite = option.sprite;
        priceText.text = "Price: " + option.price.ToString();

        // You can also add other information such as the name of the clothing option if needed.
    }

    public void BuyClothing()
    {
        ClothingOption option = options[currentOption];

        if (playerCoins >= option.price)
        {
            // Deduct the price from the player's coins
            playerCoins -= option.price;

            // Update the player's clothing object with the new sprite
            playerClothing.GetComponent<SpriteRenderer>().sprite = option.sprite;

            // Update the UI to display the new balance of coins
            UpdateCoinsUI();

            // Optionally, you can save the player's clothing choice or apply it permanently here.
        }
        else
        {
            Debug.Log("Not enough coins to buy this clothing option!");
        }
    }

    private void UpdateCoinsUI()
    {
        // Update the UI to display the new balance of coins
        // You can use a text element or any other UI element to show the player's coins.
        // For example:
        Money.text =playerCoins.ToString();
    }
}
