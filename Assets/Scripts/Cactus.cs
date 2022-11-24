using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] Rigidbody2D spike;
    [SerializeField] Transform[] spawns;
    SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnMouseDown()
    {
        //Randomize order of array?

        foreach (var spawn in spawns)
        {
            Shoot(spawn);
            yield return new WaitForSeconds(0.5f / spawns.Length);
        }

        soundManager.Play("Cactus 1");

        Destroy(gameObject);
    }

    void Shoot(Transform currentSpawn)
    {
        soundManager.PlayOneShot("Spike Shoot");

        Rigidbody2D newSpike = Instantiate(spike, currentSpawn.position, Quaternion.identity);
        Vector3 dir = newSpike.transform.position - transform.position;
        newSpike.transform.up = dir;
    }
}
