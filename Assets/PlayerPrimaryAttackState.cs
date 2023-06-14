using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{

    private int comboCounter;

    private float lastTimeAttcked;
    private float comboWindow = 2.0f;

    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (comboCounter > 2 || Time.time >= lastTimeAttcked + comboWindow)
        {
            comboCounter = 0;
        }

        player.animator.SetInteger("ComboCounter", comboCounter);
    }

    public override void Exit()
    {
        base.Exit();

        comboCounter++;
        lastTimeAttcked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
