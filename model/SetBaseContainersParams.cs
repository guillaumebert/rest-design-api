using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// The SetRecordInStep is the method sent to the Design API Server to set the record in step (Init, Actions, End).
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class SetBaseContainerParams : IComparable<SetBaseContainerParams>
    {
        private readonly BaseContainer baseContainer;

        public SetBaseContainerParams(BaseContainer baseContainer)
        {
            if (baseContainer == null)
            {
                throw new ArgumentException("Base container is mandatory.", "baseContainer");
            }
            this.baseContainer = baseContainer;
        }

        public virtual BaseContainer BaseContainer
        {
            get
            {
                return baseContainer;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<SetBaseContainerParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(SetBaseContainerParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<SetBaseContainerParams>(this)
                .With(m => m.baseContainer)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SetBaseContainerParams))
            {
                return false;
            }

            return new EqualsBuilder<SetBaseContainerParams>(this, obj)
                .With(m => m.baseContainer)
                .Equals();
        }
    }
}
