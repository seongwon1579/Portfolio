using UnityEngine;
using UnityEngine.Events;

public class EventsBundle : MonoBehaviour
{
    public UnityAction<bool> actionArgBool;

    public UnityAction actionArgNone;

    public UnityAction<int> actionArgInt;

    [SerializeField]
    private Events[] events;

    private void Awake()
    {
        foreach (var e in events)
        {
            actionArgBool += e.DoEvent;
            actionArgNone += e.DoEvent;
            actionArgInt += e.DoEvent;
        }    
    }
}
