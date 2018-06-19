using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2018, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
   /// <summary>
   /// 
   /// </summary>
    public class StartRecordingInfo : IComparable<StartRecordingInfo>
    {
        private readonly String sapSessionId;

        public StartRecordingInfo() : this(null)
        {

        }

        public StartRecordingInfo(String sapSessionId)
        {
            this.sapSessionId = sapSessionId;
        }

        public virtual String SapSessionId
        {
            get
            {
                return sapSessionId;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<StartRecordingInfo>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(StartRecordingInfo o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<StartRecordingInfo>(this)
                .With(m => m.sapSessionId)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StartRecordingInfo))
            {
                return false;
            }

            return new EqualsBuilder<StartRecordingInfo>(this, obj)
                .With(m => m.sapSessionId)
                .Equals();
        }
    }
}
