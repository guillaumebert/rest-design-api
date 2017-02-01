using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// CreateProject is the method sent to the Design API Server.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class CreateProjectParams : IComparable<CreateProjectParams>
    {
		private readonly string directoryPath;
		private readonly string name;
		private readonly bool overwrite;

		internal CreateProjectParams(CreateProjectParamsBuilder createProjectParamsBuilder)
        {
			this.directoryPath = createProjectParamsBuilder.DirectoryPath;
			this.name = createProjectParamsBuilder.Name;
			this.overwrite = createProjectParamsBuilder.Overwrite;
        }

		public virtual string DirectoryPath
        {
            get
            {
				return directoryPath;
            }
        }

		public virtual string Name
		{
			get
			{
				return name;
			}
		}

		public virtual bool Overwrite
		{
			get
			{
				return overwrite;
			}
		}

        public override string ToString()
        {
			return new ToStringBuilder<CreateProjectParams>(this).ReflectionToString(this);
        }

		public virtual int CompareTo(CreateProjectParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
			return new HashCodeBuilder<CreateProjectParams>(this)
				.With(m => m.directoryPath)
				.With(m => m.name)
				.With(m => m.overwrite)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
			if (!(obj is CreateProjectParams))
            {
                return false;
            }

			return new EqualsBuilder<CreateProjectParams>(this, obj)
				.With(m => m.directoryPath)
				.With(m => m.name)
				.With(m => m.overwrite)
                .Equals();
        }
    }
}
