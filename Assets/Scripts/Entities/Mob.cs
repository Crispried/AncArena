using Assets.Scripts.DataStructures.Concrete;
using Assets.Scripts.Events;
using Assets.Scripts.GameSystems.Abstract;
using Assets.Scripts.GameSystems.Concrete;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Mob : AliveEntity
    {
        private IBlendTreeToggleSystem comboSystem;

        [SerializeField]
        private float changeStateStep;

        [SerializeField]
        protected float attackRadius = 1;

        public ComboAttack[] comboAttacks;

        public float AttackRadius
        {
            get
            {
                return attackRadius;
            }
        }

        void Awake()
        {
            animator = GetComponent<Animator>();
            comboSystem = new ComboSystem(changeStateStep, comboAttacks);
        }

        public override void Attack()
        {
            possibleToMove = false;
            animator.SetBool("Moving", false);
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

        public override void Move(float x, float z)
        {
            transform.LookAt(new Vector3(x, 0.0f, z));
            transform.position = Vector3.MoveTowards
                (transform.position, new Vector3(x, 0.0f, z),
                    movementSpeed * Time.deltaTime);
            PlayMoveAnimation(x, z);
        }

        private void PlayMoveAnimation(float x, float z)
        {
            bool moving = x != 0f || z != 0f;
            animator.SetBool("Moving", moving);
        }

        public override void CastSpell()
        {
            
        }

        public bool IsInAttackRadiusWith(GameObject gameObject)
        {
            return Vector3.Distance(
                transform.position, gameObject.transform.position) <= attackRadius;
        }

        public override void TakeDamage(float dealedDamage)
        {
            MobEvents.HpChanged();
            base.TakeDamage(dealedDamage);
        }
    }
}
