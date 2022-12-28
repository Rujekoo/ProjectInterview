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
    public float timeLeft;
    public bool timerOn = true;
    public bool startTrendCheck = true;
    public string[] trendMessage;

    public void Awake()
    {
        instance = this;
        goldText.text = currentGoldAmount.ToString("F2");
        goldSlider.value = ((float)currentGoldAmount / (float)maxGoldAmount);
    }

    private void Update() 
    {
        if(timerOn)
        {       
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log ("Timer Up");
                GameHandler.instance.ResetItemPrices();
                startTrendCheck = true;
                timeLeft = Random.Range(20, 40);
            }

            if(startTrendCheck)
            {
                SetTrend();
                startTrendCheck = false;
            } 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StoreManager.instance.pauseMenu.SetActive(true);
            InventoryManager.instance.PausePlayer();
        }
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
            RefreshShopCostUI();
        }

        else
        {
            randomPercentage = Random.Range(30, 70);
            trendItemAffected = Random.Range(0, 19);
            GameHandler.instance.items[trendItemAffected].cost = (GameHandler.instance.itemBasePrices[trendItemAffected] + ((GameHandler.instance.itemBasePrices[trendItemAffected] / 100) * randomPercentage));
            RefreshShopCostUI();
        }
        Debug.Log ("Trend Started: " + GameHandler.instance.items[trendItemAffected]);
        TrendBoard ();
    }

    public void RefreshShopCostUI ()
    {
        for (int i = 0; i <  GameHandler.instance.items.Length; i++)
        {
            for (int a = 0; a <  GameHandler.instance.itemCost.Length; a++)
            {
                if( GameHandler.instance.items[i].name == GameHandler.instance.itemCost[a].name)
                {
                    GameHandler.instance.itemCost[a].SetText(GameHandler.instance.items[i].cost.ToString("F2"));
                }
            }
        }
    }

    public void TrendBoard ()
    {
        if (randomTrend < 3)
        {
            trendAlert.SetText("Sale! " + GameHandler.instance.items[trendItemAffected].name + " is now only " + GameHandler.instance.items[trendItemAffected].cost.ToString("F2") + " Gold!");
        }

        else
        {
            trendAlert.SetText("New Trend! " + GameHandler.instance.items[trendItemAffected].name + " has become " + GameHandler.instance.items[trendItemAffected].cost.ToString("F2") + " Gold!");
        }      
    }    
}
