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
            Assert.NotNull(dbRecipient);
            
            Assert.AreEqual(1, recipientList.Count);
            Assert.AreEqual(recipient.Email, dbRecipient.Email);
            Assert.AreEqual(recipient.NotificationRuleId, dbRecipient.NotificationRuleId);
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
            Assert.NotNull(dbRecipient);
            
            Assert.AreEqual(1, recipientList.Count);
            Assert.AreEqual(recipient.Email, dbRecipient.Email);
            Assert.AreEqual(recipient.NotificationRuleId, dbRecipient.NotificationRuleId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbRecipient.WorkflowState);
        }
    }
}