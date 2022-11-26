using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;

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
            foreach (GameObject balloon in balloons)
            {
                balloon.GetComponent<Balloon>().enabled = false;
            }

            levelManager.ReloadLevel();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            levelManager.LoadNextLevel();
        }
    }

    public void CheckForWin()
    {
        if(balloons.Count <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("Win");
        levelManager.LoadNextLevel();
    }
}
