using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillBridge.Message;
using UnityEngine;

namespace Entities
{
    public class Character : Entity
    {
        public NCharacterInfo Info;

        public Common.Data.CharacterDefine Define;

        public string Name
        {
            get
            {
                if (this.Info.Type == CharacterType.Player)
                    return this.Info.Name;
                else
                    return this.Define.Name;
            }
        }

        public bool IsPlayer
        {
            get { return this.Info.Id == Models.User.Instance.CurrentCharacter.Id; }
        }

        public Character(NCharacterInfo info) : base(info.Entity)
        {
            this.Info = info;
            this.Define = DataManager.Instance.Characters[info.Tid];
        }

        public void MoveForward()
        {
            Debug.LogFormat("{0} MoveForward",Info.Name);
            this.speed = this.Define.Speed;
        }

        public void MoveBack()
        {
            Debug.LogFormat("{0} MoveBack",Info.Name);
            this.speed = -this.Define.Speed;
        }

        public void Stop()
        {
            Debug.LogFormat("{0} Stop",Info.Name);
            this.speed = 0;
        }

        public void SetDirection(Vector3Int direction)
        {
            Debug.LogFormat("{0} Move to Direction:{1}", Info.Name, direction);
            this.direction = direction;
        }

        public void SetPosition(Vector3Int position)
        {
            Debug.LogFormat("{0} Move to Position:{1}", Info.Name, position);
            this.position = position;
        }
    }
}
