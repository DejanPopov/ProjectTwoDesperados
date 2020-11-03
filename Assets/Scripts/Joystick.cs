using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;

    //Is player touching screen
    private bool touchStart = false;

    //2D - 2 Vectors needed
    private Vector2 pointA;
    private Vector2 pointB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Converter
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
               Input.mousePosition.y, Camera.main.transform.position.z));
        }
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
