using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class IdleState_Player : State<PlayerState>
{

    public override void End(PlayerState owner)
    {
        
    }

    public override void Enter(PlayerState owner)
    {
        
    }

    public override void Execute(PlayerState owner)
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDir.magnitude > 0)
        {
            owner.changeStateReactiveCommand.Execute(playerStates.MoveState);
        }
    }
}

public class MoveState_Player : State<PlayerState>
{

    private CharacterController characterController;
  

    public override void Enter(PlayerState owner)
    {
        owner.animator.SetBool("IsRun", true);
        characterController = owner.characterController;
    }

    public override void Execute(PlayerState owner)
    {
        Vector3 inputValue = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1);
        if (inputValue.magnitude <= 0)
            owner.changeStateReactiveCommand.Execute(playerStates.Idle);
      
        characterController.Move(inputValue * Time.deltaTime * 10f);
    }

    public override void End(PlayerState owner)
    {
        characterController.Move(Vector3.zero);
        owner.animator.SetBool("IsRun", false);
    }
}

public class RollState_Player : State<PlayerState>
{
   
    public override void End(PlayerState owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter(PlayerState owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(PlayerState owner)
    {
        throw new System.NotImplementedException();
    }
}

public class AttackState_Player : State<PlayerState>
{
    
    public override void End(PlayerState owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter(PlayerState owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(PlayerState owner)
    {
        throw new System.NotImplementedException();
    }
}

public class DieState_Player : State<PlayerState>
{
    
    public override void End(PlayerState owner)
    {
        
    }

    public override void Enter(PlayerState owner)
    {
        owner.animator.SetTrigger("IsDie");
        owner.gameObject.GetComponent<Collider>().enabled = false;
    }

    public override void Execute(PlayerState owner)
    {
        
    }
}

