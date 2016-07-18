using Assets.Scripts.EntitiesActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Mob : AliveEntity
    {
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

        public override void Move(float x, float z)
        {
            transform.LookAt(new Vector3(x, 0.0f, z));
            transform.position = Vector3.MoveTowards
                (transform.position, new Vector3(x, 0.0f, z),
                    movementSpeed * Time.deltaTime);
        }
    }
}
