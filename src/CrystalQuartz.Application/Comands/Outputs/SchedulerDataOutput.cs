﻿using CrystalQuartz.Core.Domain.Activities;

namespace CrystalQuartz.Application.Comands.Outputs
{
    using CrystalQuartz.Core.Domain;
    using CrystalQuartz.Core.Timeline;

    public class SchedulerDataOutput : CommandResultWithErrorDetails
    {
        public string Name { get; set; }

        public string InstanceId { get; set; }

        public JobGroupData[] JobGroups { get; set; }

        public string Status { get; set; }

        public int JobsTotal { get; set; }

        public int JobsExecuted { get; set; }

        public long? RunningSince { get; set; }

        public bool CanStart { get; set; }

        public bool CanShutdown { get; set; }

        public SchedulerEventData[] Events { get; set; }

        public ExecutingJobInfo[] InProgress { get; set; }
    }
}