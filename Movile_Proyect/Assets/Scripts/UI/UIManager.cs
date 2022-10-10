using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI life;
    [SerializeField] TextMeshProUGUI money;

    public void SetLife(int newLife)
    {
        life.text = newLife.ToString();
    }

    public void SetMoney(int newMoney)
    {
        money.text = newMoney.ToString();
    }
}
