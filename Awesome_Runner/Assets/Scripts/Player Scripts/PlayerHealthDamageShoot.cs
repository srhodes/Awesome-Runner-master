using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDamageShoot : MonoBehaviour {

	private float distanceBeforeNewPlatforms = 120f;
	private LevelGenerator levelGenerator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Awake () {
		levelGenerator = GameObject.Find (Tags.LEVEL_GENERATOR_OBJ).GetComponent<LevelGenerator> ();
	}

	void OnTriggerEnter(Collider target){
		if(target.tag == Tags.MORE_PLATFORMS_TAG){
			Vector3 temp = target.transform.position;
			temp.x += distanceBeforeNewPlatforms;
			target.transform.position = temp;

			levelGenerator.GenerateLevel (false);
		}
	}
}
