using System.Collections.Specialized;

namespace QzScheduler.Core.Configurations
{
    public class QzSchedulerOptions
    {
        private NameValueCollection _properties;

        public NameValueCollection Properties => _properties;

        public QzSchedulerOptions()
        {
            _properties = new NameValueCollection();

            UseRAM();
        }

        /// <summary>
        /// 使用内存作为 JobStore (默认)
        /// </summary>
        public void UseRAM()
        {
            _properties["quartz.jobStore.type"] = "Quartz.Simpl.RAMJobStore, Quartz";
        }

        /// <summary>
        /// 使用数据库作为 JobStore
        /// </summary>
        /// <param name="provider"> 数据库驱动提供者：
        /// SqlServer - SQL Server driver for .NET Framework 2.0
        /// OracleODP - Oracle’s Oracle Driver
        /// OracleODPManaged - Oracle’s managed driver for Oracle 11
        /// MySql - MySQL Connector/.NET
        /// SQLite - SQLite ADO.NET Provider
        /// SQLite-Microsoft - Microsoft SQLite ADO.NET Provider
        /// Firebird - Firebird ADO.NET Provider
        /// Npgsql - PostgreSQL Npgsql
        /// </param>
        /// <param name="connectionString">数据库连接字符串</param>
        public void UseDatabase(string provider, string connectionString)
        {
            _properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            _properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz";
            _properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            _properties["quartz.jobStore.dataSource"] = "default";
            _properties["quartz.jobStore.useProperties"] = "true";

            _properties["quartz.dataSource.default.provider"] = provider;
            _properties["quartz.dataSource.default.connectionString"] = connectionString;
        }
    }
}
