using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, IHeatable, IGrativity
{
    private SignalBus signalBus;
    private HPBar hPBar;

    [Inject]
    private void Construct(SignalBus signalBus, HPBar hPBar)
    {
        this.signalBus = signalBus;
        this.hPBar = hPBar;
    }

    [Header("Settings"), SerializeField]
    private EventsBundle eventsBundle;

    [SerializeField]
    private PlayerState playerState;

    [SerializeField]
    private AttackInteractor attackInteractor;

    private ReactiveCommand gameOverCommand = new ReactiveCommand();

    private float maxHp;

    private float hp;
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            hPBar.ApplyRealtimeHp(hp, maxHp);
            eventsBundle.actionArgNone();

            if (hp <= 0)
            {
                eventsBundle.actionArgInt((int)Audio_Clip.Die);
                gameOverCommand.Execute();
            }
        }
    }

    public void Heat(float dmg)
    {
        eventsBundle.actionArgInt((int)Audio_Clip.Heat);
        Hp -= dmg;
    }

    private void Awake()
    {
        SetEvents();
    }

    private void SetEvents()
    {
        gameOverCommand.Subscribe(_ =>
        {
            playerState.changeStateReactiveCommand.Execute(playerStates.DieState);
            signalBus.TryFire(new GameOverSignal());
        });
    }

    // 잠시 플레이어 설정 
    private void Start()
    {
        Character player = new Character();
        player.Hp = 30;
        player.MaxHp = 30;
        player.MoveSpeed = 10;
        PlayerStart(player);
    }

    public void PlayerStart(Character player)
    {
        Hp = player.Hp;
        maxHp = player.MaxHp;

        ApplyGravity();

        if (playerState)
            playerState.Set(player);

        if (attackInteractor)
            attackInteractor.Set(player);
    }


    // 컴포넌트로 분리 필요 
    public void ApplyGravity()
    {
        StartCoroutine(GravityCo());
    }

    IEnumerator GravityCo()
    {
        CharacterController characterController = GetComponent<CharacterController>();

        if (!characterController)
            yield break;

        while(true)
        {
            if (!characterController.isGrounded)
            {
                characterController.Move(Vector3.up * Physics.gravity.y);
            }
            yield return null;
        }
    }
}
