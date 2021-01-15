using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float health = 1f;
    [SerializeField] float shotCount;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float obstBulletSpeed = 0.3f;

    [SerializeField] AudioClip obstacleDeathSound;
    [SerializeField] [Range(0, 1)] float obstacleDeathSoundVolume = 0.75f;

    [SerializeField] GameObject deathVisualFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(obstacleDeathSound, Camera.main.transform.position, obstacleDeathSoundVolume);
        GameObject explosion = Instantiate(deathVisualFX, transform.position, Quaternion.identity);

        Destroy(explosion, explosionDuration);

        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }

    // Start is called before the first frame update
    private void Start()
    {
        shotCount = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    private void Update()
    {
        ShootCountdown();
    }

    private void ShootCountdown()
    {
        shotCount -= Time.deltaTime;

        if (shotCount <= 0f)
        {
            ObstFire();
            shotCount = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstFire()
    {
        GameObject obstBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        obstBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstBulletSpeed);
    }
}
