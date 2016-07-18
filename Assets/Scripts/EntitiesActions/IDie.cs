using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.EntitiesActions
{
    public interface IDie
    {
        bool MustDie();
        void Die();
    }
}
