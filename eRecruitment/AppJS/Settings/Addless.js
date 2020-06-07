function LoadAddless() {
    $.ajax({
        type: "get",
        url: '../Settings/GetAddLess',
        //url: "@Url.Action("GetGridCuttings", "CustomCuttings")",
        data: {

        },
        success: function (data) {
            $("#tab2").html(data);
            getgrid();
            $("#cmbproduct").select2();
            $("#cmbAccount").select2();
            $("#cmbunits").select2();
            $("#cmbPurchaseSale").select2();
            $("#lessdiv").hide();
            Loadddp();
            $("#btnUpdate").hide();
        }


    });
}

function Updateaddless()
{
    var Addlessid = $("#hdnaddlessid").val();
    $("#confirmAddless").modal("hide");
    var add = false;
    var amount = "";
    if ($("#rdless").is(":checked")) {
        add = false;

        amount = $("#txtAmountless").val();
    }
    else {
        add = true;
        amount = $("#txtAmountadd").val();
    }
    var pstypeid = $("#cmbPurchaseSale").val();
    var accountid = $("#cmbAccount").val();
    var qnty = $("#chkquantity").is(":checked");
    var actualrate = $("#chkAmount").is(":checked");
    var direct = $("#chkDirect").is(":checked");
    var product = $("#cmbproduct").val();
    var unit = $("#cmbunits").val();
    $.ajax({
        type: "get",
        url: '../AddLessSettings/Update',
        data: {
            pstypeid: pstypeid,
            accountid: accountid,
            add: add,
            qnty: qnty,
            actualrate: actualrate,
            direct: direct,
            amount: amount,
            product: product,
            unit: unit,
            quantity:$("#hdnquantal").val(),
            Addlessid: Addlessid,
        },
        success: function (data) {
            if (data == "success") {

                success();
                resetaddless();
                getgrid()
            }
            else if (data == "edited") {
                success();
                getgrid()
            }
            else if (data == "fail") {
                fail();
            }
        }
    });
}


function EditAddless(id) {
    $("#hdnaddlessid").val(id);
    $.ajax({
        type: "get",
        url: '../Settings/GetSavedRecord',
        //url: "@Url.Action("GetGridCuttings", "CustomCuttings")",
        data: {
            id: id,
        },
        success: function (data) {
            var product = data.split(",")[0];
            var ProductId = data.split(",")[1];
            var pstype = data.split(",")[2];
            var PSTypeId = data.split(",")[3];
            var account = data.split(",")[4];
            var AccountId = data.split(",")[5];
            var unit = data.split(",")[6];
            var UnitId = data.split(",")[7];
            var isactual = data.split(",")[8];
            var isadd = data.split(",")[9];
            var isamountrate = data.split(",")[10];
            var isqty = data.split(",")[11];
            var isquantal = data.split(",")[12];
            var amount = data.split(",")[13];
            $("#back-top").trigger("click");
            $("#tab2").focus();
            $("#cmbPurchaseSale").val(PSTypeId);
            $("#cmbproduct").val(ProductId);
            $("#cmbAccount").val(AccountId);
            $("#select2-cmbPurchaseSale-container").text(pstype);
            $("#select2-cmbproduct-container").text(product);
            $("#select2-cmbAccount-container").text(account);
            if (isadd == "True" || isadd == "true") {
                $("#lessdiv").hide();
                $("#adddiv").show();
                $("#rdadd").attr("checked", true);
                $("#txtAmountadd").val(amount);
            }
            else {
                $("#adddiv").hide();
                $("#lessdiv").show();
                $("#rdless").attr("checked", true);
                $("#txtAmountless").val(amount);
            }

            if (isactual == "True" || isactual == "true")
            { $("#chkDirect").attr("checked", true); }
            if (isamountrate == "True" || isamountrate == "true")
            { $("#chkAmount").attr("checked", true); }
            if (isqty == "True" || isqty == "true")
            { $("#chkquantity").attr("checked", true); }
            if (isquantal == "True" || isquantal == "true")
            { }
            $("#btnUpdate").show();
            $("#btnAssign").hide();
            $("#cmbunits").empty();
            $("#cmbunits").append("<option value=''>Select Unit</option>");
            $.ajax({
                type: "get",
                url: '../AddLessSettings/GetProductUnits',
                //url: "@Url.Action("GetProductUnits", "AddLessSettings")",
                data: {
                    id: ProductId,
                },
                success: function (data) {



                    $.each(data, function () {
                        $("#cmbunits").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                    });
                    $("#cmbunits").val(UnitId);
                    $("#select2-cmbunits-container").text(unit);
                }



            });
        }
    });
}

function getgrid()
{
    $.ajax({
        type: "get",
        url: '../Settings/GetAddlessGrid', //url: "@Url.Action("GetGrid", "AddLessSettings")",
        data: {
              
        },
    success: function (data) {
        HideLoader();
        $("#addlesstbl").html(data);
    }
});


}


function deleteAddless(id)
{

    $.ajax({
        type: "get",
        url: '../AddLessSettings/Delete',//url: "@Url.Action("Delete", "AddLessSettings")",
        data: {
        id: id,
        },
    success: function (data) {


        if (data == "success")
        {
            deleted();
            getgrid()
        }
        else if (data == "fail") { fail();}
               
    }


});         
}

function Loadddp()
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


function ChangeProduct()
{
    var id = $("#cmbproduct").val();
    $("#cmbunits").empty();
    $("#cmbunits").append("<option value=''>Select Unit</option>");
    $.ajax({
        type: "get",
        url: '../AddLessSettings/GetProductUnits',
        //url: "@Url.Action("GetProductUnits", "AddLessSettings")",
        data: {
        id: id,
        },
    success: function (data) {

                  

        $.each(data, function () {
            $("#cmbunits").append("<option value=" + this.Value + ">" + this.Text + "</option>");

        });
    }


});

   



}
function ChangeaddlessPurchase() {
    $("#cmbPurchaseSale").empty();
    if ($("#rdPurchase").is(":checked")) {
        $("#cmbproduct").val("0");
        $("#cmbunits").val("0");
        $("#cmbAccount").val("0");
        $("#select2-cmbPurchaseSale-container").html("Select");
        $("#select2-cmbproduct-container").html("Select Product");
        $("#select2-cmbunits-container").html("");
        $("#select2-cmbAccount-container").html("Select");
        $.ajax({
            type: "get",
            url: '../ProductUnitSettings/GetPSList',
            // url: "@Url.Action("GetPSList", "ProductUnitSettings")",
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
function rdSale()
{
   if( $("#rdSale").is(":checked"))
    {
        $("#cmbproduct").val("0");
        $("#cmbunits").val("0");
        $("#cmbAccount").val("0");
        $("#cmbPurchaseSale").empty();
        $("#select2-cmbPurchaseSale-container").html("Select");
        $("#select2-cmbproduct-container").html("Select Product");
        $("#select2-cmbunits-container").html("");
        $("#select2-cmbAccount-container").html("Select");
        $.ajax({
            type: "get",
            url: '../ProductUnitSettings/GetPSList',
            //url: "@Url.Action("GetPSList", "ProductUnitSettings")",
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
   else {
       $("#cmbproduct").val("0");
       $("#cmbunits").val("0");
       $("#cmbAccount").val("0");
       $("#select2-cmbPurchaseSale-container").html("Select");
       $("#select2-cmbproduct-container").html("Select Product");
       $("#select2-cmbunits-container").html("");
       $("#select2-cmbAccount-container").html("Select");
       $.ajax({
           type: "get",
           url: '../ProductUnitSettings/GetPSList',
           // url: "@Url.Action("GetPSList", "ProductUnitSettings")",
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

function rdadd()
{
    if ($("#rdadd").is(":checked")) {

        $("#txtAmountless").val("");
        $("#lessdiv").hide();
        $("#adddiv").show();

    }

}

function rdless()
{
    if ($("#rdless").is(":checked")) {
        $("#txtAmountadd").val("");
        $("#adddiv").hide();
        $("#lessdiv").show();
    }

}


function resetaddless()
{
    $("#cmbPurchaseSale").val("");
    $("#cmbAccount").val("");
    $("#chkquantity").attr("checked", false);
    $("#chkAmount").attr("checked", false);
    $("#chkDirect").attr("checked", false);
    $("#cmbproduct").val("0");
    $("#cmbunits").val("");
    $("#txtAmountadd").val("");
    $("#txtAmountless").val("");
    $("#select2-cmbPurchaseSale-container").html("Select");
    $("#select2-cmbproduct-container").html("Select Product");
    $("#select2-cmbunits-container").html("");
    $("#select2-cmbAccount-container").html("Select");

}

function SubmitAddless()
{
    $("#confirmAddless").modal("hide");
    var add = false;
    var amount = "";
    if ($("#rdless").is(":checked")) {
        add = false;

        amount = $("#txtAmountless").val();
    }
    else {
        add = true;
        amount = $("#txtAmountadd").val();
    }
    var pstypeid = $("#cmbPurchaseSale").val();
    var accountid = $("#cmbAccount").val();
    var qnty = $("#chkquantity").is(":checked");
    var actualrate = $("#chkAmount").is(":checked");
    var direct = $("#chkDirect").is(":checked");
    var product = $("#cmbproduct").val();
    var unit = $("#cmbunits").val();
    $.ajax({
        type: "get",
        url: '../AddLessSettings/save',
        data: {
            pstypeid: pstypeid,
            accountid: accountid,
            add: add,
            qnty: qnty,
            actualrate: actualrate,
            direct: direct,
            amount: amount,
            product: product,
            unit: unit,
            quantity: $("#hdnquantal").val(),
        },
        success: function (data) {
            if (data == "success") {

                success();
                resetaddless();
                getgrid()
            }
            else if (data == "edited") {
                success();
                getgrid()
            }
            else if (data == "fail") {
                fail();
            }
        }
    });
}

function Assignaddless()
{

    if ($("#cmbPurchaseSale").val() == "")
    {
        required("Select P/S");
    }
    else if ($("#cmbproduct").val()==0)
    {
        required("Select Product");
    }
    else if ($("#cmbunits").val() == null || $("#cmbunits").val()=="")
    {
        required("Select Unit");
    }
    else if ($("#cmbAccount").val()==0)
    {
        required("Select Account");
    }
    else if ( $("#rdadd").is(":checked")==true && $("#txtAmountadd").val() == "")
    {
        required("Provide Amount");
    }
    else if ($("#rdless").is(":checked") == true && $("#txtAmountless").val() == "") {
        required("Provide Amount");
    }
    else if ($("#chkquantity").is(":checked") == false && $("#chkAmount").is(":checked") == false && $("#chkDirect").is(":checked") == false) {
        $("#confirmAddless").modal("show");
        // required("Select Type");
        //notification("bottomright", "success", "fa fa-exclamation-triangle vd_yellow", "Warning", "Amount will be considered as per quantal <button class='btn btn-success'>Proceed</button>");
        $("#hdnquantal").val(1);
    }
    else {
        SubmitAddless();
    }
 
}


function chkquantity()
{
    if ($("#chkquantity").is(":checked") == true) {
        $("#chkAmount").attr("checked", false);
        $("#chkDirect").attr("checked", false);
    }

}
function chkAmount()
{
    if ($("#chkAmount").is(":checked") == true) {
        $("#chkquantity").attr("checked", false);
        $("#chkDirect").attr("checked", false);
    }
}

function Direct()
{
    if ($("#chkDirect").is(":checked") == true) {
        $("#chkquantity").attr("checked", false);
        $("#chkAmount").attr("checked", false);
    }
}







