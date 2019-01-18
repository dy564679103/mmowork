using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI角色信息
/// </summary>
public class UICharacterInfo : MonoBehaviour {

    public SkillBridge.Message.NCharacterInfo NCharacterInfo;

    /// <summary>
    /// 角色职业种类
    /// </summary>
    [SerializeField]
    private Text m_CharacterClass;

    /// <summary>
    /// 角色名称
    /// </summary>
    [SerializeField]
    private Text m_CharacterName;

    /// <summary>
    /// 高亮背景图
    /// </summary>
    [SerializeField]
    private Image m_HighLight;

    /// <summary>
    /// 是否被选择
    /// </summary>
    public bool Selected
    {
        get { return m_HighLight.IsActive(); }
        set { m_HighLight.gameObject.SetActive(value); }
    }


	void Start ()
    {
        if (NCharacterInfo != null)
        {
            this.m_CharacterClass.text = this.NCharacterInfo.Class.ToString();
            this.m_CharacterName.text = this.NCharacterInfo.Name;
        }
	}	
}
