using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHeatable, IGrativity
{

    [Header("Settings"), SerializeField]
    private EventsBundle eventsBundle;

    [SerializeField]
    private PlayerState playerState;

    [SerializeField]
    private AttackInteractor attackInteractor;

    private float maxHp;

    private float hp;
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            UIController.uIController.ApplyRealtimeHp(hp, maxHp);
                      
            if (hp <= 0)
            {
                eventsBundle.actionArgInt((int)Audio_Clip.Die);
                playerState.EndGameCommmand.Execute();

            }
        }
    }

    public void Heat(float dmg)
    {
        eventsBundle.actionArgNone();
        eventsBundle.actionArgInt((int)Audio_Clip.Heat);
        Hp -= dmg;
    }
    
    public void Set(Character player)
    {
        Hp = player.Hp;
        maxHp = player.MaxHp;

        ApplyGravity();

        if (playerState)
            playerState.Set(player);

        if (attackInteractor)
            attackInteractor.Set(player);
    }

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
