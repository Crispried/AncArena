using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class ComboController
    {
        public static void StartComboExitEvent(ref bool resetCombo, float timeToMakeCombo, ref float timeLeftToMakeCombo, ref int currectComboState)
        {
            if (resetCombo)
            {
                timeLeftToMakeCombo -= Time.deltaTime;
                if (timeLeftToMakeCombo <= 0)
                {
                    ResetCombo(ref resetCombo, timeToMakeCombo, ref timeLeftToMakeCombo, ref currectComboState);
                }
            }
        }

        public static void ResetCombo(ref bool resetCombo, float timeToMakeCombo, ref float timeLeftToMakeCombo, ref int currectComboState)
        {
            currectComboState = 0;
            resetCombo = false;
            timeLeftToMakeCombo = timeToMakeCombo;
        }
    }
}
