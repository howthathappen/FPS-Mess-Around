using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	//my code
	public int clipSize;
	public float fireRate;
	public float reloadTime;
	
	private int currentAmmo;
	private float elapsedTime = 1000f;
	private int clipsRemaining;
	//endMyCode
	
	private LineRenderer line;
	private GUIStyle guiStyle = new GUIStyle();
	private Light _light;
	
	void Start ()
	{
		currentAmmo = clipSize; //my code
		clipsRemaining = 10; //my code
		
		line = this.gameObject.GetComponent<LineRenderer>();
		line.enabled = false;
		
		_light = this.gameObject.GetComponent<Light>();
		
		Cursor.lockState = CursorLockMode.Locked; //locks and hides the cursor
		Cursor.visible = false;
	}
	
	void Update () 
	{
		elapsedTime += Time.deltaTime;
		
		if(Input.GetButton("Fire1") && elapsedTime >= fireRate && currentAmmo > 0)
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
			
			//my code
			currentAmmo--;
			
			if(currentAmmo == 0 && clipsRemaining > 0)
			{
				//reload
				Invoke("Reload", reloadTime);
			}
			
			elapsedTime = 0f;
			//endMyCode
		}
	}
	
	private IEnumerator FireLaser ()
	{
		line.enabled = true;
		_light.enabled = true;
		
//		while(Input.GetButton("Fire1"))
//		{
			line.material.mainTextureOffset = new Vector2(0, Time.time); //doesn't really do anything with a solid color
		
			//Ray ray = new Ray(transform.position, transform.forward); //their code
			//RaycastHit hit; //their code
			
			//line.SetPosition(0, ray.origin); //their code
			
			line.SetPosition(0, transform.position); //my code
			ShootAtCenterOfScreen(); //my code
			
			//their code
//			if(Physics.Raycast(ray, out hit, 100))
//			{
//				line.SetPosition(1, hit.point);
//				if(hit.rigidbody)//if our target has a rigidbody
//				{
//					hit.rigidbody.AddForceAtPosition(transform.forward * 5, hit.point);
//				}
//			}
//			else
//			{
//				line.SetPosition(1, ray.GetPoint(100));
//			}
			
			yield return null;
		//}
		
		line.enabled = false;
		_light.enabled = false;
	}
	
	//my functions
	private void ShootAtCenterOfScreen ()
	{
		Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);
		Ray myRay = Camera.main.ScreenPointToRay(screenCenter);
		RaycastHit hit2;
		
		if(Physics.Raycast(myRay, out hit2, 100))
		{
			line.SetPosition(1, hit2.point);
			if(hit2.rigidbody)
			{
				hit2.rigidbody.AddForceAtPosition(transform.forward * 5, hit2.point);
			}
		}
		else
		{
			line.SetPosition(1, myRay.GetPoint(100));
		}
	}
	
	private void Reload ()
	{
		currentAmmo = clipSize;
		clipsRemaining--;
	}
	
	private void OnGUI ()
	{
		guiStyle.fontSize = 20;
		GUILayout.Label("Ctrl+P to stop the game", guiStyle);
		
		GUI.Label(new Rect(Screen.width - 50, 0, 50, 50), "Ammo: " + currentAmmo + " / " + clipSize);
	}
}
