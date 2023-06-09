using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    public float maxTime;
    public float maxY;
    public float minY;
    float randomY;

    public void InstantiateObstacle()
    {
        randomY = Random.Range(minY, maxY);// maxY ve minY arasada rastgele bir sayı (y koordinatı) oluşturuluyor.
        GameObject newObstacle = Instantiate(obstacle); // referans obstacle nesnemizi çoğaltarak newObstacle nesnemize atıyoruz.
        newObstacle.transform.position = new Vector2(transform.position.x, randomY); // ObstacleSpawner bulunduğu x,y koordinatlarında bir engel oluşacak
    }
    void Start()
    {

    }


    void Update()
    {
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                // belirli zaman aralığında engelimiz oluşturuluyor.
                InstantiateObstacle();
                timer = 0;
            }
        }


    }
}
