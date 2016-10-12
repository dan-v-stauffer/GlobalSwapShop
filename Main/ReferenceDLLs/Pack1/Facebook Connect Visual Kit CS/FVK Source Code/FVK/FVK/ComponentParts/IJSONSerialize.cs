// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FVK
{
    /// <summary>
    /// This interface uses for convesion from object data to JSON format
    /// </summary>
    public interface IJSONSerialize
    {
        /// <summary>
        /// Serialize object to JSON format
        /// </summary>
        /// <returns>JSON format string</returns>
        string JSONSerialize();
    }
}
