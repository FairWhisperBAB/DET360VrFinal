using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRLever : MonoBehaviour
{
    public float deadTime = 1.0f;

    private bool _deadTimeActive = false;

    public UnityEvent onPull, onRelease;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lever" && !_deadTimeActive)
        {
            onPull?.Invoke();
            Debug.Log("Pulled");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Lever" && !_deadTimeActive)
        {
            onRelease?.Invoke();
            Debug.Log("Released");
            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }
}
