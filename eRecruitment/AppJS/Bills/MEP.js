function EditMEP(id)
{
    var ids = $(id).attr("id");
    var chequeId = $(id).attr("id").split("_")[1];

    $("#hdnmep").val(chequeId);
    var text = $("#tb2_" + chequeId + "").find("td:nth-child(2)").text();;// $("#" + ids + "").text();
    $("#txtMEP").val(text);
    $("#MEPModal").modal("show");
}

function MEPUpdate() {
    var id = $("#hdnmep").val();
    var text = $("#txtMEP").val();
    $.ajax({
        type: "get",
        url: '../AllBills/EditMEP',
        data: {
            id: id,
            text: text,
        },
        success: function (data) {
            if (data == "success") {
                //id='tb3_@item.ChequeChildId'
                $("#MEPModal").modal("hide");
                $("#tb2_" + id + "").find("td:nth-child(2)").text(text);
            }
        }
    });
}