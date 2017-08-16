using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class CharacterEvents : MonoBehaviour
    {
        public delegate void CharacterEventHandler();

        public static event CharacterEventHandler OnMpChanged;

        public static event CharacterEventHandler OnHpChanged;

        public static void HpChanged()
        {
            if (OnHpChanged != null)
            {
                OnHpChanged();
            }
        }

        public static void MpChanged()
        {
            if(OnMpChanged != null)
            {
                OnMpChanged();
            }
        }
    }
}
