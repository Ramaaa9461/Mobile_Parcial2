using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    public static CharacterSelected Instance;
    public List<Characters> characters;

    private void Awake()
    {
        if (CharacterSelected.Instance == null)
        {
            CharacterSelected.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
