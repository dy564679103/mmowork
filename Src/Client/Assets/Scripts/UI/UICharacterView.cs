using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterView : MonoBehaviour {

    /// <summary>
    /// 角色
    /// </summary>
    //[SerializeField]
    public GameObject[] Characters;

    private int m_CurrentCharacter = 0;

    public int CurrentCharacter
    {
        get { return m_CurrentCharacter; }
        set
        {
            m_CurrentCharacter = value;
            this.UpdateCharacter();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateCharacter()
    {
        for (int i = 0; i < 3; i++)
        {
            Characters[i].SetActive(i == this.m_CurrentCharacter);
        }
    }
}
