using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.DataStructures.Concrete
{
    [Serializable]
    public class DamageRadius
    {
        [SerializeField]
        [Tooltip("Determines radius of sphere")]
        private float attackRadius;

        [SerializeField]
        [Tooltip("Determines the length on which sphere will be projected")]
        private float attackLength;

        public float AttackRadius
        {
            get
            {
                return attackRadius;
            }
        }

        public float AttackLegnth
        {
            get
            {
                return attackLength;
            }
        }
    }
}
