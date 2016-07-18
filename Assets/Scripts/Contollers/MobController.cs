using UnityEngine;
using System.Collections.Generic;
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
                if (mob.MustDie())
                {
                    mob.Die();
                }
            }
        }

        private void CastSpell()
        {
        }

        private void Move()
        {
            if (mob.PossibleToMove())
            {
                mob.Move(character.transform.position.x,
                         character.transform.position.z);
            }
        }

        private void Attack()
        {
        }
    }
}
