using UnityEngine;
using Assets.Scripts.Entities;
using Assets.Scripts.DataStructures;
using Assets.Scripts.GameSystems.Abstract;
using Assets.Scripts.GameSystems.Concrete;
using Assets.Scripts.Events;
using System.Collections.Generic;

namespace Assets.Scripts.Contollers
{
    public class CharacterController : MonoBehaviour
    {
        private Character character;

        private Vector3 inputDirection;

        private IMovementInputSystem movementInputSystem;

        private CharacterEvents healthChanged;

        void Awake()
        {
            character = GetComponent<Character>();
            inputDirection = new Vector3();
            movementInputSystem = GetComponent<IMovementInputSystem>();
        }

        void FixedUpdate()
        {
            TryMove();
        }

        void Update()
        {
           // GetAllMobsInAttackArea();
        }

        private void TryCastSpell()
        {
            if (character.PossibleToCastSpell())
            {
                character.CastSpell();
            }
        }

        private void TryMove()
        {
            if (character.PossibleToMove())
            {
                inputDirection = movementInputSystem.GetInputDirection();
                character.Move(inputDirection.x, inputDirection.z);
            }
        }

        private void TryAttack()
        {           
            if (character.PossibleToAttack())
            {
                character.Attack();
                GetAllMobsInAttackArea();
            }
        }

        public List<Mob> GetAllMobsInAttackArea()
        {           
            List<Mob> result = new List<Mob>();
            RaycastHit[] sphereHits =
                Physics.SphereCastAll(new Ray(transform.position,
                transform.forward), character.DamageRadius.AttackRadius,
                character.DamageRadius.AttackLegnth);
            Mob tempMob;
            foreach (var sphereHit in sphereHits)
            {
                if (sphereHit.transform.tag == "Mob")
                {
                    tempMob = sphereHit.transform.gameObject.GetComponent<Mob>();
                    if (tempMob.PossibleToTakeDamage())
                    {
                        tempMob.TakeDamage(character.Damage);
                    }
                }
            }
            return result;
        }
    }
}
