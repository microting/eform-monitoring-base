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

namespace Microting.EformMonitoringBase.Infrastructure.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Enums;
    using Microsoft.EntityFrameworkCore;
    using Microting.eForm.Infrastructure.Constants;

    public class NotificationRule : BaseEntity
    {
        public int CheckListId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public bool AttachReport { get; set; }
        public bool AttachLink { get; set; }
        public bool IncludeValue { get; set; }

        public RuleType? RuleType { get; set; }
        public int? DataItemId { get; set; }
        public string Data { get; set; }

        public virtual List<Recipient> Recipients { get; set; }
            = new List<Recipient>();
        public virtual List<DeviceUser> DeviceUsers { get; set; }
            = new List<DeviceUser>();

        public async Task Create(EformMonitoringPnDbContext dbContext)
        {
            NotificationRule rule = new NotificationRule
            {
                CheckListId = CheckListId,
                AttachReport = AttachReport,
                Subject = Subject,
                Text = Text,
                Data = Data,
                DataItemId = DataItemId,
                RuleType = RuleType,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
                AttachLink = AttachLink,
                IncludeValue = IncludeValue
            };

            await dbContext.Rules.AddAsync(rule).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            await dbContext.RuleVersions.AddAsync(MapVersion(rule)).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            Id = rule.Id;
        }

        public async Task Update(EformMonitoringPnDbContext dbContext)
        {
            var rule = await dbContext.Rules
                .FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);

            if (rule == null)
            {
                throw new NullReferenceException($"Could not find notification rule with id: {Id}");
            }

            rule.CheckListId = CheckListId;
            rule.Subject = Subject;
            rule.Text = Text;
            rule.AttachReport = AttachReport;
            rule.RuleType = RuleType;
            rule.Data = Data;
            rule.DataItemId = DataItemId;

            rule.WorkflowState = WorkflowState;
            rule.UpdatedAt = UpdatedAt;
            rule.UpdatedByUserId = UpdatedByUserId;
            rule.AttachLink = AttachLink;
            rule.IncludeValue = IncludeValue;

            if (dbContext.ChangeTracker.HasChanges())
            {
                rule.UpdatedAt = DateTime.UtcNow;
                rule.Version += 1;

                await dbContext.RuleVersions.AddAsync(MapVersion(rule)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task Delete(EformMonitoringPnDbContext dbContext)
        {
            var rule = await dbContext.Rules
                .FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);

            if (rule == null)
            {
                throw new NullReferenceException($"Could not find notification rule with id: {Id}");
            }

            rule.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                rule.UpdatedAt = DateTime.UtcNow;
                rule.Version += 1;

                await dbContext.RuleVersions.AddAsync(MapVersion(rule)).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }

        }

        private NotificationRuleVersion MapVersion(NotificationRule item)
        {
            NotificationRuleVersion itemVersion = new NotificationRuleVersion
            {
                CheckListId = item.CheckListId,
                AttachReport = item.AttachReport,
                Subject = item.Subject,
                Text = item.Text,
                Version = item.Version,
                Data = item.Data,
                DataItemId = item.DataItemId,
                RuleType = item.RuleType,
                NotificationRuleId = item.Id,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                WorkflowState = item.WorkflowState,
                UpdatedByUserId = item.UpdatedByUserId,
                CreatedByUserId = item.CreatedByUserId,
                AttachLink = item.AttachLink,
                IncludeValue = item.IncludeValue
            };

            return itemVersion;
        }
    }
}