/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// Builder for object <seealso cref="OpenProjectParams"/>.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class OpenProjectParamsBuilder
    {
        public string FilePath { get; set; }

		public OpenProjectParamsBuilder()
        {
			this.FilePath = "";
        }

        /// <summary>
		/// The path of the nlp file.</summary>
        public OpenProjectParamsBuilder filePath(string filePath)
        {
            this.FilePath = filePath;
            return this;
        }

        public OpenProjectParams Build()
        {
            if (FilePath == null || FilePath.Equals(""))
            {
                throw new System.ArgumentException("The path of the nlp file is mandatory.", "FilePath");
            }
            return new OpenProjectParams(this);
        }
    }
}
