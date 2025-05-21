var BankProduct = {
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
            // Enable both dropdowns if default "Select" option is chosen
            $("#InteresetPayableGLAccountMappingId").prop("disabled", false);
            $("#InteresetReceivableGLAccountMappingId").prop("disabled", false);
            CoditechCommon.HideLodder();
            return;
        }

        // Your existing logic for other selections
        if (
            selectedText === "Savings Account" ||
            selectedText === "Fixed Deposit (FD)" ||
            selectedText === "Recurring Deposit (RD)"
        ) {
            $("#InteresetPayableGLAccountMappingId").prop("disabled", false);
            $("#InteresetReceivableGLAccountMappingId").prop("disabled", true);
        } else {
            $("#InteresetPayableGLAccountMappingId").prop("disabled", true);
            $("#InteresetReceivableGLAccountMappingId").prop("disabled", false);
        }

    }
};

$(document).ready(function () {
    BankProduct.Initialize();
});
