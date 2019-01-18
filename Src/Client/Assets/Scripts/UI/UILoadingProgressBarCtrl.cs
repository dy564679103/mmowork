/**************************************************************** 
*	FileName: UISceneLoadingCtrl.cs								
*	Author: Denny Teng											
*	Version: 1.0												
*	UnityVersion：5.3.3f1										
*	Date: 2018-12-01 00:19										
*	Description:												
*	History:													
*****************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Loading场景UI控制器
/// </summary>
public class UILoadingProgressBarCtrl : MonoBehaviour 
{
    /// <summary>
    /// Loading进度条
    /// </summary>
    [SerializeField]
    private Slider m_LoadingProgressBar;

    /// <summary>
    /// 进度条百分比
    /// </summary>
    [SerializeField]
    private Text m_TextProgress;

    /// <summary>
    /// 发光特效图
    /// </summary>
    [SerializeField]
    private Image m_SprProgressLight;

    /// <summary>
    /// 设置进度条的值
    /// </summary>
    /// <param name="value"></param>
    public void SetProgressValue(float value)
    {
        m_LoadingProgressBar.value = value;
        m_TextProgress.text = string.Format("{0}%", (int)(value * 100));

        //m_SprProgressLight.transform.localPosition = new Vector3(880f * value, 0, 0);
    }
}
