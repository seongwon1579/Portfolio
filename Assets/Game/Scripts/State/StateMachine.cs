using Cysharp.Threading.Tasks;

public class StateMachine<T> where T : class 
{
    private T owner;
    private State<T> curState;

    public void Set(T owner, State<T> newState)
    {
        this.owner = owner;

        curState = newState;
        curState.Enter(owner);

        UpdateAsyn().Forget();
    }

    public async UniTaskVoid UpdateAsyn()
    {
        while(owner != null)
        {
            curState.Execute(owner);
            await UniTask.Yield();
        }
    }

    public void ChangeState(State<T> newState)
    {
        if (newState == null)
            return;

        if (curState != null)
            curState.End(owner);
        
        curState = newState;
        curState.Enter(owner);
    }

    public void EndState()
    {
        owner = null;
    }
}
