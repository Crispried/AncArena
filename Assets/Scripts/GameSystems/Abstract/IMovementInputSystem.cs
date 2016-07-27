using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameSystems.Abstract
{
    public interface IMovementInputSystem
    {
        Vector3 GetInputDirection();
    }
}
