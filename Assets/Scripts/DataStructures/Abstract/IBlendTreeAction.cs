using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DataStructures.Abstract
{
    public interface IBlendTreeAction
    {
        float State { get; set; }
        float ExecutionTime { get; set; }
    }
}
