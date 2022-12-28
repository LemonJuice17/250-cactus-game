using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] Rigidbody2D spike;
    [SerializeField] Transform[] spawns;
    [SerializeField] float totalTime;
    [SerializeField] SoundManager soundManager;
    [SerializeField] Crosshair crosshair;

    private void Awake()
    {
        
    }

    void Start()
    { 
        //soundManager = FindObjectOfType<SoundManager>();
        crosshair = FindObjectOfType<Crosshair>();
    }

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (!crosshair.canShoot)
        {
            return;
        }

        crosshair.SetActiveColor();
    }

    private void OnMouseStay()
    {
        if (!crosshair.canShoot)
        {
            return;
        }

        crosshair.SetActiveColor();
    }

    private void OnMouseExit()
    {
        crosshair.SetInactiveColor();
    }

    void Reshuffle(Transform[] spawns)
    {
        // Knuth shuffle algorithm
        for (int t = 0; t < spawns.Length; t++)
        {
            Transform tmp = spawns[t];
            int r = Random.Range(t, spawns.Length);
            spawns[t] = spawns[r];
            spawns[r] = tmp;
        }
    }

    private IEnumerator OnMouseDown()
    {
        if (!crosshair.canShoot)
        {
            yield break;
        }

        GetComponent<CircleCollider2D>().enabled = false;
        Reshuffle(spawns);

        soundManager = FindObjectOfType<SoundManager>();

        foreach (var spawn in spawns)
        {
            Shoot(spawn);
            yield return new WaitForSeconds(totalTime / spawns.Length);
        }

        if (soundManager)
            soundManager.Play("Cactus 1");

        Destroy(gameObject);
    }

    void Shoot(Transform currentSpawn)
    {
       // if (soundManager)
       //     soundManager.PlayOneShot("Spike Shoot");

        Rigidbody2D newSpike = Instantiate(spike, currentSpawn.position, Quaternion.identity);
        Vector3 dir = newSpike.transform.position - transform.position;
        newSpike.transform.up = dir;
    }

    private void OnDestroy()
    {
        crosshair.EnableShooting();
        crosshair.SetInactiveColor();
    }
}
