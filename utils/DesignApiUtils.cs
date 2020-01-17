using Neotys.CommonAPI.Error;
using Neotys.DesignAPI.Model;
using System;
using System.Collections.Generic;

namespace Neotys.DesignAPI.Utils
{
    public class DesignApiUtils
    {

        public const string API_KEY = "ApiKey";

        // StartRecording
        public const string START_RECORDING = "StartRecording";
        public const string VIRTUAL_USER = "VirtualUser";
        public const string BASE_CONTAINER = "BaseContainer";
        public const string PROTOCOL_WEBSOCKET = "ProtocolWebSocket";
        public const string PROTOCOL_HTTP2 = "ProtocolHTTP2";
        public const string PROTOCOL_ADOBE_RTMP = "ProtocolAdobeRTMP";
        public const string USER_AGENT = "UserAgent";
        public const string PROTOCOL_SAP_GUI = "ProtocolSAPGUI";
        public const string SAP_SESSION_ID = "SAPSessionID";
        public const string SAP_CONNECTION_STRING = "SAPConnectionString";
        public const string CREATE_TRANSACTION_BY_SAP_TCODE = "CreateTransactionBySapTCode";

        // StopRecording
        public const string STOP_RECORDING = "StopRecording";
        public const string FRAMEWORK_PARAMETER_SEARCH = "FrameworkParameterSearch";
        public const string GENERIC_PARAMETER_SEARCH = "GenericParameterSearch";
        public const string TIMEOUT = "Timeout";

        // UserPathUpdate
        public const string USER_PATH_UPDATE = "UpdateUserPath";
        public const string MATCHING_THRESHOLD = "MatchingThreshold";
        public const string UPDATE_SHARED_CONTAINERS = "UpdateSharedContainers";
        public const string INCLUDE_VARIABLES = "IncludeVariables";
        public const string DELETE_RECORDING = "DeleteRecording";
        public const string NAME = "Name";

        // SetContainer
        public const string SET_CONTAINER = "SetContainer";
        public const string CONTAINER_NAME = "Name";

        // SetScreenshot
        public const string SET_SCREENSHOT = "SetScreenshot";
        public const string SCREENSHOT_BYTES = "Image";

        // PauseRecording
        public const string PAUSE_RECORDING = "PauseRecording";

        // ResumeRecording
        public const string RESUME_RECORDING = "ResumeRecording";

        // SetBaseContainer
        public const string SET_BASE_CONTAINER = "SetBaseContainer";
        public const string BASE_CONTAINER_NAME = "Name";

        // GetRecorderSettings
        public const string GET_RECORDER_SETTINGS = "GetRecorderSettings";
        public const string PROXY_SETTINGS = "ProxySettings";
        public const string PORT = "Port";

        // GetRecordingStatus
        public const string GET_RECORDING_STATUS = "GetRecordingStatus";

        // GetStatus
        public const string GET_STATUS = "GetStatus";
        public const string STATUS = "Status";

        // ContainsUserPath
        public const string CONTAINS_USER_PATH = "ContainsUserPath";
        public const string CONTAINS = "Contains";

        // IsProjectOpen
        public const string IS_PROJECT_OPEN = "IsProjectOpen";
        public const string OPEN = "Open";
        public const string FILE_PATH = "FilePath";

        // OpenProject
        public const string OPEN_PROJECT = "OpenProject";

        // CreateProject
        public const string CREATE_PROJECT = "CreateProject";

        // Save Project
        public const string SAVE_PROJECT = "SaveProject";

        // SaveAs Project
        public const string SAVE_AS_PROJECT = "SaveAsProject";
        public const string DIRECTORY_PATH = "DirectoryPath";
        public const string OVERWRITE = "Overwrite";
        public const string SAVE = "Save";
        public const string FORCE_STOP = "ForceStop";

        // Close Project
        public const string CLOSE_PROJECT = "CloseProject";

        // Exit NeoLoad
        public const string EXIT = "Exit";

        public static IDictionary<string, object> getStartRecordingProperties(StartRecordingParams startRecordingParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[VIRTUAL_USER] = startRecordingParams.VirtualUser;
            properties[BASE_CONTAINER] = startRecordingParams.RecordInStep;
            properties[PROTOCOL_WEBSOCKET] = startRecordingParams.WebSocketProtocol;
            properties[PROTOCOL_HTTP2] = startRecordingParams.Http2Protocol;
            properties[PROTOCOL_ADOBE_RTMP] = startRecordingParams.AdobeRTMPProtocol;
            properties[USER_AGENT] = startRecordingParams.UserAgent;
            // do not set SapGuiProtocol in properties, this allows to be compatiable with old NeoLoad.
            if (startRecordingParams.SapGuiProtocol)
            {
                properties[PROTOCOL_SAP_GUI] = startRecordingParams.SapGuiProtocol;
                properties[SAP_CONNECTION_STRING] = startRecordingParams.SapConnectionString;
                properties[SAP_SESSION_ID] = startRecordingParams.SapSessionId;
                // FIXME handle retro compatibility with old neoload
                properties[CREATE_TRANSACTION_BY_SAP_TCODE] = startRecordingParams.CreateTransactionBySapTCode;
            }
            return properties;
        }

        public static IDictionary<string, object> getStopRecordingProperties(StopRecordingParams stopRecordingParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[FRAMEWORK_PARAMETER_SEARCH] = stopRecordingParams.FrameworkParameterSearch;
            properties[GENERIC_PARAMETER_SEARCH] = stopRecordingParams.GenericParameterSearch;

            if (stopRecordingParams.UpdateParams != null)
            {
                IDictionary<string, object> updateProperties = getUserPathUpdateProperties(stopRecordingParams.UpdateParams);
                foreach (KeyValuePair<string, object> pair in updateProperties)
                {
                    properties[pair.Key] = pair.Value;
                }
            }
            return properties;
        }

        public static IDictionary<string, object> getUserPathUpdateProperties(UpdateUserPathParams updateParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[MATCHING_THRESHOLD] = updateParams.MatchingThreshold;
            properties[UPDATE_SHARED_CONTAINERS] = updateParams.UpdateSharedContainers;
            properties[INCLUDE_VARIABLES] = updateParams.IncludeVariables;
            properties[DELETE_RECORDING] = updateParams.DeleteRecording;
            properties[NAME] = updateParams.Name;
            return properties;
        }

        public static IDictionary<string, object> getSetContainerProperties(SetContainerParams setContainer)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[CONTAINER_NAME] = setContainer.Name;
            return properties;
        }

        public static IDictionary<string, object> getSetScreenshotProperties(SetScreenshotParams setScreenshot)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[SCREENSHOT_BYTES] = setScreenshot.Screenshot;
            return properties;
        }

        public static IDictionary<string, object> getSetBaseContainerProperties(SetBaseContainerParams setRecordInStep)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[BASE_CONTAINER_NAME] = setRecordInStep.BaseContainer.ToString();
            return properties;
        }

        public static RecorderSettings getGetRecorderSettings(IDictionary<string, object> properties)
        {
            Object objectProxySettings = properties[PROXY_SETTINGS];
            if (!(objectProxySettings is IDictionary<string, object>))
            {
                throw new NeotysAPIException(NeotysAPIException.ErrorType.NL_DESIGN_CANNOT_GET_RECORDER_SETTINGS);
            }
            ProxySettings proxySettings = getProxySettings(objectProxySettings as IDictionary<string, object>);
            return new RecorderSettings(proxySettings);
        }

        public static ProxySettings getProxySettings(IDictionary<string, object> properties)
        {
            Object portObject = properties[PORT];
            if (portObject == null)
            {
                throw new NeotysAPIException(NeotysAPIException.ErrorType.NL_DESIGN_CANNOT_GET_RECORDER_SETTINGS);
            }
            int port = Int32.Parse(portObject.ToString());
            return new ProxySettings(port);
        }

        public static RecordingStatus getRecordingStatus(IDictionary<string, object> properties)
        {
            object objectStatus = properties[STATUS];
            if (objectStatus == null)
            {
                throw new NeotysAPIException(NeotysAPIException.ErrorType.NL_DESIGN_CANNOT_GET_RECORDING_STATUS);
            }
            return (RecordingStatus)Enum.Parse(typeof(RecordingStatus), objectStatus.ToString(), true);
        }

        public static Status getStatus(IDictionary<string, object> properties)
        {
            object objectStatus = properties[STATUS];
            if (objectStatus == null)
            {
                throw new NeotysAPIException(NeotysAPIException.ErrorType.NL_DESIGN_CANNOT_GET_STATUS);
            }
            return (Status)Enum.Parse(typeof(Status), objectStatus.ToString(), true);
        }

        public static IDictionary<string, object> getContainsUserPathProperties(ContainsUserPathParams containsUserPathParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[NAME] = containsUserPathParams.Name;
            return properties;
        }

        public static bool getContains(IDictionary<string, object> properties)
        {
            object exist = properties[CONTAINS];
            if (exist == null)
            {
                throw new NeotysAPIException(NeotysAPIException.ErrorType.NL_DESIGN_CANNOT_GET_CONTAINS_USER_PATH);
            }
            return Boolean.Parse(exist.ToString());
        }

        public static IDictionary<string, object> getIsProjectOpenProperties(IsProjectOpenParams isProjectOpenParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[FILE_PATH] = isProjectOpenParams.FilePath;
            return properties;
        }

        public static bool getOpen(IDictionary<string, object> properties)
        {
            object open = properties[OPEN];
            if (open == null)
            {
                throw new NeotysAPIException(NeotysAPIException.ErrorType.NL_DESIGN_CANNOT_GET_IS_PROJECT_OPEN);
            }
            return Boolean.Parse(open.ToString());
        }

        public static IDictionary<string, object> getOpenProjectProperties(OpenProjectParams openProjectParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[FILE_PATH] = openProjectParams.FilePath;
            return properties;
        }

        public static IDictionary<string, object> getCreateProjectProperties(CreateProjectParams createProjectParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[DIRECTORY_PATH] = createProjectParams.DirectoryPath;
            properties[NAME] = createProjectParams.Name;
            properties[OVERWRITE] = createProjectParams.Overwrite;
            return properties;
        }

        public static IDictionary<string, object> getSaveAsProjectProperties(SaveAsProjectParams saveAsParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[DIRECTORY_PATH] = saveAsParams.DirectoryPath;
            properties[NAME] = saveAsParams.Name;
            properties[OVERWRITE] = saveAsParams.Overwrite;
            properties[FORCE_STOP] = saveAsParams.ForceStop;
            return properties;
        }

        public static IDictionary<string, object> getCloseProjectProperties(CloseProjectParams closeProjectParams)
        {
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[FORCE_STOP] = closeProjectParams.ForceStop;
            properties[SAVE] = closeProjectParams.Save;
            return properties;
        }

        public static StartRecordingInfo getStartRecordingInfo(IDictionary<string, object> properties)
        {
            Object objectSapSessionId = properties.ContainsKey(SAP_SESSION_ID) ? properties[SAP_SESSION_ID] : null;
            if (!(objectSapSessionId is String))
            {
                return new StartRecordingInfo();
            }
            return new StartRecordingInfo(objectSapSessionId as String);
        }

    }
}
