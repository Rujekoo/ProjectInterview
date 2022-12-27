using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    [SerializeField] private WindowCharacterPortrait windowCharacterPortrait;
    [SerializeField] private Transform characterTransform;
    public Item[] items;
    public double[] itemBasePrices;
    public TextMeshProUGUI[] itemCost;

    private void Awake() 
    {
        instance = this;
        SetItemCount ();
        SetItemBasePrices ();
        SetupStorePrices ();
        ResetItemActionType ();
    }
    private void Start() 
    {
        windowCharacterPortrait.Show(characterTransform);
    }

    public void SetItemCount ()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].count = 0;
        }
    }

    public void SetItemBasePrices ()
    {
        for (int i = 0; i < items.Length; i++)
        {
            itemBasePrices[i] = items[i].cost;
        }
    }

    public void ResetItemPrices ()
    {
        for (int i = 0; i < items.Length; i++)
        {
             items[i].cost = itemBasePrices[i];
        }
    }

    public void SetupStorePrices ()
    {
        for (int i = 0; i < items.Length; i++)
        {
            for (int a = 0; a < itemCost.Length; a++)
            {
                if (items[i].name == itemCost[a].name)
                {
                    itemCost[a].SetText(items[i].cost.ToString("F2"));
                }
            }
        }
    }

    public void ResetItemActionType ()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].state = ActionType.NotOwned;
        }
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene (0);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
