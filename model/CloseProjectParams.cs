using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// CloseProject is the method sent to the Design API Server.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class CloseProjectParams : IComparable<CloseProjectParams>
    {
        private readonly bool forceStop;
		private readonly bool save;

		internal CloseProjectParams(CloseProjectParamsBuilder closeProjectParamsBuilder)
        {
			this.forceStop = closeProjectParamsBuilder.ForceStop;
			this.save = closeProjectParamsBuilder.Save;
        }

		public virtual bool ForceStop
        {
            get
            {
				return forceStop;
            }
        }

		public virtual bool Save
		{
			get
			{
				return save;
			}
		}

        public override string ToString()
        {
			return new ToStringBuilder<CloseProjectParams>(this).ReflectionToString(this);
        }

		public virtual int CompareTo(CloseProjectParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
			return new HashCodeBuilder<CloseProjectParams>(this)
				.With(m => m.forceStop)
				.With(m => m.save)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
			if (!(obj is CloseProjectParams))
            {
                return false;
            }

			return new EqualsBuilder<CloseProjectParams>(this, obj)
				.With(m => m.forceStop)
				.With(m => m.save)
                .Equals();
        }
    }
}
