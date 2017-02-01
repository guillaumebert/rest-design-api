using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
	/// SaveAsProject is the method sent to the Design API Server.
    /// 
    /// @author lcharlois
    /// 
    /// </summary>
	public class SaveAsProjectParams : IComparable<SaveAsProjectParams>
    {
		private readonly string directoryPath;
		private readonly string name;
		private readonly bool overwrite;
		private readonly bool forceStop;

		internal SaveAsProjectParams(SaveAsProjectParamsBuilder saveAsProjectParamsBuilder)
        {
			this.directoryPath = saveAsProjectParamsBuilder.DirectoryPath;
			this.name = saveAsProjectParamsBuilder.Name;
			this.overwrite = saveAsProjectParamsBuilder.Overwrite;
			this.forceStop = saveAsProjectParamsBuilder.ForceStop;
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

		public virtual bool ForceStop
		{
			get
			{
				return forceStop;
			}
		}

        public override string ToString()
        {
			return new ToStringBuilder<SaveAsProjectParams>(this).ReflectionToString(this);
        }

		public virtual int CompareTo(SaveAsProjectParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
			return new HashCodeBuilder<SaveAsProjectParams>(this)
				.With(m => m.directoryPath)
				.With(m => m.name)
				.With(m => m.overwrite)
				.With(m => m.forceStop)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
			if (!(obj is SaveAsProjectParams))
            {
                return false;
            }

			return new EqualsBuilder<SaveAsProjectParams>(this, obj)
				.With(m => m.directoryPath)
				.With(m => m.name)
				.With(m => m.overwrite)
				.With(m => m.forceStop)
                .Equals();
        }
    }
}
