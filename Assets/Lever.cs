using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject minecart;

    [SerializeField] Transform posA;
    [SerializeField] Transform posB;
    Transform curTargetPosition;

    public float smoothTime;
    public float speed;
    Vector3 velocity;

    bool minecartIsMoving;

    Crosshair crosshair;

    private void Start()
    {
        crosshair = FindObjectOfType<Crosshair>();
    }
    void Update()
    {
        if (minecartIsMoving)
        {
            MoveMinecart();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((Vector2.Distance(minecart.transform.position, posA.position) < 0.01f))
        {
            curTargetPosition = posB;
        }
        else
        {
            curTargetPosition = posA;
        }

        crosshair.DisableShooting();
        minecartIsMoving = true;
    }

    private void OnMouseDown()
    {
        if (!crosshair.canShoot)
        {
            return;
        }

        if((Vector2.Distance(minecart.transform.position, posA.position) < 0.01f))
        {
            curTargetPosition = posB;
        }
        else
        {
            curTargetPosition = posA;
        }

        crosshair.DisableShooting();
        minecartIsMoving = true;
    }

    void MoveMinecart()
    {
        minecart.transform.position = Vector3.SmoothDamp(minecart.transform.position, curTargetPosition.position, ref velocity, smoothTime, speed);

        if (Vector2.Distance(minecart.transform.position, curTargetPosition.position) < 0.01f)
        {
            minecart.transform.position = curTargetPosition.position;
            crosshair.EnableShooting();
            minecartIsMoving = false;
        }
    }
}
