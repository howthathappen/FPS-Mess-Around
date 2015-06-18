using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSwappingScript : MonoBehaviour {

	private List<GameObject> gunList = new List<GameObject>();
	private int currentWeaponIndex = 0;
	
	void Start ()
	{
		for(int i = 0; i < this.gameObject.transform.childCount; i++)
		{
			gunList.Add(this.gameObject.transform.GetChild(i).gameObject);
		}
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			//this.gameObject.transform.GetChild(currentWeaponIndex).gameObject.SetActive(false);
			gunList[currentWeaponIndex].SetActive(false);
			currentWeaponIndex++;
			if(currentWeaponIndex == gunList.Count)
			{
				currentWeaponIndex = 0;
			}
			gunList[currentWeaponIndex].SetActive(true);
		}
	}
}
