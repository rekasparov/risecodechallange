using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISE.Shared.Models
{
    public static class RabbitMQSettingsModel
    {
        public const string PersonCreatedQueueName = "person-created-queue";
        public const string ReportCreatedQueueName = "report-created-queue";
        public const string ReportDetailCreatedQueueName = "report-detail-created-queue";
        public const string ReportDetailNotCreatedQueueName = "report-detail-not-created-queue";
    }
}
