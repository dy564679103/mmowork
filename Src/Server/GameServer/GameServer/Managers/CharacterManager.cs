using Common;
using GameServer.Entities;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Managers
{
    class CharacterManager:Singleton<CharacterManager>,IDisposable
    {
        /// <summary>
        /// 角色字典
        /// </summary>
        Dictionary<int, Character> Characters = new Dictionary<int, Character>();

        public CharacterManager()
        {

        }

        public void Init()
        {

        }

        public void Dispose()
        {

        }

        public void Clear()
        {
            this.Characters.Clear();
        }

        public Character AddCharacter(TCharacter tCharacter)
        {
            Character character = new Character(CharacterType.Player, tCharacter);
            this.Characters[tCharacter.ID] =character;
            return character;
        }

        public void RemoveCharacter(int characterIndex)
        {
            this.Characters.Remove(characterIndex);
        }
    }
}
