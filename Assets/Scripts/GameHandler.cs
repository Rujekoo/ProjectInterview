using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private WindowCharacterPortrait windowCharacterPortrait;
    [SerializeField] private Transform characterTransform;
    public Item[] items;
    public TextMeshProUGUI[] itemCost;

    private void Awake() 
    {
        SetItemCount ();
        SetupStorePrices();
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
