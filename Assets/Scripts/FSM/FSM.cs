using Manager;
using Menu;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State currentState;
    private State lastState;
    private Dictionary<Type, State> states;
    internal Action<Aesthetic> onTransition;

    public State LastState { get => lastState; set => lastState = value; }

    public StateMachine()
    {
        states = new Dictionary<Type, State>();
    }

    public void AddState<T>(State state) where T : State
    {
        states.Add(typeof(T), state);
    }

    public void Update()
    {
        currentState.Update();
    }

    public void ChangeState<T>() where T : State
    {
        ChangeState(typeof(T));
    }
    public void ChangeState(Type nextStateType)
    {
        if(currentState != null)
            lastState = currentState;

        currentState?.Exit();

        if (states.TryGetValue(nextStateType, out var state)) 
        { 
            currentState = state;
            currentState.Enter();
        }
    }

    public void SetGameManager(GameManager gameManager)
    {
        currentState.gameManager = gameManager;
    }
}

public abstract class State
{
    protected StateMachine machine;
    protected Dictionary<Type, Condition> conditions = new Dictionary<Type, Condition> ();
    public GameManager gameManager;

    public Action enterLevel;

    protected State(StateMachine machine)
    {
        this.machine = machine;
    }

    public bool CheckCondition<T>() where T : Condition
    {
        bool ret = false;
        Type conditionType = typeof(T);

        if (conditions.TryGetValue(conditionType, out var condition))
            ret = condition.Check();
        
        return ret;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();

    protected void CallPortal()
    {
        enterLevel?.Invoke();
    }


}

public class Condition
{
    public virtual bool Check() => true;
}

public class EndLevel : Condition
{
    private PlayerStats playerStats;
    private int distance;

    public EndLevel(int distance, PlayerStats playerStats)
    {
        this.distance = distance;
        this.playerStats = playerStats;
    }

    public override bool Check()
    {
        return playerStats.distanceTraveled >= distance;
    }
}

public class Pause : Condition
{
    private PlayerStats playerStats;

    public Pause(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
    }

    public override bool Check()
    {
        return false;
    }
}

public class ClosePortal : Condition
{
    private UIManager uiManager;

    public ClosePortal(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public override bool Check()
    {
        return uiManager.portal.isPaused;
    }
}
