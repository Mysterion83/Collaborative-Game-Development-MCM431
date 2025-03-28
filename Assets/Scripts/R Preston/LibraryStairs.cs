using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class LibraryStairs : MonoBehaviour
{
    [SerializeField] private InteractableSwitch interactableSwitch;
    private Animator animator;

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;

    void Start()
    {
        transform.position = startPosition;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (interactableSwitch.State == true)
        {
            Debug.Log("Switch On");
            //transform.position = endPosition;
            //animator.SetTrigger("TrRaiseStairs");
        }
        else if (interactableSwitch.State == false)
        {
            Debug.Log("Switch Off");
            //transform.position = startPosition;
            //animator.SetTrigger("TrLowerStairs");
        }
    }
}
