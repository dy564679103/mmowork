using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillBridge.Message;
using Models;
using Services;

public class UICharacterSelect : MonoBehaviour {

    #region 组件变量定义
    [Header("UI Component Mount")]
    /// <summary>
    /// 创建角色面板
    /// </summary>
    [SerializeField]
    private GameObject m_PanelCreate;

    /// <summary>
    /// 选择角色面板
    /// </summary>
    [SerializeField]
    private GameObject m_PanelSelect;

    /// <summary>
    /// 创建角色面板返回按钮
    /// </summary>
    [SerializeField]
    private Button m_BtnCreateCancel;

    /// <summary>
    /// 角色名称输入框
    /// </summary>
    [SerializeField]
    private InputField m_InputCharacterName;

    /// <summary>
    /// 角色职业种类
    /// </summary>
    private CharacterClass characterClass;

    /// <summary>
    /// 角色列表
    /// </summary>
    [SerializeField]
    private Transform m_UiCharacterList;

    /// <summary>
    /// 角色信息
    /// </summary>
    [SerializeField]
    private GameObject m_UiCharacterInfo;

    /// <summary>
    /// 角色UI List
    /// </summary>
    [SerializeField]
    private List<GameObject> m_UiCharacters = new List<GameObject>();

    /// <summary>
    /// 角色种类图片
    /// </summary>
    [SerializeField]
    private Image[] m_ImgTitles;

    /// <summary>
    /// 角色描述
    /// </summary>
    [SerializeField]
    private Text m_CharacterDescr;

    /// <summary>
    /// 角色种类名称
    /// </summary>
    [SerializeField]
    private Text[] m_CharacterNames;

    /// <summary>
    /// 角色选择索引
    /// </summary>
    private int m_CharacterSelectIndex = -1;

    /// <summary>
    /// UICharacterView脚本
    /// </summary>
    [SerializeField]
    private UICharacterView m_CharacterView;
    #endregion

    void Start()
    {
        //DataManager.Instance.Load();
        InitCharacterSelect(true);
        UserService.Instance.OnCharacterCreate = OnCharacterCreate;
    }

    /// <summary>
    /// 初始化角色选择界面
    /// </summary>
    /// <param name="init">是否初始化</param>
    public void InitCharacterSelect(bool init)
    {
        m_PanelCreate.SetActive(false);
        m_PanelSelect.SetActive(true);

        if (init)
        {
            foreach (var old in m_UiCharacters)
            {
                Destroy(old);
            }
            m_UiCharacters.Clear();

            for (int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
            {
                GameObject obj = Instantiate(m_UiCharacterInfo, this.m_UiCharacterList);
                UICharacterInfo characterInfo = obj.GetComponent<UICharacterInfo>();
                characterInfo.NCharacterInfo = User.Instance.Info.Player.Characters[i];

                Button button = obj.GetComponent<Button>();
                int index = i;
                button.onClick.AddListener(() =>
                {
                    OnSelectCharacter(index);
                });

                m_UiCharacters.Add(obj);
                obj.SetActive(true);
            }
        }
        if (User.Instance.Info.Player.Characters.Count > 0) 
        {
            OnSelectCharacter(0);
        }
    }

    /// <summary>
    /// 初始化创建角色界面
    /// </summary>
    public void InitCharacterCreate()
    {
        m_PanelCreate.SetActive(true);
        m_PanelSelect.SetActive(false);
        OnSelectClass(1);

        for (int i = 0; i < 3; i++)
        {
            m_CharacterNames[i].text = DataManager.Instance.Characters[i + 1].Name.ToString();
        }
    }
	
    /// <summary>
    /// 角色职业种类
    /// </summary>
    /// <param name="characterClass">种类代码</param>
    public void OnSelectClass(int characterClass)
    {
        this.characterClass = (CharacterClass)characterClass;

        m_CharacterView.CurrentCharacter = characterClass - 1;

        for (int i = 0; i < 3; i++)
        {
            m_ImgTitles[i].gameObject.SetActive(i == characterClass - 1);
            m_CharacterNames[i].text = DataManager.Instance.Characters[i + 1].Name.ToString();
        }

        m_CharacterDescr.text = DataManager.Instance.Characters[characterClass].Description;
    }

    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="result">创建结果</param>
    /// <param name="message">消息</param>
    void OnCharacterCreate(Result result,string message)
    {
        if (result == Result.Success)
        {
            InitCharacterSelect(true);
            OnSelectCharacter(User.Instance.Info.Player.Characters.Count-1);
        }
        else
        {
            MessageBox.Show(message, "错误", MessageBoxType.Error);
        }
    }

    /// <summary>
    /// 选择角色
    /// </summary>
    /// <param name="index">角色索引</param>
    public void OnSelectCharacter(int index)
    {
        this.m_CharacterSelectIndex = index;
        var character = User.Instance.Info.Player.Characters[index];
        Debug.LogFormat("Select Character: [{0}]{1}[{2}]", character.Id, character.Name, character.Class);
        User.Instance.CurrentCharacter = character;
        m_CharacterView.CurrentCharacter = (int)character.Class - 1;

        for (int i = 0; i < User.Instance.Info.Player.Characters.Count; i++)
        {
            UICharacterInfo uICharacterInfo = this.m_UiCharacters[i].GetComponent<UICharacterInfo>();
            uICharacterInfo.Selected = index==i;
        }
    }

    /// <summary>
    /// 创建按钮点击事件
    /// </summary>
    public void OnClickCreate()
    {
        if (string.IsNullOrEmpty(m_InputCharacterName.text))
        {
            MessageBox.Show("请输入角色名称");
            return;
        }
        
        UserService.Instance.SendCharacterCreate(this.m_InputCharacterName.text, this.characterClass);
    }

    /// <summary>
    /// 进入游戏按钮点击事件
    /// </summary>
    public void OnClickPlay()
    {
        if (m_CharacterSelectIndex >= 0)
        {
            //MessageBox.Show("进入游戏", "进入游戏", MessageBoxType.Confirm);
            UserService.Instance.SendGameEnter(m_CharacterSelectIndex);
        }
    }

    public void OnClickBackToLogin()
    {
        SceneManager.Instance.LoadScene("Loading");       
    }
}
