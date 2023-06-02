using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D _rb;
    public float speed; // H�z
    int angle; // A��
    int maxAngle = 10; // Maksimum a��
    int minAngle = -60;  // minimum a��

    public Score score; // Game Score
    bool touchedGround; // Bal�k yere de�di mi
    public Sprite fishDied; // Yeni bir sprite, Bal���n son hali tek kare, �lm�� hali
    SpriteRenderer sp; // 

    Animator anim;
    public ObstacleSpawner obstacleSpawner;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0; // Yer�ekimini s�f�rl�yoruz. Bal�k havada as�l� kal�yor.
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        FishSwim();

    }
    void FixedUpdate()
    {
        FishRotation(); // Update yerine, FixedUpdate i�ine yazd���mz i�in Daha yumu�ak bir hareket elde ediyoruz.
    }

    void FishSwim()
    {
        // Mouse t�kland�ysa ve gameOver = false (Bal�k �lmediyse) yukar� y�nl� harekete devam et
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 1f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);// H�za g�re bal���n y pozisyonu 
                obstacleSpawner.InstantiateObstacle(); // Engel �retiliyor
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);
            }

        }
    }
    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }

        }
        else if (_rb.velocity.y < -1.2f)
        {
            if (angle >= minAngle)
            {
                angle = angle - 2;
            }
        }
        if (touchedGround == false) // E�er bal�k yere de�memi�se devam edecek
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); // rotasyonu (A�I) g�ncellemek i�in kulland�k
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) // Obstacle ge�ildiye Puan al
        {
            score.Scored();
        }
        else if (collision.gameObject.CompareTag("Column")) // Column'a temas edildiyse Oyun Sonu
        {
            // Game Over
            gameManager.GameOver();
            GameOver();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                // Game Over
                gameManager.GameOver();
                GameOver(); 
            }
            //else
            //{
            //    // Game Over (Fish)
            //    GameOver();
            //}
        }
    }

    // Fish'deki GameOver
    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);// bal��� d�zg�n hale getirdik.
        anim.enabled = false; // Bal�k animasyonunu durdurur.
        sp.sprite = fishDied; // Editorden girilen bal�k sprite'n� SpriteRenderer ee�itleniyor
    }

}