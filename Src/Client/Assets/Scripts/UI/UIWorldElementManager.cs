using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldElementManager : MonoSingleton<UIWorldElementManager>
{
    [SerializeField]
    private GameObject m_CharInfoBarPrefab;

    private Dictionary<Transform, GameObject> m_Elements = new Dictionary<Transform, GameObject>();


    public void AddCharacterInfoBar(Transform owner, Character character)
    {
        GameObject objCharInfoBar = Instantiate(m_CharInfoBarPrefab, this.transform);
        objCharInfoBar.name = "CharacterInfoBar" + character.entityId;
        objCharInfoBar.GetComponent<UIWorldElement>().Owner=owner;
        objCharInfoBar.GetComponent<UICharInfoBarMgr>().Character=character;
        objCharInfoBar.SetActive(true);
        this.m_Elements[owner] = objCharInfoBar;
    }

    public void RemoveCharacterInfoBar(Transform owner)
    {
        if (this.m_Elements.ContainsKey(owner))
        {
            Destroy(this.m_Elements[owner
                ]);
            this.m_Elements.Remove(owner);
        }
    }

}
