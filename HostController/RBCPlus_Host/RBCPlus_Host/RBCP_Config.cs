using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBCPlus_Host
{
    public enum Config
    {
        NAS_NAME,
        NAS_DESCRIPTION,
        NAS_SIZE,
        RAID_TYPE,
        SYNC_FREQUENCY,
        SYNC_STRATEGY,
        LOG_ACCURACY,
        LOG_MAIL_NOTIFY,
        LOG_EMAIL_ADDRESS,
        MAIN_DRIVE,
        ALLOW_DIRECT_ACCESS,
        ADMIN_ACCESS_ONLY,
        ENABLE_BACKUP,
        BACKUP_FREQUENCY,
        BACKUP_FORMAT,
        ENABLE_LOCAL_BACKUP,
        ENABLE_FTP_BACKUP,
        BACKUP_DRIVE,
        FTP_CONFIG,
        ENABLE_CACHING,
        CACHING_DRIVE,
        MAX_CACHABLE_SIZE,
        MAX_CACHABLE_SIZE_UNIT,
        PERMA_CACHE,
        ENABLE_REQUESTING,
        REQUEST_CACHE_DURATION,
        ALLOW_REQUEST_CANCELING,
        ALLOW_REQUEST_EXTENSION,
        MAX_REQUEST_SIZE,
        MAX_REQUEST_SIZE_UNIT,
        ENABLE_WEB_INTERFACE,
        ENABLE_WEB_MANAGEMENT,
        WEB_ADDRESS,
    }

    public class RBCP_Config
    {
        private static List<RBCP_Data> config = new List<RBCP_Data>();

        public static void Set(Config key, object value)
        {
            bool inserted = false;

            for (int i = 0; i < config.Count; i++) 
            {
                if (config[i].Key == key)
                {
                    config[i].Value = value;
                    inserted = true;
                }
            }

            if(!inserted)
            {
                config.Add(new RBCP_Data(key, value));
            }
        }

        public static object Get(Config key)
        {
            foreach(RBCP_Data data in config)
            {
                if (data.Key == key)
                {
                    return data.Value;
                }
            }

            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (RBCP_Data data in config)
            {
                sb.AppendLine(data.ToString());
            }

            return sb.ToString();
        }
    }
}
