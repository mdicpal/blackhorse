<?php

namespace AzureFunderCommonMessages\PHP\Types;

class ApplicationStatus {
    public const STARTED_ORCHESTRATION = "StartedOrchestration";
    public const FUNDER_RESPONSE_RECIEVED = "FunderResponseReceived";
    public const APPLICATION_WITH_FUNDER = "ApplicationWithFunder";
    public const NO_CHANGE = "NoChange";
    public const UNKOWN = "Unknown";
    public const ACCEPTED = "Accepted";
    public const CREDIT_LIMIT_ACCEPTED = "CreditLimitAccepted";
    public const CONDITIONAL_ACCEPT = "ConditionalAccept";
    public const REFERRED = "Referred";
    public const DECLINED = "Declined";
    public const CREDIT_LIMIT_DECLINED = "CreditLimitDeclined";
    public const CANCELLED = "Cancelled";
    public const NOT_TAKEN_UP = "NTU";
    public const RECEIVED_OK = "ReceivedOK";
    public const MORE_INFO = "MoreInfo";
    public const DOCS_RECEIVED = "DocsReceived";
    public const PAID_OUT = "PaidOut";
    public const PAYOUT_PENDING = "PayoutPending";
    public const PAYOUT_WITH_FUNDER = "PayoutWithFunder";
    Public const PAYOUT_RECEIVED = "PayoutReceived";
    public const RESUBMIT_REQUIRED = "ResubmitRequired";
    public const NOT_SENT = "NotSent";
    public const PRE_APPROVED = "PreApproved";
    public const AMENDMENT_WITH_FUNDER = "AmendmentWithFunder";
    public const EXPIRED = "Expired";
    public const ESIGN_COMPLETED = "ESignCompleted";

    public const ERROR = "Error";
    public const PAID_OUT_ERROR = "PaidOutError";
    public const CRITICAL_ERROR = "CriticalError";
}
