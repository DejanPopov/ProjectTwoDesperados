using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    //JoyStick
    public Transform innerCircle;
    public Transform outerCircle;

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

            //Joystick
            innerCircle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;

            //Enable anim when its touched
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
               Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;

        }
    }

    //Psyhics and movement caluculation
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;

            //Direction
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            //Reverse value
            moveCharacter(direction * 1);

            //Joystick
            innerCircle.transform.position = new Vector2(pointA.x + direction.x,
                pointA.y + direction.y) * 1;
        }
        else
        {
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
