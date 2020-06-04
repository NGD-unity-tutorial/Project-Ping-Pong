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
            transform.Translate(kinetic * Time.deltaTime);
            animator.SetFloat("movement", Mathf.Abs(kinetic.x) + Mathf.Abs(kinetic.y));
            if (isFlipable)
                transform.localScale = new Vector3(transform.localScale.x > 0 ? kinetic.x >= 0 ? 1 : -1 : kinetic.x <= 0 ? -1 : 1, 1, 1);
        }
        public void DoSkill(int mode)
        {

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
    }
}