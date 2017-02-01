using Neotys.CommonAPI.Utils;
using System;
/*
 * Copyright (c) 2016, Neotys
 * All rights reserved.
 */

namespace Neotys.DesignAPI.Model
{
    /// <summary>
    /// Method sent to the Design API Server to set the current screenshot image.
    /// 
    /// @author anouvel
    /// 
    /// </summary>
    public class SetScreenshotParams : IComparable<SetScreenshotParams>
    {
        private readonly byte[] screenshot;

        public SetScreenshotParams(byte[] screenshot)
        {
            if (screenshot == null)
            {
                this.screenshot = new byte[0];
            }
            else
            {
                this.screenshot = new byte[screenshot.Length];
                Array.Copy(screenshot, this.screenshot, screenshot.Length);
            }
        }

        public virtual byte[] Screenshot
        {
            get
            {
                return screenshot;
            }
        }

        public override string ToString()
        {
            return new ToStringBuilder<SetScreenshotParams>(this).ReflectionToString(this);
        }

        public virtual int CompareTo(SetScreenshotParams o)
        {
            return this.ToString().CompareTo(o.ToString());
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<SetScreenshotParams>(this)
                .With(m => m.screenshot)
                .HashCode;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SetScreenshotParams))
            {
                return false;
            }

            return new EqualsBuilder<SetScreenshotParams>(this, obj)
                .With(m => m.screenshot)
                .Equals();
        }
    }
}
