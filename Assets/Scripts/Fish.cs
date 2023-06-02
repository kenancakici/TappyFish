using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D _rb;
    public float speed; // Hýz
    int angle; // Açý
    int maxAngle = 10; // Maksimum açý
    int minAngle = -60;  // minimum açý

    public Score score; // Game Score
    bool touchedGround; // Balýk yere deðdi mi
    public Sprite fishDied; // Yeni bir sprite, Balýðýn son hali tek kare, ölmüþ hali
    SpriteRenderer sp; // 

    Animator anim;
    public ObstacleSpawner obstacleSpawner;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0; // Yerçekimini sýfýrlýyoruz. Balýk havada asýlý kalýyor.
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        FishSwim();

    }
    void FixedUpdate()
    {
        FishRotation(); // Update yerine, FixedUpdate içine yazdýðýmz için Daha yumuþak bir hareket elde ediyoruz.
    }

    void FishSwim()
    {
        // Mouse týklandýysa ve gameOver = false (Balýk ölmediyse) yukarý yönlü harekete devam et
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 1f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);// Hýza göre balýðýn y pozisyonu 
                obstacleSpawner.InstantiateObstacle(); // Engel üretiliyor
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
        if (touchedGround == false) // Eðer balýk yere deðmemiþse devam edecek
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); // rotasyonu (AÇI) güncellemek için kullandýk
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) // Obstacle geçildiye Puan al
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
        transform.rotation = Quaternion.Euler(0, 0, -90);// balýðý düzgün hale getirdik.
        anim.enabled = false; // Balýk animasyonunu durdurur.
        sp.sprite = fishDied; // Editorden girilen balýk sprite'ný SpriteRenderer eeþitleniyor
    }

}