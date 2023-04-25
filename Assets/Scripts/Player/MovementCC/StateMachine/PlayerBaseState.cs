

using Unity.VisualScripting;

public abstract class PlayerBaseState
{
    private bool _isRootState = false;
    private PlayerCCStateMachine _ctx;
    private PlayerStateFactory _factory;

    private PlayerBaseState _currentSuperState;
    private PlayerBaseState _currentSubState;

    protected bool IsRootState { set { _isRootState = value; } }
    protected PlayerCCStateMachine Ctx { get { return _ctx; } }
    protected PlayerStateFactory Factory { get { return _factory; } }

    public PlayerBaseState(PlayerCCStateMachine currentContext, PlayerStateFactory playerStateFactory)
    {
       _ctx = currentContext;
        _factory = playerStateFactory;
    }

    public abstract void EnterState();
    
    public abstract void UpdateState();

    public abstract void ExitState();
  
    public abstract void CheckSwitchStates();

    public abstract void InitializeSubState();

    public void UpdateStates()
    {
        UpdateState();

        if (_currentSubState != null ) 
        {
            _currentSubState.UpdateStates();
        }
    }

   /* public void ExitStates()
    {
        ExitState();
        if(_currentSubState != null ) 
        {
            _currentSubState.ExitStates();
        }
    }*/



    protected void SwitchState(PlayerBaseState newState)
    {
        ExitState();

        newState.EnterState();

        if (_isRootState ) 
        {
        _ctx.CurrentState = newState;
        }
        else if (_currentSuperState != null ) 
        {
            _currentSuperState.SetSubState(newState);
        }
        
    }

    protected void SetSuperState(PlayerBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    } 

    protected void SetSubState(PlayerBaseState newSubState)
    {
        _currentSubState = newSubState; 
        newSubState.SetSuperState(this);
    }
}
