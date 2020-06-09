using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFireBall : MonoBehaviour
{


    public GameObject originFireBall;
    public GameObject fireBall; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowSpot;
        Quaternion splitRotation;  //分裂球角度
        nowSpot = originFireBall.transform.position;
        if (Input.GetKeyDown(KeyCode.C))                                //分裂球
        {
            Instantiate(fireBall, nowSpot, Quaternion.Euler(0,0,90f));
        }
    }
}
