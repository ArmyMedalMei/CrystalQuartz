﻿using System.Collections.Generic;
using System.Web.Script.Serialization;
using CrystalQuartz.Core;
using CrystalQuartz.Core.SchedulerProviders;
using CrystalQuartz.Web.Comands;
using CrystalQuartz.WebFramework;

namespace CrystalQuartz.Web
{
    public class CrystalQuartzPanelApplication : Application
    {
        private readonly ISchedulerProvider _schedulerProvider;
        private readonly ISchedulerDataProvider _schedulerDataProvider;

        public CrystalQuartzPanelApplication(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider)
        {
            _schedulerProvider = schedulerProvider;
            _schedulerDataProvider = schedulerDataProvider;
        }

        public override RouteConfig Config
        {
            get
            {
                JavaScriptSerializer.RegisterConverters(new List<JavaScriptConverter>
                {
                    new DateTimeConverter(),
                    new ActivityStatusConverter()
                });

                return this
                    .When("pause_group")      .DoCommand(new PauseGroupCommand(_schedulerProvider))
                    .When("pause_job")        .DoCommand(new PauseJobCommand(_schedulerProvider))
                    .When("pause_trigger")    .DoCommand(new PauseTriggerCommand(_schedulerProvider))
                    
                    /* 
                     * Scheduler commands
                     */
                    .When("start_scheduler")  .DoCommand(new StartSchedulerCommand(_schedulerProvider, _schedulerDataProvider))
                    .When("stop_scheduler")   .DoCommand(new StopSchedulerCommand(_schedulerProvider, _schedulerDataProvider))

                    .When("get_data")         .DoCommand(new GetDataCommand(_schedulerDataProvider));
            }
        }
    }
}