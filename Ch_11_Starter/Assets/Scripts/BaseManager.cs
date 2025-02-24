using UnityEngine;

public abstract class BaseManager : MonoBehaviour
{
    protected string _state;
    public abstract string state { get; set;}
    
    public abstract void Initialize();

}