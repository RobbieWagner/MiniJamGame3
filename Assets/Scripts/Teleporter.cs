//Adapted from Brackeys Portal Tutorial https://www.youtube.com/watch?v=cuQao3hEKfs&t=171s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private CharacterController playerCC;
    [SerializeField] private Transform player;
	[SerializeField] private Transform reciever;
    [SerializeField] private float rotation = 180f;

	private bool playerIsOverlapping = false;

    private void Awake() 
    {
        player = PlayerMovement.Instance.transform;
    }

	private void Update() 
    {
		if (playerIsOverlapping)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			// This will only return true if teh player walks through on the correct side
			if (dotProduct < 0f)
			{
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				rotationDiff += rotation;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                
                PlayerMovement.Instance.player.enabled = false;
				player.position = reciever.position + positionOffset;
                PlayerMovement.Instance.player.enabled = true;

				playerIsOverlapping = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = false;
		}
	}
}
