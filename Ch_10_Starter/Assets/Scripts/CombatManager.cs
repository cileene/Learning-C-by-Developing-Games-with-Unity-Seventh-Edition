using UnityEngine;

public class CombatManager : BaseManager
{
    public override string State
    {
        get { return _state; }
        set { _state = value; } 
        
    }
    
    public void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        _state = "Let's get CombatManaging! Wait, is that a boxing thing?";
        Debug.Log(_state);
    }
}