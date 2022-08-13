using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazard : MonoBehaviour
{
    public Slider hazardTimer;
    public GameObject hazardHitbox;
    private bool hazardActive = false;
    private HazardManager hazardManager;
    private ScoreManager scoreManager;
    private float spawnTime;
    private float currentTime;
    public float warningDelay = 1f;
    public float despawnDelay = 0.5f;
    public float xLowerBound = 1.125f;
    public float zLowerBound = 1.125f;
    public AudioSource[] loseSFX;

    void Start()
    {
        // Set spawn time to when prefab instantiates
        spawnTime = Time.time;

        // Find hazardManager
        hazardManager = GameObject.Find("Game Manager").GetComponent<HazardManager>();        

        // Find scoreManager
        scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();

        // Find loseSFX
        loseSFX = GameObject.Find("Music Box").GetComponents<AudioSource>();
    }

    void Update()
    {
        // Update time since prefab instantiated
        currentTime = Time.time - spawnTime;

        // Destroy gameobject if time elapses
        if (currentTime > warningDelay + despawnDelay) {
            hazardManager.spawnLocationMap[Mathf.FloorToInt(((transform.position.x + xLowerBound) * 4) + ((transform.position.z + zLowerBound) * 40))] = false;
            Destroy(gameObject);
        }

        // Set timer value based on currentTime
        if (currentTime < warningDelay) {
            hazardTimer.value = currentTime / warningDelay;
        }

        // Activate hitbox when time elapses
        hazardHitbox.SetActive(currentTime > warningDelay);
        hazardActive = currentTime > warningDelay;
    }

    void OnTriggerStay(Collider other) {
        // Restart game upon collision with player
        if(other.gameObject.layer == 3 && hazardActive) {
            scoreManager.startTime = Time.time;
            loseSFX[1].Play();
            hazardManager.spawnLocationMap[Mathf.FloorToInt(((transform.position.x + xLowerBound) * 4) + ((transform.position.z + zLowerBound) * 40))] = false;
            Destroy(gameObject);
        }
    }
}
