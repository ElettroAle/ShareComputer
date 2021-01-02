
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Registry.Data.FileSystem.Mapping
{
    internal class TextFileDatabaseProfile : Profile
    {
        public TextFileDatabaseProfile()
        {
            this.CreateMap<Business.Data.TransferObjects.SharePurchase, AccessObjects.SharePurchase>();
        }
    }
}
