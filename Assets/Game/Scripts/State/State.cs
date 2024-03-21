using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> where T : class
{
    public abstract void Enter(T owner);
    public abstract void Execute(T owner);
    public abstract void End(T owner);
}
