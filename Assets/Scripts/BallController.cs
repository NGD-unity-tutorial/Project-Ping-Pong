using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed=10;
    public float angle=0;

    private Vector2 direction;
    void Start()
    {
        speed = 10;
        angle = 0;
        CountDir();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Up")
        {
            angle = (angle)*-1;
        }
        if (collision.gameObject.name == "Down")
        {
            angle = (angle) * -1;
        }
        if (collision.gameObject.name == "Left")
        {
            angle = (angle-180) * -1;
        }
        if (collision.gameObject.name == "Right")
        {
            angle = (angle-180) * -1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (angle >= 360)
        {
            angle -= 360;
        }
        if (angle < 0)
        {
            angle += 360;
        }
        CountDir();
        transform.Translate(direction * speed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.R))
        {
            angle +=3 ;
        }
        if (Input.GetKey(KeyCode.W))
        {
            angle =90;
        }
        if (Input.GetKey(KeyCode.A))
        {
            angle = 180;
        }
        if (Input.GetKey(KeyCode.S))
        {
            angle = 270;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (angle > 180)
            {
                angle --;
            }
            if (angle <180)
            {
                angle ++;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (angle > 0&&angle<180)
            {
                angle--;
            }
            if (angle < 360&&angle>=180)
            {
                angle++;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (angle > 90&&angle<270)
            {
                angle--;
            }
            if ((angle < 90&&angle>=0)|| (angle < 360 && angle >=270))
            {
                angle++;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if ((angle < 90 && angle >= 0) || (angle < 360 && angle >= 270))
            {
                angle--;
            }
            if (angle < 270&&angle>=90)
            {
                angle++;
            }
        }

    }

    void CountDir()
    {
        direction = new Vector2(Mathf.Cos(angle * (Mathf.PI / 180)), Mathf.Sin(angle * (Mathf.PI / 180)));
    }
}
