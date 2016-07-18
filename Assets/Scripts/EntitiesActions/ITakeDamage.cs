using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.EntitiesActions
{
    public interface ITakeDamage
    {
        bool PossibleToTakeDamage();
        void TakeDamage(float damage);
    }
}
