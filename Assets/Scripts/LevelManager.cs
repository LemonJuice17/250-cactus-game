using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public LevelManager instance;
    [SerializeField] Animator transitionAnimator;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Singleton();
    }
    IEnumerator LoadLevel(int buildIndex)
    {
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(buildIndex);
        
    }

    public IEnumerator LoadNextLevel()
    {
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //transitionAnimator.SetTrigger("end");
    }

    public IEnumerator ReloadLevel()
    {
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
