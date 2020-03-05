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

    public class DeviceUser : BaseEntity
    {
        public int DeviceUserId { get; set; }

        [ForeignKey(nameof(NotificationRule))]
        public int NotificationRuleId { get; set; }

        public async Task Create(EformMonitoringPnDbContext dbContext)
        {
            var deviceUser = new DeviceUser
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
                NotificationRuleId = NotificationRuleId,
                DeviceUserId = DeviceUserId,
            };

            await dbContext.DeviceUsers.AddAsync(deviceUser).ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            Id = deviceUser.Id;
        }

        public async Task Delete(EformMonitoringPnDbContext dbContext)
        {            
            var deviceUser = await dbContext.DeviceUsers
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (deviceUser == null)
            {
                throw new NullReferenceException($"Could not find device user in notification rule with id: {Id}");
            }

            deviceUser.WorkflowState = Constants.WorkflowStates.Removed;
            deviceUser.UpdatedAt = DateTime.UtcNow;
            deviceUser.Version += 1;

            dbContext.DeviceUsers.Update(deviceUser);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}