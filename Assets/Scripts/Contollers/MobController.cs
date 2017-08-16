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

        private Character characterEntity;

        void Awake()
        {
            mobsGameobjects = GameObject.FindGameObjectsWithTag("Mob");
            mobs = new Mob[mobsGameobjects.Length];
            for (int i = 0; i < mobsGameobjects.Length; i++)
            {
                mobs[i] = mobsGameobjects[i].GetComponent<Mob>();
            }
            character = GameObject.FindGameObjectWithTag("Character");
            characterEntity = character.GetComponent<Character>();
        }

        void Update()
        {
            ExecuteBehaviour();
        }

        private void ExecuteBehaviour()
        {
            for (int i = 0; i < mobs.Length; i++)
            {
                if (mobs[i].IsInAttackRadiusWith(character))
                {
                    Attack(mobs[i]);
                }
                else
                {
                    Move(mobs[i]);
                }
            }
        }

        private void Move(Mob mob)
        {
            if (mob.PossibleToMove())
            {
                mob.Move(character.transform.position.x,
                         character.transform.position.z);
            }
        }

        private void Attack(Mob mob)
        {
            for (int i = 0; i < mobs.Length; i++)
            {
                if (mob.PossibleToAttack())
                {
                    mob.Attack();
                    ProcessDamage(mob);
                }
            }
        }

        private void ProcessDamage(Mob mob)
        {
            if (characterEntity.PossibleToTakeDamage())
            {
                characterEntity.TakeDamage(mob.Damage);
            }
        }
    }
}
