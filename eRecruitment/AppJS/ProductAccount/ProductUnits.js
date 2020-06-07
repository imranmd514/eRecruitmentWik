
function AssignUnits() {
    var unitid = $("#cmbUnits").val();
    var productid = $("#cmbNature").val();
    if (productid == "0") {
        required("Select Nature")

    }
   else if (unitid == "0") {
        required("Provide Unit")

    }
    else {
        $.ajax({
            type: "POST",
            url: '../AssignProductUnits/Save',
            data: {
                unitid: unitid,
                productid: productid,
            },
            success: function (data) {
                if (data == "edited") {
                    success();
                    NatureChange();
                    $("#cmbUnits").val("0");
                }
                else if (data == "inserted") {
                    success();
                    NatureChange();
                    $("#cmbUnits").val("0");

                }
            }
        });


    }



}


function ProductUnits() {
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };
    $("#productunitpopup").modal("show");
    $("#cmbUnits").select2();
    $("#cmbNature").select2();
    //$("#productunitid").val(id);

    //$.ajax({
    //    type: "POST",
    //    url: '../ProductAccount/gridproductunit',
    //    data: {
    //        id: id,
    //    },
    //    success: function (data) {
    //        $("#tblpu").html(data.split('~')[0]);
    //        $("#Productname").html(data.split('~')[1]);

    //    }
    //});

    //tblpu
}
function NatureChange()
{

    var natureid = $("#cmbNature").val();
    $.ajax({
        type: "POST",
        url: '../ProductAccount/gridproductunit',
        data: {
            id: natureid,
        },
        success: function (data) {
            $("#tblpu").html(data.split('~')[0]);
            $("#Productname").html(data.split('~')[1]);

        }
    });
}
function DeleteProductUnit(id) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(id + "_AssignProductUnits");
    $("#Deletetype").val("productunit");

}
function searchTable(inputVal) {
    var table = $('#tblpu');
    table.find('tr').each(function (index, row) {
        var allCells = $(row).find('td');
        if (allCells.length > 0) {
            var found = false;
            allCells.each(function (index, td) {
                var regExp = new RegExp(inputVal, 'i');
                if (regExp.test($(td).text())) {
                    found = true;
                    return false;
                }
            });
            if (found == true)
                $(row).show();
            else
                $(row).hide();
        }
    });
}