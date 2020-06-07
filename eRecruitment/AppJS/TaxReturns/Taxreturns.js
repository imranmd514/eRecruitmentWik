
function OnTaxChange() {
   
        $("#Consolidated").attr("checked", false);
}

function OnConsolidatchk()
{
    if ($("#cmbtax").val() == "") {
        notification("topright", "notify", "fa fa-times vd_red", "Warning", "Select Tax");
        $("#Consolidated").attr("checked", false);

    }

    else {
        if ($("#Consolidated").is(":checked")) {

            //taxdataConsolidated
            var taxtype = $("#cmbtax :selected").val();
            var frmdt = $("#FromDate").val();
            var todt = $("#ToDate").val();
            var drtot = 0;
            var crtot = 0;
           
            $("#taxdata").find("tr").each(function () {
                var dr = $(this).find("td:nth-child(9)").text();
                var cr = $(this).find("td:nth-child(10)").text();
                if (dr != "") {
                    drtot = drtot + Number(dr);
                }
                if (cr != "") {
                    crtot = crtot + Number(cr);
                }
               
            });
            $("#drtotal").html(drtot);
            $("#crtotal").html(crtot);
            var result = Math.round((crtot) - Number(drtot));
           var v= $("#cmbtax :selected").text();
            $("#taxresult").text(v +" : "+result);
                    $("#hdnmaintblConsolidated").show();
                    $("#hdnmaintbl").hide();
            //$.ajax({
            //    type: "get",
            //    url: '../TaxReturns/GetProductTaxConsolidated', //url: "@Url.Action("GetProductTaxConsolidated", "TaxReturns")",
            //    data: {
            //        taxtype: taxtype,
            //        frmdt: frmdt,
            //        todt: todt,
            //    },
            //    success: function (data) {
            //        $("#tbodycons").html(data);
                  

            //        $("#hdnmaintblConsolidated").show();
            //        $("#hdnmaintbl").hide();
                 
            //    }
            //});


        }
        else if ($("#Consolidated").is(":checked") == false) {
            $("#buttnGo").trigger("click");
        }
    }

}





function GetTaxclick() {
    if ($("#cmbtax").val() == "") {
        notification("topright", "notify", "fa fa-times vd_red", "Warning", "Select Tax");

    }

    else {


        $("#Consolidated").attr("checked", false);
        var taxtype = $("#cmbtax :selected").val();
        var frmdt = $("#FromDate").val();
        var todt = $("#ToDate").val();
        $.ajax({
            type: "get",
            url: '../TaxReturns/GetProductTax', //url: "@Url.Action("GetProductTax", "TaxReturns")",
            data: {
                taxtype: taxtype,
                frmdt: frmdt,
                todt: todt,
            },
            success: function (data) {
                $("#hdnmaintblConsolidated").hide();
                $("#hdntblConsolidated").hide();
                $("#hdnmaintbl").show();
                $("#taxdata").html(data);
                $.ajax({
                    type: "get",
                    url: '../TaxReturns/VatConsolidate',//"@Url.Action("VatConsolidate", "TaxReturns")",
                    data: {
                        taxtype: taxtype,
                        frmdt: frmdt,
                        todt: todt,
                    },
                    success: function (data) {
                        $("#hdnmaintblvat").show();
                        $("#taxdatavat").html(data);
                    }
                });
                var totaldr = 0;
                var totalcr = 0;
                $("#taxdata").find("tr").each(function () {
                    var id = $(this).attr("id").split('_')[1];

                    var drtd = $("#dr_" + id + "").text();
                    var crtd = $("#cr_" + id + "").text();
                    var amount = $("#amt_" + id + "").text();

                    totaldr = totaldr + Number(drtd);

                    totalcr = totalcr + Number(crtd);

                  

                });
                //var net
                var grandtotal = Math.round(totalcr - totaldr);
                $("#drtotal").html(totaldr);
                $("#crtotal").html(totalcr);
                $("#hdntbl").show();
                $("#tdcmbval").text($("#cmbtax :selected").text() + "- Returns :");
                $("#tdtotal").html(Number(grandtotal) + "<i class='fa fa-inr vd_green pull-right'></i>");
            }


        });
    }
}