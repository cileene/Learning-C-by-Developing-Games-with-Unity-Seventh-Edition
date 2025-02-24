using UnityEngine;

public abstract class BaseManager: MonoBehaviour
{
    protected string _state = "Base Manager State";
    public abstract string State { get; set; }
    
    public abstract void Initialize();
}