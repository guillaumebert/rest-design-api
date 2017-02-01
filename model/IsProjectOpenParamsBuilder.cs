/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// Builder for object <seealso cref="IsProjectOpenParams"/>.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class IsProjectOpenParamsBuilder
    {
        public string FilePath { get; set; }

		public IsProjectOpenParamsBuilder()
        {
			this.FilePath = "";
        }

        /// <summary>
		/// The path of the nlp file.</summary>
        public IsProjectOpenParamsBuilder filePath(string filePath)
        {
            this.FilePath = filePath;
            return this;
        }

        public IsProjectOpenParams Build()
        {
            if (FilePath == null || FilePath.Equals(""))
            {
                throw new System.ArgumentException("The path of the nlp file is mandatory.", "FilePath");
            }
            return new IsProjectOpenParams(this);
        }
    }
}
