using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;

    public GameObject endUI;
    public double currentGoldAmount;
    public double maxGoldAmount = 1000;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI trendAlert;
    public Slider goldSlider;
    public int randomTrend;
    public int trendItemAffected;
    public int randomPercentage;
    public string[] trendMessage;

    public void Awake()
    {
        instance = this;
        goldText.text = currentGoldAmount.ToString("F2");
        goldSlider.value = ((float)currentGoldAmount / (float)maxGoldAmount);
    }

    public void RefreshGoldTracker (double gold)
    {
        currentGoldAmount = gold;
        goldText.text = currentGoldAmount.ToString("F2");
        goldSlider.value = ((float)currentGoldAmount / (float)maxGoldAmount);
    }


    public void UpdateGoldAmount ()
    {
        currentGoldAmount = currentGoldAmount - Shopkeeper.instance.totalGold;
        Shopkeeper.instance.totalGold = 0;
        RefreshGoldTracker(currentGoldAmount);

        if (currentGoldAmount > maxGoldAmount)
        {
            InventoryManager.instance.PausePlayer();
            Shopkeeper.instance.shopUi.SetActive(false);
            endUI.SetActive(true);
        }

        AudioManager.instance.PlaySFX("Coins");
    }

    public void SetTrend ()
    {
        randomTrend = Random.Range(0, 5);
        if(randomTrend < 3)
        {
            randomPercentage = Random.Range(10, 40);
            trendItemAffected = Random.Range(0, 19);
            GameHandler.instance.items[trendItemAffected].cost = (GameHandler.instance.itemBasePrices[trendItemAffected] - ((GameHandler.instance.itemBasePrices[trendItemAffected] / 100) * randomPercentage));

            for (int i = 0; i <  GameHandler.instance.items.Length; i++)
            {
                for (int a = 0; a <  GameHandler.instance.itemCost.Length; a++)
                {
                    if ( GameHandler.instance.items[i].name == GameHandler.instance.itemCost[a].name)
                    {
                        GameHandler.instance.itemCost[a].SetText(GameHandler.instance.items[i].cost.ToString("F2"));
                    }
                }
            }
        }

        else
        {
            randomPercentage = Random.Range(30, 70);
            trendItemAffected = Random.Range(0, 19);
            GameHandler.instance.items[trendItemAffected].cost = (GameHandler.instance.itemBasePrices[trendItemAffected] + ((GameHandler.instance.itemBasePrices[trendItemAffected] / 100) * randomPercentage));
        }
    }
}
