using System;
using System.Collections.Generic;

namespace AwesomeSerializer.Serializers
{
    public interface IMemberSerialization
    {
        SerializeAction Action { get; }

        Type Type { get; }

        IEnumerable<String> Properties { get; }
    }
}