using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLever : InteractableSwitch
{    
    public bool State { get { return _state; } }
    private bool _state = false;
    private float _timer = 0;

    [SerializeField]
    private float _timeAmount = 5f;

    public override void Interact()
    {
        _state = true;
        _timer = _timeAmount;
    }

    void FixedUpdate()
    {
        if (_timer > 0)
        {
            _timer -= Time.fixedDeltaTime;
        }

        if (_timer <= 0 && _state)
        {
            _timer = 0;
            _state = false;
        }
    }
}
