using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerCamera : MonoSingleton<MainPlayerCamera>
{

    [SerializeField]
    private Camera m_Camera;

    [SerializeField]
    private Transform m_ViewPoint;

    public GameObject Player;

    private void LateUpdate()
    {
        if (Player == null)
            return;

        this.transform.position = Player.transform.position;
        this.transform.rotation = Player.transform.rotation;
    }
}
