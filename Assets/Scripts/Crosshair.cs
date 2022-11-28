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
    private void Awake()
    {
        Singleton();
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

    void Singleton()
    {
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
