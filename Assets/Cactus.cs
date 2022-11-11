using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] Rigidbody2D spike;
    [SerializeField] Transform[] shootDirs;

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

    private void OnMouseDown()
    {
        foreach (var shootDir in shootDirs)
        {
            Shoot(shootDir);
        }

        Destroy(gameObject);
    }

    void Shoot(Transform currentDir)
    {
        //Vector2 dir = (transform.position - currentDir.position).normalized;
        Rigidbody2D newSpike = Instantiate(spike, transform.position, Quaternion.identity);
        //newSpike.transform.right = currentDir.position - newSpike.transform.position;

        float angle = Mathf.Atan2(currentDir.position.y, currentDir.position.x) * Mathf.Rad2Deg;
        newSpike.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
