using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class particles : MonoBehaviour {
	public static particles inst = null;
	public UnityEngine.GameObject[] allpartis;
		
	void Awake ()     
	{
		inst = this;
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	}
 