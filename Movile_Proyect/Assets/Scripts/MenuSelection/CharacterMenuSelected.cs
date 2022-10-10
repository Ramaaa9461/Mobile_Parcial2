using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMenuSelected : MonoBehaviour
{
    CharacterSelected characterSelected;
    
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI characterNameText;
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Toggle isUnlockedToggle;

    string playerPrefKey = "PlayerIndex";
    string moneyKey = "Money";
    string UnlockedKey = "Unlocked";
    int index;
    int money = 0;

    private void Start()
    {
        characterSelected = CharacterSelected.Instance;

        index = PlayerPrefs.GetInt(playerPrefKey);
        money = PlayerPrefs.GetInt(moneyKey);

        if (index > characterSelected.characters.Count - 1)
        {
            index = 0;
        }

        moneyText.text = "$ " + money.ToString();

        ChangeScreen();
    }

    void ChangeScreen()
    {
        PlayerPrefs.SetInt(playerPrefKey, index);

        characterSelected.characters[index].isUnlocked = PlayerPrefs.GetInt(UnlockedKey + index) == 1 ? true : false; 

        image.sprite = characterSelected.characters[index].image;
        characterNameText.text = characterSelected.characters[index].characterName;
        valueText.text = "$ " + characterSelected.characters[index].value.ToString();
        isUnlockedToggle.isOn = characterSelected.characters[index].isUnlocked;
    }

    public void NextCharacter()
    {
        if (index == characterSelected.characters.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        ChangeScreen();
    }
    public void PreviusCharacter()
    {
        if (index == 0)
        {
            index = characterSelected.characters.Count - 1;
        }
        else
        {
            index--;
        }

        ChangeScreen();
    }

    public void StartGame()
    {

        if (characterSelected.characters[index].isUnlocked)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (money >= characterSelected.characters[index].value)
        {
            money -= characterSelected.characters[index].value;
            characterSelected.characters[index].isUnlocked = true;


            PlayerPrefs.SetInt(moneyKey, money);
            PlayerPrefs.SetInt(UnlockedKey + index, 1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
