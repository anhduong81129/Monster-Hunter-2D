using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    // The monster Prefab you want to spawn
    public GameObject[] monsterPrefab;

    // A reference to the Player's Transform (to find a good spawn location)
    public Transform playerTransform;

    // Time between spawns
    public float spawnInterval = 6f;

    // Distance from the player where monsters should appear
    public float spawnDistance = 10f;

    //Using object pooling to optimize performance
    public int poolSizeperType = 5; // Number of monsters to pool for each type

    // A list to hold the pooled monsters
    private List<GameObject> monsterPool;

    private float timer;

    void Start()
    {
        // Safety check to ensure the player reference is set
        if (playerTransform == null)
        {
            playerTransform = FindAnyObjectByType<Player>().transform;
        }

        // Initialize the timer so the first monster spawns quickly
        timer = spawnInterval; 

        // Create the monster pool
        monsterPool = new List<GameObject>();

        //Check quai vat trong arr
        foreach (GameObject prefab in monsterPrefab)
        {
            // voi moi loai, chi cho so luong nhat dinh vao pool de su dung sau nay
            for(int i =0; i < poolSizeperType; i++)
            {
                CreateNewMonsterInPool(prefab);
            }
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnMonster();
            timer = spawnInterval; // Reset the timer
        }
    }

    void SpawnMonster()
    {
        // Kiểm tra xem đã cho quái vào danh sách chưa
        if (monsterPrefab.Length == 0 || playerTransform == null) return;

        // Pick a random monster prefab from the array
        int randomIndex = Random.Range(0, monsterPrefab.Length);
        GameObject selectedPrefab = monsterPrefab[randomIndex];

        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 spawnOffset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnDistance;
        Vector3 spawnPosition = playerTransform.position + spawnOffset;

        // Try to get a monster from the pool. If none are available, create a new one.
        GameObject monsterToSpawn = GetPooledMonster(selectedPrefab);
        if (monsterToSpawn != null)
        {
            monsterToSpawn.transform.position = spawnPosition;
            monsterToSpawn.transform.rotation = Quaternion.identity; 
            monsterToSpawn.SetActive(true);
        }
        // Optional: If the MonsterAI script is on the prefab, it will automatically start moving.
    }

    //tim quai vat trong pool de su dung, neu khong co thi tao moi va them vao pool
    GameObject GetPooledMonster(GameObject requestedPrefab)
        {
            for(int i =0;i < monsterPool.Count; i++)
            {
                //Tim quai cung loai va dang bi an trong pool de su dung
                if (!monsterPool[i].activeInHierarchy && monsterPool[i].name.StartsWith(requestedPrefab.name))
                {
                    return monsterPool[i];
                }
            }

             // Neu khong co quai nao trong pool, tao moi va them vao pool
            return CreateNewMonsterInPool(requestedPrefab);
        }
    GameObject CreateNewMonsterInPool(GameObject prefab)
    {
        GameObject newMonster = Instantiate(prefab);
        newMonster.name = prefab.name; // dat ten chuan de sau nay tim trong pool
        newMonster.SetActive(false); // Bat dau la an quai
        monsterPool.Add(newMonster);
        return newMonster;
    }    
}