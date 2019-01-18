using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Network;
using SkillBridge.Message;

namespace GameServer.Services
{
    class ExtremeWorldTest:Singleton<ExtremeWorldTest>
    {
        public void Init()
        {
            
        }

        public void Start()
        {
            //MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<FirstTestRequest>(this.OnFirstTestRequest);
        }

        //private void OnFirstTestRequest(NetConnection<NetSession> sender, FirstTestRequest request)
        //{
        //    Log.InfoFormat("OnFirstTestRequest: Test:{0}", request.ExtremeWorldTest);
        //}

        public void Stop()
        {

        }
    }
}
