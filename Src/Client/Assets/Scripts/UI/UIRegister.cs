using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;
using SkillBridge.Message;
using System;

public class UIRegister : MonoBehaviour {

    [SerializeField]
    private InputField IF_Username;

    [SerializeField]
    private InputField IF_Password;

    [SerializeField]
    private InputField IF_ConfirmPassword;

    [SerializeField]
    private Button Btn_Register;

    [SerializeField]
    private GameObject UI_Login;

    // Use this for initialization
    void Start () {
        UserService.Instance.OnRegister = this.OnRegister;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickRegister()
    {
        if (string.IsNullOrEmpty(this.IF_Username.text))
        {
            MessageBox.Show("请输入账号");
            return;
        }
        if (string.IsNullOrEmpty(this.IF_Password.text))
        {
            MessageBox.Show("请输入密码");
            return;
        }
        if (string.IsNullOrEmpty(this.IF_ConfirmPassword.text))
        {
            MessageBox.Show("请输入确认密码");
            return;
        }
        if (this.IF_Password.text != this.IF_ConfirmPassword.text)
        {
            MessageBox.Show("两次输入的密码不一致");
            return;
        }
        UserService.Instance.SendRegister(this.IF_Username.text, this.IF_Password.text);
    }

    void OnRegister(Result result, string msg)
    {
        if (result == Result.Success)
        {
            //登录成功，返回登录
            MessageBox.Show("注册成功, 请登录", "提示：", MessageBoxType.Information).OnYes = this.CloseRegister;
        }
        else
            MessageBox.Show(msg, "错误", MessageBoxType.Error);
    }

    void CloseRegister()
    {
        this.gameObject.SetActive(false);
        UI_Login.SetActive(true);
    }
}
