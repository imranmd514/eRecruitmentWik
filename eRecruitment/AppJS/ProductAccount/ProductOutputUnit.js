

function LoadProductOutput() {
    $.ajax({
        type: "GET",
        url: '../ProductAccount/GetProductOutputunit',
        data: {
        },
        success: function (data) {
            $("#productoutput").html(data);
            psdropdown();
            getgrid();
            $("#cmbPurchaseSale").select2();
            $("#cmbProduct").select2();
            $("#cmbOutputUnits").select2();
        }
    });
}



function psdropdown()
{
    $.ajax({
        type: "get",
        url: '../ProductUnitSettings/GetPSList',// url: "@Url.Action("GetPSList", "ProductUnitSettings")",
        data: {
            id: 1,
        },
        success: function (data) {

            $("#tdtype").html("Purchase Type");

            $.each(data, function () {
                $("#cmbPurchaseSale").append("<option value=" + this.Value + ">" + this.Text + "</option>");

            });
        }


    });
}

function ChangePs()
{
    var id = $("#cmbPurchaseSale").val();
    $.ajax({
        type: "get",
        url: '../ProductUnitSettings/GetPSWiseProductUnits',//url: "@Url.Action("GetPSWiseProductUnits", "ProductUnitSettings")",
        data: {
            id: id,
        },
        success: function (data) {
            $("#tblunits").html(data);
            $("#psheader").html($("#cmbPurchaseSale :selected").text());
            $("#myModal").modal('show');
        }
    });
}

function rdPurchase()
{
    $("#rdPurchase").is(":checked")
    {
        $("#cmbPurchaseSale").empty();
        $("#cmbProduct").val("0");
        $("#cmbOutputUnits").val("0");
        $.ajax({
            type: "get",
            url: '../ProductUnitSettings/GetPSList', //url: "@Url.Action("GetPSList", "ProductUnitSettings")",
            data: {
                id: 1,
            },
            success: function (data) {

                $("#tdtype").html("Purchase Type");

                $.each(data, function () {
                    $("#cmbPurchaseSale").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                });
            }


        });
    }

}



function rdSale() {
    $("#rdSale").is(":checked")
    {
        $("#cmbProduct").val("0");
        $("#cmbOutputUnits").val("0");
        $("#cmbPurchaseSale").empty();
        $.ajax({
            type: "get",
            url: '../ProductUnitSettings/GetPSList', // url: "@Url.Action("GetPSList", "ProductUnitSettings")",
            data: {
                id: 2,
            },
            success: function (data) {
                $("#tdtype").html("Sales Type");
                $.each(data, function () {
                    $("#cmbPurchaseSale").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                });
            }
        });

    }
}

function ChangeProduct()
{


    var id = $("#cmbProduct").val();
    $("#cmbOutputUnits").empty();
    $("#cmbOutputUnits").append("<option value='0'>Select Units</option>");
    $.ajax({
        type: "get",
        url: '../ProductUnitSettings/GetProductUnits',//url: "@Url.Action("GetProductUnits", "ProductUnitSettings")",
        data: {
            id: id,
        },
        success: function (data) {
            $.each(data, function () {
                $("#cmbOutputUnits").append("<option value=" + this.Value + ">" + this.Text + "</option>");

            });


        }
    });
}






function AssignOutput(){
    //pstype, product, units, output
    var pstype = $("#cmbPurchaseSale").val();
    var product = $("#cmbProduct").val();
    var output = $("#cmbOutputUnits").val();
    if ($("#cmbPurchaseSale").val() == 0)
    {
        required("Please select PSType");
    }
    else if ($("#cmbProduct").val() == 0) {
       required("Please select Product");
    } else if ($("#cmbOutputUnits").val() == 0) {
     required("Please select OutputUnits");
    }
    else {
        $.ajax({
            type: "get",
            url: '../ProductUnitSettings/Insert',//url: "@Url.Action("Insert", "ProductUnitSettings")",
            data: {
            pstype: pstype,
            product: product,
            output: output,
            },
        success: function (data) {
            if (data == "inserted")
            {
                $("#psheader2").html($("#cmbPurchaseSale :selected").text());
                var product = $("#cmbProduct :selected").text();
                var unit = $("#cmbOutputUnits :selected").text();
                $("#tblunits2").html(

                    "<tr><td><b class='vd_blue'>Product : </b>" + product + "</td></tr><tr><td><b class='vd_blue'>Output Unit :</b> " + unit + "</td></tr>"

                    );
                $("#myModal2").modal('show');
                success();

            }
            else if (data == "edited")
            {
                $("#psheader2").html($("#cmbPurchaseSale :selected").text());
                var product = $("#cmbProduct :selected").text();
                var unit = $("#cmbOutputUnits :selected").text();
                $("#tblunits2").html(

                    "<tr><td><b class='vd_blue'>Product : </b>" + product + "</td></tr><tr><td><b class='vd_blue'>Output Unit :</b> " + unit + "</td></tr>"

                    );
                $("#myModal2").modal('show');
                success();
            }
            getgrid();
        }
    });
}
}





function getgrid()
{
    $.ajax({
        type: "get",
        url: '../ProductAccount/GetGrid', //url: "@Url.Action("GetGrid", "ProductUnitSettings")",
        data: {
        },
    success: function (data) {
        $("#tblproductsettings").html(data);
    }
});
}
function searchTable(inputVal) {
    var table = $('#tbody');
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

function DeleteSelectedrecordpopup()
{
    $("#closeunitdeletepopup").trigger("click");
    var id = $("#DeleteSelectedrecordpopup").val();
    $.ajax({
        type: "get",
        url: '../ProductUnitSettings/Delete',// url: "@Url.Action("Delete", "ProductUnitSettings")",
        data: {
            id: id,
        },
        success: function (data) {
            if (data == "deleted") {
                deleted();
                getgrid();
            }
            else if (data == "dependent") {
                dependent();

            }
            else if (data == "fail") {
                fail();

            }

        }
    });

}

function DeleteRecord(id)
{

    $("#DeleteSelectedrecordpopup").val(id);
    $("#deleteunitpopup").modal("show");

}
function DeleteRecord2(id) {
    $.ajax({
        type: "get",
        url: '../ProductUnitSettings/Delete',//url: "@Url.Action("Delete", "ProductUnitSettings")",
        data: {
        id: id,
        },
    success: function (data) {
        if (data == "deleted") {
            $.ajax({
                type: "get",
                url: '../ProductUnitSettings/GetPSWiseProductUnits',//url: "@Url.Action("GetPSWiseProductUnits", "ProductUnitSettings")",
                data: {
                id: $("#cmbPurchaseSale").val(),
                },
            success: function (data) {
                $("#tblunits").html(data);
                deleted();

                //$("#psheader").html($("#cmbPurchaseSale :selected").text());
                //$("#myModal").modal('show');
            }
        });
    }
}
});

}