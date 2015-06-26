﻿using UnityEngine;
using System.Collections;

public class SortingLayer : MonoBehaviour {
	
	public string sortingLayerName;
	public int sortingOrder;
	void Start (){
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortingLayerName;
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = sortingOrder;
	}
}
