using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillBridge.Message;
using Common;
using Network;
using UnityEngine.Events;

public class CharacterManager : Singleton<CharacterManager>, IDisposable
{
    /// <summary>
    /// 角色字典
    /// </summary>
    public Dictionary<int, Character> Characters = new Dictionary<int, Character>();

    public UnityAction<Character> OnCharacterEnter;


    public CharacterManager()
    {

    }

    public void Dispose()
    {
        
    }

    public void Init()
    {

    }

    /// <summary>
    /// 清空字典
    /// </summary>
    public void Clear()
    {
        this.Characters.Clear();
    }

    /// <summary>
    /// 向字典中增加角色
    /// </summary>
    /// <param name="nCharacterInfo">网络协议传输角色信息</param>
    public void AddCharacter(NCharacterInfo nCharacterInfo)
    {
        Debug.LogFormat("AddCharacter:{0}:{1} Map:{2} Entity:{3}", nCharacterInfo.Id, nCharacterInfo.Name, nCharacterInfo.mapId, nCharacterInfo.Entity.ToString());
        Character character = new Character(nCharacterInfo);
        this.Characters[nCharacterInfo.Id] = character;

        if (OnCharacterEnter != null)
        {
            OnCharacterEnter(character);
        }
    }

    /// <summary>
    /// 从字典中移除角色
    /// </summary>
    /// <param name="characterId">角色Id</param>
    public void RemoveCharacter(int characterId)
    {
        Debug.LogFormat("RemoveCharacter:{0}", characterId);
        this.Characters.Remove(characterId);
    }
}
