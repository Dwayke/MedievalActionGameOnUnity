using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine){ }
    private float timer = 0f;

    public override void Enter()
    {
        Debug.Log("Enter");
        stateMachine.InputReader.JumpEvent += OnJump;
    }


    public override void Tick(float deltaTime)
    {
        stateMachine.InputReader.JumpEvent += OnJump;

        timer += Time.deltaTime;
        Debug.Log("Tick");
        Debug.Log((int)timer);
    }

    public override void Exit()
    {
        Debug.Log("Exit");
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }
}
