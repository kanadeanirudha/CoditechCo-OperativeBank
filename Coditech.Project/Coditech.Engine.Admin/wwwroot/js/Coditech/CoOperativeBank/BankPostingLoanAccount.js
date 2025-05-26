var BankPostingLoanAccount = {
    Initialize: function () {
        BankPostingLoanAccount.constructor();
    },
    constructor: function () {
    },

    GetBankMemberByCentreCode: function () {
        var selectedCentreCode = $("#CentreCode").val();
        $('#DataTablesDivId tbody').html('');
        if (selectedCentreCode !== "") {
            CoditechCommon.ShowLodder();
            $.ajax({
                type: "GET",
                url: "/BankPostingLoanAccount/GetBankMemberByCentreCode",
                data: { selectedCentreCode: selectedCentreCode }, 
                dataType: "html",
                success: function (data) {
                    $("#BankMemberId").html(data);
                    CoditechCommon.HideLodder();
                },
                error: function (xhr) {
                    if (xhr.status === 401 || xhr.status === 403) {
                        location.reload();
                    }
                    CoditechNotification.DisplayNotificationMessage("Failed to retrieve Bank Member.", "error");
                    CoditechCommon.HideLodder();
                }
            });
        } else {
            $("#BankMemberId").html("");
        }
    },

    GetBankProductByCentreCode: function () {
        var selectedCentreCode = $("#CentreCode").val();
        $('#DataTablesDivId tbody').html('');
        if (selectedCentreCode !== "") {
            CoditechCommon.ShowLodder();
            $.ajax({
                type: "GET",
                url: "/BankPostingLoanAccount/GetBankProductByCentreCode",
                data: { selectedCentreCode: selectedCentreCode },
                dataType: "html",
                success: function (data) {
                    $("#BankProductId").html(data);
                    CoditechCommon.HideLodder();
                },
                error: function (xhr) {
                    if (xhr.status === 401 || xhr.status === 403) {
                        location.reload();
                    }
                    CoditechNotification.DisplayNotificationMessage("Failed to retrieve Bank Product.", "error");
                    CoditechCommon.HideLodder();
                }
            });
        } else {
            $("#BankProductId").html("");
        }
    }
};