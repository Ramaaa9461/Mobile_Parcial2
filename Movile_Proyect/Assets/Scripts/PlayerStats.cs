using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    int maxLife = 5;
    int currentLife = 3;
    int currentMoney = 0;

    public UnityEvent<int> ChangeMoney;
    public UnityEvent<int> ChangeLife;

    private void Start()
    {
        ChangeMoney.AddListener(GameObject.Find("Canvas").GetComponent<UIManager>().SetMoney);
        ChangeLife.AddListener(GameObject.Find("Canvas").GetComponent<UIManager>().SetLife);


        currentMoney = PlayerPrefs.GetInt("Money");

        ChangeMoney.Invoke(currentMoney);
        ChangeLife.Invoke(currentLife);
    }

    public void AddLife()
    {
        if (currentLife < maxLife)
        {
            currentLife++;

            ChangeLife.Invoke(currentLife);
        }
        
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;

        PlayerPrefs.SetInt("Money", currentMoney);
        ChangeMoney.Invoke(currentMoney);
    }

    public void SubtractLife()
    {
        currentLife--;

        ChangeLife.Invoke(currentLife);

        if (currentLife <= 0)
        {
            gameObject.SetActive(false);
        }
    }


}