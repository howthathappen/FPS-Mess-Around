using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {

	public Texture2D crosshairTexture;
	public float crosshairScale = 1f;
	
	private void OnGUI ()
	{
		if(Time.timeScale != 0) //can set timescale to 0 to pause the game I guess
		{
			if(crosshairTexture != null) //if we have a texture to use
			{
				//draw the texture in the center of the screen
				GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width*crosshairScale)/2, (Screen.height - crosshairTexture.height*crosshairScale)/2, //set the x, y coordinates
								crosshairTexture.width*crosshairScale, crosshairTexture.height*crosshairScale), //set the width and height of the rectangle
								crosshairTexture); //tell unity which texture to use
			}
			else
			{
				Debug.Log("No crosshair texture set in the inspector");
			}
		}
	}
}
