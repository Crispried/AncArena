using Assets.Scripts.DataStructures.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.DataStructures.Concrete
{
    [Serializable]
    public class ComboAttack : IBlendTreeAction
    {
        [Tooltip("State of attack in blend tree")]
        [SerializeField]
        private float attackState = 0;

        [Tooltip("Time which need to execute this attack")]
        [SerializeField]
        private float executeAttackTime = 1;

        public float State
        {
            get
            {
                return attackState;
            }

            set
            {
                attackState = value;
            }
        }

        public float ExecutionTime
        {
            get
            {
                return executeAttackTime;
            }

            set
            {
                executeAttackTime = value;
            }
        }
    }
}
