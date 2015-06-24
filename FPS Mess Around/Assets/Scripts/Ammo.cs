using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public int clipSize;
	public float fireRate;
	
	private int currentAmmo;
	private float elapsedTime = 0f;
	
	void Start ()
	{
		currentAmmo = clipSize;
	}
	
	void Update () 
	{
		elapsedTime += Time.deltaTime;
		
		if(Input.GetButtonDown("Fire1") && elapsedTime >= fireRate)
		{
			//shoot
			currentAmmo--;
			
			if(currentAmmo == 0)
			{
				//reload
			}
		}
	}
	
	private void OnGUI ()
	{
		GUILayout.Label("Ammo: " + currentAmmo + " / " + clipSize);
	}
}
