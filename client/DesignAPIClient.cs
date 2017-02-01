/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */
namespace Neotys.DesignAPI.Client
{
    using Model;

    /// <summary>
    /// Neotys Design API Client interface.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public interface IDesignAPIClient
    {
        /// <summary>
        /// Start a recording. </summary>
        /// <param name="startRecordingParams"> </param>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        void StartRecording(StartRecordingParams startRecordingParams);

        /// <summary>
        /// Stop a recording. </summary>
        /// <param name="stopRecordingParams"> </param>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        void StopRecording(StopRecordingParams stopRecordingParams);

        /// <summary>
        /// Set the name of the current Transaction. </summary>
        /// <param name="setContainer"> </param>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        void SetContainer(SetContainerParams setContainer);

        /// <summary>
        /// Set the current screenshot. </summary>
        /// <param name="setScreenshot"> </param>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        void SetScreenshot(SetScreenshotParams setScreenshot);

        /// <summary>
        /// Set the base container. </summary>
        /// <param name="setRecordInStep"> </param>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        void SetBaseContainer(SetBaseContainerParams setRecordInStep);

        /// <summary>
        /// Get the recorder settings. </summary>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        RecorderSettings GetRecorderSettings();

        /// <summary>
        /// Get the recording status. </summary>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        RecordingStatus GetRecordingStatus();

        /// <summary>
        /// Get the status of NeoLoad. </summary>
        /// <exception cref="GeneralSecurityException"> </exception>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>
        /// <exception cref="NeotysAPIException"> </exception>
        Status GetStatus();

		/// <summary>
		/// Returns true if User Path exist. </summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		bool ContainsUserPath(ContainsUserPathParams containsUserPathParams);

		/// <summary>
		/// Returns true if project is open. </summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		bool IsProjectOpen(IsProjectOpenParams isProjectOpenParams);

		/// <summary>
		/// Open a project. </summary>
		/// <param name="openProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		void OpenProject(OpenProjectParams openProjectParams);


		/// <summary>
		/// Create a NeoLoad project. </summary>
		/// <param name="createProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		void CreateProject(CreateProjectParams createProjectParams);

		/// <summary>
		/// Save the project. </summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		void SaveProject();

		/// <summary>
		/// Save As the project. </summary>
		/// <param name="saveAsProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		void SaveAsProject(SaveAsProjectParams saveAsProjectParams);

		/// <summary>
		/// Close the project. </summary>
		/// <param name="closeProjectParams"> </param>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		void CloseProject(CloseProjectParams closeProjectParams);

		/// <summary>
		/// Pause the recording. </summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		void PauseRecording();

		/// <summary>
		/// Resume the recording. </summary>
		/// <exception cref="GeneralSecurityException"> </exception>
		/// <exception cref="IOException"> </exception>
		/// <exception cref="URISyntaxException"> </exception>
		/// <exception cref="NeotysAPIException"> </exception>
		void ResumeRecording();

    }
}
