using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// The SetContainer is the method sent to the Design API Server to set the current Transaction.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class SetContainerParams : IComparable<SetContainerParams>
    {
        private readonly string name;

        public SetContainerParams(string name)
        {
            if (name == null || name.Equals(""))
            {
                throw new ArgumentException("Name of the Transaction to be created is mandatory.", "Name");
            }
            this.name = name;
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
            return new ToStringBuilder<SetContainerParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(SetContainerParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<SetContainerParams>(this)
                .With(m => m.name)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SetContainerParams))
            {
                return false;
            }

            return new EqualsBuilder<SetContainerParams>(this, obj)
                .With(m => m.name)
                .Equals();
        }
    }
}
