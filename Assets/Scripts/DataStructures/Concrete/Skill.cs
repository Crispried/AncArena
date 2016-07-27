using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.DataStructures.Concrete
{
    [Serializable]
    public class Skill
    {
        [SerializeField]
        [Tooltip("Value which determines skill animation in blend tree")]
        private float animationState;

        [SerializeField]
        private float damage;

        [SerializeField]
        private float cooldown;

        [SerializeField]
        private GameObject attackPrefab;

        [SerializeField]
        private float manaCost;

        private float nextCastDelay = 0.0f;

        [SerializeField]
        private float startDelay = 0;

        public float NextCastDelay
        {
            get
            {
                return nextCastDelay;
            }
            set
            {
                nextCastDelay = value;
            }
        }

        public float ManaCost
        {
            get
            {
                return manaCost;
            }
            set
            {
                manaCost = value;
            }
        }

        public float Cooldown
        {
            get
            {
                return cooldown;
            }
            set
            {
                cooldown = value;
            }
        }

        public float Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }

        public GameObject AttackPrefab
        {
            get
            {
                return attackPrefab;
            }
            set
            {
                attackPrefab = value;
            }
        }

        public float AnimationState
        {
            get
            {
                return animationState;
            }
            set
            {
                animationState = value;
            }
        }

        public float StartDelay
        {
            get
            {
                return startDelay;
            }
            set
            {
                startDelay = value;
            }
        }
    }
}
