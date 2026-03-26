using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform reciever;

	public GameObject[] RecieverPortal;
	public GameObject[] NextPortal;

	public Vector3 positionOffset;

	private bool playerIsOverlapping = false;
	public CharacterController characterController;
	public int WaitTime=5;

	[SerializeField]private bool isChangeRoom;
	[SerializeField]private int NextRoomNo;
	[SerializeField]private LoopRoomsHandler loopRoomsHandler;

	[SerializeField]private AudioSource portalAudioSource;
    [SerializeField]private AudioClip teleportsound;


	// Update is called once per frame
	void Update () {
		if (playerIsOverlapping)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			// If this is true: The player has moved across the portal
			if (dotProduct < 0f)
			{
				// Teleport him!
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				//rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);

				positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				
				playerIsOverlapping = false;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = true;
			StartCoroutine(Teleport());
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = false;
			//RecieverPortal.SetActive(false);
		}
	}
	public IEnumerator Teleport(){
		characterController.enabled=false;
		player.position = reciever.position + positionOffset;
		portalAudioSource.PlayOneShot(teleportsound);
		yield return new WaitForSeconds(WaitTime);
		characterController.enabled=true;
		
		for (int i = 0; i < RecieverPortal.Length; i++)
		{
			RecieverPortal[i].SetActive(false);
			NextPortal[i].SetActive(true);
		}
		if(isChangeRoom){
			loopRoomsHandler.currentRoomNo=NextRoomNo;
		}
	}
}
