using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// StartRecording is the method sent to the Design API Server.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class StartRecordingParams : IComparable<StartRecordingParams>
    {
        private readonly string virtualUser;
        private readonly BaseContainer recordInStep;
        private readonly bool webSocketProtocol;
        private readonly bool http2Protocol;
        private readonly bool adobeRTMPProtocol;
        private readonly bool sapGuiProtocol;
        private readonly string userAgent;
        private readonly string sapSessionId;
        private readonly string sapConnectionString;
        private readonly bool? createTransactionBySapTCode;

        internal StartRecordingParams(StartRecordingParamsBuilder startRecordingBuilder)
        {
            this.virtualUser = startRecordingBuilder.VirtualUser;
            this.recordInStep = startRecordingBuilder.RecordInStep;
            this.webSocketProtocol = startRecordingBuilder.WebSocketProtocol;
            this.http2Protocol = startRecordingBuilder.Http2Protocol;
            this.adobeRTMPProtocol = startRecordingBuilder.AdobeRTMPProtocol;
            this.sapGuiProtocol = startRecordingBuilder.SapGuiProtocol;
            this.userAgent = startRecordingBuilder.UserAgent;
            this.sapSessionId = startRecordingBuilder.SapSessionId;
            this.sapConnectionString = startRecordingBuilder.SapConnectionString;
            this.createTransactionBySapTCode = startRecordingBuilder.CreateTransactionBySapTCode;
        }

        public virtual string VirtualUser
        {
            get
            {
                return virtualUser;
            }
        }

        public virtual BaseContainer RecordInStep
        {
            get
            {
                return recordInStep;
            }
        }

        public virtual bool WebSocketProtocol
        {
            get
            {
                return webSocketProtocol;
            }
        }

        public virtual bool Http2Protocol
        {
            get
            {
                return http2Protocol;
            }
        }

        public virtual bool AdobeRTMPProtocol
        {
            get
            {
                return adobeRTMPProtocol;
            }
        }

        public virtual bool SapGuiProtocol
        {
            get
            {
                return sapGuiProtocol;
            }
        }

        public virtual string UserAgent
        {
            get
            {
                return userAgent;
            }
        }

        public virtual string SapSessionId
        {
            get
            {
                return sapSessionId;
            }
        }

        public virtual string SapConnectionString
        {
            get
            {
                return sapConnectionString;
            }
        }

        public virtual bool? CreateTransactionBySapTCode
        {
            get
            {
                return createTransactionBySapTCode;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<StartRecordingParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(StartRecordingParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<StartRecordingParams>(this)
                .With(m => m.virtualUser)
                .With(m => m.recordInStep)
                .With(m => m.http2Protocol)
                .With(m => m.webSocketProtocol)
                .With(m => m.adobeRTMPProtocol)
                .With(m => m.sapGuiProtocol)
                .With(m => m.userAgent)
                .With(m => m.sapSessionId)
                .With(m => m.sapConnectionString)
                .With(m => m.createTransactionBySapTCode)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StartRecordingParams))
            {
                return false;
            }

            return new EqualsBuilder<StartRecordingParams>(this, obj)
                .With(m => m.virtualUser)
                .With(m => m.recordInStep)
                .With(m => m.http2Protocol)
                .With(m => m.webSocketProtocol)
                .With(m => m.adobeRTMPProtocol)
                .With(m => m.sapGuiProtocol)
                .With(m => m.userAgent)
                .With(m => m.sapSessionId)
                .With(m => m.sapConnectionString)
                .With(m => m.createTransactionBySapTCode)
                .Equals();
        }
    }
}
