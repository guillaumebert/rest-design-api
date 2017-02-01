/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// Builder for object <seealso cref="CloseProjectParams"/>.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class CloseProjectParamsBuilder
    {
        public bool ForceStop { get; set; }

		public bool Save { get; set; }

		public CloseProjectParamsBuilder()
        {
			this.ForceStop = false;
			this.Save = true;
        }

        /// <summary>
        /// Default value is false. If set to true, running tests and recordings are stopped.</summary>
        public CloseProjectParamsBuilder forceStop(bool forceStop)
        {
            this.ForceStop = forceStop;
            return this;
        }

        /// <summary>
		/// Default value is true. If set to false, current project is not saved.</summary>
        public CloseProjectParamsBuilder save(bool save)
        {
            this.Save = save;
            return this;
        }

        public CloseProjectParams Build()
        {
			return new CloseProjectParams(this);
        }
    }
}
