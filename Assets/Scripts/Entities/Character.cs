using System.Collections;
using UnityEngine;
using Assets.Scripts.DataStructures.Concrete;
using Assets.Scripts.GameSystems.Concrete;
using Assets.Scripts.GameSystems;
using Assets.Scripts.GameSystems.Abstract;
using System;
using Assets.Scripts.Events;

namespace Assets.Scripts.Entities
{
    public class Character : AliveEntity
                             
    {
        private float experience;

        private Rigidbody characterRigidbody;

        private Vector3 movement;

        private IBlendTreeToggleSystem comboSystem;

        [SerializeField]
        private DamageRadius damageRadius;

        [SerializeField]
        private float changeStateStep;

        public DamageRadius DamageRadius
        {
            get
            {
                return damageRadius;
            }
        }

        public ComboAttack[] comboAttacks;

        void Awake()
        {
            animator = GetComponent<Animator>();
            currentSkill = skills[skillIndex];
            characterRigidbody = GetComponent<Rigidbody>();
            timeLeftToMakeNextAttack = comboNextAttackHotTime;
            comboSystem = new ComboSystem(changeStateStep, comboAttacks);
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
            possibleToMove = false;
            nextFireDelay = Time.time + attackSpeed;
            PlayAttackAnimation();
        }

        private void PlayAttackAnimation()
        {
            animator.SetTrigger("Attacking");
            animator.SetFloat("ComboState", comboSystem.CurrentActionState);
            StartCoroutine(ActivatePossibilityToMoveAfter(comboSystem.CurrentActionExecutionTime));
            comboSystem.NextActionState();
        }

        IEnumerator ActivatePossibilityToMoveAfter(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            possibleToMove = true;
        }

        public override void Die()
        {
            animator.SetTrigger("Die");
            Destroy(this.gameObject, destroyTime);
        }

        public override void CastSpell()
        {
            MP -= currentSkill.ManaCost;
            currentSkill.NextCastDelay = Time.time + currentSkill.Cooldown;
            PlaySpellAnimation();
            CharacterEvents.MpChanged();
        }

        private void PlaySpellAnimation()
        {
            possibleToMove = false;
            animator.SetTrigger("Casting");
            animator.SetFloat("SkillState", currentSkill.AnimationState);
            StartCoroutine(CastAfter(currentSkill.StartDelay));
        }

        private IEnumerator CastAfter(float startDelay)
        {
            yield return new WaitForSeconds(startDelay);
            Instantiate(currentSkill.AttackPrefab);
            possibleToMove = true;
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

        public override void TakeDamage(float dealedDamage)
        {
            CharacterEvents.HpChanged();
            base.TakeDamage(dealedDamage);
        }
    }
}
