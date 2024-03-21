using UnityEngine;

public class Events : MonoBehaviour
{
    public virtual void DoEvent(bool e) { }

    public virtual void DoEvent() { }

    public virtual void DoEvent(int e) { }
}
