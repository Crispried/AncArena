using Assets.Scripts.DataStructures.Abstract;

namespace Assets.Scripts.GameSystems.Abstract
{
    public interface IBlendTreeToggleSystem
    {
        float CurrentActionState { get; }

        IBlendTreeAction[] Actions { get; }

        float CurrentActionExecutionTime { get; }

        void NextActionState();
    }
}
