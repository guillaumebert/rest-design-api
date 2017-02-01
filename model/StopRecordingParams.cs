using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// StopRecording is the method sent to the Design API Server.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class StopRecordingParams : IComparable<StopRecordingParams>
    {
        private readonly bool frameworkParameterSearch;
        private readonly bool genericParameterSearch;
        private readonly UpdateUserPathParams updateParams;
        private readonly int timeout;

        internal StopRecordingParams(StopRecordingParamsBuilder stopRecordingBuilder)
        {
            this.frameworkParameterSearch = stopRecordingBuilder.FrameworkParameterSearch;
            this.genericParameterSearch = stopRecordingBuilder.GenericParameterSearch;
            this.updateParams = stopRecordingBuilder.UpdateParams;
            this.timeout = stopRecordingBuilder.Timeout;
        }

        public virtual bool FrameworkParameterSearch
        {
            get
            {
                return frameworkParameterSearch;
            }
        }

        public virtual bool GenericParameterSearch
        {
            get
            {
                return genericParameterSearch;
            }
        }

        public virtual UpdateUserPathParams UpdateParams
        {
            get
            {
                return updateParams;
            }
        }

        public virtual int Timeout
        {
            get
            {
                return timeout;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<StopRecordingParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(StopRecordingParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<StopRecordingParams>(this)
                .With(m => m.frameworkParameterSearch)
                .With(m => m.genericParameterSearch)
                .With(m => m.updateParams)
                .With(m => m.timeout)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StopRecordingParams))
            {
                return false;
            }

            return new EqualsBuilder<StopRecordingParams>(this, obj)
                .With(m => m.frameworkParameterSearch)
                .With(m => m.genericParameterSearch)
                .With(m => m.updateParams)
                .With(m => m.timeout)
                .Equals();
        }
    }
}
