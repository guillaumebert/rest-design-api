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
	public class ContainsUserPathParams : IComparable<ContainsUserPathParams>
    {
        private readonly string name;

		internal ContainsUserPathParams(ContainsUserPathParamsBuilder containsUserPathParamsBuilder)
        {
			this.name = containsUserPathParamsBuilder.Name;
        }

        public virtual string Name
        {
            get
            {
                return name;
            }
        }

        public override string ToString()
        {
			return new ToStringBuilder<ContainsUserPathParams>(this).ReflectionToString(this);
        }

		public virtual int CompareTo(ContainsUserPathParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
			return new HashCodeBuilder<ContainsUserPathParams>(this)
                .With(m => m.name)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
			if (!(obj is ContainsUserPathParams))
            {
                return false;
            }

			return new EqualsBuilder<ContainsUserPathParams>(this, obj)
				.With(m => m.name)
                .Equals();
        }
    }
}
