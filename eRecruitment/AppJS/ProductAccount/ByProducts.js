

function ChangeProducts(id)
{
    var ids = $(id).val();

    $("#cmbByProducts").empty();
    $("#cmbByProducts").append("<option value='' selected>Select By Product</option>");

    $.ajax({
        url: '../ProductAccount/GetByProductsList',
        data:
            {
                id:ids,
            },
        success: function (data) {
            $.each(data, function () {
                $("#cmbByProducts").append("<option value=" + this.Value + " selected>" + this.Text + "</option>");

            });
            $("#cmbproducts").select2();
            $("#cmbByProducts").select2();
        }
    });

}

function LoadProduction() {
    $.ajax({
        type: "GET",
        url: '../ProductAccount/GetProductionSettings',
        data: {
        },
        success: function (data) {
            $("#divprocess").html(data);
            $("#cmbproducts").select2();
            $("#cmbByProducts").select2();
        }
    });
}



function AddByProduct() {


    ProductProcessSettingslist = [];
    var input = $("#cmbproducts").val();
    var output = $("#cmbByProducts").val();
    var percent = $("#txtpercent").val();
    var yielding = $("#chkyeild").is(":checked");
    var millid = $("#cmbProcess").val();
    if (input == "")
    {

        required("Select Product");
    }
    else if (millid == "") {
        required("Select Mill Unit");
    }
    else if (output == "")
    {

        required("Select ByProduct");
    }
    else if (percent == "")
    {
        required("Provide Percent(%)");
    }
    else
    {
        var process = {

            ProductInput: input,
            ProductOutput: output,
            Percent: percent,
            yeilding: yielding,
            millunit: millid
        };

        ProductProcessSettingslist.push(process);
        var Data = {
            "ProductProcessSettingslist": ProductProcessSettingslist
        };
        $.ajax({
            url: '../ProductAccount/SaveProductionSetting',
            data:
        JSON.stringify(Data),
            type: 'POST',
            async: false,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data == "success") {

                    success();
                    getgridproduction();

                }

                else if (data == "fail") {
                    fail();

                }
            }
        });
    }
}
function getgridproduction()
{
    var ids = $("#cmbProcess").val();
    var input = $("#cmbproducts").val();
    $.ajax({
        url: '../ProductAccount/GetByProductsInput', // url: "@Url.Action("GetByProductsInput", "ProductAccount")",
        data:
    {
        id: ids,
        input: input,
        },
    success: function (data) {
        $("#byproducttbl").html(data);
        $("#cmbByProducts").val("");
        $("#txtpercent").val("");
        $("#chkyeild").attr("checked",true);
    }
});
}

function ChangeMill(id)
{
    getgridproduction()
    $("#hiddensettings").show();
            
}

      
function DeleteByProduct(id)
{
    var processid = $(id).attr("id");
    $.ajax({
        url: '../ProductionProcess/DeleteOutputProcess',// url: "@Url.Action("DeleteOutputProcess", "ProductionProcess")",
        data:
    {
        id: processid,
        },
    success: function (data) {
        getgridproduction()
    }
});
}
