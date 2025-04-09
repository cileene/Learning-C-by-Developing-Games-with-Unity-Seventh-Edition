using System;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    // Declare a delegate with a void return type and no parameters
    private delegate void SimpleDelegate();

    // Create a variable of type delegate
    private SimpleDelegate _myDelegate;

    void Start()
    {
        // Assign a method to the delegate
        _myDelegate = PrintMessage;

        // Invoke the delegate (calls the assigned method)
        _myDelegate();
    }

    private void PrintMessage()
    {
        Debug.Log("Hello from the delegate!");
    }
}