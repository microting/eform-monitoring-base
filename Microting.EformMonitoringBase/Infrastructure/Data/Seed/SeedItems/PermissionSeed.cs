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

namespace Microting.EformMonitoringBase.Infrastructure.Data.Seed.SeedItems
{
    using Const;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public static class PermissionSeed
    {
        public static ModelBuilder AddPermissions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission()
                {
                    Id = MonitoringPermissions.EditPluginSettings,
                    PermissionName = "Edit Plugin Settings"
                },
                new Permission()
                {
                    Id = MonitoringPermissions.ReadNotificationRules,
                    PermissionName = "Read Notification Rules"
                },
                new Permission()
                {
                    Id = MonitoringPermissions.CreateNotificationRules,
                    PermissionName = "Create Notification Rules"
                },
                new Permission()
                {
                    Id = MonitoringPermissions.UpdateNotificationRules,
                    PermissionName = "Update Notification Rules"
                },
                new Permission()
                {
                    Id = MonitoringPermissions.DeleteNotificationRules,
                    PermissionName = "Delete Notification Rules"
                }
            );
            return modelBuilder;
        }
    }
}