using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject minecart;

    [SerializeField] Transform posA;
    [SerializeField] Transform posB;
    [SerializeField] Transform curTargetPosition;
    SpriteRenderer spriteRenderer;
    SoundManager soundManager;

    public float smoothTime;
    public float speed;
    Vector3 velocity;

    bool minecartIsMoving;

    Crosshair crosshair;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        crosshair = FindObjectOfType<Crosshair>();
        soundManager = FindObjectOfType<SoundManager>();
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
        FlipLever();
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

    void FlipLever()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;

        if(curTargetPosition == posA)
        {
            curTargetPosition = posB;
        }
        else
        {
            curTargetPosition = posA;
        }

        /*if ((Vector2.Distance(minecart.transform.position, posA.position) < 0.01f))
        {
            curTargetPosition = posB;
        }
        else
        {
            curTargetPosition = posA;
        }*/

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Lever - Hit");
        crosshair.DisableShooting();
        minecartIsMoving = true;
    }
}
