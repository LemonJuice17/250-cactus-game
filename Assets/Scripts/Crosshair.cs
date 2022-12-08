using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    static public Crosshair instance;

    public Color activeColor;
    public Color inactiveColor;

    public SpriteRenderer spriteRenderer;

    private Vector3 mousePosition;
    public Vector3 Offset;

    public bool canShoot;
    private void Awake()
    {
        Cursor.visible = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition + Offset;
    }

    public void SetInactiveColor()
    {
        spriteRenderer.color = inactiveColor;
    }

    public void SetActiveColor()
    {
        spriteRenderer.color = activeColor;
    }

    public void DisableShooting()
    {
        canShoot = false;
    }

    public void EnableShooting()
    {
        canShoot = true;
    }
}
