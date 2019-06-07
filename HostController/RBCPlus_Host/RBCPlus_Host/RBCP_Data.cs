using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBCPlus_Host
{
    class RBCP_Data
    {
        private Config key;
        private object value;

        public Config Key
        {
            get => key;
            set => key = value;
        }

        public object Value
        {
            get => this.value;
            set => this.value = value;
        }

        public RBCP_Data(Config _key, object _value)
        {
            Key = _key;
            Value = _value;
        }

        public override string ToString()
        {
            return "Key: " + Key + " - Value: " + Value;
        }
    }
}
