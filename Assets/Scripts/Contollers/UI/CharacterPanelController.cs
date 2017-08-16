using Assets.Scripts.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Contollers.UI
{
    public class CharacterPanelController : MonoBehaviour
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

        static float characterBaseHP;

        static float characterCurrentHP;

        static float characterBaseMP;

        static float characterCurrentMP;

        static float characterCurrentExperience;

        void Awake()
        {
            hpAmount = GameObject.Find("HPAmount").GetComponent<Text>();
            mpAmount = GameObject.Find("MPAmount").GetComponent<Text>();
            level = GameObject.Find("LVLAmount").GetComponent<Text>();
            character = GameObject.FindGameObjectWithTag("Character").GetComponent<AliveEntity>();
        }

        void Start()
        {
            characterBaseHP = character.GetHp;
            characterBaseMP = character.GetMP;
            hpAmount.text = characterBaseHP.ToString();
            mpAmount.text = characterBaseMP.ToString();
            CharacterEvents.OnHpChanged += ChangeHp;
            CharacterEvents.OnMpChanged += ChangeMp;
        }

        private void ChangeMp()
        {
            characterCurrentMP = character.GetMP;
            mpFillAmount = characterCurrentMP / characterBaseMP;
            mpContent.fillAmount = mpFillAmount;
            mpAmount.text = characterCurrentMP.ToString();
        }

        private void ChangeHp()
        {
            characterCurrentHP = character.GetHp;
            hpFillAmount = characterCurrentHP / characterBaseHP;
            hpContent.fillAmount = hpFillAmount;
            hpAmount.text = characterCurrentHP.ToString();
        }
    }
}
