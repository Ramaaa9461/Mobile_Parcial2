using System.Collections;
using UnityEngine;

public class WaitInitScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Await());
    }

    IEnumerator Await()
    {
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
