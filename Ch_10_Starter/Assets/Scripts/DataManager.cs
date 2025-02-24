using UnityEngine;

public class DataManager : MonoBehaviour, IManager
{
    public string State { get; set; }
    
    public void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        State = "If you got Data, I'll manage it!";
        Debug.Log(State);
    }
}