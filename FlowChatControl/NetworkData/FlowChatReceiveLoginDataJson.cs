﻿using FlowChatControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowChatControl.NetworkData
{
    public class FlowChatReceiveLoginDataJson : FlowChatReceiveDataJson
    {
        public FlowChatUserModel Data { get; set; }
    }
}
