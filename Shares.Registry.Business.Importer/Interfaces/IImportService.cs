﻿
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shares.Registry.Business.Importer.Interfaces
{
    public interface IImportService
    {
        public Task ImportSharesAsync();
    }
}