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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(rule.Data));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(rule.Subject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(rule.Text));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(rule.CheckListId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(rule.DataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(rule.AttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(rule.RuleType));
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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(rule.Data));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(rule.Subject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(rule.Text));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(rule.CheckListId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(rule.DataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(rule.AttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(rule.RuleType));
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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(rule.Data));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(rule.Subject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(rule.Text));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(rule.CheckListId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(rule.DataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(rule.AttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(rule.RuleType));
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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));
            Assert.That(notificationRuleVersionList.Count, Is.EqualTo(2));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(newData));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(newSubject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(newText));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(newChecklistId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(newDataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(newAttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(RuleType.CheckBox));

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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));
            Assert.That(notificationRuleVersionList.Count, Is.EqualTo(2));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(newData));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(newSubject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(newText));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(newChecklistId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(newDataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(newAttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(RuleType.Select));
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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));
            Assert.That(notificationRuleVersionList.Count, Is.EqualTo(2));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(newData));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(newSubject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(newText));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(newChecklistId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(newDataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(newAttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(RuleType.Number));
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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));
            Assert.That(notificationRuleVersionList.Count, Is.EqualTo(2));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(rule.Data));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(rule.Subject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(rule.Text));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(rule.CheckListId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(rule.DataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(rule.AttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(rule.RuleType));
            Assert.That(dbNotificationRule.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));
            Assert.That(notificationRuleVersionList.Count, Is.EqualTo(2));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(rule.Data));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(rule.Subject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(rule.Text));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(rule.CheckListId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(rule.DataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(rule.AttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(rule.RuleType));
            Assert.That(dbNotificationRule.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
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
            Assert.That(dbNotificationRule, Is.Not.Null);

            Assert.That(notificationRuleList.Count, Is.EqualTo(1));
            Assert.That(notificationRuleVersionList.Count, Is.EqualTo(2));

            Assert.That(dbNotificationRule.Data, Is.EqualTo(rule.Data));
            Assert.That(dbNotificationRule.Subject, Is.EqualTo(rule.Subject));
            Assert.That(dbNotificationRule.Text, Is.EqualTo(rule.Text));
            Assert.That(dbNotificationRule.CheckListId, Is.EqualTo(rule.CheckListId));
            Assert.That(dbNotificationRule.DataItemId, Is.EqualTo(rule.DataItemId));
            Assert.That(dbNotificationRule.AttachReport, Is.EqualTo(rule.AttachReport));
            Assert.That(dbNotificationRule.RuleType, Is.EqualTo(rule.RuleType));
            Assert.That(dbNotificationRule.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        }
    }
}