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

    void OnMouseDown()
    {
        if (!crosshair.canShoot)
        {
            return;
        }

        GetComponent<CircleCollider2D>().enabled = false;
        soundManager = FindObjectOfType<SoundManager>();

        foreach (var spawn in spawns)
        {
            Shoot(spawn);
        }

        if (soundManager)
            soundManager.Play("Cactus 1");

        Destroy(gameObject);
    }

    void Shoot(Transform currentSpawn)
    {
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
