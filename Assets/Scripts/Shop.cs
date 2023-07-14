using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI; // Reference to the shop UI canvas

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the shop UI canvas when the player enters the trigger
            shopUI.SetActive(true);
        }
    }
}
