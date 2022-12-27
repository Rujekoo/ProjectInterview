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
    public Slider goldSlider;

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
    }
}
