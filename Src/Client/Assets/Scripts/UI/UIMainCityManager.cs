using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainCityManager : MonoBehaviour
{

    [SerializeField]
    private Text m_AvatarName;

    [SerializeField]
    private Text m_AvatarLevel;


	void Start ()
    {
        this.UpdateAvatar();
	}

    void UpdateAvatar()
    {
        this.m_AvatarName.text = string.Format("{0} [{1}]", User.Instance.CurrentCharacter.Name,User.Instance.CurrentCharacter.Id);
        this.m_AvatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
    }
	

}
