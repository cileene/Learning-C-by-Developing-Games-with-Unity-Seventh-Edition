using UnityEngine;

public interface IManager
{
    string State { get; set; }
    
    void Initialize();
}