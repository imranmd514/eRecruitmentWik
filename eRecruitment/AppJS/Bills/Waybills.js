function EditWaybill(id)
{
    var ids = $(id).attr("id");
    var chequeId = $(id).attr("id").split("_")[1];

    $("#hdnwaybill").val(chequeId);
    var text = $("#tb1_" + chequeId + "").find("td:nth-child(2)").text();// $("#" + ids + "").text();
    $("#txtWaybill").val(text);
    $("#WaybillModal").modal("show");
}

function WaybillUpdate() {
    var id = $("#hdnwaybill").val();
    var text = $("#txtWaybill").val();
    $.ajax({
        type: "get",
        url: '../AllBills/EditWaybill',
        data: {
            id: id,
            text: text,
        },
        success: function (data) {
            if (data == "success") {
                //id='tb3_@item.ChequeChildId'
                $("#WaybillModal").modal("hide");
                $("#tb1_" + id + "").find("td:nth-child(2)").text(text);
            }
        }
    });
}