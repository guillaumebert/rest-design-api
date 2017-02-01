using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// ContainsUserPath is the method sent to the Design API Server.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class IsProjectOpenParams : IComparable<IsProjectOpenParams>
    {
        private readonly string filePath;

		internal IsProjectOpenParams(IsProjectOpenParamsBuilder isProjectOpenParamsBuilder)
        {
			this.filePath = isProjectOpenParamsBuilder.FilePath;
        }

		public virtual string FilePath
        {
            get
            {
				return filePath;
            }
        }

        public override string ToString()
        {
			return new ToStringBuilder<IsProjectOpenParams>(this).ReflectionToString(this);
        }

		public virtual int CompareTo(IsProjectOpenParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
			return new HashCodeBuilder<IsProjectOpenParams>(this)
				.With(m => m.filePath)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
			if (!(obj is IsProjectOpenParams))
            {
                return false;
            }

			return new EqualsBuilder<IsProjectOpenParams>(this, obj)
				.With(m => m.filePath)
                .Equals();
        }
    }
}
