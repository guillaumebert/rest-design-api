/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// Builder for object <seealso cref="UpdateUserPathParams"/>.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class UpdateUserPathParamsBuilder
    {
        public int? MatchingThreshold { get; set; }
        public bool? UpdateSharedContainers { get; set; }
        public bool? IncludeVariables { get; set; }
        public bool? DeleteRecording { get; set; }
        public string Name { get; set; }

        public UpdateUserPathParamsBuilder()
        {
            this.MatchingThreshold = null;
            this.UpdateSharedContainers = null;
            this.IncludeVariables = null;
            this.DeleteRecording = null;
            this.Name = null;
        }

        /// <summary>
		/// The name of the User Path to update.</summary>
        public UpdateUserPathParamsBuilder name(string name)
        {
            this.Name = name;
            return this;
        }

        /// <summary>
		/// Default value is false.</summary>
        public UpdateUserPathParamsBuilder deleteRecording(bool deleteRecording)
        {
            this.DeleteRecording = deleteRecording;
            return this;
        }

        /// <summary>
		/// The higher the threshold is, the more matches will be found but higher the risk to display elements as matches while they are new.
		/// Default value is 60.</summary>
		///
		/// <param>matchingThreshold should be between 0 and 100.</param>
        public UpdateUserPathParamsBuilder matchingThreshold(int matchingThreshold)
        {
            this.MatchingThreshold = matchingThreshold;
            return this;
        }

        /// <summary>
		/// When set to true, Shared Containers are updated in the User Path to be updated.
		/// Default value is false.</summary>
        public UpdateUserPathParamsBuilder updateSharedContainers(bool updateSharedContainers)
        {
            this.UpdateSharedContainers = updateSharedContainers;
            return this;
        }

        /// <summary>
		/// When set to true, variable extractors and variables are included during the merge of matching requests.
		/// Default value is true.</summary>
        public UpdateUserPathParamsBuilder includeVariables(bool includeVariables)
        {
            this.IncludeVariables = includeVariables;
            return this;
        }

        public UpdateUserPathParams Build()
        {
            if (Name == null || Name.Equals(""))
            {
                throw new System.ArgumentException("Name of the User Path to be updated is mandatory.", "Name");
            }
            if (MatchingThreshold != null && (MatchingThreshold < 0 || MatchingThreshold > 100))
            {
                throw new System.ArgumentException("The matching threshold should be between 0 and 100.", "MatchingThreshold");
            }
            return new UpdateUserPathParams(this);
        }
    }
}
