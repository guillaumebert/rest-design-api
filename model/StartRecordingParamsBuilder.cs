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
        public string UserAgent { get; set; }

        public StartRecordingParamsBuilder()
        {
            this.VirtualUser = null;
            this.RecordInStep = BaseContainer.Actions;
            this.WebSocketProtocol = true;
            this.Http2Protocol = true;
            this.AdobeRTMPProtocol = false;
            this.UserAgent = "";
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

        public StartRecordingParamsBuilder userAgent(string userAgent)
        {
            this.UserAgent = userAgent;
            return this;
        }

        public StartRecordingParams Build()
        {
            return new StartRecordingParams(this);
        }
    }
}
