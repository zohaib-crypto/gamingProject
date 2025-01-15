using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventChannel", menuName = "Event Channel")]
public class EventChannel : ScriptableObject
{
    private UnityAction onEventRaised;

    public UnityAction OnEventRaised
    {
        get { return onEventRaised; }
        set { onEventRaised = value; }
    }
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke(); //     
    }
}
