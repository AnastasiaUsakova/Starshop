using System;

namespace Utils
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InvokeOnResetProgress : Attribute
    {
    }
}