using UnityEngine;
using Assets.Scripts.Entities;
using Assets.Scripts.DataStructures;
using Assets.Scripts.GameSystems.Abstract;
using Assets.Scripts.GameSystems.Concrete;

namespace Assets.Scripts.Contollers
{
    public class CharacterController : MonoBehaviour
    {
        private Character character;

        private Vector3 inputDirection;

        private IMovementInputSystem movementInputSystem;

        void Awake()
        {
            character = GetComponent<Character>();
            inputDirection = new Vector3();
            movementInputSystem = GetComponent<IMovementInputSystem>();
        }

        void FixedUpdate()
        {
            Move();
        }

        void Update()
        {            
            Die();
        }

        private void TryCastSpell()
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
                inputDirection = movementInputSystem.GetInputDirection();
                character.Move(inputDirection.x, inputDirection.z);
            }
        }

        private void TryAttack()
        {           
            if (character.PossibleToAttack())
            {
                character.Attack();
            }
        }
    }
}
