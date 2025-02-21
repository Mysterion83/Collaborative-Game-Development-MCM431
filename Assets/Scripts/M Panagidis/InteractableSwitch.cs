using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSwitch : Interactable
{
    public bool State { get { return _state; } }
    private bool _state;
    private int index;

    [SerializeField]
    private PuzzleManager puzzleManager;

    public override void Interact()
    {
        _state = !_state;
        puzzleManager.SetState(index, State);
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

    private void Start()
    {
        index = puzzleManager.AddSwitch();
    }
}

