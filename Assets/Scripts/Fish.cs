using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D _rb;
    public float speed;
    int angle;
    int maxAngle = 10;
    int minAngle = -60;

    public Score score;
    bool touchedGround; // Balýk yere deðidi mi

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false) // Mouse týklandýysa ve gameOver = false (Balýk ölmediyse) yukarý yönlü harekete devam et
        {
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
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
        else if (collision.gameObject.CompareTag("Column")) // Column'a temaa edildiye Oyun Sonu
        {
            // Game Over
            gameManager.GameOver();
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
                GameOver(); // Fish'deki GameOver fonksiyonu
            }
            else
            {
                // Game Over (Fish)
                GameOver();
            }
        }        
    }

    // Fish'deki GameOver
    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

}