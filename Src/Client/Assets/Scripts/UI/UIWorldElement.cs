using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldElement : MonoBehaviour {

    public Transform Owner;

    public float Height = 1.5f;

	void Start () {
		
	}
	
	void Update ()
    {
        if (Owner != null)
        {
            this.transform.position = Owner.position + Vector3.up * Height;
        }	
	}
}
