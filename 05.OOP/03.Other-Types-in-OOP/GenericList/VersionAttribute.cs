using System;

namespace GenericList
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Interface |
        AttributeTargets.Enum |
        AttributeTargets.Method
                   )
    ]
    public class VersionAttribute : Attribute
    {
        private int major;
        private int minor;
        public VersionAttribute(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.major, this.minor);
        }
    }
}
