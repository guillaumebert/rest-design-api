using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// Settings of the Proxy.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class ProxySettings : IComparable<ProxySettings>
    {
        private readonly int port;

        public ProxySettings() : this(0)
        {

        }

        public ProxySettings(int port)
        {
            this.port = port;
        }

        public virtual int Port
        {
            get
            {
                return port;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<ProxySettings>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(ProxySettings o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<ProxySettings>(this)
                .With(m => m.port)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProxySettings))
            {
                return false;
            }

            return new EqualsBuilder<ProxySettings>(this, obj)
                .With(m => m.port)
                .Equals();
        }
    }
}
