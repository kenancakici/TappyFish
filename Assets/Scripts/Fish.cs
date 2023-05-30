using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    int angle;
    int maxAngle = 10;
    int minAngle = -60;

    public Score score;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        FishSwim();     
        transform.rotation = Quaternion.Euler(0,0,angle); // rotasyonu güncellemek için kullandýk
    }
    void FixedUpdate()
    {
        FishRotation(); // Daha yumuþak bir hareket elde ediyoruz.
    }             
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            print("PUAN.....");
           // score.Scored();
        }
    }
    

}