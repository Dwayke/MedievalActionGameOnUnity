using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine){ }
    
    public override void Enter()
    {
        
    }


    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();
        
        stateMachine.CharacterController.Move(movement*stateMachine.FreeLookMovementSpeed*deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
            return;
        }
        stateMachine.Animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);

        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
    }

    public override void Exit()
    {
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();
        Vector3 right = stateMachine.MainCameraTransform.right;
        right.y = 0f;
        right.Normalize();

        return forward*stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }
}
