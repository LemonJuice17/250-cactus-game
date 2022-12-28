using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    static public Crosshair instance;

    public Color activeColor;
    public Color inactiveColor;

    public SpriteRenderer spriteRenderer;
    [SerializeField] Sprite smallCrosshair;
    [SerializeField] Sprite largeCrosshair;

    private Vector3 mousePosition;
    public Vector3 Offset;

    public bool canShoot;
    SoundManager soundManager;

    private void Awake()
    {
        Cursor.visible = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition + Offset;

        if (canShoot && Input.GetMouseButtonDown(0))
        {
            
            soundManager.PlayOneShot("Click");
        }
    }

    public void SetInactiveColor()
    {
        spriteRenderer.color = inactiveColor;
        spriteRenderer.sprite = smallCrosshair;
    }

    public void SetActiveColor()
    {
        spriteRenderer.color = activeColor;
        spriteRenderer.sprite = largeCrosshair;
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
