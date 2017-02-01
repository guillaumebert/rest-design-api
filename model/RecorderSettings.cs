using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// Settings of the Recorder.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class RecorderSettings : IComparable<RecorderSettings>
    {
        private readonly ProxySettings proxySettings;

        public RecorderSettings() : this(new ProxySettings())
        {

        }

        public RecorderSettings(ProxySettings proxySettings)
        {
            this.proxySettings = proxySettings;
        }

        public virtual ProxySettings ProxySettings
        {
            get
            {
                return proxySettings;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<RecorderSettings>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(RecorderSettings o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<RecorderSettings>(this)
                .With(m => m.proxySettings)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RecorderSettings))
            {
                return false;
            }

            return new EqualsBuilder<RecorderSettings>(this, obj)
                .With(m => m.proxySettings)
                .Equals();
        }
    }
}
