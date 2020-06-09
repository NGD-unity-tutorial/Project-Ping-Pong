using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed=10;
    private Vector2 direction;
    private float disappear;
    private bool disCountUp = true;
    private Color32 color;
    private bool isThrough;           //判斷是否穿過蟲洞
    private float timer;
    private Vector3 wormHole_1_Pos;
    private Vector3 wormHole_2_Pos;
    private Vector3 nowSpot;           //紀錄當前位置
    private Quaternion nowRotation;    //紀錄當前角度


    public GameObject wormHole_1;
    public GameObject wormHole_2;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float angle;

    /*private void Awake()
    {
        nowRotation = gameObject.transform.rotation;
    }*/
    void Start()
    {
        disappear = 255;
        speed = 10;
        //angle = nowRotation.z;
        //angle = 20;
        CountDir();
        Disappear();
        SetColor();
        isThrough = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        nowRotation = gameObject.transform.rotation;                //紀錄當前位置角度
        nowSpot = gameObject.transform.position;
        
        if (angle >= 360)
        {
            angle -= 360;
        }
        if (angle < 0)
        {
            angle += 360;
        }
        CountDir();
        transform.eulerAngles = new Vector3(0, 0, angle);           //決定火球飛行方向
        transform.Translate(direction * speed * Time.deltaTime);    //火球前進

        if (Input.GetKey(KeyCode.Q))                                //隱形球
        {
            //animator.
            Disappear();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            disappear=255;
        }

        if (Input.GetKey(KeyCode.R))                                //旋轉球
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
        if (isThrough == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5)
            {
                timer = 0;
                isThrough = false;
            }
        }
    }

    void CountDir()
    {
        direction = new Vector2(1,0);
        //direction = new Vector2(Mathf.Cos(angle * (Mathf.PI / 180)), Mathf.Sin(angle * (Mathf.PI / 180)));
    }

    void Disappear()
    {
        SetColor();
        color.a = (byte)(disappear);
        if (disappear >= 255)
        {
            disCountUp = false;
        }
        if (disappear <= 1)
        {
            disCountUp = true;
        }
        if (disCountUp)
        {
            disappear +=2;
        }
        else
        {
            disappear -=2;
        }
        spriteRenderer.color = color;
    }
    void SetColor()
    {
        color.r = 255;
        color.b = 255;
        color.g = 255;
    }
    void OnCollisionEnter2D(Collision2D collision)          //碰撞牆壁
    {
        if (collision.gameObject.name == "Up")
        {
            angle = (angle) * -1;
        }
        if (collision.gameObject.name == "Down")
        {
            angle = (angle) * -1;
        }
        if (collision.gameObject.name == "Left")
        {
            angle = (angle - 180) * -1;
        }
        if (collision.gameObject.name == "Right")
        {
            angle = (angle - 180) * -1;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        wormHole_1_Pos = InstantiateWormHole.position_1;
        wormHole_2_Pos = InstantiateWormHole.position_2;
        if (isThrough == false)
        {
            if (collision.gameObject.CompareTag("WormHole_1"))
            {
                transform.position = wormHole_2_Pos;

            }
            if (collision.gameObject.CompareTag("WormHole_2"))
            {
                transform.position = wormHole_1_Pos;

            }
            isThrough = true;
        }
    }
}
