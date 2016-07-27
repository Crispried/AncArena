using UnityEngine;
using Assets.Scripts.Entities;

namespace Assets.Scripts.Contollers
{
    public class MobController : MonoBehaviour
    {
        private Mob mob;

        private GameObject[] mobsGameobjects;

        private Mob[] mobs;

        private GameObject character;

        void Awake()
        {
            mobsGameobjects = GameObject.FindGameObjectsWithTag("Mob");
            mobs = new Mob[mobsGameobjects.Length];
            for (int i = 0; i < mobsGameobjects.Length; i++)
            {
                mobs[i] = mobsGameobjects[i].GetComponent<Mob>();
            }
            character = GameObject.FindGameObjectWithTag("Character");
        }

        void FixedUpdate()
        {
            Move();
        }

        void Update()
        {
            Attack();
            CastSpell();
            Die();
        }

        private void Die()
        {
            for (int i = 0; i < mobs.Length; i++)
            {
                if (mobs[i].MustDie())
                {
                    mobs[i].Die();
                }
            }
        }

        private void CastSpell()
        {
        }

        private void Move()
        {
            for (int i = 0; i < mobs.Length; i++)
            {
                if (mobs[i].PossibleToMove())
                {
                    mobs[i].Move(character.transform.position.x,
                             character.transform.position.z);
                }
            }
        }

        private void Attack()
        {
        }
    }
}
