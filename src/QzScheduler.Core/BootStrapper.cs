using Autofac;
using Autofac.Extras.Quartz;
using QzScheduler.Core.Configurations;
using System;
using System.Reflection;

namespace QzScheduler.Core
{
    public static class BootStrapper
    {
        public static void AddQzScheduler(ContainerBuilder iocBuilder, Action<QzSchedulerOptions> action, params Assembly[] jobAsms)
        {
            var options = new QzSchedulerOptions();
            action?.Invoke(options);

            var scheduleFactoryModule = new QuartzAutofacFactoryModule();
            scheduleFactoryModule.ConfigurationProvider = ctx => options.Properties;

            iocBuilder.RegisterModule(scheduleFactoryModule);
            iocBuilder.RegisterModule(new QuartzAutofacJobsModule(jobAsms));
        }
    }
}
