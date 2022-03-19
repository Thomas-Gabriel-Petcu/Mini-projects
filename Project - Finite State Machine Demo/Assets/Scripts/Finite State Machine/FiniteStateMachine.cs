using UnityEngine;

public abstract class FiniteStateMachine : MonoBehaviour
{
    private State _activeState;

    // Start is called before the first frame update
    void Start()
    {
        _activeState = GetInitialState();
        if (_activeState !=null)
        {
            _activeState.OnEnter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _activeState.OnLogicUpdate();
    }

    public virtual State GetInitialState()
    {
        return null;
    }

    public virtual void ChangeState(State state)
    {
        _activeState.OnExit();
        _activeState = state;
        _activeState.OnEnter();
    } 
}
