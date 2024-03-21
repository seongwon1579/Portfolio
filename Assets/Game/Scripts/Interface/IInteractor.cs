using UnityEngine;

public interface IInteractor 
{
    public void Interact();

    public Transform Pivot { get; set; }
    public float Radius { get; set; }
    public LayerMask LayerMask { get; set; }

}
