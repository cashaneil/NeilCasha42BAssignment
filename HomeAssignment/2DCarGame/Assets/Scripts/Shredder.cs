using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D otherObject)
    {

    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        int scoreValue = 5;

        Destroy(otherObject.gameObject);

        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }
}