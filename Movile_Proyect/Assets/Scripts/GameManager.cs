using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Transform[] spawPositions;

    public static GameManager instance;
    public GameObject Player;
    private PowerUpSpawner powerUpSpawner;
    private Consumer consumer;

    public int maxMissileInstance = 5;
    int currentInstanceMissiles = 0;
    float timer = 0;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        spawPositions = new Transform[4];

        consumer = GetComponent<Consumer>();
        powerUpSpawner = GetComponent<PowerUpSpawner>();

        initPlayer();
    }

    private void Start()
    {
        powerUpSpawner.SpawnRandomPowerUp();
    }

    public Vector3 GetRandomSpawnposition()
    {
        return spawPositions[Random.Range(0, spawPositions.Length)].position;
    }

    private void Update()
    {
        if (currentInstanceMissiles < maxMissileInstance)
        {
            timer += Time.deltaTime;

            if (timer > 4)
            {
                consumer.Spawn();
                currentInstanceMissiles++;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            consumer.Spawn();
        }
    }

    public void ReSpawnMissile()
    {
        StartCoroutine(WaitToRespaw());
    }

    IEnumerator WaitToRespaw()
    {
        yield return new WaitForSeconds(3);
        consumer.Spawn();
    }

    public void SpawnRandomPowerUp()
    {
        powerUpSpawner.SpawnRandomPowerUp();
    }
    void initPlayer()
    {
        int indexPlayer = PlayerPrefs.GetInt("PlayerIndex");
        Instantiate(CharacterSelected.Instance.characters[indexPlayer].character_prefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

       
        Player = GameObject.FindGameObjectWithTag("Player");

        GameObject positionManager = Player.transform.Find("PowerUpSpawnerPositions").gameObject;

        for (int i = 0; i < positionManager.transform.childCount; i++)
        {
            spawPositions[i] = positionManager.transform.GetChild(i);
            Debug.Log(spawPositions[i].name);
        }
    }
}
