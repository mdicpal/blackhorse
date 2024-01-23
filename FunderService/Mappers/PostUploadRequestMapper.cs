namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Models;
    using AzureFunderCommonMessages.DotNet.Request;
    using AzureFunderCommonMessages.DotNet.Request.DataTypes;
    using FunderApi;
    using FunderService.Mappers.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PostUploadRequestMapper : IPostUploadRequestMapper
    {
        public PostUploadRequest Map(DocumentRequest documentRequest)
        {
            return new()
            {
                File_type = documentRequest.FileType.ToString(),
                // //Service="",TO DO
                //Document_type=,TO DO
                // Document=null,TO DO
                // Uv_verified="",TO DO
            };
        }
    }
}
