using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using Assets.Scripts.DataStructures;
using Assets.Scripts.GameSystems;
using System;

namespace Assets.Scripts.Contollers
{
    public class CharacterController : MonoBehaviour
    {
        private Character character;

        private Direction inputDirection;

        void Awake()
        {
            character = GetComponent<Character>();
            inputDirection = new Direction();
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

        private void CastSpell()
        {
            if (character.PossibleToCastSpell())
            {
                character.CastSpell();
            }
        }

        private void Die()
        {
            if (character.MustDie())
            {
                character.Die();
            }
        }

        private void Move()
        {
            if (character.PossibleToMove())
            {
                inputDirection = MovementInputSystem.GetInputDirection();
                character.Move(inputDirection.X, inputDirection.Z);
            }
        }

        private void Attack()
        {
            if (character.PossibleToAttack())
            {
                character.Attack();
            }
        }
    }
}
