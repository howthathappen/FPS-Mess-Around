using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

	//private Collider playerCollider;
	private GameObject playerCamera;
	private bool canPickUpWeapon = false;
	
	void Start () 
	{
		//playerCollider = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Rigidbody>()
		playerCamera = GameObject.FindWithTag("MainCamera");
	}
	
	private void Update ()
	{
		if(Input.GetKey(KeyCode.E) && canPickUpWeapon && playerCamera.transform.FindChild(this.gameObject.name).tag != "Equipped")
		{
			for(int i = 0; i < playerCamera.transform.childCount; i++)
			{
				if(playerCamera.transform.GetChild(i).gameObject.activeInHierarchy)
				{
					//playerCamera.transform.GetChild(i).parent = null;
					playerCamera.transform.GetChild(i).tag = "Untagged";
					playerCamera.transform.GetChild(i).gameObject.SetActive(false);
				}
			}
			playerCamera.transform.FindChild(this.gameObject.name).gameObject.SetActive(true);
			playerCamera.transform.FindChild(this.gameObject.name).gameObject.tag = "Equipped";
			Debug.Log(playerCamera.GetComponent<WeaponSwappingScript>().currentWeaponIndex);
			playerCamera.GetComponent<WeaponSwappingScript>().gunList[playerCamera.GetComponent<WeaponSwappingScript>().currentWeaponIndex] = playerCamera.transform.FindChild(this.gameObject.name).gameObject; 
			//this.gameObject.transform.parent = playerCamera.transform;
			//this.gameObject.transform.GetComponent<BoxCollider>().enabled = false;
		}
	}
	
	private void OnTriggerEnter (Collider other) 
	{
		if(other.gameObject.tag == ("Player"))
		{
			canPickUpWeapon = true;
		}
	}
	
	private void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == ("Player"))
		{
			canPickUpWeapon = false;
		}
	}
}
