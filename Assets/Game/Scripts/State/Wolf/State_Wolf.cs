using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleState_Wolf : State<Wolf>
{
    //float time = 0;

    //public override void Enter(Wolf owner)
    //{

    //}

    //public override void Execute(Wolf owner)
    //{
    //    time += Time.deltaTime;

    //    if(time > 0.1f)
    //        owner.ChangeState(WOLFSTATE.CHASETARGETW); 
    //}

    //public override void End(Wolf owner)
    //{
    //    time = 0;
    //}
    public override void End(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(Wolf owner)
    {
        throw new System.NotImplementedException();
    }
}

public class ChaseTargetState_Wolf : State<Wolf>
{
    //public override void Enter(Wolf owner)
    //{      
    //    if(!owner.isAttackPlayer)
    //        owner.animator.SetBool("RunForward", true);    
    //}

    //public override void Execute(Wolf owner)
    //{
    //    if (owner.targetTransform == null)
    //        return;

    //    // 플레이어에서 1.5만큼 떨어진 거리까지 계속 추적한다  
    //    owner.navMeshAgent.destination = owner.targetTransform.position + new Vector3(1.5f,0,1.5f);

    //    // 플레이어와 trigger충돌하면 isAttackPlayer가 true가 되어 공격상태로 바뀐다 
    //    if (owner.isAttackPlayer)
    //        owner.ChangeState(WOLFSTATE.ATTACKTARGETW);
    //}

    //public override void End(Wolf owner)
    //{
    //    owner.animator.SetBool("RunForward", false);       
    //}
    public override void End(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(Wolf owner)
    {
        throw new System.NotImplementedException();
    }
}

public class AttackTargetState_Wolf : State<Wolf>
{
    //float intervalBtwAttacks = 0f;

    //public override void Enter(Wolf owner)
    //{
    //    // 플레이어를 바라보고 공격하도록 한다 
    //    owner.transform.LookAt(owner.targetTransform);
    //    owner.animator.SetTrigger("Bite Attack");      
    //}

    //public override void Execute(Wolf owner)
    //{
    //    // 플레이어에게 공격 받아 죽을 때 Die상태로 바꾼다 
    //    if(owner.HP <= 0)
    //    {
    //        owner.ChangeState(WOLFSTATE.DIEW);
    //    }

    //    intervalBtwAttacks += Time.deltaTime;

    //    // 다음공격까지의 간격을 설정 
    //    if (intervalBtwAttacks > 1f)
    //        owner.ChangeState(WOLFSTATE.IDLEW);        
    //}

    //public override void End(Wolf owner)
    //{
    //    intervalBtwAttacks = 0f;
    //}
    public override void End(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(Wolf owner)
    {
        throw new System.NotImplementedException();
    }
}
public class DieState_Wolf : State<Wolf>
{
    //public override void Enter(Wolf owner)
    //{      
    //    owner.offStateMachine = true;
    //    owner.animator.SetBool("Die", true); 
    //    owner.DestoryWolf();
    //}

    //public override void Execute(Wolf owner)
    //{    
    //}
    //public override void End(Wolf owner)
    //{ 
    //}
    public override void End(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter(Wolf owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(Wolf owner)
    {
        throw new System.NotImplementedException();
    }
}


