using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class clearedObjectList : MonoBehaviour {
	int count = 1;

//	public List<SpriteRenderer> clearedConditionElementsObjList = new List<SpriteRenderer>();
	public List<Image> clearedConditionElementsUIList = new List<Image>();
	[SerializeField] GameObject clearedCondition;


	// Use this for initialization
	void Start () {
		StartCoroutine ("GetChildElement");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public IEnumerator GetChildElement() {
		yield return new WaitForSeconds(0.2f);
		for (int i = 0; i < clearedCondition.transform.childCount; i++) {
			clearedConditionElementsUIList.Add(clearedCondition.transform.GetChild(i).gameObject.GetComponent<Image>());
		}
	}

	public void CheckSpriteName(string name) {
		for (int i = 0; i < gameObject.transform.childCount; i++) {
			if (clearedConditionElementsUIList [i].sprite.name.Equals (name)) {
				Destroy (clearedConditionElementsUIList [i].gameObject);
				clearedConditionElementsUIList.RemoveAt (i);
				break;
			}
		}
		CheckElementCount ();
	}

	public void CheckElementCount() {
		if(clearedConditionElementsUIList.Count == 0) {
			count ++;
			GameReference.generator.NextLevel(count);
			StartCoroutine ("GetChildElement");
			GameReference.batteryController.InitbulletNUm();
			GameReference.timerController.InitTimer ();
			GameReference.timerController.StopWillTimeOverAnimation ();
//			GameReference.gameController.isFinishedCountDownAnimation = true;
		}
	}
}
