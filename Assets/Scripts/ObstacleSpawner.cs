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
        randomY = Random.Range(minY, maxY);// maxY ve minY arasada rastgele bir sayý (y koordinatý) oluþturuluyor.
        GameObject newObstacle = Instantiate(obstacle); // referans obstacle nesnemizi çoðaltarak newObstacle nesnemize atýyoruz.
        newObstacle.transform.position = new Vector2(transform.position.x,randomY); // ObstacleSpawner bulunduðu x,y koordinatlarýnda bir engel oluþacak
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            // belirli zaman aralýðýnda engelimiz oluþturuluyor.
            InstantiateObstacle();
            timer = 0;
        }
    }
}
