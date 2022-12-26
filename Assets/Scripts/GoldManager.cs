using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;

    public double currentGoldAmount;
    public double maxGoldAmount = 10000;
    public TextMeshProUGUI goldText;
    public Slider goldSlider;

    public void Awake()
    {
        instance = this;
        goldText.text = currentGoldAmount.ToString();
        goldSlider.value = ((float)currentGoldAmount / (float)maxGoldAmount);
    }

    public void RefreshGoldTracker (double gold)
    {
        currentGoldAmount = gold;
        goldText.text = currentGoldAmount.ToString();
        goldSlider.value = ((float)currentGoldAmount / (float)maxGoldAmount);
    }


    public void UpdateGoldAmount ()
    {
        currentGoldAmount = currentGoldAmount - Shopkeeper.instance.totalGold;
        RefreshGoldTracker(currentGoldAmount);
    }
}
