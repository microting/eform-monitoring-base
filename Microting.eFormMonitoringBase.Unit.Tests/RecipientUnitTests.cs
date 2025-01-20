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
    public class RecipientUnitTests : DbTestFixture
    {
        [Test]
        public async Task Recipient_Save_DoesSave()
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

            NotificationRule ruleForRecipient = DbContext.Rules.AsNoTracking().First();

            Recipient recipient = new Recipient();

            recipient.Email = Guid.NewGuid().ToString();
            recipient.NotificationRuleId = ruleForRecipient.Id;

            //Act
            await recipient.Create(DbContext).ConfigureAwait(false);

            Recipient dbRecipient = DbContext.Recipients.AsNoTracking().First();
            List<Recipient> recipientList = DbContext.Recipients.AsNoTracking().ToList();
            //Assert
            Assert.That(dbRecipient, Is.Not.Null);

            Assert.That(recipientList.Count, Is.EqualTo(1));
            Assert.That(dbRecipient.Email, Is.EqualTo(recipient.Email));
            Assert.That(dbRecipient.NotificationRuleId, Is.EqualTo(recipient.NotificationRuleId));
        }
        [Test]
        public async Task Recipient_Delete_DoesDelete()
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

            NotificationRule ruleForRecipient = DbContext.Rules.AsNoTracking().First();

            Recipient recipient = new Recipient();

            recipient.Email = Guid.NewGuid().ToString();
            recipient.NotificationRuleId = ruleForRecipient.Id;
            await recipient.Create(DbContext).ConfigureAwait(false);

            //Act
            await recipient.Delete(DbContext).ConfigureAwait(false);

            Recipient dbRecipient = DbContext.Recipients.AsNoTracking().First();
            List<Recipient> recipientList = DbContext.Recipients.AsNoTracking().ToList();
            //Assert
            Assert.That(dbRecipient, Is.Not.Null);

            Assert.That(recipientList.Count, Is.EqualTo(1));
            Assert.That(dbRecipient.Email, Is.EqualTo(recipient.Email));
            Assert.That(dbRecipient.NotificationRuleId, Is.EqualTo(recipient.NotificationRuleId));
            Assert.That(dbRecipient.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        }
    }
}