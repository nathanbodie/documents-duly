using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public float deadTime = 1.0f;
    private bool _deadTimeActivate = false;
    public UnityEvent onPressed, onReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActivate)
        {
            onPressed?.Invoke();
            Debug.Log("I have been pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && _deadTimeActivate)
        {
            onReleased?.Invoke();
            Debug.Log("I have been released");
            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActivate = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActivate = false;
    }
}


