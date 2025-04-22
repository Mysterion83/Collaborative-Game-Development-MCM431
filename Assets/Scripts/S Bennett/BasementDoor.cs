using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : Interactable
{
    GameObject player;
    private Animator _hinge;
    public bool locked = false;
    private string _unlockedText;

    [SerializeField] private GameObject teleportPosition;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        _hinge = transform.parent.parent.gameObject.GetComponent<Animator>();
        _unlockedText = TooltipText;
    }
    void Update()
    {
        if (locked)
        {
            TooltipText = "Locked";
        }
        else
        {
            TooltipText = _unlockedText;
        }
    }
    public override void Interact()
    {
        if (locked) return;

        player.transform.position = teleportPosition.transform.position;
    }
    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }
}
