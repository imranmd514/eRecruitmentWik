function RetriveSettings(id) {
    var i = $(id).attr("id");
        var ids = $(id).attr("id").split("_")[1];
        var psid = $("#cmbPurchaseSale").val();
        var productid = $("#cmbProducts_" + ids + "").val();
        var qty = $("#Quality_" + ids + "").val();
        var netwt = $("#NewNet_" + ids + "").val();
        var units = $("#Units_" + ids + "").val();
        var isfromsettings = $("#" + i + "").is(":checked");
        $.ajax({
            type: "get",
            url: '../Purchase_Sales/getnewsettingscuttingpop',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
            data: {
                id: ids,
                psid: psid,
                productid: productid,
                qty: qty,
                netwt: netwt,
                units: units,
                isfromsettings: $("#" + i + "").is(":checked"),
                ioproductid: 0,
                iooutproductid:0
            },
            success: function (data) {
                if ($("input:hidden[id=hdn_fromsettings_" + productrowid + "]").length != 0) {
                    $("input:hidden[id=hdn_fromsettings_" + productrowid + "]").remove();
                }
                $("#bodysection").append("<input type='hidden'  id=hdn_fromsettings_" + productrowid + ">");
                if($("#" + i + "").is(":checked"))
                {
                    $("#hdn_fromsettings_" + productrowid + "").val($("#" + i + "").is(":checked"));
                    $("#tblcutting").html(data);
                    $("#" + i + "").attr("checked",true);
                    var code = $("#lblNet_" + ids + "").text();
                    var netwt = $("#NewNet_" + ids + "").val();
                    $("#netcuttings").html("Gross wt. " + netwt + " -" + code);
                $("#myModal2").modal("show");
            }
        else
                {
                    $("#hdn_fromsettings_" + productrowid + "").val($("#" + i + "").is(":checked"));
                    $("#tblcutting").html(data);
                   
                    $("#myModal2").modal("show");
                    var code = $("#lblNet_" + ids + "").text();
                    var netwt = $("#NewNet_" + ids + "").val();
                    $("#netcuttings").html("Gross wt. " + netwt + " -" + code);
        }
            }
        });
 
}
var productrowid = 0;
var cutval = 0;

function showcuttings2(id)
{

   // var i = $(id).attr("id");

    //var ids = $(id).attr("id").split("_")[1];
    var psid = $("#cmbPurchaseSale").val();
    var productid = $("#cmbProducts_" + id + "").val();
    var qty = $("#Quality_" + id + "").val();
    var netwt = $("#NewNet_" + id + "").val();
    var units = $("#Units_" + id + "").val();
    var firsttd = $("#tr_" + id + "").find("td:first").attr("id");
    var firsttdclass = $("#tr_" + id + "").find("td:first").attr("class");
    var isfromsettings = false;
    if ($("#hdn_fromsettings_" + id + "").val() == undefined) {
        isfromsettings = false;
    }
    else if ($("#hdn_fromsettings_" + id + "").val() == "")
    {
        isfromsettings = false;
    }
    else {
        isfromsettings = $("#hdn_fromsettings_" + id + "").val();
    }
    var ioproductid = 0;
    var iooutproductid = 0;

    if (firsttd == undefined && firsttdclass==undefined) {

        ioproductid = 0;
        iooutproductid = 0;
        $.ajax({
            type: "get",
            url: '../Purchase_Sales/getnewsettingscuttingpop',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
            data: {
                id: id,
                psid: psid,
                productid: productid,
                qty: qty,
                netwt: netwt,
                units: units,
                isfromsettings: isfromsettings,
                ioproductid: ioproductid,
                iooutproductid: iooutproductid
            },
            success: function (data) {
                productrowid = id;
                $("#tblcutting").html(data);
                var code = $("#lblNet_" + id + "").text();
                var netwt = $("#NewNet_" + id + "").val();
                $("#netcuttings").html("Gross wt. " + netwt + " -" + code);
                $("#myModal2").modal("show");

                // }

            }
        });
    }
    else if(firsttd!="" && firsttdclass==undefined){

        ioproductid = Number(firsttd.split("_")[1]);
        iooutproductid = 0;
        $.ajax({
            type: "get",
            url: '../Purchase_Sales/getnewsettingscuttingpop',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
            data: {
                id: id,
                psid: psid,
                productid: productid,
                qty: qty,
                netwt: netwt,
                units: units,
                isfromsettings: isfromsettings,
                ioproductid: ioproductid,
                iooutproductid: iooutproductid
            },
            success: function (data) {
                productrowid = id;
                $("#tblcutting").html(data);
                var code = $("#lblNet_" + id + "").text();
                var netwt = $("#NewNet_" + id + "").val();
                $("#netcuttings").html("Gross wt. " + netwt + " -" + code);
                $("#myModal2").modal("show");

                // }

            }
        });

    }
    else if (firsttd == undefined && firsttdclass =="out") {

        ioproductid = 0;
        iooutproductid = -1;
        $.ajax({
            type: "get",
            url: '../Purchase_Sales/IsCuttingsset',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
            data: {
                rowid: id,
              
            },
            success: function (data) {
                if (data == "settings")
                {
                    isfromsettings = true;
                }
                else if (data == "custom")
                { isfromsettings = false;}
                else if (data == "new")
                {
                    isfromsettings = false;
                }


                if (isfromsettings == "") {
                    isfromsettings = false;
                }
                $.ajax({
                    type: "get",
                    url: '../Purchase_Sales/getnewsettingscuttingpop',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
                    data: {
                        id: id,
                        psid: psid,
                        productid: productid,
                        qty: qty,
                        netwt: netwt,
                        units: units,
                        isfromsettings: isfromsettings,
                        ioproductid: ioproductid,
                        iooutproductid: iooutproductid
                    },
                    success: function (data) {
                        productrowid = id;
                        $("#tblcutting").html(data);
                        var code = $("#lblNet_" + id + "").text();
                        var netwt = $("#NewNet_" + id + "").val();
                        $("#netcuttings").html("Gross wt. " + netwt + " -" + code);
                        $("#myModal2").modal("show");

                        // }

                    }
                });

            }
        });
    }
   
   
}


//function showcuttings2(id) {
//    if ($("#hdn_tbCuttings_" + id + "").val() == undefined) {

//        $.ajax({
//            type: "get",
//            url: '../Purchase_Sales/getnewcuttingpop',//"@Url.Action("getnewcuttingpop", "Purchase_Sales")",
//            data: {
//                id: id,
//            },
//            success: function (data) {
//                $("#tblcutting").html(data);
//                var code = $("#lblNet_" + id + "").text();
//                var netwt = $("#Net_" + id + "").val();
//                $("#netcuttings").html("Gross wt. " + netwt + " -" + code);
//                $("#myModal2").modal("show");
//                productrowid = id;
//                var tot = 0;
//                $("#tbCuttings_" + productrowid + "").find("tr").each(function () {
//                    var trlength = $(this).find("td").length - 1;
//                    var inp = Number($(this).find("td:nth-child(" + trlength + ") :input[type='text']").val());
//                    tot = tot + inp;
//                    for (var i = 1; i <= trlength; i++) {
//                        var textval = $(this).find("td:nth-child(" + i + ") :input[type='text']").val();
//                        if (textval != undefined) {
//                            var myid = $(this).find("td:nth-child(" + i + ") :input[type='text']").attr("id");
//                            $("#" + myid + "").attr("value", textval);
//                            // alert($("#" + myid + "").val());
//                        }
//                    }
//                });
//            }
//        });
//    }
//    else {

//        $("#tblcutting").html($("#hdn_tbCuttings_" + id + "").val());
//        $("#myModal2").modal("show");

//        productrowid = id;
//        var tot = 0;
//        $("#tbCuttings_" + productrowid + "").find("tr").each(function () {
//            var trlength = $(this).find("td").length - 1;
//            var inp = Number($(this).find("td:nth-child(" + trlength + ") :input[type='text']").val());
//            tot = tot + inp;
//            for (var i = 1; i <= trlength; i++) {
//                var textval = $(this).find("td:nth-child(" + i + ") :input[type='text']").val();
//                if (textval != undefined) {
//                    var myid = $(this).find("td:nth-child(" + i + ") :input[type='text']").attr("id");
//                    $("#" + myid + "").attr("value", textval);
//                    //alert($("#" + myid + "").val());
//                }
//            }
//        });

//    }
//}


function SetCuttings2() {
    var cuttinghelplist = [];
    var totalcuttings = 0;
    //alert(productrowid);
    //if ($("input:hidden[id=hdn_tbCuttings_" + productrowid + "]").length != 0) {
    //    $("input:hidden[id=hdn_tbCuttings_" + productrowid + "]").remove();
    //}
    //$("#bodysection").append("<input type='hidden'  id=hdn_tbCuttings_" + productrowid + ">");
    $("#tbCuttings_" + productrowid + "").find("tr").each(function () {

        //var Accountid = $(this).attr("id").split("_")[1];
        var Account = $(this).find("td:first").text().trim();
        var textboxcount = $(this).find("input[type='text']").length
        var calculatedvalue = "";
        var custom = "";
        var Percent = "";
        var qty = true;
        var psid = $("#cmbPurchaseSale").val();
        var productId = $("#cmbProducts_" + productrowid + "").val();
        var isretrivefromsettings = $("#Ret_" + productrowid + "").is(":checked");
        if (isretrivefromsettings == true) {
            if (Account == "Bag Cutting") {
                Percent = "";
                custom = "";
                calculatedvalue = $(this).find("td:nth-child(2) :input[type='text']").val();
                qty = $(this).find("input[type='checkbox']").is(":checked");
            }
            else if (Account == "Moisture Cutting") {
                Percent = "";
                custom = $(this).find("td:nth-child(2) :input[type='text']").val();
                calculatedvalue = $(this).find("td:nth-child(3) :input[type='text']").val();
                qty = $(this).find("input[type='checkbox']").is(":checked");
              
            }
            else if (Account == "Gidde Cuttings") {
                Percent = "";
                custom = $(this).find("td:nth-child(2) :input[type='text']").val();
                calculatedvalue = Number($(this).find("td:nth-child(3) :input[type='text']").val());
                qty = $(this).find("input[type='checkbox']").is(":checked");

            }
            else if (Account !== "Moisture Cutting" && Account !== "Bag Cutting" &&  Account !== "Gidde Cuttings") {
                Percent = "";
                custom = "";
                calculatedvalue = $(this).find("input[type='text']").val();
                qty = $(this).find("input[type='checkbox']").is(":checked");

            }
        }
        else {
            if (Account == "Bag Cutting") {
                Percent = "";// $(this).find("td:nth-child(2) :input[type='text']").val();
                custom = $(this).find("td:nth-child(2) :input[type='text']").val();
                calculatedvalue = $(this).find("td:nth-child(3) :input[type='text']").val();
                qty = $(this).find("input[type='checkbox']").is(":checked");
            }
            else if (Account == "Moisture Cutting") {
                Percent = $(this).find("td:nth-child(2) :input[type='text']").val();
                custom = $(this).find("td:nth-child(3) :input[type='text']").val();
                calculatedvalue = $(this).find("td:nth-child(4) :input[type='text']").val();
                qty = $(this).find("input[type='checkbox']").is(":checked");

            }
            else if (Account == "Gidde Cuttings") {
                Percent = $(this).find("td:nth-child(2) :input[type='text']").val();
                custom = $(this).find("td:nth-child(3) :input[type='text']").val();
                calculatedvalue = Number($(this).find("td:nth-child(4) :input[type='text']").val());
                qty = $(this).find("input[type='checkbox']").is(":checked");
            }
            else {
                Percent = "";
                custom = $(this).find("td:nth-child(2) :input[type='text']").val();
                calculatedvalue = $(this).find("td:nth-child(3) :input[type='text']").val();
                qty = $(this).find("input[type='checkbox']").is(":checked");

            }


        }

        var data = isretrivefromsettings + "," + Account + "," + Percent + "," + custom + "," + calculatedvalue + "," + qty;
        //alert(data);
        totalcuttings = Number(totalcuttings) + Number(calculatedvalue);
        var isret = 1;
        //if (isretrivefromsettings == true) {
        //    isret = 1;
        //}
        //else {
        //    isret = 2;
        //}
        //$("#hdn_tbCuttings_" + productrowid + "").val(isret);
        calculatedvalue = Math.abs(calculatedvalue);
        var cutting=
            {

                "IsRetriveFromSettings": isretrivefromsettings,
                "percent": Percent,
                "Isqty": qty,
                "custom": custom,
                "CalculatedValue": calculatedvalue,
                "CutAccount": Account



            }

        cuttinghelplist.push(cutting);
    });

    var Data = {
        "cuttinghelplist": cuttinghelplist,
        "rowid": productrowid,
      
    }
    $.ajax({
        url: '../Purchase_Sales/SavecuttingsTemp',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data == "success") {
                //netcuttings



                    var Unitcode = $("#lblNet_" + productrowid + "").text();
                    $.ajax({
                        type: "get",
                        url: '../Purchase_Sales/Getopunnitname',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
                        data: {
                            Unitcode: Unitcode,
                        },
                        success: function (data) {
                            var result = Number(totalcuttings / Number(data)).toFixed(2).replace(/\.0+$/, '');;
                            $("#cut_" + productrowid + "").html(result + " Kgs");

                            //var net = Number($("#Quintals_" + id + "").text().split(' ')[0]) - Number($("#cut_" + id + "").text().split(' ')[0]); Jan 7th modified
                            var newnet = $("#netcuttings").text();// $("#Net_" + productrowid + "").val();
                            newnet = newnet.replace("Gross wt. ", "");
                            newnet = newnet.split('-')[0];
                            var net = ((newnet) - Number(result)).toFixed(2).replace(/\.0+$/, '');;
                            $("#Net_" + productrowid + "").val(net);
                            //$("#lblNet_" + id + "").html(measure);

                           
                            calculaterate(productrowid);
                            customRate2(productrowid);
                            AmountChange(productrowid);
                            $("#closecuttings").trigger("click");
                        }
                    });


               
            }

            else if (data == "fail") {
                fail();

            }
        }
    });


}




function ResetSettings(id) {
    var ids = $(id).attr("id").split("_")[1];

    $.ajax({
        type: "get",
        url: '../Purchase_Sales/getnewcuttingpop',//"@Url.Action("getnewcuttingpop", "Purchase_Sales")",
        data: {
            id: ids,
        },
        success: function (data) {
            $("#tblcutting").html(data);
            $("#myModal2").modal("show");
        }
    });
}

function setselfvalue(id) {
    var val = $(id).attr("id");
    var pval = $("#" + val + "").val();
    //$("#" + val + "").attr("value",pval);
    // alert(pval);

}

function PerBagChange(id) {
    var newid = $(id).attr("id");
    var textval = newid.replace("chk", "txt");
    var qty = $("#Quality_" + productrowid + "").val();
    var netwt = $("#Net_" + productrowid + "").val();
    //hdncut_

    var cutu = newid.replace("chk", "hdncut"); //Number(newid.split("_")[2]);
    var cutunit = $("#" + cutu + "").val();

    if ($(id).is(":checked")) {
        var result = Number(qty * cutunit).toFixed(2).replace(/\.0+$/, '');;
       // result = result.toFixed(2).replace(/\.0+$/, '');

        $("#" + textval + "").val(result);
        $("#" + textval + "").attr("value",result);
    }
    else {
        var result = Number(netwt * cutunit).toFixed(2).replace(/\.0+$/, '');;
       // result = result.toFixed(2).replace(/\.0+$/, '');

        $("#" + textval + "").val(result);
        $("#" + textval + "").attr("value",result);
    }
    //productrowid

}


function PerBagChange2(id) {
    var newid = $(id).attr("id");
    var textval = newid.replace("chk", "txt");
    var qty = $("#Quality_" + productrowid + "").val();
    var netwt = $("#Net_" + productrowid + "").val();
    //hdncut_

    // var cutu = newid.replace("chk", "hdncut"); //Number(newid.split("_")[2]);
    var cutunit = cutval;// $("#" + cutu + "").val();

    if ($(id).is(":checked")) {
        var result = Number(qty * cutunit).toFixed(2).replace(/\.0+$/, '');;
        //result=result.toFixed(2).replace(/\.0+$/,'');
        $("#" + textval + "").val(result);
        $("#" + textval + "").attr("value",result);
    }
    else {
        var result = Number(netwt * cutunit).toFixed(2).replace(/\.0+$/, '');;
       // result = result.toFixed(2).replace(/\.0+$/, '');
        $("#" + textval + "").val(result);
        $("#" + textval + "").attr("value",result);
    }
    //productrowid

}

function getcuttingsettingpercent(id) {
    var ids = $(id).attr("id");
    var accountid = $(id).attr("id").split("_")[1];
    var pstypeid = $(id).attr("id").split("_")[2];
    var productid = $(id).attr("id").split("_")[3];
    var percent = $(id).val();

    var qty = $("#Quality_" + productrowid + "").val();
    $.ajax({
        type: "get",
        url: '../Purchase_Sales/getcuttingsettingpercent',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
        data: {
            cutid: accountid,
            percent: percent
        },
        success: function (data) {
            var result = (Number(data) * qty).toFixed(2).replace(/\.0+$/, '');
           // result = result.toFixed(2).replace(/\.0+$/, '');
            $("#txt_" + accountid + "").val(result);
            $("#txt_" + accountid + "").attr("value",result);
            cutval = data;
        }
    });
}

function getcuttingsettingbagunit(id) {
    var ids = $(id).attr("id");
    var accountid = $(id).attr("id").split("_")[1];
    var percent = $(id).val();

    var qty = $("#Quality_" + productrowid + "").val();
    $.ajax({
        type: "get",
        url: '../Purchase_Sales/getcuttingsettingbgunit',//"@Url.Action("getnewsettingscuttingpop", "Purchase_Sales")",
        data: {
            cutid: accountid,
            unit: percent
        },
        success: function (data) {
            var result = (Number(data) * qty).toFixed(2).replace(/\.0+$/, '');;
           // result = result.toFixed(2).replace(/\.0+$/, '');

            $("#txt_" + accountid + "").val(result);
            $("#txt_" + accountid + "").attr("value",result);
            cutval = data;
        }
    });
}

function getcuttingcustompercent(id) {
    var custom = $(id).attr("id");
    var acountid = $(id).attr("id").split('_')[1];
    //trcustom_5851
    var trow = $("#trcustom_" + acountid + "").find("td:first").text().trim();
    if (trow == "Moisture Cutting")
    {

         var prepercent = custom.replace("custom", "prepercent");
        var resulttxt = custom.replace("custom", "txt");
        var customval = $("#" + custom + "").val();
        var prepercentval = $("#" + prepercent + "").val();
        var diff = customval - prepercentval;
        var qty = $("#Quality_" + productrowid + "").val();
        var result = Number(qty * diff).toFixed(2).replace(/\.0+$/, '');;
        $("#" + resulttxt + "").val(result);
        $("#" + resulttxt + "").attr("value",result);
        cutval = diff;
    }
    else if (trow == "Bag Cutting")
    {
        // var prepercent = custom.replace("custom", "prepercent");
        var resulttxt = custom.replace("custom", "txt");
        var customval = $("#" + custom + "").val();
        //var prepercentval = $("#" + prepercent + "").val();
        var diff = customval;////customval - prepercentval;
        var qty = $("#Quality_" + productrowid + "").val();
        var result = Number(qty * diff).toFixed(2).replace(/\.0+$/, '');;
       
        $("#" + resulttxt + "").val(result);
        $("#" + resulttxt + "").attr("value",result);
        cutval = diff;
    }
    else if (trow == "Gidde Cuttings") {
        var prepercent = custom.replace("custom", "prepercent");
        var resulttxt = custom.replace("custom", "txt");
        var customval = $("#" + custom + "").val();
        var prepercentval = $("#" + prepercent + "").val();
        var diff = customval - prepercentval;
        var qty = $("#Quality_" + productrowid + "").val();
        var result = Math.abs(Number(qty * diff).toFixed(2).replace(/\.0+$/, ''));
        $("#" + resulttxt + "").val(result);
        $("#" + resulttxt + "").attr("value", result);
        cutval = diff;
    }
  
}


function GetCustomeOthercuttings(id) {
    var qty = $("#Quality_" + productrowid + "").val();
    var netwt = $("#Net_" + productrowid + "").val();
    var result = 0;
    var ids = $(id).attr("id").split("_")[1];
    if ($("#chkother_" + ids + "").is(":checked")) {
        var udata = $("#customcc_" + ids + "").val();
        result = Number(udata * qty).toFixed(2).replace(/\.0+$/, '');;
       // result = result.toFixed(2).replace(/\.0+$/, '');

        $("#txt_" + ids + "").val(result);
    }
    else {
        var udata = $("#customcc_" + ids + "").val();
        result = Number(udata * netwt).toFixed(2).replace(/\.0+$/, '');
       // result = result.toFixed(2).replace(/\.0+$/, '');

        $("#txt_" + ids + "").val(result);
    }
}

function PerBagChangeother(id) {
    var qty = $("#Quality_" + productrowid + "").val();
    var netwt = $("#Net_" + productrowid + "").val();
    var result = 0;
    var ids = $(id).attr("id").split("_")[1];
    if ($("#chkother_" + ids + "").is(":checked")) {
        var udata = $("#customcc_" + ids + "").val();
        result = Number(udata * qty).toFixed(2).replace(/\.0+$/, '');;
       // result = result.toFixed(2).replace(/\.0+$/, '');

        $("#txt_" + ids + "").val(result);
        $("#txt_" + ids + "").attr("value",result);
    }
    else {
        var udata = $("#customcc_" + ids + "").val();
        result = Number(udata * netwt).toFixed(2).replace(/\.0+$/, '');
       // result = result.toFixed(2).replace(/\.0+$/, '');

        $("#txt_" + ids + "").val(result);
        $("#txt_" + ids + "").attr("value",result);

    }
}