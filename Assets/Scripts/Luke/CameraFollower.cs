using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private Transform Player; // Reference to the player's transform

    [SerializeField]
    private float Distance = 0f; // Distance from the player

    [SerializeField]
    private float Height = 0f; // Height above the player

    [SerializeField]
    private float Damping = 8.0f; // Damping for smooth movement

    //LateUpdate is called after all Update functions have been called 
    private void LateUpdate()
    {
        if (Player == null)
        {
            Debug.Log("Player transform is not assigned.");
            return;
        }

        // Calculate the desired position
        Vector3 DesiredPosition = Player.position - Player.forward * Distance + Vector3.up * Height;

        // Smoothly interpolate to the desired position
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, Time.deltaTime * Damping);

        // Make the camera look at the player
        transform.LookAt(Player);
    }
}
