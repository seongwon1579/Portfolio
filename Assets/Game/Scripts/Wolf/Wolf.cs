using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum WOLFSTATE { IDLEW ,CHASETARGETW, ATTACKTARGETW, DIEW }
public class Wolf : MonoBehaviour, IHeatable
{

    //public State<Wolf>[] stateWs;
    //public StateMachine<Wolf> stateMachine;
    //public NavMeshAgent navMeshAgent;
    //public Transform targetTransform;
    //public Animator animator;
    //public bool isAttackPlayer;
    //public bool offStateMachine;

    //public int atk = 10;

    //[SerializeField]
    //private int hp;
    //public int HP
    //{
    //    get { return hp; }
    //    set { hp = value;}
    //}

    //private void Awake()
    //{
    //    animator = GetComponent<Animator>();
    //    navMeshAgent = GetComponent<NavMeshAgent>();
    //    stateMachine = new StateMachine<Wolf>();

    //    // 상태의 추가가 더 필요하면 할당 
    //    stateWs = new State<Wolf>[4];
    //    stateWs[(int)WOLFSTATE.IDLEW] = new IdleState_Wolf();
    //    stateWs[(int)WOLFSTATE.CHASETARGETW] = new ChaseTargetState_Wolf();
    //    stateWs[(int)WOLFSTATE.ATTACKTARGETW] = new AttackTargetState_Wolf();
    //    stateWs[(int)WOLFSTATE.DIEW] = new DieState_Wolf();

    //    stateMachine.Set(this, stateWs[(int)WOLFSTATE.IDLEW]);
    //}

    //// 플레이어의 위치 확인 
    //private void Start()
    //{
    //    targetTransform = MonsterManager.Instance.targetTransform;
    //}

    //// 울프의 상태가 Die상태일 때 호출 
    //public void DestoryWolf()
    //{
    //    StartCoroutine(DestroyWolfCo());
    //}

    //IEnumerator DestroyWolfCo()
    //{
    //    yield return new WaitForSeconds(1.8f);
    //    Destroy(this.gameObject);
    //}

    //// 늑대의 Execute를 매프레임 호출 
    //public void Update()
    //{
       
    //}

    //// 늑대의 상태를 변경하고 할 떄 호출 
    //public void ChangeState(WOLFSTATE state)
    //{
    //    stateMachine.ChangeState(stateWs[(int)state]);
    //}

    //// 애니메이션의 이벤트에서 특정 프레임의 공격모션을 취할 때 플레이어에게 데미지를 가한다 
    //public void OnAttackTarget()
    //{
    //    if (targetTransform == null)
    //        return;
    //    // 트리거 충돌을 하면 true로 초기화 
    //    if (isAttackPlayer)
    //    {
    //        //targetTransform.GetComponent<Player>().HP -= atk;            
    //    }
    //}

    public void Heat(float dmg)
    {
        Debug.Log("울프 공격 받음 " + dmg);
    }

}