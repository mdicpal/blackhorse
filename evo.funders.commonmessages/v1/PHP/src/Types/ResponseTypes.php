<?php

namespace AzureFunderCommonMessages\PHP\Types;

class ResponseTypes {
	public const ERROR = "Error";
	public const SERVICE_ERROR = "ServiceErrors";
	public const FUNDER_ERROR = "FunderErrors";
	public const AZURE_VALIDATION_ERROR = "ValidationErrors";
	public const AZURE_DOCUMENT_AVAILABLE = "DocumentAvailable";
	public const STATUS_UPDATE = "StatusResponse";
	public const DRIVING_LICENCE_UPDATE = "DrivingLicenceUpdateResponse";
	public const ESIGN = "EsignResponse";
	public const OPEN_BANKING_RESPONSE = "OpenBankingResponse";
	public const COMMUNICATION_RESPONSE = "CommunicationResponse";
	public const GENERIC_RESPONSE = "GenericResponse";
	public const ENHANCED_BANKING_RESPONSE = "EnhancedBankingResponse";
	public const TASK_RESPONSE = "TaskResponse";
	public const DOCUMENT_UPLOAD_RESPONSE = "DocumentUploadResponse";
	public const ADDITIONAL_FINANCE_RESPONSE = "AdditionalFinanceResponse";
	public const INVOICE_ADDRESS_RESPONSE = "InvoiceAddressResponse";
	public const GUARANTEED_FUTURE_VALUE_RESPONSE = "GuaranteedFutureValueResponse";
	public const ESIGN_COMPLETED_RESPONSE = "ESignCompletedResponse";
	public const ESIGN_TRIGGERED_RESPONSE = "ESignTriggeredResponse";
}