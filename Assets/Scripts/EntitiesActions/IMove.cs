using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.EntitiesActions
{
    public interface IMove
    {
        bool PossibleToMove();
        void Move(float x, float z);
    }
}
