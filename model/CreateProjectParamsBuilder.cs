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
	public class CreateProjectParamsBuilder
    {
		public string DirectoryPath { get; set; }

		public string Name { get; set; }

		public bool Overwrite { get; set; }

		public CreateProjectParamsBuilder()
        {
			this.DirectoryPath = null;
			this.Name = "";
			this.Overwrite = false;
        }

        /// <summary>
		/// The location of the project. By default, projects are created in NeoLoad projects folder.</summary>
        public CreateProjectParamsBuilder directoryPath(string directoryPath)
        {
            this.DirectoryPath = directoryPath;
            return this;
        }

        /// <summary>
		/// The name of the project.</summary>
        public CreateProjectParamsBuilder name(string name)
        {
            this.Name = name;
            return this;
        }

        /// <summary>
		/// Default value is false. If set to true, an existing project with the same name and location is deleted.</summary>
        public CreateProjectParamsBuilder overwrite(bool overwrite)
        {
            this.Overwrite = overwrite;
            return this;
        }

        public CreateProjectParams Build()
        {
            if (Name == null || Name.Equals(""))
            {
                throw new System.ArgumentException("Name of the new Project is mandatory.", "Name");
            }
            return new CreateProjectParams(this);
        }
    }
}
