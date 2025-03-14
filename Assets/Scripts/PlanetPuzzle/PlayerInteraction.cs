using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInteraction : MonoBehaviour
{
    public Gearbox gearbox;
    private int gearsHeld = 0;



    void Update()
    {
        // Check for gear pickup
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                Gear gear = hit.collider.GetComponent<Gear>();
                if (gear != null)
                {
                    InventoryManager.Instance.AddItem(0);
                    gear.PickUp();
                    gearsHeld++;
                    Debug.Log("Picked up a gear. Total gears held: " + gearsHeld);
                }
                else
                {
                    Debug.Log("Hit object does not have a Gear component.");
                }
            }
            else
            {
                Debug.Log("No gear detected in front of the player.");
            }
        }

        // Check for gear deposit
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Vector3.Distance(transform.position, gearbox.transform.position) < 2f && gearsHeld > 0)
            {
                gearbox.AddGear();
                gearsHeld--;
                Debug.Log("Deposited a gear. Gears held: " + gearsHeld);
            }
            else if (gearsHeld == 0)
            {
                Debug.Log("No gears to deposit.");
            }
            else
            {
                Debug.Log("Not close enough to the gearbox.");
            }
            InventoryManager.Instance.RemoveTargetItem(0);
        }
    }
}
