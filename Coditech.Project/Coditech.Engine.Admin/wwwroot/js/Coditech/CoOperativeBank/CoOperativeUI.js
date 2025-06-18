var CoOperativeUI = {
    Initialize: function () {
        CoOperativeUI.constructor();
    },
    constructor: function () {
    },

    GetBankMemberByCentreCode: function () {
        var selectedCentreCode = $("#CentreCode").val();
        CoditechCommon.ShowLodder();
        $('#DataTablesDivId tbody').html('');
        if (selectedCentreCode !== "") {
            CoditechCommon.ShowLodder();
            $.ajax({
                type: "GET",
                url: "/CoOperativeUI/GetBankMemberByCentreCode",
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
    LoadCoOperativeUIPartial: function () {
        var centreCode = $('#CentreCode').val();
        var bankMemberId = $('#BankMemberId').val();       
        if (!centreCode || !bankMemberId) {
            CoditechNotification.DisplayNotificationMessage("Please select both Centre and Bank Member.", "error");
            return;
        }
        CoditechCommon.ShowLodder();
        $.ajax({
            url: '/CoOperativeUI/LoadCoOperativeUIPartial',
            type: 'GET',
            data: {
                centreCode: centreCode,
                bankMemberId: bankMemberId
            },
            success: function (response) {
                $('#cooperativeUIPartialContainer').html(response);
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
    }
};
