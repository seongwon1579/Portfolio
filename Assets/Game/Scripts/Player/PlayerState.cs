using UnityEngine;
using UniRx;

public enum playerStates { Idle, MoveState, RollState, AttackState, DieState }

public class PlayerState : MonoBehaviour
{
    public Animator animator;

    public CharacterController characterController;

    public ReactiveCommand<playerStates> changeStateReactiveCommand;

    public ReactiveCommand EndGameCommmand;

    private StateMachine<PlayerState> stateMachine;

    private State<PlayerState>[] states;

    
    private float moveSpeed;
    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    
    private void Awake()
    {   
        stateMachine = new StateMachine<PlayerState>();

        changeStateReactiveCommand = new ReactiveCommand<playerStates>();
        EndGameCommmand = new ReactiveCommand();

        SetEvents();
    }

    private void SetEvents()
    {
        changeStateReactiveCommand.Subscribe(newState =>
        {
            stateMachine.ChangeState(states[(int)newState]);
        });

        EndGameCommmand.Subscribe(_ =>
        {
            changeStateReactiveCommand.Execute(playerStates.DieState);
            GameManager.Instance.EndGame();         
        });
    }

    public void Set(Character character)
    {
        MoveSpeed = character.MoveSpeed;
        SetStates();
    }

    private void SetStates()
    {
        states = new State<PlayerState>[5];
        states[(int)playerStates.Idle] = new IdleState_Player();
        states[(int)playerStates.MoveState] = new MoveState_Player();
        states[(int)playerStates.RollState] = new RollState_Player();
        states[(int)playerStates.AttackState] = new AttackState_Player();
        states[(int)playerStates.DieState] = new DieState_Player();

        stateMachine.Set(this, states[(int)playerStates.Idle]);       
    }
}
