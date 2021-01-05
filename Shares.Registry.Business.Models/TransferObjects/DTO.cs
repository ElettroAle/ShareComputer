
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects
{
    public class DTO
    {
        public string Serialize() => JsonSerializer.Serialize(this, GetType());
    }
}
