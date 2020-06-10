using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sprites.Player
{
    public class Control : MonoBehaviour, IBasicControl
    {
        [SerializeField]
        float startAttackDuration;
        float attackDuration;
        [SerializeField]
        bool isFlipable;
        [SerializeField]
        float obstacleDistance;

        Rigidbody2D rb;
        Animator animator;

        public void DoAttack(Vector2 str)
        {
            if (attackDuration <= 0)
            {
                attackDuration = startAttackDuration;
                animator.SetTrigger("Attack1");
            }
        }
        public void DoMove(Vector2 kinetic)
        {
            MoveState(kinetic);
            ObstacleDetect(ref kinetic);
            Debug.Log(kinetic);
            transform.Translate(kinetic * Time.deltaTime);

        }
        public void DoSkill(int mode)
        {
            //Skill feature.
        }
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
        void Update()
        {
            if (attackDuration > 0) attackDuration -= Time.deltaTime;
        }
        void ObstacleDetect(ref Vector2 kinetic)
        {
            if (Physics2D.Raycast(transform.position, new Vector2(kinetic.x, 0), obstacleDistance, LayerMask.GetMask("Obstacle")))
            {
                kinetic = new Vector2(0, kinetic.y);
            }
            if (Physics2D.Raycast(transform.position, new Vector2(0, kinetic.y), obstacleDistance, LayerMask.GetMask("Obstacle")))
            {
                kinetic = new Vector2(kinetic.x, 0);
            }
        }
        void MoveState(Vector2 kinetic)
        {
            animator.SetFloat("movement", Mathf.Abs(kinetic.x) + Mathf.Abs(kinetic.y));
            if (isFlipable)
                transform.localScale = new Vector3(transform.localScale.x > 0 ? kinetic.x >= 0 ? 1 : -1 : kinetic.x <= 0 ? -1 : 1, 1, 1);
        }
    }
}