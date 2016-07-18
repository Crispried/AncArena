using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.EntitiesActions
{
    public interface IAttack
    {
        bool PossibleToAttack();
        void Attack();
    }
}
