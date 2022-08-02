using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardHitbox : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start() {
        // Find scoreManager
        scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter(Collider other) {
        // Restart game upon collision with player
        if(other.gameObject.layer == 3) {
            scoreManager.startTime = Time.time;
        }
    }
}
