using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopState : State
{
    GameObject obj;
    public TopState(GameplayStateMachine gsm) : base("TopState", gsm) { }
    public override void OnEnter()
    {
        base.OnEnter();
        if (obj == null) obj = GameObject.Find("TopArrow");
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
        if (Input.GetKeyUp(KeyCode.W))
        {
            fsm.ChangeState(((GameplayStateMachine)fsm).centerState);
        }
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }
}
