/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// Builder for object <seealso cref="SaveAsProjectParams"/>.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class SaveAsProjectParamsBuilder
    {
		public string DirectoryPath { get; set; }

		public string Name { get; set; }

		public bool Overwrite { get; set; }

		public bool ForceStop { get; set; }

		public SaveAsProjectParamsBuilder()
        {
			this.DirectoryPath = null;
			this.Name = "";
			this.Overwrite = false;
			this.ForceStop = false;
        }

         /// <summary>
		 /// The new location of the project. By default, projects are saved in NeoLoad projects folder.</summary>
        public SaveAsProjectParamsBuilder directoryPath(string directoryPath)
        {
            this.DirectoryPath = directoryPath;
            return this;
        }

         /// <summary>
		 /// The new name of the project.</summary>
        public SaveAsProjectParamsBuilder name(string name)
        {
            this.Name = name;
            return this;
        }

         /// <summary>
		 /// Default value is false. If set to true, an existing project with the same name and location is deleted.</summary>
        public SaveAsProjectParamsBuilder overwrite(bool overwrite)
        {
            this.Overwrite = overwrite;
            return this;
        }

         /// <summary>
		 /// Default value is false. If set to true, running tests and recordings are stopped.</summary>
        public SaveAsProjectParamsBuilder forceStop(bool forceStop)
        {
            this.ForceStop = forceStop;
            return this;
        }

        public SaveAsProjectParams Build()
        {
            if (Name == null || Name.Equals(""))
            {
                throw new System.ArgumentException("Name of the new Project is mandatory.", "Name");
            }
            return new SaveAsProjectParams(this);
        }
    }
}
