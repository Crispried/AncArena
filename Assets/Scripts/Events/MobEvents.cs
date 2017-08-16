using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class MobEvents : MonoBehaviour
    {
        public delegate void MobEventHandler();

        public static event MobEventHandler OnHpChanged;

        public static void HpChanged()
        {
            if (OnHpChanged != null)
            {
                OnHpChanged();
            }
        }
    }
}
