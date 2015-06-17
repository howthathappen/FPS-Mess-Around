using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	private LineRenderer line;
	private GUIStyle guiStyle = new GUIStyle();
	private Light light;
	
	void Start () 
	{
		line = this.gameObject.GetComponent<LineRenderer>();
		line.enabled = false;
		
		light = this.gameObject.GetComponent<Light>();
		
		Cursor.lockState = CursorLockMode.Locked; //locks and hides the cursor
		Cursor.visible = false;
	}
	
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
		}
	}
	
	private IEnumerator FireLaser ()
	{
		line.enabled = true;
		light.enabled = true;
		
		while(Input.GetButton("Fire1"))
		{
			line.material.mainTextureOffset = new Vector2(0, Time.time);
		
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			
			line.SetPosition(0, ray.origin);
			
			if(Physics.Raycast(ray, out hit,100))
			{
				line.SetPosition(1, hit.point);
				if(hit.rigidbody)//if our target has a rigidbody
				{
					hit.rigidbody.AddForceAtPosition(transform.forward * 5, hit.point);
				}
			}
			else
			{
				line.SetPosition(1, ray.GetPoint(100));
			}
			
			yield return null;
		}
		
		line.enabled = false;
		light.enabled = false;
	}
	
	private void OnGUI ()
	{
		guiStyle.fontSize = 20;
		GUILayout.Label("Ctrl+P to stop the game", guiStyle);
	}
}
