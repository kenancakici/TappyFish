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
        randomY = Random.Range(minY, maxY);// maxY ve minY arasada rastgele bir say� (y koordinat�) olu�turuluyor.
        GameObject newObstacle = Instantiate(obstacle); // referans obstacle nesnemizi �o�altarak newObstacle nesnemize at�yoruz.
        newObstacle.transform.position = new Vector2(transform.position.x,randomY); // ObstacleSpawner bulundu�u x,y koordinatlar�nda bir engel olu�acak
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            // belirli zaman aral���nda engelimiz olu�turuluyor.
            InstantiateObstacle();
            timer = 0;
        }
    }
}
