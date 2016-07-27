using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Mob : AliveEntity
    {
        void Awake()
        {
            animator = GetComponent<Animator>();
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
    }
}
