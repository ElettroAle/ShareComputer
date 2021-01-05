
using AutoMapper;

using Shares.Registry.Business.Abstractions.DataPlugins.TransferObjects;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Data.FileSystem.Mapping
{
    internal class TextFileDatabaseProfile : Profile
    {
        public TextFileDatabaseProfile()
        {
            this.CreateMap<Share, AccessObjects.Share>();
        }
    }
}
