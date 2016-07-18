using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIController : MonoBehaviour
    {
        static float hpFillAmount = 1;

        static float mpFillAmount = 1;

        static float expFillAmount = 1;

        [SerializeField]
        Image hpContent;

        [SerializeField]
        Image mpContent;

        AliveEntity character;

        Text hpAmount;

        Text mpAmount;

        Text expAmount;

        Text level;

        Text currentSkill;

        static float characterBaseHP;

        static float characterCurrentHP;

        static float characterBaseMP;

        static float characterCurrentMP;

        static float characterCurrentExperience;

        void Awake()
        {
            var textComponents = GetComponentsInChildren<Text>();
            hpAmount = textComponents[0];
            mpAmount = textComponents[1];
            level = GameObject.Find("lvl amount").GetComponent<Text>();
            currentSkill = GameObject.Find("CurrentSkill").GetComponent<Text>();
            character = GameObject.FindGameObjectWithTag("Character").GetComponent<AliveEntity>();

           // characterBaseHP = character.HP;
            characterCurrentHP = characterBaseHP;

           // characterBaseMP = character.MP;
            characterCurrentMP = characterBaseMP;
            //level.text = character.level.ToString();
        }

        void Update()
        {
            HandleUI();
        }

        private void HandleUI()
        {
            hpContent.fillAmount = hpFillAmount;
            hpAmount.text = characterCurrentHP.ToString();
            mpContent.fillAmount = mpFillAmount;
            mpAmount.text = characterCurrentMP.ToString();
            currentSkill.text = character.GetCurrentSkillName;
        }

        public static void ChangeHealthBar(float currentHP)
        {
            characterCurrentHP = currentHP;
            hpFillAmount = characterCurrentHP / characterBaseHP;
        }

        public static void ChangeManaBar(float currentMP)
        {
            characterCurrentMP = currentMP;
            mpFillAmount = characterCurrentMP / characterBaseMP;
        }

        public static void ChangeExperienceBar(float currentExperience, int currentLevel)
        {
            Debug.Log(currentExperience);
            characterCurrentExperience = currentExperience;
            expFillAmount = currentExperience / (currentLevel * 1000);
        }
    }
}
