using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager.balloons.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<SoundManager>().Play("Pop");

        gameManager.balloons.Remove(gameObject);
        gameManager.CheckForWin();
        Destroy(gameObject);
    }
}
