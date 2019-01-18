using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharInfoBarMgr : MonoBehaviour {


    [SerializeField]
    private Text avatarName;

    [HideInInspector]
    public Character Character;

    void Start () {
        if (this.Character != null)
        {
            //UpdateInfo();
        }
	}
	
	void Update ()
    {
        this.UpdateInfo();
    }

    private void LateUpdate()
    {
        //方法1：
        //this.transform.rotation = Camera.main.transform.rotation;
        //方法2：
        this.transform.forward = Camera.main.transform.forward;

        //方法3
        // Vector3 v = Camera.main.transform.forward;
        //this.transform.forward = v;
        //this.transform.forward = Vector3.Slerp (this.transform.forward,v,10*Time.deltaTime);
    }

    void UpdateInfo()
    {
        if (this.Character != null)
        {
            string name = this.Character.Name + " Lv." + this.Character.Info.Level;
            if (name != this.avatarName.text) 
            {
                this.avatarName.text = name;
            }
        }
    }
}
