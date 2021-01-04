/*
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.EformMonitoringBase.Infrastructure.Data.Entities;
using Microting.EformMonitoringBase.Infrastructure.Enums;
using NUnit.Framework;

namespace Microting.eFormMonitoringBase.Unit.Tests
{
    [TestFixture]
    public class NotificationRuleUnitTests : DbTestFixture
    {
        [Test]
        public async Task NotificationRule_Save_DoesSave_WRuleTypeNumber()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.Number;
            // Act
            await rule.Create(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);

            Assert.AreEqual(rule.Data, dbNotificationRule.Data);
            Assert.AreEqual(rule.Subject, dbNotificationRule.Subject);
            Assert.AreEqual(rule.Text, dbNotificationRule.Text);
            Assert.AreEqual(rule.CheckListId, dbNotificationRule.CheckListId);
            Assert.AreEqual(rule.DataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(rule.AttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(rule.RuleType, dbNotificationRule.RuleType);
        }
        [Test]
        public async Task NotificationRule_Save_DoesSave_WRuleTypeCheckBox()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.CheckBox;
            // Act
            await rule.Create(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);

            Assert.AreEqual(rule.Data, dbNotificationRule.Data);
            Assert.AreEqual(rule.Subject, dbNotificationRule.Subject);
            Assert.AreEqual(rule.Text, dbNotificationRule.Text);
            Assert.AreEqual(rule.CheckListId, dbNotificationRule.CheckListId);
            Assert.AreEqual(rule.DataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(rule.AttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(rule.RuleType, dbNotificationRule.RuleType);
        }
        [Test]
        public async Task NotificationRule_Save_DoesSave_WRuleTypeSelect()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.Select;
            // Act
            await rule.Create(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);

            Assert.AreEqual(rule.Data, dbNotificationRule.Data);
            Assert.AreEqual(rule.Subject, dbNotificationRule.Subject);
            Assert.AreEqual(rule.Text, dbNotificationRule.Text);
            Assert.AreEqual(rule.CheckListId, dbNotificationRule.CheckListId);
            Assert.AreEqual(rule.DataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(rule.AttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(rule.RuleType, dbNotificationRule.RuleType);
        }
         [Test]
        public async Task NotificationRule_Update_DoesUpdate_WRuleTypeCheckBox()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.Number;
            await rule.Create(DbContext).ConfigureAwait(false);

            string newData = Guid.NewGuid().ToString();
            string newSubject = Guid.NewGuid().ToString();
            string newText = Guid.NewGuid().ToString();
            int newChecklistId = rnd.Next(1, 255);
            int newDataItemId = rnd.Next(1, 255);
            bool newAttachReport = rnd.NextDouble() >= 0.5;
            // Act
            rule.Data = newData;
            rule.Subject = newSubject;
            rule.Text = newText;
            rule.CheckListId = newChecklistId;
            rule.DataItemId = newDataItemId;
            rule.AttachReport = newAttachReport;
            rule.RuleType = RuleType.CheckBox;
            await rule.Update(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            List<NotificationRuleVersion> notificationRuleVersionList = DbContext.RuleVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);
            Assert.AreEqual(2, notificationRuleVersionList.Count);

            Assert.AreEqual(newData, dbNotificationRule.Data);
            Assert.AreEqual(newSubject, dbNotificationRule.Subject);
            Assert.AreEqual(newText, dbNotificationRule.Text);
            Assert.AreEqual(newChecklistId, dbNotificationRule.CheckListId);
            Assert.AreEqual(newDataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(newAttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(RuleType.CheckBox, dbNotificationRule.RuleType);

        }
        [Test]
        public async Task NotificationRule_Update_DoesUpdate_WRuleTypeSelect()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.CheckBox;
            await rule.Create(DbContext).ConfigureAwait(false);

            string newData = Guid.NewGuid().ToString();
            string newSubject = Guid.NewGuid().ToString();
            string newText = Guid.NewGuid().ToString();
            int newChecklistId = rnd.Next(1, 255);
            int newDataItemId = rnd.Next(1, 255);
            bool newAttachReport = rnd.NextDouble() >= 0.5;
            // Act
            rule.Data = newData;
            rule.Subject = newSubject;
            rule.Text = newText;
            rule.CheckListId = newChecklistId;
            rule.DataItemId = newDataItemId;
            rule.AttachReport = newAttachReport;
            rule.RuleType = RuleType.Select;
            await rule.Update(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            List<NotificationRuleVersion> notificationRuleVersionList = DbContext.RuleVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);
            Assert.AreEqual(2, notificationRuleVersionList.Count);

            Assert.AreEqual(newData, dbNotificationRule.Data);
            Assert.AreEqual(newSubject, dbNotificationRule.Subject);
            Assert.AreEqual(newText, dbNotificationRule.Text);
            Assert.AreEqual(newChecklistId, dbNotificationRule.CheckListId);
            Assert.AreEqual(newDataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(newAttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(RuleType.Select, dbNotificationRule.RuleType);
        }
        [Test]
        public async Task NotificationRule_Update_DoesUpdate_WRuleTypeNumber()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.Select;
            await rule.Create(DbContext).ConfigureAwait(false);

            string newData = Guid.NewGuid().ToString();
            string newSubject = Guid.NewGuid().ToString();
            string newText = Guid.NewGuid().ToString();
            int newChecklistId = rnd.Next(1, 255);
            int newDataItemId = rnd.Next(1, 255);
            bool newAttachReport = rnd.NextDouble() >= 0.5;
            // Act
            rule.Data = newData;
            rule.Subject = newSubject;
            rule.Text = newText;
            rule.CheckListId = newChecklistId;
            rule.DataItemId = newDataItemId;
            rule.AttachReport = newAttachReport;
            rule.RuleType = RuleType.Number;
            await rule.Update(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            List<NotificationRuleVersion> notificationRuleVersionList = DbContext.RuleVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);
            Assert.AreEqual(2, notificationRuleVersionList.Count);

            Assert.AreEqual(newData, dbNotificationRule.Data);
            Assert.AreEqual(newSubject, dbNotificationRule.Subject);
            Assert.AreEqual(newText, dbNotificationRule.Text);
            Assert.AreEqual(newChecklistId, dbNotificationRule.CheckListId);
            Assert.AreEqual(newDataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(newAttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(RuleType.Number, dbNotificationRule.RuleType);
        }
        [Test]
        public async Task NotificationRule_Delete_DoesDelete_WRuleTypeNumber()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.Number;
            await rule.Create(DbContext).ConfigureAwait(false);
            // Act
            await rule.Delete(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            List<NotificationRuleVersion> notificationRuleVersionList = DbContext.RuleVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);
            Assert.AreEqual(2, notificationRuleVersionList.Count);

            Assert.AreEqual(rule.Data, dbNotificationRule.Data);
            Assert.AreEqual(rule.Subject, dbNotificationRule.Subject);
            Assert.AreEqual(rule.Text, dbNotificationRule.Text);
            Assert.AreEqual(rule.CheckListId, dbNotificationRule.CheckListId);
            Assert.AreEqual(rule.DataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(rule.AttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(rule.RuleType, dbNotificationRule.RuleType);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbNotificationRule.WorkflowState);
        }
        [Test]
        public async Task NotificationRule_Delete_DoesDelete_WRuleTypeCheckBox()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.CheckBox;
            await rule.Create(DbContext).ConfigureAwait(false);
            // Act
            await rule.Delete(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            List<NotificationRuleVersion> notificationRuleVersionList = DbContext.RuleVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);
            Assert.AreEqual(2, notificationRuleVersionList.Count);

            Assert.AreEqual(rule.Data, dbNotificationRule.Data);
            Assert.AreEqual(rule.Subject, dbNotificationRule.Subject);
            Assert.AreEqual(rule.Text, dbNotificationRule.Text);
            Assert.AreEqual(rule.CheckListId, dbNotificationRule.CheckListId);
            Assert.AreEqual(rule.DataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(rule.AttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(rule.RuleType, dbNotificationRule.RuleType);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbNotificationRule.WorkflowState);
        }
        [Test]
        public async Task NotificationRule_Delete_DoesDelete_WRuleTypeSelect()
        {
            //Arrange
            Random rnd = new Random();
            NotificationRule rule = new NotificationRule();

            rule.Data = Guid.NewGuid().ToString();
            rule.Subject = Guid.NewGuid().ToString();
            rule.Text = Guid.NewGuid().ToString();
            rule.CheckListId = rnd.Next(1, 255);
            rule.DataItemId = rnd.Next(1, 255);
            rule.AttachReport = rnd.NextDouble() >= 0.5;
            rule.RuleType = RuleType.Select;
            await rule.Create(DbContext).ConfigureAwait(false);

            // Act
            await rule.Delete(DbContext).ConfigureAwait(false);

            NotificationRule dbNotificationRule = DbContext.Rules.AsNoTracking().First();
            List<NotificationRule> notificationRuleList = DbContext.Rules.AsNoTracking().ToList();
            List<NotificationRuleVersion> notificationRuleVersionList = DbContext.RuleVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbNotificationRule);

            Assert.AreEqual(1, notificationRuleList.Count);
            Assert.AreEqual(2, notificationRuleVersionList.Count);

            Assert.AreEqual(rule.Data, dbNotificationRule.Data);
            Assert.AreEqual(rule.Subject, dbNotificationRule.Subject);
            Assert.AreEqual(rule.Text, dbNotificationRule.Text);
            Assert.AreEqual(rule.CheckListId, dbNotificationRule.CheckListId);
            Assert.AreEqual(rule.DataItemId, dbNotificationRule.DataItemId);
            Assert.AreEqual(rule.AttachReport, dbNotificationRule.AttachReport);
            Assert.AreEqual(rule.RuleType, dbNotificationRule.RuleType);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbNotificationRule.WorkflowState);
        }
    }
}