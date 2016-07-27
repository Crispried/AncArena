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
        [SerializeField]
        private float attackState = 0;

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
