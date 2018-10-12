/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// Builder for object <seealso cref="StartRecordingParams"/>.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class StartRecordingParamsBuilder
    {
        public string VirtualUser { get; set; }
        public BaseContainer RecordInStep { get; set; }
        public bool WebSocketProtocol { get; set; }
        public bool Http2Protocol { get; set; }
        public bool AdobeRTMPProtocol { get; set; }
        public bool SapGuiProtocol { get; set; }
        public string UserAgent { get; set; }
        public string SapSessionId { get; set; }
        public string SapConnectionString { get; set; }

        public StartRecordingParamsBuilder()
        {
            this.VirtualUser = null;
            this.RecordInStep = BaseContainer.Actions;
            this.WebSocketProtocol = true;
            this.Http2Protocol = true;
            this.AdobeRTMPProtocol = false;
            this.SapGuiProtocol = false;
            this.UserAgent = null;
            this.SapSessionId = null;
            this.SapConnectionString = null;
        }

        public StartRecordingParamsBuilder virtualUser(string virtualUser)
        {
            this.VirtualUser = virtualUser;
            return this;
        }

        public StartRecordingParamsBuilder recordInStep(BaseContainer recordInStep)
        {
            this.RecordInStep = recordInStep;
            return this;
        }

        public StartRecordingParamsBuilder isWebSocketProtocol(bool isWebSocketProtocol)
        {
            this.WebSocketProtocol = isWebSocketProtocol;
            return this;
        }

        public StartRecordingParamsBuilder isHTTP2Protocol(bool isHTTP2Protocol)
        {
            this.Http2Protocol = isHTTP2Protocol;
            return this;
        }

        public StartRecordingParamsBuilder isAdobeRTMPProtocol(bool isAdobeRTMPProtocol)
        {
            this.AdobeRTMPProtocol = isAdobeRTMPProtocol;
            return this;
        }

        /// <summary>
        /// Allows to start a SAP GUI recording. Use sapSessionId to attach to an existing SAP session or sapConnectionString to create a new session.
        /// </summary>
        /// <param name="isSapGuiProtocol"></param>
        /// <returns></returns>
        public StartRecordingParamsBuilder isSapGuiProtocol(bool isSapGuiProtocol)
        {
            this.SapGuiProtocol = isSapGuiProtocol;
            return this;
        }


        public StartRecordingParamsBuilder userAgent(string userAgent)
        {
            this.UserAgent = userAgent;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sapSessionId">the name of the SAP session ID to attach.</param>
        /// <returns></returns>
        public StartRecordingParamsBuilder sapSessionId(string sapSessionId)
        {
            this.SapSessionId = sapSessionId;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sapConnectionString">the SAP connection String describing the server to create a new session.</param>
        /// <returns></returns>
        public StartRecordingParamsBuilder sapConnectionString(string sapConnectionString)
        {
            this.SapConnectionString = sapConnectionString;
            return this;
        }

        public StartRecordingParams Build()
        {
            return new StartRecordingParams(this);
        }
    }
}
