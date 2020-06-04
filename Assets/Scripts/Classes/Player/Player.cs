using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sprites.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        float speed;
        Control control;
        Vector3 movement;

        void Awake()
        {
            control = GetComponent<Control>();
        }

        // Update is called once per frame
        void Update()
        {
            control.DoMove(movement * speed);
            if (Input.GetKeyDown(KeyCode.Space)) control.DoAttack(new Vector2(0, 0));
        }

        private void FixedUpdate()
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

}