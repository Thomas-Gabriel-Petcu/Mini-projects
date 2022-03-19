using UnityEngine;

public abstract class State
{
    private string _name;
    protected FiniteStateMachine fsm;
    public State(string name, FiniteStateMachine fsm)
    {
        _name = name;
        this.fsm = fsm;
    }

    #region functions
    public virtual void OnEnter() { }
    public virtual void OnLogicUpdate() { }
    public virtual void OnPhysicsUpdate() { }
    public virtual void OnExit() { }

    #endregion
}
