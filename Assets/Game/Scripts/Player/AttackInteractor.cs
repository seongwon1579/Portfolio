using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInteractor : MonoBehaviour, IInteractor
{
    [SerializeField, Range(0, 2)]
    private float radius;
    public float Radius { get => radius; set => throw new System.NotImplementedException(); }

    [SerializeField]
    private Transform pivot;
    public Transform Pivot { get => pivot; set => throw new System.NotImplementedException(); }
    
    public LayerMask LayerMask { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private float dmg;

    public void Set(Character character)
    {
        dmg = character.Dmg;
    }

    public void Interact()
    {
        Collider[] colliders = Physics.OverlapBox(Pivot.position, new Vector3(radius,radius,radius));

        if (colliders.Length <= 0)
            return;

        if (colliders[0].TryGetComponent(out IHeatable heatable))
        {
            heatable.Heat(dmg);
        }
    }

    // 애니메이션 Function
    public void Attack()
    {
        Interact();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Pivot.position, new Vector3(radius, radius, radius));
       
    }
}