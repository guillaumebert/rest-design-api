using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// OpenProject is the method sent to the Design API Server.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class OpenProjectParams : IComparable<OpenProjectParams>
    {
        private readonly string filePath;

		internal OpenProjectParams(OpenProjectParamsBuilder openProjectParamsBuilder)
        {
			this.filePath = openProjectParamsBuilder.FilePath;
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
			return new ToStringBuilder<OpenProjectParams>(this).ReflectionToString(this);
        }

		public virtual int CompareTo(OpenProjectParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
			return new HashCodeBuilder<OpenProjectParams>(this)
				.With(m => m.filePath)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
			if (!(obj is OpenProjectParams))
            {
                return false;
            }

			return new EqualsBuilder<OpenProjectParams>(this, obj)
				.With(m => m.filePath)
                .Equals();
        }
    }
}
