var BankProduct = {
    previousSelectedText: "",

    Initialize: function () {
        BankProduct.Setup();
    },

    Setup: function () {
        // Set initial enabled/disabled state on page load
        BankProduct.GetDisabledDropdownOfAccPayableAndAccRecievable();

        // Bind change event to account type dropdown
        $('#AccountTypeEnumId').on('change', function () {
            BankProduct.GetDisabledDropdownOfAccPayableAndAccRecievable();
        });
    },

    GetDisabledDropdownOfAccPayableAndAccRecievable: function () {
        var selectedText = $("#AccountTypeEnumId option:selected").text().trim();

        if (selectedText === "---------Select----------") {
            $("#InteresetPayableGLAccountMappingId").prop("disabled", false);
            $("#InteresetReceivableGLAccountMappingId").prop("disabled", false);
            CoditechCommon.HideLodder();
            BankProduct.previousSelectedText = selectedText;
            return;
        }

        // For Savings, FD, RD: Receivable is disabled
        if (
            selectedText === "Savings Account" ||
            selectedText === "Fixed Deposit (FD)" ||
            selectedText === "Recurring Deposit (RD)"
        ) {
            // If Receivable is going to be disabled and it was previously enabled, clear it
            if ($("#InteresetReceivableGLAccountMappingId").is(":enabled")) {
                $("#InteresetReceivableGLAccountMappingId").val('');
            }
            $("#InteresetPayableGLAccountMappingId").prop("disabled", false);
            $("#InteresetReceivableGLAccountMappingId").prop("disabled", true);
        } else {
            // If Payable is going to be disabled and it was previously enabled, clear it
            if ($("#InteresetPayableGLAccountMappingId").is(":enabled")) {
                $("#InteresetPayableGLAccountMappingId").val('');
            }
            $("#InteresetPayableGLAccountMappingId").prop("disabled", true);
            $("#InteresetReceivableGLAccountMappingId").prop("disabled", false);
        }

        BankProduct.previousSelectedText = selectedText;
    }
};

$(document).ready(function () {
    BankProduct.Initialize();
});
