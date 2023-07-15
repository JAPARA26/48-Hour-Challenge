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
        LoadPlayerCoins();
    }

    public GameObject shopUI; // Reference to the shop UI canvas
    public GameObject clothingOptionPanel; // Reference to the clothing option UI panel
    public Image clothingImage; // Reference to the image element for displaying the selected clothing
    public Text priceText; // Reference to the text element for displaying the price
    public TextMeshProUGUI Money;

    public List<ClothingOption> options = new List<ClothingOption>(); // List of clothing options

    public int playerCoins = 100; // Initial player coins
    public GameObject playerClothing; // Reference to the player's clothing object (e.g., a GameObject with a SpriteRenderer)
    public GameObject playerClothing2;
    public GameObject playerClothing3;

    private int currentOption = 0;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
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

    private void SetOption(int optionIndex)
    {
        ClothingOption option = options[optionIndex];

        // Update the UI panel with the selected clothing option and its price
        clothingImage.sprite = option.sprite;
        priceText.text = "Price: " + option.price.ToString();      
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
            SavePlayerCoins();
            UpdateCoinsUI();


           
        }
        else
        {
            Debug.Log("Not enough coins to buy this clothing option!");
        }
    }
    public void SellClothing()
    {
        Sprite defaultSprite = null; 

        playerClothing.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        playerClothing2.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        playerClothing3.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        // Add 100 coins to the player's coins
        playerCoins += 100;
        SavePlayerCoins();
        // Update the UI to display the new balance of coins
        UpdateCoinsUI();
        currentOption = 0;
        SetOption(currentOption);
       
    }

    private void UpdateCoinsUI()
    {
        // Update the UI to display the new balance of coins
        Money.text =playerCoins.ToString();
    }

    private void LoadPlayerCoins()
    {
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            playerCoins = PlayerPrefs.GetInt("PlayerCoins");
            SavePlayerCoins();
        }
        else
        {
            playerCoins = 100; // Default value if no saved data is found
            SavePlayerCoins();
        }
    }

    private void SavePlayerCoins()
    {
        PlayerPrefs.SetInt("PlayerCoins", playerCoins);
        PlayerPrefs.Save();
    }
}
