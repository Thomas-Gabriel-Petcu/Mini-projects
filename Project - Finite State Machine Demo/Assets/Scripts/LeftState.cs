using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftState : State
{
    GameObject obj;
    public LeftState(GameplayStateMachine gsm) :base("LeftState", gsm) { }
    public override void OnEnter()
    {
        base.OnEnter();
        if (obj == null) obj = GameObject.Find("LeftArrow"); 
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
        if (Input.GetKeyUp(KeyCode.A))
        {
            fsm.ChangeState(((GameplayStateMachine)fsm).centerState);
        }
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }
}
