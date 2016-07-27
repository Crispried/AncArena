using UnityEngine;
using Assets.Scripts.DataStructures;
using System.Linq;
using Assets.Scripts.GameSystems.Abstract;
using Assets.Scripts.DataStructures.Abstract;

namespace Assets.Scripts.GameSystems.Concrete
{
    public class ComboSystem : IBlendTreeToggleSystem
    {
        private float currentAttackState;

        private float changeStateStep;

        [SerializeField]
        private IBlendTreeAction[] comboAttacks;

        private IBlendTreeAction currentComboAttack;

        public ComboSystem(float changeStateStep, IBlendTreeAction[] comboAttacks)
        {
            this.changeStateStep = changeStateStep;
            this.comboAttacks = comboAttacks;
            currentComboAttack = comboAttacks[0];
            currentAttackState = 0;
        }

        public float CurrentActionState
        {
            get
            {
                return currentAttackState;
            }
        }

        public float CurrentActionExecutionTime
        {
            get
            {
                return currentComboAttack.ExecutionTime;
            }
        }

        public IBlendTreeAction[] Actions
        {
            get
            {
                return comboAttacks;
            }
        }

        public void NextActionState()
        {
            if(currentAttackState + changeStateStep <= 1)
            {
                currentAttackState += changeStateStep;
                currentComboAttack = comboAttacks.Where(ca =>
                                ca.State == currentAttackState).FirstOrDefault();
            }
            else
            {
                currentAttackState = 0;
                currentComboAttack = comboAttacks[0];
            }
        }
    }
}
