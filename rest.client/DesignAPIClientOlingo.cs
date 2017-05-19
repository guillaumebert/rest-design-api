using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Simple.OData.Client;

/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */
namespace Neotys.DesignAPI.Client
{
    using Model;
    using CommonAPI.Client;
    using Utils;
    using NeotysAPIException = CommonAPI.Error.NeotysAPIException;

    /// <summary>
    /// An implementation of a Design API Client, based on Apache Olingo framework.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    internal sealed class DesignAPIClientOlingo : NeotysAPIClientOlingo, IDesignAPIClient
    {

        private readonly string apiKey;

        /// <summary>
        /// Create a new Design API client, connected to the server at the end point 'url' and authenticating with 'apiKey'. </summary>
        /// <param name="url"> </param>
        /// <param name="apiKey"> </param>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        internal DesignAPIClientOlingo(string url, string apiKey) : base(url)
        {
            if (Enabled)
            {
				this.apiKey = apiKey != null ? apiKey : "";
            }
            else
            {
                this.apiKey = "";
            }
        }

        /// <summary>
        /// Start a recording. </summary>
        /// <param name="startRecordingParams"> </param>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public void StartRecording(StartRecordingParams startRecordingParams)
        {
            if (!Enabled)
            {
                return;
            }
            IDictionary<string, object> properties = DesignApiUtils.getStartRecordingProperties(startRecordingParams);
			properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                CreateEntity(DesignApiUtils.START_RECORDING, properties);
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Stop a recording. </summary>
        /// <param name="stopRecordingParams"> </param>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public void StopRecording(StopRecordingParams stopRecordingParams)
        {
            if (!Enabled)
            {
                return;
            }
            IDictionary<string, object> properties = DesignApiUtils.getStopRecordingProperties(stopRecordingParams);
            properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                CreateEntity(DesignApiUtils.STOP_RECORDING, properties);
				Task t = Task.Factory.StartNew (() => WaitUntilServerIsReady());
				//Wait untill timeout, if timeout expires Wait() returns false.
				if(!t.Wait(stopRecordingParams.Timeout * 1000))
				{
					throw new NeotysAPIException(NeotysAPIException.ErrorType.NL_DESIGN_ILLEGAL_STATE_FOR_OPERATION, "The timeout of " + stopRecordingParams.Timeout + " second(s) has been reached.");
				}
            }
			//Task has been interrupted by another reason than timeout, throw error with real cause.
			catch (System.AggregateException aggregateException) {
				throw new NeotysAPIException(aggregateException.InnerException);
			}
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

		internal void WaitUntilServerIsReady()
		{
			while (GetStatus () != Status.READY) {
				Thread.Sleep(1000);
			}
		}

        /// <summary>
        /// Set the name of the current Transaction. </summary>
        /// <param name="setContainer"> </param>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public void SetContainer(SetContainerParams setContainer)
        {
            if (!Enabled)
            {
                return;
            }
            IDictionary<string, object> properties = DesignApiUtils.getSetContainerProperties(setContainer);
            properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                CreateEntity(DesignApiUtils.SET_CONTAINER, properties);
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Set the current screenshot. </summary>
        /// <param name="setScreenshot"> </param>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public void SetScreenshot(SetScreenshotParams setScreenshot)
        {
            if (!Enabled)
            {
                return;
            }
            IDictionary<string, object> properties = DesignApiUtils.getSetScreenshotProperties(setScreenshot);
            properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                CreateEntity(DesignApiUtils.SET_SCREENSHOT, properties);
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Set the base container. </summary>
        /// <param name="setBaseContainer"> </param>
        /// <exception cref="ODataException"> </exception>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public void SetBaseContainer(SetBaseContainerParams setBaseContainer)
        {
            if (!Enabled)
            {
                return;
            }
            IDictionary<string, object> properties = DesignApiUtils.getSetBaseContainerProperties(setBaseContainer);
            properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                CreateEntity(DesignApiUtils.SET_BASE_CONTAINER, properties);
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Get the recorder settings. </summary>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public RecorderSettings GetRecorderSettings()
        {
            if (!Enabled)
            {
                return new RecorderSettings();
            }
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                ODataEntry entity = ReadEntity(DesignApiUtils.GET_RECORDER_SETTINGS, properties);
                return DesignApiUtils.getGetRecorderSettings(entity.AsDictionary());
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Get the recording status. </summary>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public RecordingStatus GetRecordingStatus()
        {
            if (!Enabled)
            {
                return RecordingStatus.READY;
            }
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                ODataEntry entity = ReadEntity(DesignApiUtils.GET_RECORDING_STATUS, properties);
                return DesignApiUtils.getRecordingStatus(entity.AsDictionary());
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Get the status of NeoLoad. </summary>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public Status GetStatus()
		{
			if (!Enabled)
			{
				return Status.BUSY;
			}
			IDictionary<string, object> properties = new Dictionary<string, object>();
			properties[DesignApiUtils.API_KEY] = apiKey;
			try
			{
				ODataEntry entity = ReadEntity(DesignApiUtils.GET_STATUS, properties);
				return DesignApiUtils.getStatus(entity.AsDictionary());
			}
			catch (Microsoft.OData.Core.ODataException oDataException)
			{
				throw new NeotysAPIException(oDataException);
			}
		}

		/// <summary>
		/// Returns true if User Path exist. </summary>
		/// <param name="containsUserPathParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public bool ContainsUserPath(ContainsUserPathParams containsUserPathParams)
		{
			if (!Enabled)
			{
				return false;
			}
			IDictionary<string, object> properties = DesignApiUtils.getContainsUserPathProperties (containsUserPathParams);
			properties[DesignApiUtils.API_KEY] = apiKey;
			try
			{
				ODataEntry entity = ReadEntity(DesignApiUtils.CONTAINS_USER_PATH, properties);
				return DesignApiUtils.getContains(entity.AsDictionary());
			}
			catch (Microsoft.OData.Core.ODataException oDataException)
			{
				throw new NeotysAPIException(oDataException);
			}
		}

		/// <summary>
		/// Returns true if project is open. </summary>
		/// <param name="isProjectOpenParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public bool IsProjectOpen(IsProjectOpenParams isProjectOpenParams)
		{
			if (!Enabled)
			{
				return false;
			}
			IDictionary<string, object> properties = DesignApiUtils.getIsProjectOpenProperties(isProjectOpenParams);
			properties[DesignApiUtils.API_KEY] = apiKey;
			try 
			{
				ODataEntry entity = ReadEntity(DesignApiUtils.IS_PROJECT_OPEN, properties);
				return DesignApiUtils.getOpen(entity.AsDictionary());
			}
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}


		/// <summary>
		/// Open a project. </summary>
		/// <param name="openProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public void OpenProject(OpenProjectParams openProjectParams)
		{
			if(!Enabled)
			{
				return;
			}
			IDictionary<string, object> properties = DesignApiUtils.getOpenProjectProperties(openProjectParams);
			properties[DesignApiUtils.API_KEY] = apiKey;
			try 
			{
				CreateEntity(DesignApiUtils.OPEN_PROJECT, properties);
			}
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}

		/// <summary>
		/// Create a NeoLoad project. </summary>
		/// <param name="createProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public void CreateProject(CreateProjectParams createProjectParams)
		{
			if(!Enabled)
			{
				return;
			}
			IDictionary<string, object> properties = DesignApiUtils.getCreateProjectProperties(createProjectParams);
			properties[DesignApiUtils.API_KEY] = apiKey;
			try 
			{
				CreateEntity(DesignApiUtils.CREATE_PROJECT, properties);
			}
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}

		/// <summary>
		/// Save the project. </summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public void SaveProject()
		{
			if(!Enabled)
			{
				return;
			}
			IDictionary<string, object> properties = new Dictionary<string, object>();
			properties[DesignApiUtils.API_KEY] = apiKey;
			try
			{
				CreateEntity(DesignApiUtils.SAVE_PROJECT, properties);
			}
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}

		/// <summary>
		/// Save As the project. </summary>
		/// <param name="saveAsProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public void SaveAsProject(SaveAsProjectParams saveAsProjectParams)
		{
			if(!Enabled)
			{
				return;
			}
			IDictionary<string, object> properties = DesignApiUtils.getSaveAsProjectProperties(saveAsProjectParams);
			properties[DesignApiUtils.API_KEY] = apiKey;
			try
			{
				CreateEntity(DesignApiUtils.SAVE_AS_PROJECT, properties);
			}
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}

		/// <summary>
		/// Close the project. </summary>
		/// <param name="closeProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public void CloseProject(CloseProjectParams closeProjectParams)
		{
			if(!Enabled)
			{
				return;
			}
			IDictionary<string, object> properties = DesignApiUtils.getCloseProjectProperties(closeProjectParams);
			properties[DesignApiUtils.API_KEY] = apiKey;
			try
			{
				CreateEntity(DesignApiUtils.CLOSE_PROJECT, properties);
			}
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}

        /// <summary>
		/// Close NeoLoad.</summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public void Exit()
        {
            if (!Enabled)
            {
                return;
            }
            IDictionary<string, object> properties = new Dictionary<string, object>();
            properties[DesignApiUtils.API_KEY] = apiKey;
            try
            {
                CreateEntity(DesignApiUtils.EXIT, properties);
            }
            catch (Microsoft.OData.Core.ODataException oDataException)
            {
                throw new NeotysAPIException(oDataException);
            }
        }

        /// <summary>
        /// Pause the recording. </summary>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        public void PauseRecording()
		{
			if(!Enabled)
			{
				return;
			}
			IDictionary<string, object> properties = new Dictionary<string, object>();
			properties[DesignApiUtils.API_KEY] = apiKey;
			try
			{
				CreateEntity(DesignApiUtils.PAUSE_RECORDING, properties);
			}			
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}

		/// <summary>
		/// Resume the recording. </summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		public void ResumeRecording()
		{
			if(!Enabled)
			{
				return;
			}
			IDictionary<string, object> properties = new Dictionary<string, object>();
			properties[DesignApiUtils.API_KEY] = apiKey;
			try
			{
				CreateEntity(DesignApiUtils.RESUME_RECORDING, properties);
			}
			catch (Microsoft.OData.Core.ODataException oDataException) 
			{
				throw new NeotysAPIException(oDataException);
			}
		}

    }
}
