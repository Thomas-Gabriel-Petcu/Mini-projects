using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterState : State
{
    GameObject obj;
    public CenterState(GameplayStateMachine gsm) : base("CenterState", gsm) { }

    public override void OnEnter()
    {
        base.OnEnter();
        if (obj == null) obj = GameObject.Find("Center");
        if (obj == null) return;

        obj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
    }

    public override void OnExit()
    {
        base.OnExit();
        if (obj == null) return;
        obj.GetComponent<SpriteRenderer>().color = new Color(244, 0, 0);
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        string input;
        input = Input.inputString;
        switch (input)
        {
            case "w":
                fsm.ChangeState(((GameplayStateMachine)fsm).topState);
                break;
            case "a":
                fsm.ChangeState(((GameplayStateMachine)fsm).leftState);
                break;
            case "s":
                fsm.ChangeState(((GameplayStateMachine)fsm).bottomState);
                break;
            case "d":
                fsm.ChangeState(((GameplayStateMachine)fsm).rightState);
                break;
            default:
                break;
        }
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }
}
