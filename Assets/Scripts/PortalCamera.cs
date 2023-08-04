//Adapted from Brackeys Portal Tutorial https://www.youtube.com/watch?v=cuQao3hEKfs&t=171s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	[SerializeField] private Transform playerCamera;
	[SerializeField] private Transform portal;
	[SerializeField] private Transform otherPortal;

    private void Awake() 
    {
        playerCamera = Camera.main.transform;
    }
	
	// Follows the current player camera to display the correct visuals for the other side of the "portal"
	private void LateUpdate()
    {
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = portal.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
