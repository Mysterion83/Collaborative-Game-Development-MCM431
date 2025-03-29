using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLever : InteractableSwitch
{    
    private Coroutine _timedLeverCoroutine;

    [SerializeField]
    private float _timeAmount = 5f;

    public override void Interact()
    {
        // Stops any current timer and resets it
        if (_timedLeverCoroutine != null )
        {
            StopCoroutine(_timedLeverCoroutine);
        }
        _timedLeverCoroutine = StartCoroutine(ActivateTimer());
    }

    private IEnumerator ActivateTimer()
    {
        _state = true;
        yield return new WaitForSeconds(_timeAmount);
        _state = false;
    }
}
