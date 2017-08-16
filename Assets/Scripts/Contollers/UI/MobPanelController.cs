using Assets.Scripts.Entities;
using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Contollers.UI
{
    public class MobPanelController : MonoBehaviour
    {
        private static float hpFillAmount = 1;

        [SerializeField]
        private Sprite hpSprite;

        private static float mobBaseHP;

        private static float mobCurrentHP;

        private Mob mob;

        private GameObject UIContainer;

        private GameObject mobPanel;

        void Awake()
        {
            UIContainer = GameObject.FindGameObjectWithTag("UI");
            mob = GetComponent<Mob>();
            mobPanel = GameObject.Find("MobPanel");
        }

        void Start()
        {
            mobBaseHP = mob.GetHp;
            MobEvents.OnHpChanged += ChangeHp;
        }

        private void ChangeHp()
        {
            mobCurrentHP = mob.GetHp;
            hpFillAmount = mobCurrentHP / mobBaseHP;
            Debug.Log(UIContainer);
            var tmpImage = mobPanel.AddComponent<Image>();
            mobPanel.GetComponent<Image>().sprite = hpSprite;
            //tmpImage.sprite = hpSprite;
            tmpImage.fillAmount = hpFillAmount;
           

            Debug.Log(tmpImage);
            Destroy(tmpImage, 1.0f);
        }
    }
}
