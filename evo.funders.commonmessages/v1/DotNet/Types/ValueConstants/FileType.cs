using System.Runtime.Serialization;

namespace AzureFunderCommonMessages.DotNet.Types.ValueConstants
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileType
    {
        [EnumMember(Value = "DrivingLicence")]
        DrivingLicence,
        [EnumMember(Value = "Passport")]
        Passport,
        [EnumMember(Value = "BankStatements")]
        BankStatements,
        [EnumMember(Value = "DvlaEndorsementCheck")]
        DvlaEndorsementCheck,
        [EnumMember(Value = "ComputerisedPayslip")]
        ComputerisedPayslip,
        [EnumMember(Value = "ProofOfComprehensiveInsurance")]
        ProofOfComprehensiveInsurance,
        [EnumMember(Value = "PhotoId")]
        PhotoId,
        [EnumMember(Value = "ProofOfId")]
        ProofOfId,
        [EnumMember(Value = "ESignAcceptanceConditions")]
        ESignAcceptanceConditions,
        [EnumMember(Value = "DealersBankDetails")]
        DealersBankDetails,
        [EnumMember(Value = "DealerInvoice")]
        DealerInvoice,
        [EnumMember(Value = "HpiCheck")]
        HpiCheck,
        [EnumMember(Value = "Other")]
        Other,
        [EnumMember(Value = "DirectDebitMandate")]
        DirectDebitMandate,
        [EnumMember(Value = "HpPcpAgreement")]
        HpPcpAgreement,
        [EnumMember(Value = "DealerOfferAndWarranty")]
        DealerOfferAndWarranty,
        [EnumMember(Value = "PreContract")]
        PreContract,
        [EnumMember(Value = "ProofOfAddress")]
        ProofOfAddress,
        [EnumMember(Value = "HpiCheckPartEx")]
        HpiCheckPartEx,
        [EnumMember(Value = "ProofOfPostage")]
        ProofOfPostage,
        [EnumMember(Value = "ValidationCall")]
        ValidationCall,
        [EnumMember(Value = "ProofOfSignature")]
        ProofOfSignature,
        [EnumMember(Value = "FcaPermissions")]
        FcaPermissions,
        [EnumMember(Value = "CreditSafeReport")]
        CreditSafeReport,
        [EnumMember(Value = "Ico")]
        Ico,
        [EnumMember(Value = "PdfDocumentPack")]
        PdfDocumentPack,
        [EnumMember(Value = "BankCard")]
        BankCard,
        [EnumMember(Value = "WetSignSelfie")]
        WetSignSelfie,
        [EnumMember(Value = "MotCertificate")]
        MotCertificate,
        [EnumMember(Value = "BankMatchCheck")]
        BankMatchCheck,
        [EnumMember(Value = "IncomeAndExpenditure")]
        IncomeAndExpenditure,
        [EnumMember(Value = "RightToRemain")]
        RightToRemain,
        [EnumMember(Value = "ProofOfDeposit")]
        ProofOfDeposit,
        [EnumMember(Value = "Clearance")]
        Clearance,
        [EnumMember(Value = "InsolvencyRegisterResult")]
        InsolvencyRegisterResult,
        [EnumMember(Value = "ManualSearch")]
        ManualSearch,
        [EnumMember(Value = "SupplierEmail")]
        SupplierEmail,

        [EnumMember(Value = "UtilityBill")]
        UtilityBill,
        [EnumMember(Value = "BureauReport")]
        BureauReport,
        [EnumMember(Value = "Invoice")]
        Invoice,
        [EnumMember(Value = "MortgageStatement")]
        MortgageStatement,
        [EnumMember(Value = "CouncilTaxStatement")]
        CouncilTaxStatement,
        [EnumMember(Value = "P60")]
        P60,
        [EnumMember(Value = "InsuranceDocument")]
        InsuranceDocument,
        [EnumMember(Value = "CcjSettlement")]
        CcjSettlement,
        [EnumMember(Value = "DebtLetter")]
        DebtLetter,
        [EnumMember(Value = "HpSettleMent")]
        HpSettleMent
}
}