using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;

    private void Awake()
    {
        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); // Kameranýn Sol alt köþesini iþaret ettik, LeftMovement.cs içerisinde kullandýk
        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
