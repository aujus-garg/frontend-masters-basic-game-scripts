using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardHitbox : MonoBehaviour
{
    public ScoreManager scoreManager;

    void OnTriggerEnter(Collider other) {
        // Restart game upon collision with player
        if(other.gameObject.layer == 3) {
            scoreManager.startTime = Time.time;
        }
    }
}
