namespace Neotys.DesignAPI.Model
{
    public enum Status
    {
        /// <summary>
        /// NeoLoad is starting up. </summary>
        NEOLOAD_INITIALIZING,
        /// <summary>
        /// No project is opened. </summary>
        NO_PROJECT,
        /// <summary>
        /// The project is getting opened. </summary>
        PROJECT_INITIALIZING,
        /// <summary>
        /// Project is opened, NeoLoad is ready to start a test. </summary>
        READY,
        /// <summary>
        /// NeoLoad is busy, a test can't be started. </summary>
        BUSY,
        /// <summary>
        /// The test is getting started. </summary>
        TEST_LOADING,
        /// <summary>
        /// The test is running. </summary>
        TEST_RUNNING,
        /// <summary>
        /// The test is getting stopped. </summary>
        TEST_STOPPING
    }
}
