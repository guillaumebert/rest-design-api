using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    ///  Allows to launch a User Path Update at the end of the post recording.
    ///  The name of the User Path to update is mandatory.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class UpdateUserPathParams : IComparable<UpdateUserPathParams>
    {
        private readonly int? matchingThreshold;
        private readonly bool? updateSharedContainers;
        private readonly bool? includeVariables;
        private readonly bool? deleteRecording;
        private readonly string name;
        

        internal UpdateUserPathParams(UpdateUserPathParamsBuilder updateUserPathBuilder)
        {
            this.matchingThreshold = updateUserPathBuilder.MatchingThreshold;
            this.updateSharedContainers = updateUserPathBuilder.UpdateSharedContainers;
            this.includeVariables = updateUserPathBuilder.IncludeVariables;
            this.deleteRecording = updateUserPathBuilder.DeleteRecording;
            this.name = updateUserPathBuilder.Name;
        }

        public virtual int? MatchingThreshold
        {
            get
            {
                return matchingThreshold;
            }
        }

        public virtual bool? UpdateSharedContainers
        {
            get
            {
                return updateSharedContainers;
            }
        }

        public virtual bool? IncludeVariables
        {
            get
            {
                return includeVariables;
            }
        }

        public virtual bool? DeleteRecording
        {
            get
            {
                return deleteRecording;
            }
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
            return new ToStringBuilder<UpdateUserPathParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(UpdateUserPathParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<UpdateUserPathParams>(this)
                .With(m => m.matchingThreshold)
                .With(m => m.updateSharedContainers)
                .With(m => m.includeVariables)
                .With(m => m.deleteRecording)
                .With(m => m.name)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UpdateUserPathParams))
            {
                return false;
            }

            return new EqualsBuilder<UpdateUserPathParams>(this, obj)
                .With(m => m.matchingThreshold)
                .With(m => m.updateSharedContainers)
                .With(m => m.includeVariables)
                .With(m => m.deleteRecording)
                .With(m => m.name)
                .Equals();
        }
    }
}
