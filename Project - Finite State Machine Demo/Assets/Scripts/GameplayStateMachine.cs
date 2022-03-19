using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayStateMachine : FiniteStateMachine
{
    public CenterState centerState;
    public BottomState bottomState;
    public TopState topState;
    public RightState rightState;
    public LeftState leftState;

    private void Awake()
    {
        centerState = new CenterState(this);
        bottomState = new BottomState(this);
        topState = new TopState(this);
        rightState = new RightState(this);
        leftState = new LeftState(this);
    }

    public override State GetInitialState()
    {
        return centerState;
    }
}
