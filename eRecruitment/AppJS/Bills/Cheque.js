function EditCheque(id)
{
    var ids = $(id).attr("id");
    var chequeId = $(id).attr("id").split("_")[1];
   
    $("#hdncheque").val(chequeId);
    var text = $("#tb3_" + chequeId + "").find("td:nth-child(3)").text();;// $("#" + ids + "").text();
    $("#txtcheno").val(text);
    $("#ChequesModal").modal("show");
}

function ChequeUpdate()
{
    var id = $("#hdncheque").val();
    var text = $("#txtcheno").val();
    $.ajax({
        type: "get",
        url: '../AllBills/EditCheque',
        data: {
            id: id,
            text: text,
        },
        success: function (data) {
            if (data == "success")
            {
                //id='tb3_@item.ChequeChildId'
                $("#ChequesModal").modal("hide");
                $("#tb3_" + id + "").find("td:nth-child(3)").text(text);
            }
        }
    });
}