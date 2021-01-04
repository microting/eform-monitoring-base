﻿/*
The MIT License (MIT)

Copyright (c) 2007 - 2021 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Microting.EformMonitoringBase.Infrastructure.Models
{
    using System.Collections.Generic;
    using Enums;

    public class NotificationRuleModel
    {
        public int? Id { get; set; }
        public int CheckListId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public bool AttachReport { get; set; }
        public bool AttachLink { get; set; }
        public bool IncludeValue { get; set; }
        public RuleType? RuleType { get; set; }
        public int? DataItemId { get; set; }
        public object Data { get; set; }

        public List<RecipientModel> Recipients { get; set; }
            = new List<RecipientModel>();
        public List<DeviceUserModel> DeviceUsers { get; set; }
            = new List<DeviceUserModel>();
    }
}
