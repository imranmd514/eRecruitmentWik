function CalculateTotal(i)
{
    var total = 0;
    var qtlstotal = 0;
    var id = $(i).attr("id").split("_")[1];
    var bag = $("#hdn_" + id + "").val();
    var value = $("#bg_" + id + "").val();
    var result = 0;
    if (value != 0) {
        result = Number(bag * value) / 100;
        $("#qt_" + id + "").val(result);
    }
    else {
        $("#qt_" + id + "").val($("#qt_" + id + "").val());
    }
 
   
    $(".bags").each(function () { total = total + Number($(this).val()) });
    $(".qtls").each(function () { qtlstotal = qtlstotal + Number($(this).val()) });
    $("#Totalbagsqtls").html("<b>Total Bags: "+total+" , Total Quantals: "+ qtlstotal+"</b>");

}

function AddtoTable()
{
    $("#outputgrid").show();
    var productid = $("#cmbByProducts").val();
    var isyelding = $("#cmbByProducts").val().split("_")[1];
    var product = $("#cmbByProducts :selected").text().trim();
    var totbags = $("#Totalbagsqtls").text().split(",")[0];
    var totqtls = $("#Totalbagsqtls").text().split(",")[1];
    totbags = totbags.replace("Total Bags: ", "").trim();
    totqtls = totqtls.replace(" Total Quantals: ", "").trim();
    var godowns = $("#cmbbottomgowdown :selected").text();
    var len = $("#StockTable").find("tr").length;
    var max = 0;
    var data = "";
    $("#assignedbyproducts").find("tr").each(function () {
        $this = $(this).find("input[type='hidden']").val();
        if ($this > max) max = $this;
        var bags=$(this).find("td:nth-child(1) input[type='text']").val();
        var qtls=$(this).find("td:nth-child(2) input[type='text']").val();
        data = data +  bags + "," + qtls + "," + $(this).find("input[type='hidden']").val()+"#";
    });
    data = data +"~"+ godowns + "," + product ;
    if (len > 0) {
        if ($("#cmbbottomgowdown").val() != "") {
            var str = "";
            $("#StockTable").find("tr").each(function () {

                if ($(this).attr("id") == "row_" + productid + "") {



                    $("#row_" + productid + "").remove();
                    if (totbags == 0) {

                        $("#StockTable").append("<tr id='row_" + productid + "'><td>" + product + "</td><td>" + max + "</td><td>" + totqtls + "</td><td>" + godowns + "</td><td style='cursor:pointer' id='td_" + productid + "' onclick='Remove(this)'><i class='fa fa-trash vd_red' ></i></td><td class='hide'>" + data + "</td></tr>");
                    }
                    else {
                        $("#StockTable").append("<tr id='row_" + productid + "'><td>" + product + "</td><td>" + totbags + "</td><td>" + totqtls + "</td><td>" + godowns + "</td><td style='cursor:pointer' id='td_" + productid + "' onclick='Remove(this)'><i class='fa fa-trash vd_red' ></i></td><td class='hide'>" + data + "</td></tr>");

                    }
                    str = "same";
                    return false;
                }


            });
            if (str == "") {

                if (totbags == 0) {

                  //  var newbags=max

                    $("#StockTable").append("<tr id='row_" + productid + "'><td>" + product + "</td><td>" + max + "</td><td>" + totqtls + "</td><td>" + godowns + "</td><td style='cursor:pointer' id='td_" + productid + "' onclick='Remove(this)'><i class='fa fa-trash vd_red' ></i></td><td class='hide'>" + data + "</td><td class='hide'>"+isyelding+"</td></tr>");
                }
                else {
                    $("#StockTable").append("<tr id='row_" + productid + "'><td>" + product + "</td><td>" + totbags + "</td><td>" + totqtls + "</td><td>" + godowns + "</td><td style='cursor:pointer' id='td_" + productid + "' onclick='Remove(this)'><i class='fa fa-trash vd_red' ></i></td><td class='hide'>" + data + "</td><td class='hide'>" + isyelding + "</td></tr>");

                }

            }
        }
    }
    else {
        if ($("#cmbbottomgowdown").val() != "") {
            if (totbags != "0") {
                $("#StockTable").append("<tr id='row_" + productid + "'><td>" + product + "</td><td>" + totbags + "</td><td>" + totqtls + "</td><td>" + godowns + "</td><td style='cursor:pointer' id='td_" + productid + "' onclick='Remove(this)'><i class='fa fa-trash vd_red' ></i></td><td class='hide'>" + data + "</td><td class='hide'>" + isyelding + "</td></tr>");
            }
            else {
                $("#StockTable").append("<tr id='row_" + productid + "'><td>" + product + "</td><td>" + max + "</td><td>" + totqtls + "</td><td>" + godowns + "</td><td style='cursor:pointer' id='td_" + productid + "' onclick='Remove(this)'><i class='fa fa-trash vd_red' ></i></td><td class='hide'>" + data + "</td><td class='hide'>" + isyelding + "</td></tr>");

            }
        }
    }
    
}

function Remove(id)
{
    var i=$(id).attr("id").split("_")[1];
    $("#row_" + i + "").remove();

}

function ProduceSingle()
{

    var invalid = 0;
    $("#no").trigger("click");
   
    //Production Process Master
    var ProductionSettingId = $("#cmbProductunit").val();
    var ProductionDate = $("#txtdate").val();
    var ProductionOutput = "";
    var total = 0;
    var inputbags = 0;
    var inputdata = "";
    var Product = $("#cmbinputproduct").val();
    var gid = $("#cmbgodown").val();
    var ProductionProcessMasterId = $("#cmbProductunit").val();
    //$("#assignedbyproducts").find("tr").each(function () {
    //    var id = $(this).attr("id");
    //    var data = $(this).find("td:nth-child(6)").text();

    //    var stock = Number($(this).find("td:nth-child(3)").text());
    //    var yeilding = Number($(this).find("td:last").text());
    //    //var godown = $(this).find("td:nth-child(1)").text();
    //    //var productname = $(this).find("td:nth-child(1)").text();

    //    //var stock = Number($(this).find("input[type='text']").val());
    //    if (stock != 0) {
    //        if (yeilding == "y") {
    //            total = total + stock;
    //        }
    //        //  var godown = $(this).find('select :selected').val();
    //        ProductionOutput = ProductionOutput +data + "!";
    //    }
    //});
    //alert(ProductionOutput);
               
    var ProductionInput = "";
    var inputtotal = 0;
             
    //$("#bagsqtls").find("tr").each(function () {

    //    var qty = Number($(this).find("td:nth-child(4) input[type='text']").val());//$("#" + qq + "").val();
    //    var inputqty =  Number($(this).find("td:nth-child(3) input[type='text']").val());
    //    var inputunit =$(this).find("td:nth-child(1)").text().split('(')[1].split(' ')[0];
    //    var Product = $("#cmbinputproduct").val();
    //    var gid = $("#cmbgodown").val();
    //    inputtotal = inputtotal + qty;
    //    ProductionInput = ProductionInput + gid + "," + qty + "," + inputqty + "," + inputunit + "," + Product + ","+inputtotal+"!";
    //});
    $("#bagsqtls").find("tr").each(function () {

        var qty = Number($(this).find("td:nth-child(4) input[type='text']").val());//$("#" + qq + "").val();
        var inputqty = Number($(this).find("td:nth-child(3) input[type='text']").val());
        var inputunit = $(this).find("td:nth-child(1)").text().split('(')[1].split(' ')[0];

        var actualbags = Number($(this).find("td:nth-child(5)").text());
        var actualqty = Number($(this).find("td:nth-child(6)").text());
        if (inputqty == 0 && qty != 0) {
            inputqty = actualbags * qty / actualqty;
        }
        inputtotal = inputtotal + qty;
        inputbags = inputbags + inputqty;


        inputdata = inputdata + qty + "," + inputqty + "," + inputunit + "!";
    });
    ProductionInput = gid + "," + Product + "," + inputtotal + "," + inputbags + "#" + inputdata;
    var working = inputtotal;

              $.ajax({
                    type: "Get",
                 url: '../ProductionProcessMaster/SaveGowdownsProducts',// url: "@Url.Action("SaveGowdownsProducts", "ProductionProcessMaster")",
        data: {
        ProductionSettingId: ProductionSettingId,
        ProductionDate: ProductionDate,
        ProductionInput: ProductionInput,
        ProductionOutput: ProductionOutput,
        working: working,
        ProductionProcessMasterId: ProductionProcessMasterId,
        fromsingel: $("#fromsingle").val()
        },
    success: function (data) {
        if (data == "success") {
            notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
            $(".blockUI").hide();
            $(".blockUI blockOverlay").hide();
            $(".blockUI blockMsg blockElement").hide();
            //window.location.reload();
            clearfields();
            $('#producefromsingle').modal('hide');
        }
        else {
            $(".blockUI").hide();
            $(".blockUI blockOverlay").hide();
            $(".blockUI blockMsg blockElement").hide();
            notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in submiting Record");

        }

    }

});
//}
//else {
//    notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Error", "Select Godown");


//}

}


function ContinueMilling()
{
    $("#outputgrid").hide();
    if ($("#ckhsingle").is(":checked") == false) {

        if ($("#godownlist").find("li").length == 0) {
            notification("topright", "notify", "fa fa-times vd_red", "Warning", "Please select input stock");

        }
        else {
            if ($("#process").val() != "working") {
                $("#outputsection").show();
                $("#refresh").show();
                var inputproductid = $("#cmbinputproduct").val();
                var ProductionUnit = $("#cmbProductunit :selected").val();
                $("#cmbByProducts").empty();
                $("#cmbByProducts").append("<option value='0'>Select Byproducts</option>");
                var quantity = Number($("#godownlist").find("li").html().split("-")[0].split("=")[1]); //$("#stock").val();
                $.ajax({
                    type: "Get",
                    url: '../ProductionProcessMaster/GetByProducts',// url: "@Url.Action("GetByProducts", "ProductionProcessMaster")",
                    data: {
                    ProductionUnit: ProductionUnit,
                        //quantity: quantity,
                    inputproductid:inputproductid,
                    },
                success: function (data) {
                    //cmbByProducts
                    $.each(data, function () {

                        $("#cmbByProducts").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                    });
                }

            });
        }
    }
}
}