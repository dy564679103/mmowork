using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;
using SkillBridge.Message;

public class UILogin : MonoBehaviour {

    [SerializeField]
    private InputField inputUsername;

    [SerializeField]
    private InputField inputPassword;

    [SerializeField]
    private Button buttonLogin;

    [SerializeField]
    private Button buttonRegister;

    [SerializeField]
    private Toggle toggleRememberAccount;

    [SerializeField]
    private Toggle toggleUserAgreement;

    private int m_IsRemenberAccount = 0;
    private int m_IsAgreeUserAgreement = 0;

    void Start ()
    {
        UserService.Instance.OnLogin = OnLogin;

        if (PlayerPrefs.HasKey(Network.NetClient.USER_NAME))
        {
            inputUsername.text = PlayerPrefs.GetString(Network.NetClient.USER_NAME);
        }
        if (PlayerPrefs.HasKey(Network.NetClient.PASS_WORD))
        {
            inputPassword.text = PlayerPrefs.GetString(Network.NetClient.PASS_WORD);
        }
        if (PlayerPrefs.HasKey(Network.NetClient.IS_REMEMBER_ACCOUNT))
        {
            m_IsRemenberAccount = PlayerPrefs.GetInt(Network.NetClient.IS_REMEMBER_ACCOUNT);
            if (m_IsRemenberAccount == 1)
            {
                toggleRememberAccount.isOn = true;
            }
        }
        if (PlayerPrefs.HasKey(Network.NetClient.IS_Agree_The_UserAgreement))
        {
            m_IsAgreeUserAgreement = PlayerPrefs.GetInt(Network.NetClient.IS_Agree_The_UserAgreement);
            if (m_IsRemenberAccount == 1)
            {
                toggleUserAgreement.isOn = true;
            }
        }
    }



    public void OnClickLogin()
    {
        if (string.IsNullOrEmpty(this.inputUsername.text))
        {
            MessageBox.Show("请输入账号...");
            return;
        }
        if (string.IsNullOrEmpty(this.inputPassword.text))
        {
            MessageBox.Show("请输入密码...");
            return;
        }
        if (toggleRememberAccount.isOn)
        {
            PlayerPrefs.SetString(Network.NetClient.USER_NAME, inputUsername.text);
            PlayerPrefs.SetString(Network.NetClient.PASS_WORD, inputPassword.text);
            PlayerPrefs.SetInt(Network.NetClient.IS_REMEMBER_ACCOUNT, 1);
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
        if (toggleUserAgreement.isOn)
        {
            PlayerPrefs.SetInt(Network.NetClient.IS_Agree_The_UserAgreement, 1);
        }
        else
        {
            MessageBox.Show("请阅读并同意《用户协议》后登陆...");
            return;
        }

        // Enter Game
        UserService.Instance.SendLogin(this.inputUsername.text,this.inputPassword.text);

    }

    void OnLogin(Result result, string message)
    {
        if (result == Result.Success)
        {
            //登录成功，进入角色选择
            //MessageBox.Show("登录成功,准备角色选择" + message,"提示", MessageBoxType.Information);
            SceneManager.Instance.LoadScene("CharacterSelect");

        }
        else
            MessageBox.Show(message, "错误", MessageBoxType.Error);
    }
}
