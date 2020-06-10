using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWormHole : MonoBehaviour
{
    [SerializeField]
    int[] WormHole_1_range, WormHole_2_range;
    private Quaternion rotation;
    private bool exist = false;
    private float timer;

    public static Vector3 position_1;
    public static Vector3 position_2;
    public GameObject WormHole;
    public GameObject WormHole_2;

    // Start is called before the first frame update
    void Start()
    {
        ChangePosition();
        //position = new Vector3(10, 10, 0);
        rotation = new Quaternion(0, 90, 0, 0);
        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Random.Range(0, 200) == 10 && exist == false)
        {
            ChangePosition();
            Instantiate(WormHole, position_1, rotation);
            Instantiate(WormHole_2, position_2, rotation);
            exist = true;
        }
        if (exist == true)
        {
            timer += Time.deltaTime;
            if (timer >= 15)
            {
                timer = 0;
                exist = false;
            }
        }
    }

    void ChangePosition()
    {
        position_1 = new Vector3(Random.Range(WormHole_1_range[0], WormHole_1_range[1]), Random.Range(WormHole_1_range[2], WormHole_1_range[3]), 0);
        position_2 = new Vector3(Random.Range(WormHole_2_range[0], WormHole_1_range[1]), Random.Range(WormHole_1_range[2], WormHole_1_range[3]), 0);
    }
}
