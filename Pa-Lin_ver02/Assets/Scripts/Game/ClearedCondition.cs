using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearedCondition : MonoBehaviour {


	void Awake() {

	}

	// Use this for initialization
	void Start () {
//		maxSize = GameReference.generator.sprites.Length - 1;
//		InstantiateClearedCOnditionElement (instantiateCount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void InstantiateClearedCOnditionElement(int instantiateCount) {
//		for(int i = 0; i < instantiateCount; i++) {
//			int rnd = Random.Range(0, maxSize);
//			GameObject clearedConditionElementObject = (GameObject)Instantiate (clearedConditionElement, clearedCondition.transform.position,Quaternion.identity);
//			clearedConditionElementObject.GetComponent<Image>().sprite = GameReference.generator.sprites[rnd];
//			GameReference.generator.InstantiateClearedConditionElement(rnd);
//			clearedConditionElementObject.transform.parent = clearedCondition.transform;
//			clearedConditionElementObject.transform.localScale = Vector3.one;
//
//		}
//	}
}
