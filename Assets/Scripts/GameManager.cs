using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    SoundManager soundManager;
    public List<GameObject> balloons;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("RestartSFX", 0.25f);
            StartCoroutine(levelManager.ReloadLevel());
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(levelManager.LoadNextLevel());
        }
    }

    public void CheckForWin()
    {
        if(balloons.Count <= 0)
        {
            Invoke("VictorySFX", 0.25f);
            Invoke("Win", 0.8f);
        }
    }
    void RestartSFX()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Restart");
    }

    void VictorySFX()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Victory");
    }
    void Win()
    {
        StartCoroutine(levelManager.LoadNextLevel());
    }
}
