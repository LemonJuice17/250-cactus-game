using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] Rigidbody2D spike;
    [SerializeField] Transform[] spawns;

    private void Awake()
    {
       
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
            Shoot2(spawn);
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }

    void Shoot2(Transform currentSpawn)
    {
        Rigidbody2D newSpike = Instantiate(spike, currentSpawn.position, Quaternion.identity);
        Vector3 dir = newSpike.transform.position - transform.position;
        newSpike.transform.up = dir;
    }
}
