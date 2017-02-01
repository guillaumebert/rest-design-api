/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// Builder for object <seealso cref="StopRecordingParams"/>.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class StopRecordingParamsBuilder
    {
        public bool FrameworkParameterSearch { get; set; }
        public bool GenericParameterSearch { get; set; }
        public UpdateUserPathParams UpdateParams { get; set; }
        public int Timeout { get; set; }

        public StopRecordingParamsBuilder()
        {
            this.FrameworkParameterSearch = false;
            this.GenericParameterSearch = false;
            this.UpdateParams = null;
            this.Timeout = 1200;
        }

        public StopRecordingParamsBuilder frameworkParameterSearch(bool frameworkParameterSearch)
        {
            this.FrameworkParameterSearch = frameworkParameterSearch;
            return this;
        }

        public StopRecordingParamsBuilder genericParameterSearch(bool genericParameterSearch)
        {
            this.GenericParameterSearch = genericParameterSearch;
            return this;
        }

        /// <summary>
		/// Use this parameter in order to launch a User Path Update at the end of the post recording.</summary>
        public StopRecordingParamsBuilder updateParams(UpdateUserPathParams updateParams)
        {
            this.UpdateParams = updateParams;
            return this;
        }

        /// <summary>
		/// Use this parameter to set the timeout in seconds to wait for the end of the post record.
		/// Default value is 1200 seconds.</summary>
        public StopRecordingParamsBuilder timeout(int timeout)
        {
            this.Timeout = timeout;
            return this;
        }

        public StopRecordingParams Build()
        {
            if (Timeout <= 0)
            {
                throw new System.ArgumentException("Timeout cannot be negative or equals to 0.", "Timeout");
            }
            return new StopRecordingParams(this);
        }
    }
}
