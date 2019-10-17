/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading.Tasks;
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Microsoft.EntityFrameworkCore;
    using Microting.eForm.Infrastructure.Constants;

    public class Recipient : BaseEntity
    {
        public string Email { get; set; }

        [ForeignKey(nameof(NotificationRule))]
        public int NotificationRuleId { get; set; }

        public async Task Save(EformMonitoringPnDbContext dbContext)
        {
            var recipient = new Recipient
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
                NotificationRuleId = NotificationRuleId,
                Email = Email,
            };

            await dbContext.Recipients.AddAsync(recipient);
            await dbContext.SaveChangesAsync();

            Id = recipient.Id;
        }

        public async Task Delete(EformMonitoringPnDbContext dbContext)
        {            
            var recipient = await dbContext.Recipients
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (recipient == null)
            {
                throw new NullReferenceException($"Could not find notification rule with id: {Id}");
            }

            recipient.WorkflowState = Constants.WorkflowStates.Removed;
            recipient.UpdatedAt = DateTime.UtcNow;
            recipient.Version += 1;

            dbContext.Recipients.Update(recipient);
            await dbContext.SaveChangesAsync();
        }
    }
}