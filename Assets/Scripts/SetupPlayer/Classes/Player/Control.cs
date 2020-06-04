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
            if (ObstacleDetect(kinetic) == false)
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
        bool ObstacleDetect(Vector2 kinetic)
        {
            Vector2 value = transform.position.normalized;
            if (value + kinetic == Vector2.zero)
            {

            }
            return false;
        }
        void MoveState(Vector2 kinetic)
        {
            animator.SetFloat("movement", Mathf.Abs(kinetic.x) + Mathf.Abs(kinetic.y));
            if (isFlipable)
                transform.localScale = new Vector3(transform.localScale.x > 0 ? kinetic.x >= 0 ? 1 : -1 : kinetic.x <= 0 ? -1 : 1, 1, 1);
        }
    }
}