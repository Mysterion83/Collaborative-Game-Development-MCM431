using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSwitch : Interactable
{
    public bool State { get { return _state; } }
    private bool _state;
    private int _index;

    [SerializeField]
    private PuzzleManager _puzzleManager;

    public override void Interact()
    {
        _state = !_state;
        _puzzleManager.SetState(_index, State);
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

    private void Start()
    {
        _index = _puzzleManager.AddSwitch();
    }
}

