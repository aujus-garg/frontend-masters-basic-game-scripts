using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    [HideInInspector] public bool[] spawnLocationMap;
    public int mapSize = 100;
    public GameObject hazard;
    public int xWidth = 10;
    public int zWidth = 10;
    public float spawnDelay = 0.75f;
    private float spawnTime;

    void Start()
    {
        // Initialize array
        spawnLocationMap = new bool[mapSize];
        for(int i = 0; i < mapSize; i++) {
            spawnLocationMap[i] = false;
        }

        // Set spawn time
        spawnTime = Time.time;
    }

    void Update()
    {
        // Spawn hazards based on score
        if (Time.time - spawnTime < spawnDelay) {
            return;
        }
        for(int i = 0; i < (scoreManager.score > 65 ? Random.Range(65, 75) : Random.Range(scoreManager.score / 2, (scoreManager.score / 2) + 10)); i++) {
            SpawnHazard();
        }
        spawnTime = Time.time;
    }

    void SpawnHazard() {
        // Randomize spawn position
        float hazardXLoc = Mathf.Floor(Random.Range(0, xWidth));
        float hazardZLoc = Mathf.Floor(Random.Range(0, zWidth));
        if (spawnLocationMap[Mathf.FloorToInt(hazardXLoc) + (xWidth * Mathf.FloorToInt(hazardZLoc))]) {
            return;
        }

        // Prevent spawn overlap
        spawnLocationMap[Mathf.FloorToInt(hazardXLoc) + (xWidth * Mathf.FloorToInt(hazardZLoc))] = true;
        Vector3 hazardLoc = new Vector3(hazardXLoc / 4, 0, hazardZLoc / 4);

        // Instantiate and move hazard
        GameObject hazardClone = Instantiate(hazard);
        hazardClone.transform.position += hazardLoc;
    }
}
