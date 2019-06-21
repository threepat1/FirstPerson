using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    public string hitTag;
    public UnityEvent onEnter;

    private void OnTriggerEnter(Collider other)
    {
        // If hitting hit tag OR hitTag is set to nothing
        if (other.tag == hitTag || hitTag == "")
        {
            // Invoke (Run) the event!
           onEnter.Invoke();
        }
    }
}
