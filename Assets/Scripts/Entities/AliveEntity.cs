using UnityEngine;
using Assets.Scripts.EntitiesActions;
using Assets.Scripts.DataStructures.Concrete;
using Assets.Scripts.Events;

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
        protected float attackAreaWidth = 1;

        [SerializeField]
        protected float attackAreaHeight = 1;

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

        public Vector3 EntityPosition
        {
            get
            {
                return transform.position;
            }
        }

        public string GetCurrentSkillName
        {
            get
            {
                return currentSkill.AttackPrefab.name;
            }
        }

        public float GetMP
        {
            get
            {
                return MP;
            }
        }

        public float GetHp
        {
            get
            {
                return HP;
            }
        }

        public float Damage
        {
            get
            {
                return damage;
            }
        }

        public float AttackAreaWidth
        {
            get
            {
                return attackAreaWidth;
            }
        }

        public float AttackAreaHeight
        {
            get
            {
                return attackAreaHeight;
            }
        }

        public virtual void TakeDamage(float dealedDamage)
        {
            HP -= dealedDamage;
            if (MustDie())
            {
                Die();
            }
        }

        public bool PossibleToTakeDamage()
        {
            return HP > 0;
        }

        public abstract void Die();

        public bool MustDie()
        {
            return HP <= 0;
        }

        public abstract void Attack();

        public virtual bool PossibleToAttack()
        {
            return Time.time > nextFireDelay;
        }

        public abstract void Move(float x, float z);

        public bool PossibleToMove()
        {
            return possibleToMove;
        }

        public abstract void CastSpell();

        public bool PossibleToCastSpell()
        {
            return (Time.time > currentSkill.NextCastDelay) &&
                   (MP >= currentSkill.ManaCost);
        }
    }
}

