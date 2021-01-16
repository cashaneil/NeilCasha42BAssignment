using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] int health = 50;

    int playerScore = 0;
    
    [SerializeField] float playerSpeed = 10.0f;
    
    [SerializeField] float padding = 0.7f;

    float xMin, xMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        ProcessHit(dmgDealer);
    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        playerScore = FindObjectOfType<GameSession>().GetScore();

        int sceneToLoad;

        if (health <= 0 && playerScore < 100)
        {
            health = 0; //to hide minus value
            sceneToLoad = 0;
            Die(sceneToLoad);
        }
        else if (health <= 0 && playerScore >= 100)
        {
            health = 0; //to hide minus value
            sceneToLoad = 1;
            Die(sceneToLoad);
        }
    }

    private void Die(int loadScene)
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

        if(loadScene == 0)
        {
            FindObjectOfType<Level>().LoadGameOver();
        }
        else if(loadScene == 1)
        {
            FindObjectOfType<Level>().LoadWinnerScene();
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera camera = Camera.main;

        xMin = camera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
