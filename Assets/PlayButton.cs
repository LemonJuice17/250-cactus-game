using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    Animator transitionAnimator;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        //transitionAnimator = levelManager.GetComponentInChildren<Animator>();
    }

    private void OnMouseDown()
    {
        StartCoroutine(levelManager.LoadNextLevel());
        //levelManager.LoadNextLevel();
    }
}
