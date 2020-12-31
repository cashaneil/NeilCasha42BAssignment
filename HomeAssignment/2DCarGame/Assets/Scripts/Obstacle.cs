using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float shotCount;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float obstBulletSpeed = 0.3f;
    
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
