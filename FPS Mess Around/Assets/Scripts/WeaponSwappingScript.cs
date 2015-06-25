using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSwappingScript : MonoBehaviour {

	[HideInInspector] public List<GameObject> gunList = new List<GameObject>();
	[HideInInspector] public int currentWeaponIndex = 0;
	
	void Start ()
	{
		for(int i = 0; i < this.gameObject.transform.childCount; i++)
		{
			if(this.gameObject.transform.GetChild(i).tag == "Equipped")
			{
				gunList.Add(this.gameObject.transform.GetChild(i).gameObject);
			}
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
