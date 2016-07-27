using UnityEngine;
using Assets.Scripts.EntitiesActions;
using Assets.Scripts.DataStructures.Concrete;

namespace Assets.Scripts
{
    public abstract class AliveEntity : MonoBehaviour, IDie, IAttack,
                                        IMove, ICastSpell, ITakeDamage
    {
        [SerializeField]
        [Tooltip("Array with Skill data structure")]
        protected Skill[] skills;

        [SerializeField]
        protected float HP = 100;

        [SerializeField]
        protected float MP = 100;

        [SerializeField]
        protected float armor = 1;

        [SerializeField]
        protected float damage = 1;

        [SerializeField]
        protected float movementSpeed = 1;

        [SerializeField]
        [Tooltip("In fact determines delay between 2 attacks")]
        protected float attackSpeed = 1;

        [SerializeField]
        protected float attackRadius = 1;

        protected Animator animator;

        [SerializeField]
        protected int level = 1;

        [Tooltip("Delay between object's death and physical destruction")]
        [SerializeField]
        protected float destroyTime = 0.8F;

        protected Skill currentSkill;

        protected int skillIndex = 0;

        protected float nextFireDelay = 0.0F;

        protected bool isCollided = false;

        [Tooltip("The time for which you can continue to make combo attack. If attack willn't produce for this time combo attacks will start from begining.")]
        [SerializeField]
        protected float comboNextAttackHotTime = 3.0f;

        protected float timeLeftToMakeNextAttack;

        protected int currectComboState = 0;

        protected bool resetCombo = false;

        protected bool possibleToMove = true;

        public string GetCurrentSkillName
        {
            get
            {
                return currentSkill.AttackPrefab.name;
            }
        }

        public void TakeDamage(float dealedDamage)
        {
            HP -= dealedDamage;
        }

        public bool PossibleToTakeDamage()
        {
            if (HP > 0)
            {
                return true;
            }
            return false;
        }

        public abstract void Die();

        public bool MustDie()
        {
            if (HP <= 0)
            {
                return true;
            }
            return false;
        }

        public abstract void Attack();

        public bool PossibleToAttack()
        {
            if ((Time.time > nextFireDelay))
            {
                return true;
            }
            return false;
        }

        public abstract void Move(float x, float z);

        public bool PossibleToMove()
        {
            if (possibleToMove)
            {
                return true;
            }
            return false;
        }

        public abstract void CastSpell();

        public bool PossibleToCastSpell()
        {
            if ((Time.time > currentSkill.NextCastDelay) &&
                (MP >= currentSkill.ManaCost))
            {
                return true;
            }
            return false;
        }
    }
}

