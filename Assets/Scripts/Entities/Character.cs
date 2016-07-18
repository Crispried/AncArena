using Assets.Scripts.EntitiesActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Character : AliveEntity
                             
    {
        private float experience;

        private Rigidbody characterRigidbody;

        private Vector3 movement;

        void Awake()
        {
            animator = GetComponent<Animator>();
            currentSkill = skills[skillIndex];
            characterRigidbody = GetComponent<Rigidbody>();
            timeLeftToMakeNextAttack = comboNextAttackHotTime;
        }

        public override void Move(float x, float z)
        {
            movement.Set(x, 0f, z);
            movement = movement.normalized * movementSpeed;
            characterRigidbody.MovePosition(transform.position + movement);
            transform.LookAt(transform.position + movement);
            PlayMoveAnimation(x, z);
        }

        private void PlayMoveAnimation(float x, float z)
        {
            bool moving = x != 0f || z != 0f;
            animator.SetBool("Moving", moving);
        }

        public override void Attack()
        {
            PlayAttackAnimation();
        }

        private void PlayAttackAnimation()
        {
            Debug.Log("Currect combo attack animation played here");
        }

        public override void Die()
        {
            animator.SetTrigger("Die");
            Destroy(this.gameObject, destroyTime);
        }

        public void NextSkill()
        {
            skillIndex++;
            if (skillIndex >= skills.Length)
            {
                skillIndex = 0;
            }
            currentSkill = skills[skillIndex];
        }

        public void PrevSkill()
        {
            skillIndex--;
            if (skillIndex < 0)
            {
                skillIndex = skills.Length - 1;
            }
            currentSkill = skills[skillIndex];
        }
    }
}
