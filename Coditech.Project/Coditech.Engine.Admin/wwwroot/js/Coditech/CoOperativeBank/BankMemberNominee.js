﻿var BankMemberNominee = {
    Initialize: function () {
    },

    constructor: function () {
    },
    GetBankMemberByCentreCode: function () {
        var selectedCentreCode = $("#CentreCode").val();
        $('#DataTablesDivId tbody').html('');
        if (selectedCentreCode != "") {
            CoditechCommon.ShowLodder();
            $.ajax({
                cache: false,
                type: "GET",
                dataType: "html",
                url: "/BankMemberNominee/GetBankMemberByCentreCode",
                data: { "selectedCentreCode": selectedCentreCode },
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    console.log(data);
                    $("#BankMemberId").html("").html(data);
                    CoditechCommon.HideLodder();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    if (xhr.status == "401" || xhr.status == "403") {
                        location.reload();
                    }
                    CoditechNotification.DisplayNotificationMessage("Failed to retrieve Bank Member.", "error")
                    CoditechCommon.HideLodder();
                }
            });
        }
        else {
            $('#DataTablesDivId tbody').html('');
            $("#BankMemberId").html("");
        }
    },
}