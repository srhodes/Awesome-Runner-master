using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSmoke : MonoBehaviour {

	public GameObject smokeEffect;
	public GameObject smokePosition;

	void OnTriggerEnter(Collider target)
	{
		if (target.tag == Tags.PLATFORM_TAG) 
		{
			print ("We are on the platform");
			if (smokePosition.activeInHierarchy)
				Instantiate (smokeEffect, smokePosition.transform.position, Quaternion.identity);
		}
	}
}
