using UnityEngine;

public class ConversationInteractor : MonoBehaviour, IInteractor
{
    private IInteractable curInteractable;

    [SerializeField]
    private Transform pivot;
    public Transform Pivot { get => pivot; set => throw new System.NotImplementedException(); }

    [SerializeField, Range(0, 5)]
    private float radius;
    public float Radius { get => radius; set => throw new System.NotImplementedException(); }

    [SerializeField]
    private LayerMask layerMask;
    public LayerMask LayerMask { get => layerMask; set => throw new System.NotImplementedException(); }

    private void Update()
    {       
        Interact();
    }

    public void Interact()
    {        
        Collider[] colliders = Physics.OverlapSphere(Pivot.position, radius, LayerMask);

        if (colliders.Length <= 0)
        {
            curInteractable?.OffInteraction();
            curInteractable = null;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && colliders[0].TryGetComponent(out IInteractable tempInteractable))
        {
            if (tempInteractable != curInteractable)
            {
                curInteractable?.OffInteraction();
                curInteractable = tempInteractable;
            }
            curInteractable.OnInteraction();
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Pivot.position, radius);
    }
}
