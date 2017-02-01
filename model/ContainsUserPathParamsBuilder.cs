/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// Builder for object <seealso cref="ContainsUserPathParams"/>.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class ContainsUserPathParamsBuilder
    {
        public string Name { get; set; }

		public ContainsUserPathParamsBuilder()
        {
            this.Name = "";
        }

        /// <summary>
	    /// The name of the project.</summary>
        public ContainsUserPathParamsBuilder name(string name)
        {
            this.Name = name;
            return this;
        }

        public ContainsUserPathParams Build()
        {
            if (Name == null || Name.Equals(""))
            {
                throw new System.ArgumentException("Name of the User Path is mandatory.", "Name");
            }
            return new ContainsUserPathParams(this);
        }
    }
}
