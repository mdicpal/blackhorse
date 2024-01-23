using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunderCommonMessages.DotNet.Types
{
    public enum RequestType {
        GetEsign, 
        MakeApplication,
        AdditionalData,
        GetQuote,
        DocumentUpload,
        ActivateQuote,
        OpenBankingRequest,
        CancelApplication
    };
}
