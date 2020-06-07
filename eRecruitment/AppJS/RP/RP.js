$("#Generaltab").hide();
$("#psspinner").hide();
$("#psspinner2").hide();
$(".blockUI").hide();
$(".blockUI blockOverlay").hide();
$(".blockUI blockMsg blockElement").hide();
$("#cmbps").select2();
$("#cmbbill").select2();
$("#txtreturndt").datepicker({
    dateFormat: "dd/mm/yy",
    defaultDate: new Date(),
    minDate: $("#ViewBagFromDateRange").val(),
    maxDate: $("#ViewBagToDateRange").val(),
    yearRange: $("#ViewBagDateRange").val(),
    changeMonth: true,
    changeYear: true,
    onClose: function (dateText, inst) {
        var validDate = $.datepicker.formatDate("dd/mm/yy", $('#txtreturndt').datepicker('getDate'));
        $('#txtreturndt').datepicker('setDate', validDate);
    },
    //maxDate: '-1d'
    onSelect: function () {
        $(this).change();

        ReceiptsChange();
        PaymentsChange();
        ContraChange();
        //$("#FromDate").val($(this).val());
        //$("#ToDate").val($(this).val());
    }
});





function GetAddLessTab()
{
    var ioid = $("#cmbBillio").val();
    $("#Addlesstab").hide();
    $("#Generaltab").show();
  
    $("#psspinner2").show();
    $.ajax({
        type: "get",
        url: '../ReceiptsPaymentsContra/GetAddlessGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
        data: {
            mode: ioid,
           
        },
        success: function (data) {
            $("#bottomgrid").html(data);
            //cashbankamount
            var cash = 0;
            var bank = 0;
            $("#tblProductGrid").find("tr").each(function () {

                var mode = $(this).find("td:nth-child(7)").text().trim();
                if (mode == "Cash") {
                    var amount = Number($(this).find("td:nth-child(4)").text());
                    cash = cash + amount;
                }
                else {

                    var amount = Number($(this).find("td:nth-child(4)").text());
                    bank = bank + amount;
                }



            });

            $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");



            $("#psspinner2").hide();
        }
    });
}

function OnBillChange()
{
    var ioid = $("#cmbBillio").val();
    GetAddLessTab()
}

function GetGeneral()
{
    $("#Addlesstab").show();
    $("#Generaltab").hide();
    var mode = 0;
    if ($("#rdReceipts").is(":checked"))
    { mode = 2 }
    else if ($("#rdPayments").is(":checked")) {
        mode = 1
    }
    else {
        mode: 3;
    }
    var dt = $("#txtreturndt").val();
    $("#psspinner2").show();
    $.ajax({
        type: "get",
        url: '../ReceiptsPaymentsContra/GetGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
        data: {
            mode: mode,
            dt: dt,

        },
        success: function (data) {
            $("#bottomgrid").html(data);
            //cashbankamount
            var cash = 0;
            var bank = 0;
            $("#tblProductGrid").find("tr").each(function () {

                var mode = $(this).find("td:nth-child(7)").text().trim();
                if (mode == "Cash") {
                    var amount = Number($(this).find("td:nth-child(4)").text());
                    cash = cash + amount;
                }
                else {

                    var amount = Number($(this).find("td:nth-child(4)").text());
                    bank = bank + amount;
                }



            });

            $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");



            $("#psspinner2").hide();
        }
    });

}
function tab1Addless() {

    GetAddLessTab();
}


function tab2Adjustments() {
    //$("#tab2").html();
    var ioid = $("#cmbBillio").val();
    $("#psspinneradj").show();
    //$("#Generaltab").show();

    if (ioid != 0) {
        $.ajax({
            type: "get",
            url: '../ReceiptsPaymentsContra/GetAdjustmentGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
            data: {
                mode: ioid,

            },
            success: function (data) {
                $("#tab2").html(data);
                $("#psspinneradj").hide();

            }
        });
    }
}

var ClassObjs = {};
var ClassNames = [];

$("#cmbcustomer").typeahead({
    source: function (query, process) {

        $.ajax({
            url: '../PurchaseSalesOrder/GetCustomers'// url: '@Url.Action("GetCustomers", "PurchaseSalesOrder")'
            , cache: false
            , success: function (data) {
						   
                ClassObjs = {};
                ClassNames = [];

                _.each(data, function (item, ix, list) {
                    ClassNames.push(item.Text);
                    ClassObjs[item.Text] = item.Value;
                });

                process(ClassNames);
            }
        });
    }
    , updater: function (selectedName) {

        $("#hdnCustomerId").val(ClassObjs[selectedName]);

        return selectedName;
    }
});
$("#addnewpersonal").click(function () {
    $.ajax({
        type: "get",
        url: '../ReceiptsPaymentsContra/GetControlstb1',//url: "@Url.Action("GetControlstb1", "ReceiptsPaymentsContra")",
        data: {
        },
    success: function (data) {
        $.fn.modal.Constructor.prototype.enforceFocus = function () { };
        $("#personalaccount").modal("show");
        $("#pbody").html(data);
        $("#NatureId").select2();
    }
});
});

$("#FromDate").datepicker({
    dateFormat: "dd/mm/yy",
    defaultDate: new Date(),
    minDate: $("#ViewBagFromDateRange").val(),
    maxDate: $("#ViewBagToDateRange").val(),
    yearRange: $("#ViewBagDateRange").val(),
    changeMonth: true,
    changeYear: true,
    onClose: function (dateText, inst) {
        var validDate = $.datepicker.formatDate("dd/mm/yy", $('#FromDate').datepicker('getDate'));
        $('#FromDate').datepicker('setDate', validDate);
    }
});

$("#ToDate").datepicker({
    dateFormat: "dd/mm/yy",
    defaultDate: new Date(),
    minDate: $("#ViewBagFromDateRange").val(),
    maxDate: $("#ViewBagToDateRange").val(),
    yearRange: $("#ViewBagDateRange").val(),
    changeMonth: true,
    changeYear: true,
    onClose: function (dateText, inst) {
        var validDate = $.datepicker.formatDate("dd/mm/yy", $('#ToDate').datepicker('getDate'));
        $('#ToDate').datepicker('setDate', validDate);
    }
});
$("#ChequeDate").datepicker({
    dateFormat: 'dd/mm/yy',
    changeMonth: true,
    changeYear: true,
    yearRange: '-100y:c+nn',
    //maxDate: '-1d'
});
$("#ChequeDate").val($("#ViewCurrentDate").val());
//ChequeDate
$("#FromDate").val($("#ViewBagFromDateRange").val());
$("#ToDate").val($("#ViewBagToDateRange").val());
$("#txtreturndt").val($("#ViewCurrentDate").val());

$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/GetPurchaseSales',// url: "@Url.Action("GetPurchaseSales", "ReceiptsandPayments")",
    data: {
    mode: 2,
    },
success: function (data) {
    $.each(data, function () {
        $("#cmbps").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
}
});
var ClassObjs = {};
var ClassNames = [];

$("#cmbcustomer").typeahead({
    source: function (query, process) {

        //get the data to populate the typeahead (plus an id value)
        $.ajax({
            url: '../PurchaseSalesOrder/GetCustomers'// url: '@Url.Action("GetCustomers", "PurchaseSalesOrder")'
            , cache: false
            , success: function (data) {
                ClassObjs = {};
                ClassNames = [];

                _.each(data, function (item, ix, list) {

                    ClassNames.push(item.Text);

                    ClassObjs[item.Text] = item.Value;
                });
                process(ClassNames);
            }
        });
    }
    , updater: function (selectedName) {

        $("#hdnCustomerId").val(ClassObjs[selectedName]);

        return selectedName;
    }
});
$("#rdcashAdjustments").on("change", function () {

    if ($("#rdcashAdjustments").is(":checked")) {
        $("#bankdetails").hide();
    }


});

$("#rdbankAdjustments").on("change", function () {
    if ($("#rdbankAdjustments").is(":checked")) {
        $("#bankdetails").show();
    }

});



var BrokerObjs = {};
var BrokerNames = [];

$("#cmbAdjustments").typeahead({
    source: function (query, process) {

        //get the data to populate the typeahead (plus an id value)
        $.ajax({
            url: '../ReceiptsandPayments/GetAccounts'// url: '@Url.Action("GetAccounts", "ReceiptsandPayments")'
            , cache: false
            , success: function (data) {
						   
                BrokerObjs = {};
                BrokerNames = [];

                _.each(data, function (item, ix, list) {

                    BrokerNames.push(item.Text);

                    BrokerObjs[item.Text] = item.Value;
                });

                //send the array of results to bootstrap for display
                process(BrokerNames);
            }
        });
    }
    , updater: function (selectedName) {

        //save the id value into the hidden field
        $("#hdnAdjustmentId").val(BrokerObjs[selectedName]);

        return selectedName;
    }
});



//$("#btnconfirm").hide();
$("#extrareturns").hide();
$("#btnconfirmcash").show();
// $("#btnconfirm").hide();



var mode = 2;
var dt = $("#txtreturndt").val();
$("#psspinner2").show();
$.ajax({
    type: "get",
    url: '../ReceiptsPaymentsContra/GetGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
    data: {
    mode: mode,
    dt: dt,

    },
success: function (data) {
    $("#bottomgrid").html(data);
    //cashbankamount
    var cash = 0;
    var bank = 0;
    $("#tblProductGrid").find("tr").each(function () {

        var mode = $(this).find("td:nth-child(7)").text().trim();
        if (mode == "Cash") {
            var amount = Number($(this).find("td:nth-child(4)").text());
            cash = cash + amount;
        }
        else {

            var amount = Number($(this).find("td:nth-child(4)").text());
            bank = bank + amount;
        }



    });

    $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");



    $("#psspinner2").hide();
}
});



$.ajax({
    type: "get",
    url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
    data: {
    },
success: function (data) {
    $.each(data, function () {
        $("#craccount").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
}
});



$("#refresh").click(function () {
    $("#select2-cmbps-container").text("Select PsType");
    $("#cmbps").val("0");
    $("#select2-cmbbill-container").text("Select PsType");
    $("#cmbbill").val("0")
    $("#FromDate").val($("#ViewCurrentDate").val());
    $("#ToDate").val($("#ViewCurrentDate").val());
    productgrid();
});


$("#ckhInward").on("change", function () {
    if ($(this).is(":checked")) {
        $("#psspinner").show();
        $("#ckhoutstanding").prop("checked", false);
        $("#ckhAdjustments").prop("checked", false);

        if ($("#rdReceipts").is(":checked"))
        { pid = 2 }
        else if ($("#rdPayments").is(":checked")) {
            pid = 1
        }

        $.ajax({
            type: "get",
            url: '../ReceiptsandPayments/GetInwardCustomersGrid',// url: "@Url.Action("GetInwardCustomersGrid", "ReceiptsandPayments")",
            data: {

            pid: pid
            },
        success: function (data) {
            //$("#tblIOGrid").show();

            if (data != "") {
                var mode = 0;
                if ($("#rdReceipts").is(":checked"))
                { mode = 2; } else if ($("#rdPayments").is(":checked"))
                { mode = 1; } else if ($("#rdContra").is(":checked"))
                { mode = 3; }
                $.ajax({
                    type: "get",
                    url: '../ReceiptsandPayments/GetPurchaseSales',
                    data: {
                    mode: mode,
                    },
                success: function (data) {
                    $.each(data, function () {
                        $("#cmbpsinward").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                    });
                }
            });



            //$("#tblIOGrid2").show();
            $("#tblIwardGrid").html(data);
            $("#psspinner").hide();
            $("#inward").modal("show")
        }
    else {

                    $("#psspinner").hide();
        notification("topright", "info", "fa fa-exclamation-triangle vd_red", "Warning", "No Inwards Found");

    }


}


});


}
else {

    $("#lblps").text("")
    $("#lblbillno").text("")
    $("#lblcustomer").text("")
}

});

$('#confirmGeneral').on('hidden.bs.modal', function () {
    // do something…
    $("#submitbuttons").find("button").attr("disabled", false);
})


$("#cmbpsinward").on("change", function () {
    $("#cmbbillinward").empty();
    var ps = $(this).val();
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetPurchaseSalesBillnos',// url: "@Url.Action("GetPurchaseSalesBillnos", "ReceiptsandPayments")",
        data: {
        ps: ps,
        },
    success: function (data) {
        $.each(data, function () {
            $("#cmbbillinward").append("<option value=" + this.Value + ">" + this.Text + "</option>");

        });
    }
});
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/GetInwardCustomersGridPSFilter',
    data: {
    pid: ps,
    },
success: function (data) {
    $("#tblIwardGrid").html(data);
}
});

});

$("#cmbbillinward").on("change", function () {

    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetInwardCustomersGridPSbill',// url: "@Url.Action("GetInwardCustomersGridPSbill", "ReceiptsandPayments")",
        data: {
        bill: $("#cmbbillinward :selected").text(),
        },
    success: function (data) {
        $("#tblIwardGrid").html(data);
    }
});

});

$("#closeBpopup").click(function () {
    $("#ckhoutstanding").attr("checked", false)

});
$('#srch-term').keyup(function () {
    searchTable3($(this).val());
});
$('#srch-term2').keyup(function () {
    searchTable2($(this).val());
});
$('#srch-term3').keyup(function () {

    searchTable($(this).val());
});
$("#btnFetch").click(function () {
    var str = ""
    $("#ckhInward").attr("checked", false);
    //find("input[type='checkbox']")
    var unbindingamount = "";
    $("#tblProductGrid2").find("tr").each(function () {

        if ($(this).attr("id").indexOf('un_') >= 0) {
            var id = $(this).attr("id");
            var custname = id.split("_")[1].trim();
            var amount = Number(id.split("_")[2].trim());
            if (amount != 0) {
                unbindingamount = unbindingamount + " " + custname + " : " + Math.round(amount, 2) + " Rs. ,"
            }
        }
        else {

            var rowid = $(this).attr("id").replace("trr_", "")
            $("#" + rowid + "").find("input[type='checkbox']").each(function () {
                if ($(this).is(":checked")) {

                    var a = $(this).attr("id").replace("chk_", "")
                    var amt = $("#" + rowid + "").find("td:last").html();
                    //if (amt.indexOf('(') >= 0) {
                    //    alert(amt);
                    //    amt = amt.split('(')[0]//.split(')')[0];

                    //}
                    //else {
                    //    amt = amt;
                    //}
                    str = str + a + "_" + amt + ",";
                }
            });
        }
        // alert($("#trr_" + rowid + "").html());


    });
    var mode = "";
    if ($("#rdcash").is(":checked")) {
        mode = "cash"
    }
    else if ($("#rdbank").is(":checked")) {
        mode = "bank"
    }
    var pid = 0;
    if ($("#rdReceipts").is(":checked")) {
        pid = 1;
    }
    else if ($("#rdPayments").is(":checked")) {
        pid = 2;
    }
    else {
        pid = 0;
    }
    var cash = 0;
    var bank = 0;
    if ($("#tblreturnscash").find("tr").length != 0) {
        cash = $("#tblreturnscash").find("tr").length;
    }
    else if ($("#tblreturns").find("tr").length != 0) {
        bank = $("#tblreturns").find("tr").length;
    }
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetCustomerGridData',//url: "@Url.Action("GetCustomerGridData", "ReceiptsandPayments")",
        data: {
        waybill: str,
        mode: mode,
        pid: pid,
            cash:cash,
            bank:bank
        },
    success: function (data) {

        var unbill = data.split("~")[1];
       
        var tbl = data.split("~")[0];
        $("#closeBpopup").trigger("click");

        if ($("#rdcash").is(":checked")) {
            if (unbill != "") {
                $("#hdnUnbilledPannel").show();
                $("#unbind").html(unbill);//unbindingamount.slice(0, -1));
              
            }
            else {
                $("#hdnUnbilledPannel").hide();
                $("#unbind").html("");
            }
            $("#extraoutstabding").hide()
            $("#extraoutstabdingcash").show()
            $("#extrareturnscash").hide()
            $("#extrareturns").hide()

            $("#submitbuttons").html("<button class='btn btn-warning' onclick='btnconfirmOutCash()'>Submit</button>");
            $("#Inwardbank").hide();
            $("#Inwardcash").hide();
            var str = "";
            if ($("#tblreturnscash").find("tr").length != 0) {

                //comehere
                $("#tblreturnscash").find("tr").each(function () {
                    var id = $(this).attr("id").split("_")[1];
                    if ($("#cmbReturnAccountsc_" + id + "").val() > 0 && $("#Receiptc_" + id + "").val() > 0) {
                        var acount = $("#cmbReturnAccountsc_" + id + "").val();
                        var accounttext = $("#cmbReturnAccountsc_" + id + " :selected").text();
                        var amount = $("#Receiptc_" + id + "").val();
                        var voucher = $("#txtvoucherc_" + id + "").val();
                        var details = $("#txtdescc_" + id + "").val();
                        var reportno = $("#txtrepnoc_" + id + "").val();
                        var reportdt = $("#txtrepdtc_" + id + "").val();
                        str = str + "<tr id='trroc_" + id + "'><td id='tdReturnAccountoc_" + id + "' ><select style='width:200px'  id='cmbReturnAccountsoc_" + id + "'  class='mustprovide'></select> </td>" +
                         "<td ><input type='text'   id='Receiptoc_" + id + "' onkeypress='return isNumberStudentMarksKey(event)' value='" + amount + "'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                      "<td><input type=text id='txtvoucheroc_" + id + "' value='" + voucher + "'/></td>" +
                    "<td><input type=text id='txtdescoc_" + id + "' value='" + details + "'/></td>" +
                     "<td class='notmonthly'><input type=text id='txtrepnooc_" + id + "' value='" + reportno + "'/></td>" +
                     "<td class='notmonthly'><input type=text id='txtrepdtoc_" + id + "' value='" + reportdt + "'/></td>" +
                            "<td><label id='txtpsoc_" + id + "'>-</label></td>" +
                           "<td><label id='lblbillnooc_" + id + "'>-</label></td>" +
                            "<td class='hide'><label id='lblioidoc_" + id + "'>-</label></td>" +
                            "<td class='hide' id='lblamtc_" + id + "'>-</td>" +
                            "<td class='hide' id='lblZAccountc_" + id + "'>-</td>" +
                            "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + id + ")'><i class='fa fa-plus'></i></button></td>" +
                                         "</tr>"
                        $("#txtrepdtc_" + id + "").datepicker({
                            dateFormat: "dd/mm/yy",
                            defaultDate: new Date(),
                            minDate: $("#ViewBagFromDateRange").val(),
                            maxDate: $("#ViewBagToDateRange").val(),
                            yearRange: $("#ViewBagDateRange").val(),
                            changeMonth: true,
                            changeYear: true,
                            onClose: function (dateText, inst) {
                                var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtc_" + id + "").datepicker('getDate'));
                                $("#txtrepdtc_" + id + "").datepicker('setDate', validDate);
                            }
                        });

                        //$.ajax({
                        //    type: "get",
                        //    url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
                        //    data: {
                        //    },
                        //    success: function (data) {
                        //        $.each(data, function () {
                        //            $("#cmbReturnAccountsoc_" + id + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                        //        });
                        //        $("#cmbReturnAccountsoc_" + id + "").val(acount);
                        //    }
                        //});
                        var ClassObjs = {};
                        var ClassNames = [];

                        $("#cmbReturnAccountsoc_" + rowid + "").typeahead({
                            source: function (query, process) {

                                $.ajax({
                                    url: '../Purchase_Sales/GetSubAccount'
                                    , data: {
                                       
                                    }
                                    , cache: false
                                    , success: function (data) {

                                        ClassObjs = {};
                                        ClassNames = [];

                                        _.each(data, function (item, ix, list) {
                                            ClassNames.push(item.Text);
                                            ClassObjs[item.Text] = item.Value;
                                        });

                                        process(ClassNames);
                                    }
                                });
                            }
                            , updater: function (selectedName) {

                                $("#hdncmbReturnAccountsoc_" + rowid + "").val(ClassObjs[selectedName]);

                                return selectedName;
                            }
                        });
                    }

                });



                $("#tbloutstandingcash").html(str + tbl);
                CalTotal(1);

            }
        }
        else if ($("#rdbank").is(":checked")) {
            if (unbill != "") {
                $("#hdnUnbilledPannel2").show();
                $("#unbind2").html(unbill);//unbindingamount.slice(0, -1));
            }
            else {
                $("#hdnUnbilledPannel2").hide();
                $("#unbind2").html("");
            }
            $("#extraoutstabding").show()
            $("#extraoutstabdingcash").hide()
            $("#extrareturnscash").hide()
            $("#extrareturns").hide()

            $("#submitbuttons").html("<button class='btn btn-success' onclick='btnconfirmOutBank()'>Submit</button>");

            $("#Inwardbank").hide();
            $("#Inwardcash").hide();
            var str = "";
            if ($("#tblreturns").find("tr").length != 0) {

                $("#tblreturns").find("tr").each(function () {
                    var id = $(this).attr("id").split("_")[1];
                    if ($("#cmbReturnAccounts_" + id + "").val() > 0 && $("#Receipt_" + id + "").val() > 0) {
                        var acount = $("#cmbReturnAccounts_" + id + "").val();
                        var accounttext = $("#cmbReturnAccounts_" + id + " :selected").text();
                        var amount = $("#Receipt_" + id + "").val();
                        var voucher = $("#txtvoucher_" + id + "").val();
                        var details = $("#txtdesc_" + id + "").val();
                        var reportno = $("#txtrepno_" + id + "").val();
                        var reportdt = $("#txtrepdt_" + id + "").val();
                        var trans = $("#cmbtrans_" + id + "").val();
                        var transtext = $("#cmbtrans_" + id + " :selected").text();
                        var checkno = $("#txtchkno_" + id + "").val();
                        var checkdt = $("#txtchkdt_" + id + "").val();

                        str = str + "<tr id='trrob_" + id + "'><td id='tdReturnAccountob_" + id + "'>"+
                            //<select style='width:200px' id='cmbReturnAccountsob_" + id + "' class='mustprovide'  >";
                       // str = str + "</select></td>" +
                        " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsob_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsc_" + rowid + "' />" +
           "<b id='cmbReturnAccountobdata_" + rowid + "'></b></td>" +

                                                         "<td ><input type='text' style='width:160px'  id='Receiptob_" + id + "' value='" + amount + "' style='width:160px' onkeypress='return isNumberStudentMarksKey(event)' class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
                                                   // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                                                      "<td><input type=text id='txtvoucherob_" + id + "' value='" + voucher + "'/></td>" +
                                                    "<td><input type=text id='txtdescob_" + id + "' style='width:160px' value='"+details+"'/></td>" +
                                                     "<td><input type=text id='txtrepnoob_" + id + "' value='" + reportno + "'/></td>" +
                                   "<td><input type=text id='txtrepdtob_" + id + "' value='" + reportdt + "'/></td>" +
                                                     "<td><select id='cmbBankob_" + id + "' style='width:160px' onchange='Getrelatedcheques(this)'>";
                        str = str + "</select></td>";
                        if ($("#rdPayments").is(":checked")) {
                            data = data + "<td id='tdchkno_" + rowid + "' ><select style='width:100px' id='ddlchknoob_" + rowid + "'></select></td>";
                        }
                        else {

                            data = data + "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchequeob_" + rowid + "'  /></td>";
                        }
                        //str = str + "<td><input type=text id='txtchequeob_" + id + "' value='" + checkno + "'/></td>";
                        str = str + "<td><input type=text id='txtchequedtob_" + id + "' value='" + checkdt + "'/></td>" +
                              "<td><label id='txtpsob_" + id + "'>-</label></td>" +
                              "<td><label id='lblbillnoob_" + id + "'>-</label></td>" +
                               "<td><label id='lblioidob_" + id + "'>-</label></td>" +
                                "<td class='hide' id='lblamtb_" + id + "'>-</td>" +
                                 "<td class='hide' id='lblZAccountb_" + id + "'>-</td>" +
                              "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddOutstandingRowid(" + id + ")'><i class='fa fa-plus'></i></button></td>" +
                                  "</tr>";
                        $("#txtrepdtob_" + id + "").datepicker({
                            dateFormat: "dd/mm/yy",
                            defaultDate: new Date(),
                            minDate: $("#ViewBagFromDateRange").val(),
                            maxDate: $("#ViewBagToDateRange").val(),
                            yearRange: $("#ViewBagDateRange").val(),
                            changeMonth: true,
                            changeYear: true,
                            onClose: function (dateText, inst) {
                                var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtc_" + id + "").datepicker('getDate'));
                                $("#txtrepdtob_" + id + "").datepicker('setDate', validDate);
                            }
                        });

                        //$.ajax({
                        //    type: "get",
                        //    url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
                        //    data: {
                        //    },
                        //    success: function (data) {
                        //        $.each(data, function () {
                        //            $("#cmbReturnAccountsob_" + id + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                        //        });
                        //        $("#cmbReturnAccountsob_" + id + "").val(acount);
                        //    }
                        //});
                        var ClassObjs = {};
                        var ClassNames = [];

                        $("#cmbReturnAccountsob_" + rowid + "").typeahead({
                            source: function (query, process) {

                                $.ajax({
                                    url: '../Purchase_Sales/GetSubAccount'
                                    , data: {
                                       
                                    }
                                    , cache: false
                                    , success: function (data) {

                                        ClassObjs = {};
                                        ClassNames = [];

                                        _.each(data, function (item, ix, list) {
                                            ClassNames.push(item.Text);
                                            ClassObjs[item.Text] = item.Value;
                                        });

                                        process(ClassNames);
                                    }
                                });
                            }
                            , updater: function (selectedName) {

                                $("#hdncmbReturnAccountsob_" + rowid + "").val(ClassObjs[selectedName]);

                                return selectedName;
                            }
                        });
                        $.ajax({
                            type: "get",
                            url: '../ReceiptsandPayments/Getbanks',//url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
                            data: {
                            },
                            success: function (data) {
                                $.each(data, function () {
                                    $("#cmbBankob_" + id + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                                });
                                $("#cmbBankob_" + id + "").val(trans);
                            }
                        });

                    }

                });




            }
            $("#tbloutstanding").html(str + tbl);
            CalTotal(1);
            $("#tbloutstanding").find("tr").each(function () {
                var id = $(this).attr("id").split("_")[1];
                $("#txtrepdtob_" + id + "").datepicker({
                    dateFormat: "dd/mm/yy",
                    defaultDate: new Date(),
                    minDate: $("#ViewBagFromDateRange").val(),
                    maxDate: $("#ViewBagToDateRange").val(),
                    yearRange: $("#ViewBagDateRange").val(),
                    changeMonth: true,
                    changeYear: true,
                    onClose: function (dateText, inst) {
                        var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtob_" + id + "").datepicker('getDate'));
                        $("#txtrepdtob_" + id + "").datepicker('setDate', validDate);
                    }
                });
                $("#txtchequedtob_" + id + "").datepicker({
                    dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    changeYear: true,
                    yearRange: '-100y:c+nn',
                    //maxDate: '-1d'
                });
                //txtrepdtob_1
                //txtchequedtob_1
            });

           
        }

        }


});




});

$("#craccount").select2();
$("#crsection").hide();



$("#ckhoutstanding").on("change", function () {
    if ($("#ckhoutstanding").is(":checked")) {
        $("#psspinner").show();

        $("#ckhAdjustments").prop("checked", false);
        $("#ckhInward").prop("checked", false);
        $("#lblps").text("")
        $("#lblbillno").text("")
        $("#lblcustomer").text("")
        var pid = 0
        if ($("#rdReceipts").is(":checked"))
        { pid = 2 }
        else if ($("#rdPayments").is(":checked")) {
            pid = 1
        }

        $.ajax({
            type: "get",
            url: '../ReceiptsPaymentsContra/GetCustomerGrid',// url: "@Url.Action("GetCustomerGrid", "ReceiptsPaymentsContra")",
            data: {

                pid: pid,
                fromrow:0
            },
            success: function (data) {
            //$("#tblIOGrid").show();
            if (data.trim() != "") {
                if (data == "fail") {
                    $("#psspinner").hide();
                    notification("topright", "info", "fa fa-exclamation-triangle vd_red", "Warning", "No Outstanding Found");
                }
                else {
                    var mode = 0;
                    if ($("#rdReceipts").is(":checked"))
                    { mode = 2; } else if ($("#rdPayments").is(":checked"))
                    { mode = 1; } else if ($("#rdContra").is(":checked"))
                    { mode = 3; }
                    $.ajax({
                        type: "get",
                        url: '../ReceiptsandPayments/GetPurchaseSales',
                        data: {
                        mode: mode,
                        },
                    success: function (data) {
                        $.each(data, function () {
                            $("#cmbpsout").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                        });
                    }
                });
                $("#FromDateout").val($("#ViewCurrentDate").val());
                $("#ToDateout").val($("#ViewCurrentDate").val());
                $("#FromDateout").datepicker({
                    dateFormat: "dd/mm/yy",
                    defaultDate: new Date(),
                    minDate: $("#ViewBagFromDateRange").val(),
                    maxDate: $("#ViewBagToDateRange").val(),
                    yearRange: $("#ViewBagDateRange").val(),
                    changeMonth: true,
                    changeYear: true,
                    onClose: function (dateText, inst) {
                        var validDate = $.datepicker.formatDate("dd/mm/yy", $("#FromDateout").datepicker('getDate'));
                        $("#FromDateout").datepicker('setDate', validDate);
                    }
                });
                $("#ToDateout").datepicker({
                    dateFormat: "dd/mm/yy",
                    defaultDate: new Date(),
                    minDate: $("#ViewBagFromDateRange").val(),
                    maxDate: $("#ViewBagToDateRange").val(),
                    yearRange: $("#ViewBagDateRange").val(),
                    changeMonth: true,
                    changeYear: true,
                    onClose: function (dateText, inst) {
                        var validDate = $.datepicker.formatDate("dd/mm/yy", $('#ToDateout').datepicker('getDate'));
                        $('#ToDateout').datepicker('setDate', validDate);
                    }
                });





                $("#tblIOGrid2").show();
                $("#tblProductGrid2").html(data);
                var amt = 0;
                $("#tblProductGrid2").find("tr").each(function () {

                    if ($(this).find("td:last").text() && $(this).attr("class")!="success") {
                        amt = amt + Number($(this).find("td:last").text());
                        // alert(amt);
                        //amt = Math.round(amt,2);
                    }


                });

                $("#outstandingtotal").html(' <label class="vd_blue pull-right">Total Amount : ' + amt + ' Rs/-</label>')






                $("#psspinner").hide();
                $("#outstanding").modal("show")
            }



        }
    else {
                    $("#psspinner").hide();
        notification("topright", "info", "fa fa-exclamation-triangle vd_red", "Warning", "No Outstanding Found");

    }
}

});

}


})






$("#cmbpsout").on("change", function () {
    var ps = $(this).val();
    $("#cmbbillout").empty();
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetPurchaseSalesBillnos',// url: "@Url.Action("GetPurchaseSalesBillnos", "ReceiptsandPayments")",
        data: {
        ps: ps,
        },
    success: function (data) {
        $.each(data, function () {
            $("#cmbbillout").append("<option value=" + this.Value + ">" + this.Text + "</option>");

        });
    }
});
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/GetCustomersGridOutPS',// url: "@Url.Action("GetCustomersGridOutPS", "ReceiptsandPayments")",
    data: {
    pid: ps,
    },
success: function (data) {
    $("#tblProductGrid2").html(data);
}
});


});

$("#cmbbillout").on("change", function () {
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetCustomersGridOutBill',// url: "@Url.Action("GetCustomersGridOutBill", "ReceiptsandPayments")",
        data: {
        bill: $("#cmbbillout :selected").text(),
        },
    success: function (data) {
        $("#tblProductGrid2").html(data);
    }
});

});



$("#rdcash").on("change", function () {
    $(".notmonthly").show();
    $(".monthly").hide();
    var ddl = $("input:hidden.mustprovide").val();
   
    var textbox = $("input.mustprovideinput").val();
    var ddltext = $("input.mustprovide").val();
    // alert(ddl);
    
    if ($("#rdcash").is(":checked")) {


        $("#tblreturns").html("");
        $("#tblreturnscash").html("");
        if ($("#tblreturnscash tr").length == 0) {
            PSReturnsCash();

        }
        else {

            var no = $("#tblreturnscash tr:nth-child(1)").attr("id").split("_")[1];
            if ($("#cmbReturnAccountsc_" + no + "").val() != "") {
                PSReturnsCash();
            }
        }
        $("#extrareturnscash").show();
        $("#extrareturns").hide();
        $("#submitbuttons").html("<button class='btn btn-info' onclick='btnconfirmcash()'>Submit</button>");
        $("#Inwardbank").hide();
        $("#Inwardcash").hide();
        $("#extraoutstabding").hide();
        $("#extraoutstabdingcash").hide();
        $("#ckhInward").prop("checked", false);
        $("#ckhoutstanding").prop("checked", false);
      
       
            $("#cmbReturnAccountsc_1").val(ddltext);
            $("#Receiptc_1").val(textbox);
            setTimeout(function () {
                $("#hdncmbReturnAccountsc_1").prop("value", ddl);
            }, 1000);
        //var ddl = $("select.mustprovide").val();
        //var textbox = $("input.mustprovide").val();
        //var ddltext = $("select.mustprovide :selected").text();
        //if ($("#rdcash").is(":checked")) {
        //    $("#rdcash").trigger("change");
        //    $("#cmbReturnAccountsc_1").val(ddl);
        //    $("#select2-cmbReturnAccountsc_1-container").text(ddltext);
        //    $("#Receiptc_1").val(textbox);
        //}
        //else if ($("#rdbank").is(":checked")) {
        //    $("#rdbank").trigger("change");
        //    $("#select2-cmbReturnAccounts_1-container").text(ddltext);
        //    $("#cmbReturnAccounts_1").val(ddl);
        //    $("#Receipt_1").val(textbox);
        //}

    }


});
$("#rdbank").on("change", function () {
    $(".notmonthly").show();
    $(".monthly").hide();
    var ddl = $("input:hidden.mustprovide").val();
   

    var textbox = $("input.mustprovideinput").val();
    var ddltext = $("input.mustprovide").val();
    
    if ($("#rdbank").is(":checked")) {

               
        $("#tblreturnscash").html("");
        $("#tblreturns").html("");
        if ($("#tblreturns tr").length == 0) {
            PSReturns();

        }
        else {
            var no = $("#tblreturns tr:nth-child(1)").attr("id").split("_")[1];
            if ($("#cmbReturnAccounts_" + no + "").val() != "") {
                PSReturns();
            }
        }
        $("#extrareturns").show();
        $("#extrareturnscash").hide();
        $("#extraoutstabding").hide();
        $("#extraoutstabdingcash").hide();
        $("#Inwardbank").hide();
        $("#Inwardcash").hide();
        $("#submitbuttons").html("<button class='btn btn-info' onclick='btnconfirm()'>Submit</button>");
        $("#ckhInward").prop("checked", false);
        $("#ckhoutstanding").prop("checked", false);
       // $("#select2-cmbReturnAccounts_1-container").text(ddltext);
        $("#cmbReturnAccounts_1").prop("value", ddltext);
        $("#hdncmbReturnAccounts_1").prop("value", ddl);
        $("#Receipt_1").val(textbox);
        setTimeout(function () {
            $("#hdncmbReturnAccounts_1").prop("value", ddl);
            $("#cmbReturnAccounts_1").prop("value",ddltext);
        }, 1000);
    }

  
    //if ($("#rdcash").is(":checked")) {
    //    $("#rdcash").trigger("change");
    //    $("#cmbReturnAccountsc_1").val(ddl);
    //    $("#select2-cmbReturnAccountsc_1-container").text(ddltext);
    //    $("#Receiptc_1").val(textbox);
    //}
    //else if ($("#rdbank").is(":checked")) {
    //    $("#rdbank").trigger("change");
    //    $("#select2-cmbReturnAccounts_1-container").text(ddltext);
    //    $("#cmbReturnAccounts_1").val(ddl);
    //    $("#Receipt_1").val(textbox);
    //}

});










$("#cmbps").on("change", function () {
    $("#psspinner2").show();
    $(".blockUI").show();
    $(".blockUI blockOverlay").show();
    $(".blockUI blockMsg blockElement").show();
    var ps = $(this).val();
    $("#cmbbill").empty();
    var mode = 0;
    if ($("#rdReceipts").is(":checked"))
    { mode = 2; } else if ($("#rdPayments").is(":checked"))
    { mode = 1; } else if ($("#rdContra").is(":checked"))
    { mode = 3; }

    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetPurchaseSalesBillnos',// url: "@Url.Action("GetPurchaseSalesBillnos", "ReceiptsandPayments")",
        data: {
        ps: ps,
        },
    success: function (data) {
        $.each(data, function () {
            $("#cmbbill").append("<option value=" + this.Value + ">" + this.Text + "</option>");

        });
    }
});
var dt = $("#txtreturndt").val();
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/GetReceiptspaymentsGridPs',//  url: "@Url.Action("GetReceiptspaymentsGridPs", "ReceiptsandPayments")",
    data: {
    dt: dt,
    ps: ps,
    mode: mode,
    },
success: function (data) {
    $("#bottomgrid").html(data);
    var cash = 0;
    var bank = 0;
    $("#tblProductGrid").find("tr").each(function () {

        var mode = $(this).find("td:nth-child(7)").text().trim();;
        if (mode == "Cash") {
            var amount = Number($(this).find("td:nth-child(4)").text());
            cash = cash + amount;
        }
        else {

            var amount = Number($(this).find("td:nth-child(4)").text());
            bank = bank + amount;
        }



    });
    $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");

    //$("#cashbankamount").html("Cash Payment: " + cash + " , Bank Payment : " + bank + "");
    $("#psspinner2").hide();
    $(".blockUI").hide();
    $(".blockUI blockOverlay").hide();
    $(".blockUI blockMsg blockElement").hide();
}
});



});

$("#cmbbill").on("change", function () {
    $("#psspinner2").show();
    $(".blockUI").show();
    $(".blockUI blockOverlay").show();
    $(".blockUI blockMsg blockElement").show();
    var dt = $("#txtreturndt").val();
    var mode = 0;
    var bill = $("#cmbbill :selected").text();
    if ($("#rdReceipts").is(":checked"))
    { mode = 2; } else if ($("#rdPayments").is(":checked"))
    { mode = 1; } else if ($("#rdContra").is(":checked"))
    { mode = 3; }
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetReceiptspaymentsGridBills',//  url: "@Url.Action("GetReceiptspaymentsGridBills", "ReceiptsandPayments")",
        data: {
        dt: dt,
        bill: bill,
        mode: mode,
        },
    success: function (data) {
        $("#bottomgrid").html(data);
        var cash = 0;
        var bank = 0;
        $("#tblProductGrid").find("tr").each(function () {

            var mode = $(this).find("td:nth-child(7)").text().trim();
            if (mode == "Cash") {
                var amount = Number($(this).find("td:nth-child(4)").text());
                cash = cash + amount;
            }
            else {

                var amount = Number($(this).find("td:nth-child(4)").text());
                bank = bank + amount;
            }



        });
        $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");

        //$("#cashbankamount").html("Cash Payment: " + cash + " , Bank Payment : " + bank + "");
        $("#psspinner2").hide();
        $(".blockUI").hide();
        $(".blockUI blockOverlay").hide();
        $(".blockUI blockMsg blockElement").hide();
    }
});

});

$("#buttnGo").click(function () {
    $("#psspinner2").show();
    //$(".blockUI").show();
    //$(".blockUI blockOverlay").show();
    //$(".blockUI blockMsg blockElement").show();
    var frmdt = $("#FromDate").val();
    var todt = $("#ToDate").val();
    var mode = 0;
    var ps = $("#cmbps").val();
    if ($("#rdReceipts").is(":checked"))
    { mode = 2; } else if ($("#rdPayments").is(":checked"))
    { mode = 1; } else if ($("#rdContra").is(":checked"))
    { mode = 3; }
    $.ajax({
        type: "get",
        url: '../ReceiptsPaymentsContra/BottomGridDateSort',//url: "@Url.Action("BottomGridDateSort", "ReceiptsPaymentsContra")",
        data: {
        frmdt: frmdt,
        todt: todt,
        mode: mode,


        },
    success: function (data) {
        $("#bottomgrid").html(data);
        $("#psspinner2").hide();
        var cash = 0;
        var bank = 0;
        $("#tblProductGrid").find("tr").each(function () {

            var mode = $(this).find("td:nth-child(7)").text().trim();
            if (mode == "Cash") {
                var amount = Number($(this).find("td:nth-child(4)").text());
                cash = cash + amount;
            }
            else {

                var amount = Number($(this).find("td:nth-child(4)").text());
                bank = bank + amount;
            }


        });
        $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");

        //$("#cashbankamount").html("Cash Payment: " + cash + " , Bank Payment : " + bank + "");


    }
});

});

$("#buttnGooout").click(function () {
    var frmdt = $("#FromDateout").val();
    var todt = $("#ToDateout").val();
    var mode = 0;
    var ps = $("#cmbpsout").val();
    if ($("#rdReceipts").is(":checked"))
    { mode = 2; } else if ($("#rdPayments").is(":checked"))
    { mode = 1; } else if ($("#rdContra").is(":checked"))
    { mode = 3; }
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetCustomersGridOutFromToDate',// url: "@Url.Action("GetCustomersGridOutFromToDate", "ReceiptsandPayments")",
        data: {
        frmdt: frmdt,
        todt: todt,
        mode: mode,
        ps: ps,

        },
    success: function (data) {
        $("#tblProductGrid2").html(data);
    }
});

});

$("#ckhAdjustments").on("change", function () {
    $("#adjtitle").text("Adjustments");
    if ($("#rdReceipts").is(":checked")) {
        if ($("#ckhAdjustments").is(":checked")) {
            $("#ckhoutstanding").prop("checked", false);
            $("#ckhInward").prop("checked", false);
            $("#Adjustmentbtn").hide();
            $("#Addlessbtn").show();
            $("#toggleAdjustment").val("0");
            $("#cmbBankAdjustments").empty();
            $.ajax({
                type: "get",
                url: '../ReceiptsandPayments/Getbanks',//  url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
                data: {
                },
            success: function (data) {
                $.each(data, function () {
                    $("#cmbBankAdjustments").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                });
            }
        });
        $("#unbillpara").html("");
        $("#lblps").html("");
        $("#lblbillno").html("");
        $("#lblcustomer").html("");
        $("#divInward").hide();
        $("#diAdjust").show();
        $("#hdnio").val("");
        $("#amountinfo").html("");
        $.fn.modal.Constructor.prototype.enforceFocus = function () { };
        $("#Adjustments").modal("show");

    }

}
else if ($("#rdPayments").is(":checked")) {
                    if ($("#ckhAdjustments").is(":checked")) {
                        if ($("#ckhAdjustments").is(":checked")) {
                            $("#ckhoutstanding").prop("checked", false);
$("#ckhInward").prop("checked", false);
$("#cmbBankAdjustments").empty();
$("#Adjustmentbtn").hide();
$("#Addlessbtn").show();
$("#toggleAdjustment").val("0");

$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/Getbanks',//  url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
    data: {
    },
success: function (data) {
    $.each(data, function () {
        $("#cmbBankAdjustments").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
}
});
$("#unbillpara").html("");
$("#lblps").html("");
$("#lblbillno").html("");
$("#lblcustomer").html("");
$("#divInward").hide();
$("#diAdjust").show();
$("#toggleAdjustment").val("0");

$("#amountinfo").html("");
$("#hdnio").val("");

$.fn.modal.Constructor.prototype.enforceFocus = function () { };
$("#Adjustments").modal("show");

}
}
}


});










$("#txtreturndt").on("change", function () {
    $("#psspinner3").show();
    $("#psspinner4").show();
    var dt = $("#txtreturndt").val();
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/getopeningclosing',// url: "@Url.Action("getopeningclosing", "ReceiptsandPayments")",
        data: {
        dt: dt,
        },
    success: function (data) {

        $("#openingbal").val(data.split(",")[0]);
        $("#closingbal").val(data.split(",")[1]);
        $("#psspinner3").hide();
        $("#psspinner4").hide();
    }
});
});
OpeningClosingBal();
PSReturnsCash();
function OpeningClosingBal() {
    var dt = $("#txtreturndt").val();
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/getopeningclosing',
        data: {
        dt: dt,
        },
    success: function (data) {
        ////alert(data);
        $("#openingbal").val(data.split(",")[0]);
        $("#closingbal").val(data.split(",")[1]);
        $("#submitbuttons").find("button").attr("disabled", false);
        $("#accountbal").html("");
        var tot = 0;
        $("input.mustprovide").each(function () {
            //alert($(this).val());
            tot = tot + Number($(this).val());
        });
        $("#totalamount").val(tot);
    }
});
}

function CalTotal(id) {
    
    var tot = 0;
    $("input.mustprovideinput").each(function () {
        //alert($(this).val());
        tot = tot + Number($(this).val());
    });
    $("#totalamount").val(tot);
}


function OnDateChange() {
    ReceiptsChange();
    PaymentsChange();
    ContraChange();

}



function PSReturnsOutstangingCash() {

    if ($("#tblreturnscash").find("tr").length == 0) {
        var rowid = 1;
        var data = "";

        data = data + "<tr id='trrc_" + rowid + "'><td id='tdReturnAccountc_" + rowid + "' >"+
          // " <select style='width:200px' class='mustprovide' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)'></select> "+
         " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />"+
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsc_" + rowid + "' />" +
           "<b id='cmbReturnAccountscdata_" + rowid + "'></b></td>" +

                         "<td ><input type='text'   id='Receiptc_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                      "<td><input type=text id='txtvoucherc_" + rowid + "'/></td>" +
                    "<td><input type=text id='txtdescc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepnoc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepdtc_" + rowid + "'/></td>" +
        "<td class='monthly' hidden='hidden'><input type='checkbox' id='chkc_" + rowid + "' /> Monthly Payment Tax</td>";
        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
                         "</tr>"
        $('#tblreturnscash').html(data);

    }
    else {
        var rowid = $("#tblreturnscash").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
        var prev = rowid - 1;
        var previous = $("#tblreturnscash tr:nth-child(" + prev + ")").attr("id");
        var deleteid = previous.split('_')[1];
        //if (prev == 1) {

        //    $("#trs_" + prev + "").find("td:last").html("");
        //}
        //else {

        $("#tblreturnscash tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRowcash(" + deleteid + ")'><i class='fa fa-trash'></i></button>");

        var data = "";
        data = data + "<tr id='trrc_" + rowid + "'><td id='tdReturnAccountc_" + rowid + "'>"+
            //"<select style='width:200px' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' class='mustprovide' ></select>"+
             " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsc_" + rowid + "' />" +
            "<b id='cmbReturnAccountscdata_" + rowid + "'></b></td>" +

        "<td ><input type='text'  id='Receiptc_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
    // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
      "<td><input type=text id='txtvoucherc_" + rowid + "'/></td>" +
                   "<td><input type='text' id='txtdescc_" + rowid + "'/></td>" +

        "<td class='notmonthly'><input type=text id='txtrepnoc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepdtc_" + rowid + "'/></td>" +
        "<td class='monthly' hidden='hidden'><input type='checkbox' id='chkc_" + rowid + "' /> Monthly Payment Tax</td>";
        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
          "</tr>"


        $('#tblreturnscash tr').last().after(data);

    }
    $("#txtrepdtc_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtc_" + rowid + "").datepicker('getDate'));
            $("#txtrepdtc_" + rowid + "").datepicker('setDate', validDate);
        }
    });
    var ClassObjs = {};
    var ClassNames = [];

    $("#cmbReturnAccountsc_" + rowid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'
                , data: {
                   
                }
                , cache: false
                , success: function (data) {

                    ClassObjs = {};
                    ClassNames = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames.push(item.Text);
                        ClassObjs[item.Text] = item.Value;
                    });

                    process(ClassNames);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdncmbReturnAccountsc_" + rowid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });
//    $.ajax({
//        type: "get",
//        url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
//        data: {
//        },
//    success: function (data) {
//        $.each(data, function () {
//            $("#cmbReturnAccountsc_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

//        });
//    }
//});
//$("#cmbReturnAccountsc_" + rowid + "").select2();
}

function PSReturnsCash() {

    if ($("#tblreturnscash").find("tr").length == 0) {
        var rowid = 1;
        var data = "";

        data = data + "<tr id='trrc_" + rowid + "'><td id='tdReturnAccountc_" + rowid + "'>"+
           // "<select style='width:200px' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' class='mustprovide'  ></select>"+
            " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsc_" + rowid + "'  />" +
           "<b id='cmbReturnAccountscdata_" + rowid + "'></b></td>" +
                         "<td ><input type='text'  id='Receiptc_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                      "<td><input type=text id='txtvoucherc_" + rowid + "'/></td>" +
                    "<td><input type=text id='txtdescc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepnoc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepdtc_" + rowid + "'/></td>" +
        "<td class='monthly' hidden='hidden'><input type='checkbox' id='chkc_" + rowid + "' /> Monthly Payment Tax</td>";

        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
                         "</tr>"
        $('#tblreturnscash').html(data);

    }
    else {
        var rowid = $("#tblreturnscash").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
        var prev = rowid - 1;
        var previous = $("#tblreturnscash tr:nth-child(" + prev + ")").attr("id");
        var deleteid = previous.split('_')[1];
        //if (prev == 1) {

        //    $("#trs_" + prev + "").find("td:last").html("");
        //}
        //else {

        $("#tblreturnscash tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRowcash(" + deleteid + ")'><i class='fa fa-trash'></i></button>");

        var data = "";
        data = data + "<tr id='trrc_" + rowid + "'><td id='tdReturnAccountc_" + rowid + "'>"+
            //"<select style='width:200px' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' class='mustprovide' ></select>"+
             " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsc_" + rowid + "' />" +
            "</td>" +

        "<td ><input type='text'  id='Receiptc_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)'/></td>" +
    // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                  "<td><input type=text id='txtvoucherc_" + rowid + "'/></td>" +
    "<td><input type='text' id='txtdescc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepnoc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepdtc_" + rowid + "'/></td>" +
         "<td class='monthly' hidden='hidden'><input type='checkbox' id='chkc_" + rowid + "' /> Monthly Payment Tax</td>";
        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
          "</tr>"


        $('#tblreturnscash tr').last().after(data);

    }
    $("#txtrepdtc_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtc_" + rowid + "").datepicker('getDate'));
            $("#txtrepdtc_" + rowid + "").datepicker('setDate', validDate);
        }
    });

//    $.ajax({
//        type: "get",
//        url: '../Purchase_Sales/GetSubAccount',//url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
//        data: {
//        },
//    success: function (data) {
//        $.each(data, function () {
//            $("#cmbReturnAccountsc_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

//        });
//    }
//});
    //    $("#cmbReturnAccountsc_" + rowid + "").select2();
    var ClassObjs = {};
    var ClassNames = [];

    $("#cmbReturnAccountsc_" + rowid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'
                , data: {
                    
                }
                , cache: false
                , success: function (data) {

                    ClassObjs = {};
                    ClassNames = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames.push(item.Text);
                        ClassObjs[item.Text] = item.Value;
                    });

                    process(ClassNames);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdncmbReturnAccountsc_" + rowid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });
    $("#Addlesstab").show();
    $("#Generaltab").hide();
}


function PSReturns() {

    if ($("#tblreturns").find("tr").length == 0) {
        var rowid = 1;
        var data = "";

        data = data + "<tr id='trr_" + rowid + "'><td id='tdReturnAccount_" + rowid + "'>"+
            //"<select style='width:200px' id='cmbReturnAccounts_" + rowid + "' onchange='AccountChange(this)' class='mustprovide' ></select>"+
               " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccounts_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccounts_" + rowid + "' />" +

           "<b id='cmbReturnAccountsdata_" + rowid + "'></b></td>" +

                         "<td ><input type='text'  id='Receipt_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                      "<td><input type=text id='txtvoucher_" + rowid + "'/></td>" +
                    "<td><input type=text id='txtdesc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepno_" + rowid + "'/></td>" +
      "<td class='notmonthly'><input type=text id='txtrepdt_" + rowid + "'/></td>" +
       "<td class='monthly' hidden='hidden'><input type='checkbox' id='chk_" + rowid + "' /> Monthly Payment Tax</td>";
        var a="cmbtrans_";
        var b="ddlchkno_";
        data = data + "<td id='tdmode_" + rowid + "'><select style='width:100px' id='cmbtrans_" + rowid + "' onchange='Getrelatedcheques(this)' ></select></td>";
        // "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchkno_" + rowid + "'  /></td>"

        if ($("#rdPayments").is(":checked")) {
            data = data + "<td id='tdchkno_" + rowid + "'><select style='width:100px' id='ddlchkno_" + rowid + "'></select></td>";
        }
        else {

            data = data + "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchkno_" + rowid + "'  /></td>";
        }

        data = data + "<td  id='tdchkdt_" + rowid + "'><input type='text' style='width:100px' id='txtchkdt_" + rowid + "'/></td>";




        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRow(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
                         "</tr>"
        $('#tblreturns').html(data);

    }
    else {
        var rowid = $("#tblreturns").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
        var prev = rowid - 1;
        var previous = $("#tblreturns tr:nth-child(" + prev + ")").attr("id");
        var deleteid = previous.split('_')[1];
        //if (prev == 1) {

        //    $("#trs_" + prev + "").find("td:last").html("");
        //}
        //else {

        $("#tblreturns tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRow(" + deleteid + ")'><i class='fa fa-trash'></i></button>");


        var data = "";
        data = data + "<tr id='trr_" + rowid + "'><td id='tdReturnAccount_" + rowid + "'>"+
           // "<select style='width:200px' id='cmbReturnAccounts_" + rowid + "' onchange='AccountChange(this)' class='mustprovide' ></select>"+
            " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccounts_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccounts_" + rowid + "' />" +
           "<b id='cmbReturnAccountsdata_" + rowid + "'></b></td>" +

        "<td ><input type='text'  id='Receipt_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
    // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
      "<td><input type=text id='txtvoucher_" + rowid + "'/></td>" +
       "<td><input type='text' id='txtdesc_" + rowid + "'/></td>" +
        "<td class='notmonthly'><input type=text id='txtrepno_" + rowid + "'/></td>" +
       "<td class='notmonthly'><input type=text id='txtrepdt_" + rowid + "'/></td>" +
        "<td class='monthly' hidden='hidden'><input type='checkbox' id='chk_" + rowid + "' /> Monthly Payment Tax</td>";


        var a="cmbtrans_";
        var b="ddlchkno_";
        data = data + "<td id='tdmode_" + rowid + "'><select style='width:100px' id='cmbtrans_" + rowid + "' onchange='Getrelatedcheques(this)' ></select></td>";
       
        //  "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchkno_" + rowid + "'  /></td>
        if ($("#rdPayments").is(":checked")) {
            data = data + "<td id='tdchkno_" + rowid + "' ><select style='width:100px' id='ddlchkno_" + rowid + "'></select></td>";
        }
        else {

            data = data + "<td id='tdchkno_" + rowid + "' ><input type='text'  id='txtchkno_" + rowid + "'  /></td>";
        }

        data = data + "<td id='tdchkdt_" + rowid + "'><input type='text' style='width:100px' id='txtchkdt_" + rowid + "'/></td>" +


    "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRow(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
   "</tr>"


        $('#tblreturns tr').last().after(data);

    }
    $("#txtrepdt_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdt_" + rowid + "").datepicker('getDate'));
            $("#txtrepdt_" + rowid + "").datepicker('setDate', validDate);
        }
    });
    $("#txtchkdt_" + rowid + "").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn',
        //maxDate: '-1d'
    });
    var ClassObjs = {};
    var ClassNames = [];

    $("#cmbReturnAccounts_" + rowid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'
                , data: {
                   
                }
                , cache: false
                , success: function (data) {

                    ClassObjs = {};
                    ClassNames = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames.push(item.Text);
                        ClassObjs[item.Text] = item.Value;
                    });

                    process(ClassNames);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdncmbReturnAccounts_" + rowid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });
//$.ajax({
//    type: "get",
//    url: '../Purchase_Sales/GetSubAccount',//url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
//    data: {
//},
//success: function (data) {
//    $.each(data, function () {
//        $("#cmbReturnAccounts_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

//    });
//}
//});
//$("#cmbReturnAccounts_" + rowid + "").select2();
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/Getbanks',//url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
    data: {
},
success: function (data) {
    $.each(data, function () {
        $("#cmbtrans_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
}
});
$("#cmbtrans_" + rowid + "").select2();
}
function AddChangeIC(row) {


    if ($("#AddIC_" + row + "").val() != "") {
        $("#LessIC_" + row + "").val("");
    }


}
function LessChangeIC(row) {


    if ($("#LessIC_" + row + "").val() != "") {
        $("#AddIC_" + row + "").val("");
    }


}
function AddChangeIB(row) {


    if ($("#AddIB_" + row + "").val() != "") {
        $("#LessIB_" + row + "").val("");
    }


}
function LessChangeIB(row) {


    if ($("#LessIB_" + row + "").val() != "") {
        $("#AddIB_" + row + "").val("");
    }


}
function AddInwardBank() {

    if ($("#tblInwardbank").find("tr").length == 0) {
        var rowid = 1;
        var data = "";

        data = data + "<tr id='trrIB_" + rowid + "'><td id='tdReturnAccountIB_" + rowid + "'>"+
            "<select style='width:200px' id='cmbReturnAccountsIB_" + rowid + "'  ></select>"+
            
            "</td>" +

                         "<td ><input type='text'  id='AddIB_" + rowid + "' onfocusout='AddChangeIB(" + rowid + ")' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                          "<td ><input type='text'  id='LessIB_" + rowid + "' onfocusout='LessChangeIB(" + rowid + ")' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                       "<td ><input type='text'  id='PercentIB_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                                                     "<td><input type=text id='txtvoucherIB_" + rowid + "'/></td>" +

                                     "<td><input type=text id='txtrepnoIB_" + rowid + "'/></td>" +
       "<td><input type=text id='txtrepdtIB_" + rowid + "'/></td>" +

        "<td id='tdmodeIB_" + rowid + "'><select style='width:100px' id='cmbtransIB_" + rowid + "' onchange='Getrelatedcheques(this)' ></select></td>";
        // "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchkno_" + rowid + "'  /></td>"

        if ($("#rdPayments").is(":checked")) {
            data = data + "<td id='tdchknoIB_" + rowid + "'><select style='width:100px' id='ddlchknoIB_" + rowid + "'></select></td>";
        }
        else {

            data = data + "<td id='tdchknoIB_" + rowid + "'><input type='text'  id='txtchknoIB_" + rowid + "'  /></td>";
        }

        data = data + "<td  id='tdchkdtIB_" + rowid + "'><input type='text' style='width:100px' id='txtchkdtIB_" + rowid + "'/></td>";




        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddInwardBank(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
                         "</tr>"
        $('#tblInwardbank').html(data);

    }
    else {
        var rowid = $("#tblInwardbank").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
        var prev = rowid - 1;
        var previous = $("#tblreturns tr:nth-child(" + prev + ")").attr("id");
        var deleteid = previous.split('_')[1];
        //if (prev == 1) {

        //    $("#trs_" + prev + "").find("td:last").html("");
        //}
        //else {

        $("#tblInwardbank tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteInwardBank(" + deleteid + ")'><i class='fa fa-trash'></i></button>");


        var data = "";
        data = data + "<tr id='trrIB_" + rowid + "'><td id='tdReturnAccountIB_" + rowid + "'><select style='width:200px' id='cmbReturnAccountsIB_" + rowid + "'  ></select></td>" +

       // "<td ><input type='text'  id='ReceiptIC_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
    // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +


                         "<td ><input type='text'  id='AddIB_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                          "<td ><input type='text'  id='LessIB_" + rowid + "' onfocusout='LessChangeIB(" + rowid + ")' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +

                       "<td ><input type='text'  id='PercentIB_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                       "<td><input type=text id='txtvoucherIB_" + rowid + "'/></td>" +
                                      "<td><input type=text id='txtrepnoIB_" + rowid + "'/></td>" +
       "<td><input type=text id='txtrepdtIB_" + rowid + "'/></td>" +


         "<td id='tdmodeIB_" + rowid + "'><select style='width:100px' id='cmbtransIB_" + rowid + "' onchange='Getrelatedcheques(this)' ></select></td>";

        //  "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchkno_" + rowid + "'  /></td>
        if ($("#rdPayments").is(":checked")) {
            data = data + "<td id='tdchknoIB_" + rowid + "' ><select style='width:100px' id='ddlchknoIB_" + rowid + "'></select></td>";
        }
        else {

            data = data + "<td id='tdchknoIB_" + rowid + "' ><input type='text'  id='txtchknoIB_" + rowid + "'  /></td>";
        }

        data = data + "<td id='tdchkdtIB_" + rowid + "'><input type='text' style='width:100px' id='txtchkdtIB_" + rowid + "'/></td>" +


    "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddInwardBank(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
   "</tr>"


        $('#tblInwardbank tr').last().after(data);

    }
    $("#txtrepdtIB_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtIB_" + rowid + "").datepicker('getDate'));
            $("#txtrepdtIB_" + rowid + "").datepicker('setDate', validDate);
        }
    });
    $("#txtchkdtIB_" + rowid + "").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn',
        //maxDate: '-1d'
    });
    //var ClassObjs = {};
    //var ClassNames = [];

    //$("#cmbReturnAccountsIB_" + rowid + "").typeahead({
    //    source: function (query, process) {

    //        $.ajax({
    //            url: '../Purchase_Sales/GetSubAccount'
    //            , data: {
                   
    //            }
    //            , cache: false
    //            , success: function (data) {

    //                ClassObjs = {};
    //                ClassNames = [];

    //                _.each(data, function (item, ix, list) {
    //                    ClassNames.push(item.Text);
    //                    ClassObjs[item.Text] = item.Value;
    //                });

    //                process(ClassNames);
    //            }
    //        });
    //    }
    //    , updater: function (selectedName) {

    //        $("#hdncmbReturnAccountsIB_" + rowid + "").val(ClassObjs[selectedName]);

    //        return selectedName;
    //    }
    //});
$.ajax({
    type: "get",
    url: '../Purchase_Sales/GetSubAccount',//url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
    data: {
},
success: function (data) {
    $.each(data, function () {
        $("#cmbReturnAccountsIB_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
    $("#cmbReturnAccountsIB_" + rowid + "").select2();
}
});
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/Getbanks',// url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
    data: {
},
success: function (data) {
    $.each(data, function () {
        $("#cmbtransIB_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
    $("#cmbtransIB_" + rowid + "").select2();
}
});
}

function AccountChange(id) {
    var myid = $(id).attr("id");
    var actid = $("#hdn" + myid + "").val();;//$(id).val();
    var texts = $("#" + myid + "").val();
   
    $.ajax({
        type: "get",
        url: '../ReceiptsPaymentsContra/IsTaxAccount',// url: "@Url.Action("IsTaxAccount", "ReceiptsPaymentsContra")",
        data: {
        id: actid
        },
    success: function (data) {

        if (data == true || data == "True") {
            if ($("#rdPayments").is(":checked")) {
                $(".notmonthly").hide();
                $(".monthly").show();

            }
            else {
                $(".notmonthly").show();
                $(".monthly").hide();
            }
        }
        else {
            $(".notmonthly").show();
            $(".monthly").hide();
        }
    }
});
$.ajax({
    type: "get",
    url: '../ReceiptsPaymentsContra/GetAccountBal',// url: "@Url.Action("GetAccountBal", "ReceiptsPaymentsContra")",
    data: {
    account: actid
},
success: function (data) {
    // alert(data);
    var msg = "";
    if (data > 0)
    {
        msg = "Credit-";
    }
    else if (data < 0)
    {
        msg = "Debit-";

    }
    $("#accountbal").text(texts + " (" + msg+" "+data+")");
}
});
}

function ValidAccount(id) {
    var actid = $(id).attr("id");
    //alert($("#" + actid + "").val());
    var proname = $("#" + actid + "").val();
    $.ajax({
        type: "get",
        url: '../Purchase_Sales/Productexists',// "@Url.Action("Productexists", "Purchase_Sales")",
        data: {

            proname: proname,
        },
        success: function (data) {
            if (data>0) {
                AccountChange(id);
            }
            else {
                $("#" + actid + "").val("");
                $("#hdn" + actid + "").val("");
                $("#accountbal").html("");
                
            }
        }
    });
}

function AddInwardCash() {
    if ($("#tblInwardcash").find("tr").length == 0) {
        var rowid = 1;
        var data = "";

        data = data + "<tr id='trrIC_" + rowid + "' style='font-size:11px'>" +

            "<td id='tdReturnAccountIC_" + rowid + "'><select style='width:200px' id='cmbReturnAccountsIC_" + rowid + "'  onchange='AccountChange(this)' class='mustprovide'></select></td>" +
            "<td ><input type='text' style='width:80px'  id='AddIC_" + rowid + "' onfocusout='AddChangeIC(" + rowid + ")' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
                          "<td ><input type='text' style='width:80px'  id='LessIC_" + rowid + "' onfocusout='LessChangeIC(" + rowid + ")' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                       "<td ><input type='text'  id='PercentIC_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                      "<td><input type=text id='txtvoucherIC_" + rowid + "'/></td>" +
                       "<td><input type=text id='txtdetailsIC_" + rowid + "'/></td>" +
                       "<td class='notmonthly'><input type=text id='txtrepnoIC_" + rowid + "'/></td>" +
       "<td class='notmonthly'><input type=text id='txtrepdtIC_" + rowid + "'/></td>" +
        "<td class='monthly' hidden='hidden'><input type='checkbox' id='chkIC_" + rowid + "' /></td>";

        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddInwardCash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
                          "</tr>"
        $('#tblInwardcash').html(data);

    }
    else {
        var rowid = $("#tblInwardcash").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
        var prev = rowid - 1;
        var previous = $("#tblInwardcash tr:nth-child(" + prev + ")").attr("id");
        var deleteid = previous.split('_')[1];
        //if (prev == 1) {

        //    $("#trs_" + prev + "").find("td:last").html("");
        //}
        //else {

        $("#tblInwardcash tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteInwardCash(" + deleteid + ")'><i class='fa fa-trash'></i></button>");


        var data = "";
        data = data + "<tr id='trrIC_" + rowid + "' style='font-size:11px'>" +
            "<td id='tdReturnAccountIC_" + rowid + "'><select style='width:200px' id='cmbReturnAccountsIC_" + rowid + "'  ></select></td>" +

       // "<td ><input type='text'  id='ReceiptIC_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
    // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +


                         "<td ><input type='text' style='width:80px' id='AddIC_" + rowid + "' onfocusout='AddChangeIC(" + rowid + ")' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                          "<td ><input type='text' style='width:80px'  id='LessIC_" + rowid + "' onfocusout='LessChangeIC(" + rowid + ")' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +
                     // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                    "<td ><input type='text'  id='PercentIC_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' /></td>" +

                      "<td><input type=text id='txtvoucherIC_" + rowid + "'/></td>" +
                       "<td><input type=text id='txtdetailsIC_" + rowid + "'/></td>" +
        "<td><input type=text id='txtrepnoIC_" + rowid + "'/></td>" +
      "<td><input type=text id='txtrepdtIC_" + rowid + "'/></td>";



        //data = data + "<td id='tdmodeIC_" + rowid + "'><select style='width:100px' id='cmbtransIC_" + rowid + "'  ></select></td>";

        ////  "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchkno_" + rowid + "'  /></td>
        //if ($("#rdPayments").is(":checked")) {
        //    data = data + "<td id='tdchknoIC_" + rowid + "' ><select style='width:100px' id='ddlchknoIC_" + rowid + "'></select></td>";
        //}
        //else {

        //    data = data + "<td id='tdchknoIC_" + rowid + "' ><input type='text'  id='txtchknoIC_" + rowid + "'  /></td>";
        //}

        //data = data + "<td id='tdchkdtIC_" + rowid + "'><input type='text' style='width:100px' id='txtchkdtIC_" + rowid + "'/></td>" +


        data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddInwardCash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
   "</tr>"


        $('#tblInwardcash tr').last().after(data);

    }

    $("#txtrepdtIC_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtIc_" + rowid + "").datepicker('getDate'));
            $("#txtrepdtIc_" + rowid + "").datepicker('setDate', validDate);
        }
    });
    $("#txtchkdtIC_" + rowid + "").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn',
        //maxDate: '-1d'
    });
    var ClassObjs = {};
    var ClassNames = [];

    //$("#cmbReturnAccountsIC_" + rowid + "").typeahead({
    //    source: function (query, process) {

    //        $.ajax({
    //            url: '../Purchase_Sales/GetSubAccount'
    //            , data: {
                   
    //            }
    //            , cache: false
    //            , success: function (data) {

    //                ClassObjs = {};
    //                ClassNames = [];

    //                _.each(data, function (item, ix, list) {
    //                    ClassNames.push(item.Text);
    //                    ClassObjs[item.Text] = item.Value;
    //                });

    //                process(ClassNames);
    //            }
    //        });
    //    }
    //    , updater: function (selectedName) {

    //        $("#hdncmbReturnAccountsIC_" + rowid + "").val(ClassObjs[selectedName]);

    //        return selectedName;
    //    }
    //});
$.ajax({
    type: "get",
    url: '../Purchase_Sales/GetSubAccount',//url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
    data: {
},
success: function (data) {
    $.each(data, function () {
        $("#cmbReturnAccountsIC_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
    $("#cmbReturnAccountsIC_" + rowid + "").select2();
}
});
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/Getbanks',//url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
    data: {
},
success: function (data) {
    $.each(data, function () {
        $("#cmbtransIC_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
    $("#cmbtransIC_" + rowid + "").select2();
}
});
}


function AddingreturnRow(row) {
    var rowid = row + 1;
    var rowids = $("#tblreturns").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
    var prev = rowids - 1;
    var previous = $("#tblreturns tr:nth-child(" + prev + ")").attr("id");
    var deleteid = previous.split('_')[1];
    //if (prev == 1) {

    //    $("#trs_" + prev + "").find("td:last").html("");
    //}
    //else {

    $("#tblreturns tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRow(" + deleteid + ")'><i class='fa fa-trash'></i></button>");


    var data = "";
    data = data + "<tr id='trr_" + rowid + "'><td id='tdReturnAccount_" + rowid + "'>"+
        //"<select style='width:200px' id='cmbReturnAccounts_" + rowid + "' onchange='AccountChange(this)' class='mustprovide' ></select>"+
         " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccounts_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccounts_" + rowid + "' />" +
        "<b id='cmbReturnAccountsdata_" + rowid + "'></b></td>" +

    "<td ><input type='text'  id='Receipt_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
// "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
  "<td><input type=text id='txtvoucher_" + rowid + "'/></td>" +
           "<td><input type='text' id='txtdesc_" + rowid + "'/></td>" +

    "<td class='notmonthly'><input type=text id='txtrepno_" + rowid + "'/></td>" +
  "<td class='notmonthly'><input type=text id='txtrepdt_" + rowid + "'/></td>" +
    "<td class='monthly' hidden='hidden'><input type='checkbox' id='chk_" + rowid + "' /> Monthly Payment Tax</td>";
    var a="cmbtrans_";
    var b="ddlchkno_";
    data = data + "<td id='tdmode_" + rowid + "'><select style='width:100px' id='cmbtrans_" + rowid + "' onchange='Getrelatedcheques(this)' ></select></td>";
    //"<td id='tdchkno_" + rowid + "' ><input type='text'  id='txtchkno_" + rowid + "'  /></td>
    if ($("#rdPayments").is(":checked")) {
        data = data + "<td id='tdchkno_" + rowid + "' ><select style='width:100px' id='ddlchkno_" + rowid + "'></select></td>";
    }
    else {

        data = data + "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchkno_" + rowid + "'  /></td>";
    }
    data = data + "<td id='tdchkdt_" + rowid + "'><input type='text' style='width:100px' id='txtchkdt_" + rowid + "'/></td>" +

     "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRow(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
      "</tr>"


    $('#tblreturns tr').last().after(data);

    $("#txtrepdt_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdt_" + rowid + "").datepicker('getDate'));
            $("#txtrepdt_" + rowid + "").datepicker('setDate', validDate);
        }
    });

    $("#txtchkdt_" + rowid + "").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn',
        //maxDate: '-1d'
    });
  
//$.ajax({
//    type: "get",
//    url: '../Purchase_Sales/GetSubAccount',//url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
//    data: {
//},
//success: function (data) {
//    $.each(data, function () {
//        $("#cmbReturnAccounts_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

//    });
//    $("#cmbReturnAccounts_" + rowid + "").select2();
//    $("#cmbReturnAccounts_" + rowid + "").focus();

//}
    //});
    var ClassObjs = {};
    var ClassNames = [];

    $("#cmbReturnAccounts_" + rowid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'
                , data: {
                   
                }
                , cache: false
                , success: function (data) {

                    ClassObjs = {};
                    ClassNames = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames.push(item.Text);
                        ClassObjs[item.Text] = item.Value;
                    });

                    process(ClassNames);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdncmbReturnAccounts_" + rowid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/Getbanks',// url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
    data: {
},
success: function (data) {
    $.each(data, function () {
        $("#cmbtrans_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
    $("#cmbtrans_" + rowid + "").select2();
}
});

var tr = $("#tblreturns tr").length;
if (tr != 1) {
    str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRow(" + tr + ")'><i class='fa fa-plus'></i></button>"+
    "<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRow(" + tr + ")'><i class='fa fa-trash'></i></button>" ;
    

    $("#tblreturns tr:last").find("td:last").html(str);

}
// PSReturns();

//}
}


function AddingreturnRowcash(row) {
    var rowid = row + 1;
    var rowids = $("#tblreturnscash").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
    var prev = rowids - 1;
    var previous = $("#tblreturnscash tr:nth-child(" + prev + ")").attr("id");
    var deleteid = previous.split('_')[1];
    //if (prev == 1) {

    //    $("#trs_" + prev + "").find("td:last").html("");
    //}
    //else {

    $("#tblreturnscash tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRowcash(" + deleteid + ")'><i class='fa fa-trash'></i></button>");


    var data = "";
    data = data + "<tr id='trrc_" + rowid + "'><td id='tdReturnAccountc_" + rowid + "'>"+
        //"<select style='width:200px' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' class='mustprovide' ></select>"+
         " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsc_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsc_" + rowid + "' />" +
        "<b id='cmbReturnAccountscdata_" + rowid + "'></b></td>" +
    "<td ><input type='text'  id='Receiptc_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
// "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
  "<td><input type=text id='txtvoucherc_" + rowid + "'/></td>" +
           "<td><input type='text' id='txtdescc_" + rowid + "'/></td>" +

    "<td class='notmonthly'><input type=text id='txtrepnoc_" + rowid + "'/></td>" +
      "<td class='notmonthly'><input type=text id='txtrepdtc_" + rowid + "'/></td>" +
    "<td class='monthly' hidden='hidden'><input type='checkbox' id='chkc_" + rowid + "' /> Monthly Payment Tax</td>";

    data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
      "</tr>"


    $('#tblreturnscash tr').last().after(data);


    $("#txtrepdtc_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtc_" + rowid + "").datepicker('getDate'));
            $("#txtrepdtc_" + rowid + "").datepicker('setDate', validDate);
        }
    });


//    $.ajax({
//        type: "get",
//        url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
//        data: {
//        },
//    success: function (data) {
//        $.each(data, function () {
//            $("#cmbReturnAccountsc_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

//        });
//    }
//});
    var ClassObjs = {};
    var ClassNames = [];

    $("#cmbReturnAccountsc_" + rowid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'
                , data: {
                   
                }
                , cache: false
                , success: function (data) {

                    ClassObjs = {};
                    ClassNames = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames.push(item.Text);
                        ClassObjs[item.Text] = item.Value;
                    });

                    process(ClassNames);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdncmbReturnAccountsc_" + rowid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });

$("#cmbReturnAccountsc_" + rowid + "").focus();

//var tr = $("#tblreturnscash tr").length;
//if (tr != 1) {

//    str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + tr + ")'><i class='fa fa-plus'></i></button>" +
//    "<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRowcash(" + tr + ")'><i class='fa fa-trash'></i></button>";
    

//    $("#tblreturnscash tr:last").find("td:last").html(str);

    //}
var tr = $("#tblreturnscash tr").length;

if (tr != 1) {
    str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + tr + ")'><i class='fa fa-plus'></i></button>" +
    "<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRowcash(" + tr + ")'><i class='fa fa-trash'></i></button>";


    $("#tblreturnscash tr:last").find("td:last").html(str);

}
else {
    str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + tr + ")'><i class='fa fa-plus'></i></button>";

    $("#tblreturnscash tr:last").find("td:last").html(str);
}
//var i = 1;
//$("#tblreturnscash tr").each(function ()
//{
//    var tr = $("#tblreturnscash tr").length;
//    if (tr != i )
//    {
//        str = "<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRowcash(" + i + ")'><i class='fa fa-trash'></i></button>";
//        // "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + i + ")'><i class='fa fa-plus'></i></button>";

//        $("#tblreturnscash tr:last").find("td:last").html(str);
//    }
//    i++;
//});



}



function DeleteReturnRow(row) {

    $("#trr_" + row + "").remove();
    var tr = $("#tblreturns tr").length;
    if (tr != 1) {

        str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRow(" + tr + ")'><i class='fa fa-plus'></i></button>" +
        "<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRow(" + tr + ")'><i class='fa fa-trash'></i></button>";
         

        $("#tblreturns tr:last").find("td:last").html(str);

    }
    else {
        str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRow(" + tr + ")'><i class='fa fa-plus'></i></button>";

        $("#tblreturns tr:last").find("td:last").html(str);
    }

}
function DeleteReturnRowcash(row) {

    $("#trrc_" + row + "").remove();
    var tr = $("#tblreturnscash tr").length;
    if (tr != 1) {
        str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + tr + ")'><i class='fa fa-plus'></i></button>" +
        "<button class='btn btn-danger btn-xs' type='button' onclick='DeleteReturnRowcash(" + tr + ")'><i class='fa fa-trash'></i></button>";
        

        $("#tblreturnscash tr:last").find("td:last").html(str);

    }
    else {
        str = "<button class='btn btn-info btn-xs'  type='button'  onclick='AddingreturnRowcash(" + tr + ")'><i class='fa fa-plus'></i></button>";

        $("#tblreturnscash tr:last").find("td:last").html(str);
    }
}
function isNumberStudentMarksKey(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    //var charec = /[A]|[a]/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
function searchTable(inputVal) {
    var table = $('#tblProductGrid');
    table.find('tr').each(function (index, row) {
        var allCells = $(row).find("td[class != 'hide']");
        if (allCells.length > 0) {
            var found = false;
            allCells.each(function (index, td) {
                var regExp = new RegExp(inputVal, 'i');
                if (regExp.test($(td).text())) {
                    found = true;
                    return false;
                }
            });
            if (found == true) {
                $(row).show();
            }
            else {
                //alert($(row).attr("id"));
                $(row).hide();
            }
        }
    });
}
function searchTable2(inputVal) {
    var table = $('#tblIwardGrid');
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
function searchTable3(inputVal) {
    var table = $('#tblProductGrid2');
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
function cancelform() {
    document.location.reload();
}

function AddOutstandingRowbank(row) {
    var rowid = row + 1;
    var rowids = $("#tbloutstanding").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
    var prev = rowids - 1;
    var previous = $("#tbloutstanding tr:nth-child(" + prev + ")").attr("id");
    var deleteid = previous.split('_')[1];


    $("#tbloutstanding tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteoutstandingRowbank(" + deleteid + ")'><i class='fa fa-trash'></i></button>");

    var data = "";
    data = data + "<tr id='trrob_" + rowid + "'><td id='tdReturnAccountob_" + rowid + "'>"+
        //<select style='width:200px' id='cmbReturnAccountsob_" + rowid + "' class='mustprovide'  ></select></td>" +
        " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsob_" + rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsob_" + rowid + "' />" +
           "<b id='cmbReturnAccountobdata_" + rowid + "'></b></td>" +



    "<td ><input type='text' style='width:160px' class='mustprovide'  onblur='CalTotal(this)' id='Receiptob_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)'  value='' /></td>" +
    // "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +
                        "<td><input type=text id='txtvoucherob_" + rowid + "'/></td>" +
                      "<td><input type=text id='txtdescob_" + rowid + "' style='width:160px'/></td>" +
    "<td><input type=text id='txtrepnoob_" + rowid + "'/></td>" +
     "<td><input type=text id='txtrepdtob_" + rowid + "'/></td>" +
    "<td><select id='cmbBankob_" + rowid + "' style='width:160px' onchange='Getrelatedcheques(this)'><option value=''>Select</option></select></td>";
    if ($("#rdPayments").is(":checked")) {
        data = data + "<td id='tdchkno_" + rowid + "' ><select style='width:100px' id='ddlchknoob_" + rowid + "'></select></td>";
    }
    else {

        data = data + "<td id='tdchkno_" + rowid + "'><input type='text'  id='txtchequeob_" + rowid + "'  /></td>";
    }
    // "<td><input type=text id='txtchequeob_" + rowid + "'/></td>" +
    data = data + "<td><input type=text id='txtchequedtob_" + rowid + "'/></td>" +
                   "<td><label id='txtpsob_" + rowid + "'>-</label></td>" +
                   "<td><label id='lblbillnoob_" + rowid + "'>-</label></td>" +
                    "<td><label id='lblioidob_" + rowid + "'>0</label></td>" +
    "<td class='hide' id='lblamtb_" + rowid + "'>0</td>";
    data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddOutstandingRowbank(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
      "</tr>"


    $('#tbloutstanding tr').last().after(data);
    CalTotal(1);

$("#txtchequedtob_" + rowid + "").datepicker({
    dateFormat: 'dd/mm/yy',
    changeMonth: true,
    changeYear: true,
    yearRange: '-100y:c+nn',
    //maxDate: '-1d'
});
$("#txtrepdtob_" + rowid + "").datepicker({
    dateFormat: "dd/mm/yy",
    defaultDate: new Date(),
    minDate: $("#ViewBagFromDateRange").val(),
    maxDate: $("#ViewBagToDateRange").val(),
    yearRange: $("#ViewBagDateRange").val(),
    changeMonth: true,
    changeYear: true,
    onClose: function (dateText, inst) {
        var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtob_" + rowid + "").datepicker('getDate'));
        $("#txtrepdtob_" + rowid + "").datepicker('setDate', validDate);
    }
});
//$.ajax({
//    type: "get",
//    url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
//    data: {
//},
//success: function (data) {
//    $.each(data, function () {
//        $("#cmbReturnAccountsob_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

//    });
//    $("#cmbReturnAccountsob_" + rowid + "").select2();
//}
    //});
var ClassObjs = {};
var ClassNames = [];

$("#cmbReturnAccountsob_" + rowid + "").typeahead({
    source: function (query, process) {

        $.ajax({
            url: '../Purchase_Sales/GetSubAccount'
            , data: {
               
            }
            , cache: false
            , success: function (data) {

                ClassObjs = {};
                ClassNames = [];

                _.each(data, function (item, ix, list) {
                    ClassNames.push(item.Text);
                    ClassObjs[item.Text] = item.Value;
                });

                process(ClassNames);
            }
        });
    }
    , updater: function (selectedName) {

        $("#hdncmbReturnAccountsob_" + rowid + "").val(ClassObjs[selectedName]);

        return selectedName;
    }
});
$.ajax({
    type: "get",
    url: '../ReceiptsandPayments/Getbanks',// url: "@Url.Action("Getbanks", "ReceiptsandPayments")",
    data: {
},
success: function (data) {
    $.each(data, function () {
        $("#cmbBankob_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

    });
    $("#cmbBankob_" + rowid + "").select2();
    $("#cmbBankob_" + rowid + "").focus();

}
});
}
function DeleteoutstandingRowbank(row) {
    $("#trrob_" + row + "").remove();
}
function DeleteOutstandingRowcash(row) {
    $("#trroc_" + row + "").remove();
    CalTotal(1);
}
function DeleteInwardBank(row) {
    $("#trrIB_" + row + "").remove();
    CalTotal(1);
}
function DeleteInwardCash(row) {
    $("#trrIC_" + row + "").remove();
    CalTotal(1);
}




function AddoutstandingRowcash(row) {
    var rowid = row + 1;
    var rowids = $("#tbloutstandingcash").find("tr").length + 1;//$('#mainTable tr:last').index() + 1;//$("#mainTable").find("tr").length
    var prev = rowids - 1;
    var previous = $("#tbloutstandingcash tr:nth-child(" + prev + ")").attr("id");
    var deleteid = previous.split('_')[1];

    $("#tbloutstandingcash tr:nth-child(" + prev + ")").find("td:last").html("<button class='btn btn-danger btn-xs' type='button' onclick='DeleteOutstandingRowcash(" + deleteid + ")'><i class='fa fa-trash'></i></button>");


    var data = "";
    data = data + "<tr id='trroc_" + rowid + "'><td id='tdReturnAccountoc_" + rowid + "'>" +
         " <input type='text'  onfocus='this.select()' class='typeahead form-control input-sm mustprovide' value='' id='cmbReturnAccountsoc_" +rowid + "' onchange='AccountChange(this)' onblur='ValidAccount(this)' autocomplete='off' data-provide='typeahead' />" +
          "<input type='hidden' class='mustprovide' id='hdncmbReturnAccountsoc_" + rowid + "'  />" +
       // "<select style='width:200px' id='cmbReturnAccountsoc_" + rowid + "' class='mustprovide' ></select>"+
        "</td>" +

    "<td ><input type='text'  id='Receiptoc_" + rowid + "' onkeypress='return isNumberStudentMarksKey(event)' style='width:160px' class='mustprovideinput' onblur='CalTotal(this)' /></td>" +
// "<td id='tdReturnVoucher_" + rowid + "'><select style='width:100px' id='cmbReturnVoucher_" + rowid + "'  ></select></td>" +



    "<td><input type=text id='txtvoucheroc_" + rowid + "'/></td>" +
                     "<td><input type=text id='txtdescoc_" + rowid + "'/></td>" +
                       "<td><input type=text id='txtrepnooc_" + rowid + "'/></td>" +
     "<td><input type=text id='txtrepdtoc_" + rowid + "'/></td>" +
                      "<td><label id='txtpsoc_" + rowid + "'>-</label></td>" +
                      "<td><label id='lblbillnooc_" + rowid + "'>-</label></td>" +
                       "<td class='hide'><label id='lblioidoc_" + rowid + "'>0</label></td>" +
    "<td class='hide' id='lblamtc_" + rowid + "'>0</td>";
    data = data + "<td><button class='btn btn-info btn-xs'  type='button'  onclick='AddoutstandingRowcash(" + rowid + ")'><i class='fa fa-plus'></i></button></td>" +
      "</tr>"


    $('#tbloutstandingcash tr').last().after(data);
    CalTotal(1);
    $("#txtrepdtoc_" + rowid + "").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: new Date(),
        minDate: $("#ViewBagFromDateRange").val(),
        maxDate: $("#ViewBagToDateRange").val(),
        yearRange: $("#ViewBagDateRange").val(),
        changeMonth: true,
        changeYear: true,
        onClose: function (dateText, inst) {
            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtoc_" + rowid + "").datepicker('getDate'));
            $("#txtrepdtoc_" + rowid + "").datepicker('setDate', validDate);
        }
    });

//    $.ajax({
//        type: "get",
//        url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
//        data: {
//        },
//    success: function (data) {
//        $.each(data, function () {
//            $("#cmbReturnAccountsoc_" + rowid + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

//        });
//        $("#cmbReturnAccountsoc_" + rowid + "").select2();
//        $("#cmbReturnAccountsoc_" + rowid + "").focus();

//    }
//});
    var ClassObjs = {};
    var ClassNames = [];

    $("#cmbReturnAccountsoc_" + rowid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'
                , data: {
                   
                }
                , cache: false
                , success: function (data) {

                    ClassObjs = {};
                    ClassNames = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames.push(item.Text);
                        ClassObjs[item.Text] = item.Value;
                    });

                    process(ClassNames);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdncmbReturnAccountsoc_" + rowid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });
}
//come here
function Getrelatedcheques(a)
{
    if ($("#rdPayments").is(":checked")) {
        var id=$(a).attr("id");
        var text=id.split("_")[0];
        var no=id.split("_")[1];
        var ddl = "";
        if(text=="cmbtrans")
        {
            ddl="ddlchkno_"+no;
           
               
        }
        else if(text=="cmbtransIB")
        { ddl="ddlchknoIB_"+no;}
        else if(text=="cmbBankob")
        {ddl="ddlchknoob_"+no;}

        var BankName = $("#" + id + "").val();
        $("#" + ddl + "").empty();
        $.ajax({
            type: "get",
            url: '../ReceiptsandPayments/GetCheques',// url: "@Url.Action("GetCheques", "ReceiptsandPayments")",
            data: {
                id:BankName,
            },
            success: function (data) {
                $.each(data, function () {
                    $("#" + ddl + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                });
            }
        });
        $("#" + ddl + "").select2();
    }
}



function fetchInward(id) {
    $(".blockUI").show();
    $(".blockUI blockOverlay").show();
    $(".blockUI blockMsg blockElement").show();
    var ps = $("#Itr_" + id + "").find(":nth-child(2)").html()
    var billno = $("#Itr_" + id + "").find(":nth-child(3)").html()
    var customer = $("#Itr_" + id + "").find(":nth-child(5)").html()

    $("#inwarddetails").show();
    $("#lblps").html("<b class='vd_blue'>Purchase/Sales Type :</b> " + ps)
    $("#lblbillno").html("<b class='vd_green'>Bill NO : </b>" + billno)
    $("#lblcustomer").html("<b class='vd_red'>Customer Name : </b>" + customer)
    $("#hdnio").val(id);


    if ($("#rdcash").is(":checked")) {
        $("#Inwardcash").show();
        $("#extrareturnscash").hide();
        $("#extrareturns").hide();

        $("#extraoutstabding").hide();
        $("#extraoutstabdingcash").hide();
        $("#Inwardbank").hide();
        $("#submitbuttons").html("<button class='btn btn-info' type='button'  onclick='btnInwardcash()'>Submit</button>");
        //extraoutstabdingcash
        AddInwardCash();
        $(".blockUI").hide();
        $(".blockUI blockOverlay").hide();
        $(".blockUI blockMsg blockElement").hide();
    }
    else if ($("#rdbank").is(":checked")) {
        $("#Inwardcash").hide();
        $("#extrareturnscash").hide();
        $("#extrareturns").hide();

        $("#extraoutstabding").hide();
        $("#extraoutstabdingcash").hide();
        $("#Inwardbank").show();

        $("#submitbuttons").html("<button class='btn btn-info' onclick='btnInwardbank()'>Submit</button>");
        AddInwardBank();
        $(".blockUI").hide();
        $(".blockUI blockOverlay").hide();
        $(".blockUI blockMsg blockElement").hide();
    }
    $("#closeInwardpopup").trigger("click");


}



function btnInwardcash() {

    var ioid = $("#hdnio").val();
    var customerid = "";

    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetCustomerId',// url: "@Url.Action("GetCustomerId", "ReceiptsandPayments")",
        data: {
        io: ioid,
        },
    success: function (data) {
        customerid = data;
        $("#no1").trigger("click");
        var JournalDetail = [];
        $("#tblInwardcash").find("tr").each(function () {
            if ($("#cmbReturnAccountsIC_" + rowid + "").val() != "0") {

                var CrAccount = "";
                var DrAccount = "";
                var Amount = 0;
                var TransactionType = 0;
                var rowid = $(this).attr("id").split('_')[1];
                var isedit = $(this).attr("id").split('_')[0];
                var JournalId = 0;
                if (isedit == "trrIC") {
                    JournalId = 0;
                }
                else {

                    var jrn = Number($(this).attr("id").split('_')[0].replace("t", ""));
                    JournalId = jrn;
                }
                var accountid = $("#cmbReturnAccountsIC_" + rowid + "").val();
                var receipt = Number($("#AddIC_" + rowid + "").val());
                var payment = Number($("#LessIC_" + rowid + "").val());
                var voucher = $("#txtVoucherIC_" + rowid + "").val();
                var ReportNo = $("#txtrepnoIC_" + rowid + "").val();
                var RepartDate = $("#txtrepdtIC_" + rowid + "").val();
                var Monthlytax = $("#chkIC_" + rowid + "").is(":checked");
                var BilPending = true;
                var Details = "";
                //if ($("#PercentIC_" + rowid + "").val() == "")
                //{
                Details = $("#txtdetailsIC_" + rowid + "").val();
                //}
                //else
                //{
                //  Details = $("#PercentIC_" + rowid + "").val();
                //}
                //txtdetailsIC_
                var JournalDate = $("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));

                if ($("#rdReceipts").is(":checked")) {
                    if (receipt == null || receipt == "") {

                        Amount = payment;
                        TransactionType = 2;
                        DrAccount = accountid;
                        //if ($("#rdcash").is(":checked")) {
                        //    CrAccount = 12;
                        //}
                        //else if ($("#rdbank").is(":checked")) {
                        CrAccount = customerid;
                        //}

                    }
                    else if (payment == null || payment == "") {
                        Amount = receipt;
                        TransactionType = 2;
                        CrAccount = accountid;

                        //if ($("#rdcash").is(":checked")) {
                        //    DrAccount = 12;
                        //}
                        //else if ($("#rdbank").is(":checked")) {
                        DrAccount = customerid;
                        // }

                    }
                }
                else if ($("#rdPayments").is(":checked")) {
                    if (receipt == null || receipt == "") {

                        Amount = payment;
                        TransactionType = 1;
                        DrAccount = customerid; //accountid;
                        //if ($("#rdcash").is(":checked")) {
                        //    CrAccount = 12;
                        //}
                        //else if ($("#rdbank").is(":checked")) {
                        CrAccount = accountid;//customerid;
                        //}

                    }
                    else if (payment == null || payment == "") {
                        Amount = receipt;
                        TransactionType = 1;
                        CrAccount = customerid; //accountid;

                        //if ($("#rdcash").is(":checked")) {
                        //    DrAccount = 12;
                        //}
                        //else if ($("#rdbank").is(":checked")) {
                        DrAccount = accountid; //customerid;
                        // }
                    }
                }
                var Datadetails = {
                    Amount: Amount,
                    CrAccount: CrAccount,
                    DrAccount: DrAccount,
                    VoucherSystemId: voucher,
                    JournalId: JournalId,
                    JournalDate: JournalDate,
                    Details: Details,
                    TransactionType: TransactionType,
                    IOMasterId: ioid,
                    ReportNo: ReportNo,
                    ReportDate: RepartDate,
                    BilPending: BilPending,
                };

                JournalDetail.push(Datadetails);

            }
        });

        var jounal = {

            "JournalDetails": JournalDetail,
            "IOMasterId": ioid
            //"VoucherSystemId":voucher
        };

        $.ajax({
            url: '../ReceiptsPaymentsContra/SaveOutstandings',// url: "@Url.Action("SaveOutstandings", "ReceiptsandPayments")",
            data:
        JSON.stringify(jounal),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            if (data.message == "ok") {

                notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
                //document.location.reload()
                OpeningClosingBal();
                setTimeout(productgrid(), 2000);
                $("#tblInwardcash").html("");
                //InwardCash();
                AddInwardCash();
                $("#cancelAdjustments").trigger("click");
            }


        },
        error: function (data) {

            notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in submitting form");
        }
    });
}
});




}

function btnconfirmcash() {
    var validamt = 0;
    var validselect = 0;

    $("input.mustprovideinput").each(function () {
        if (($(this).val() == 0 || $(this).val() == "") && ($("#rdcash").is(":checked") == true || $("#rdContra").is(":checked") == true)) {
            validamt = validamt + 1;
        }

    });
    $(".mustprovide").each(function () {
        if ($(this).val() == "" && (($("#rdcash").is(":checked") == true || $("#rdContra").is(":checked") == true))) {
            validselect = validselect + 1;
        }

    });
    if (validselect > 0) {

        required("Select Account");

    }
    else if (validamt > 0)
    { required("Invalid Amount"); }
    else {

        $("#no2").trigger("click");
        $("#hdnButton").val("btnconfirmcash");
        $("#submitbuttons").find("button").attr("disabled", true);
        $("#confirmGeneral").modal('show');
    }

    //if ($("select.mustprovide").val() == "0") {
    //    required("Select Account");
    //}
    //else if ($("input.mustprovide").val() == "")
    //{ required("Provide Amount"); }
    //else if($("input.mustprovide").val() == 0 )
    //{ required("Amount should not be Zero"); }
    //else {

    //    $("#no2").trigger("click");
    //    $("#hdnButton").val("btnconfirmcash");
    //    $("#submitbuttons").find("button").attr("disabled", true);
    //    $("#confirmGeneral").modal('show');
    //}
}



function btnconfirm() {

    var validamt = 0;
    var validselect = 0;
    $("input.mustprovide").each(function () {
        if (($(this).val() == 0 || $(this).val() == "") && ($("#rdbank").is(":checked") == true)) {
            validamt = validamt + 1;
        }

    });
    $("select.mustprovide").each(function () {
        if ($(this).val() == 0 && $("#rdbank").is(":checked") == true) {
            validselect = validselect + 1;
        }

    });
    if (validselect > 0)
    { required("Select Account"); }
    else if (validamt > 0)
    { required("Invalid Amount"); }
    else if ($("#cmbtrans_1").val() == "0")
    {
        required("Select Bank");
    }
    else {
        $("#hdnButton").val("btnconfirm");
        $("#submitbuttons").find("button").attr("disabled", true);

        $("#confirmGeneral").modal("show");
    }

}

function btnconfirmOutBank() {

    var validamt = 0;
    var validselect = 0;
    //$("input.mustprovide").each(function () {
    //    if (($(this).val() == 0 || $(this).val() == "") && $("#rdbank").is(":checked")==true) {
    //        validamt = validamt + 1;
    //    }

    //});
    //$("select.mustprovide").each(function () {
    //    if ($(this).val() == 0 && $("#rdbank").is(":checked") == true) {
    //        validselect = validselect + 1;
    //    }

    //});
    //if (validselect > 0)
    //{ required("Select Account"); }
    //else if (validamt > 0)
    //{ required("Invalid Amount"); }
    //else {
    if ($("#cmbBankob_2").val() == "" || $("#cmbBankob_2").val() == "0")
    { required("Select Bank");}
    else
    {
        $("#hdnButton").val("btnconfirmOutBank");
        $("#submitbuttons").find("button").attr("disabled", true);

        $("#confirmGeneral").modal("show");
    }
    // }

}

function popupoutstanding() {
    // $("#no5").trigger("click");
    //$(".blockUI").show();
    //$(".blockUI blockOverlay").show();
    //$(".blockUI blockMsg blockElement").show();
    var JournalDetail = [];
    var vcount = 0;
    $("#noout").trigger("click");
    $("#tbloutstandingcash").find("tr").each(function () {
        if ($("#hdncmbReturnAccountsoc_" + rowid + "").val() != 0) {

            var CrAccount = "";
            var DrAccount = "";

            var TransactionType = 0;
            var rowid = $(this).attr("id").split('_')[1];
            var accountid = $("#hdncmbReturnAccountsoc_" + rowid + "").val();
            var Amount = Number($("#Receiptoc_" + rowid + "").val());
            var BIllno = $("#lblbillnooc_" + rowid + "").text();
            var ioid = Number($("#lblioidoc_" + rowid + "").text());
            var ReportNo = $("#txtrepnooc_" + rowid + "").val();
            var RepartDate = $("#txtrepdtoc_" + rowid + "").val();//txtrepnoob_1
            var Monthlytax = $("#chkoc_" + rowid + "").is(":checked");
            var actualamount = Number($("#lblamtc_" + rowid + "").text());
            // alert(actualamount);
            var pending = false;
            //if (Amount != actualamount) {
            //    pending = true;

            //}
            //else {
            //    pending =false;
            //}
            //alert(Amount+","+actuadedertdlamount+","+pending)
            if ($("#rdReceipts").is(":checked")) {

                TransactionType = 2;
                CrAccount = accountid;
                if ($("#rdcash").is(":checked")) {
                    DrAccount = $("#ViewBagCash").val();
                } else if ($("#rdbank").is(":checked")) {
                    DrAccount = 4;
                }


            }
            else if ($("#rdPayments").is(":checked")) {

                TransactionType = 1;
                DrAccount = accountid;
                if ($("#rdcash").is(":checked")) {
                    CrAccount = $("#ViewBagCash").val();
                } else if ($("#rdbank").is(":checked")) {
                    CrAccount = 4;
                }


            }
            else if ($("#rdContra").is(":checked")) {

                TransactionType = 3;
                CrAccount = $("#craccount").val();
                DrAccount = accountid;

            }

            var voucher = $("#txtvoucheroc_" + rowid + "").val();
            if (voucher == "") {

                vcount++;
            }

            var Details = String($("#txtdescoc_" + rowid + "").val());
            var JournalDate = $("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));


            var Datadetails = {
                Amount: Amount,
                CrAccount: CrAccount,
                DrAccount: DrAccount,
                VoucherSystemId: voucher,
                JournalDate: JournalDate,
                Details: Details,
                IOMasterId: ioid,
                ReportNo: ReportNo,
                RepartDate: RepartDate,
                Monthlytaxpurchase: Monthlytax,
                TransactionType: TransactionType,
                // BilPending: pending,
            };

            JournalDetail.push(Datadetails);




        }

    });

    //if (vcount == 0) {
    var jounal = {

        "JournalDetails": JournalDetail
    };

    $.ajax({
        url: '../ReceiptsPaymentsContra/SaveOutstandings',//url: "@Url.Action("SaveOutstandings", "ReceiptsandPayments")",
        data:
    JSON.stringify(jounal),
    type: 'POST',
    contentType: 'application/json; charset=utf-8',
    success: function (data) {

        notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
        OpeningClosingBal();
        setTimeout(productgrid(), 2000);
        $("#tbloutstandingcash").html("");
        // PSReturnsOutstangingCash();
        // $("#tbloutstandingcash").html("");
        //PSReturnsOutstangingCash();

        $("#extraoutstabdingcash").hide();
        $("#extrareturnscash").show();
        $("#tblreturnscash").html("");
        PSReturnsCash();
        $("#unbind").html("");
        $("#hdnUnbilledPannel").hide();
        $("#unbind2").html("");
        $("#hdnUnbilledPannel2").hide();
        $("#unbind").hide();
        $("#unbind2").hide();
        $("#submitbuttons").html("<button class='btn btn-info' onclick='btnconfirmcash()'>Submit</button>");
        var ps = "";
        var sms = "";
        var mail = "";
        if ($("#rdReceipts").is(":checked")) {
            ps = "rep";
        }
        else if ($("#rdPayments").is(":checked")) {
            ps = "pay";
        }
        if ($("#ckhsms").is(":checked")) {
            sms = "yes";
        }
        if ($("#ckhmail").is(":checked")) {
            mail = "yes";
        }
        if ($("#ckhshowreport").is(":checked")) {
            if (ps == "rep") {
                $("#mainsection").hide();
                $("#reportsection").show();
                $("#Transactionsection").hide();
                $("#iframereport").show();
                document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVouchergenerate&pid=" + data.jid + "&total=rp";

                //redirectWindow = window.open('/stiReport/Index?form=ReceiptsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                //redirectWindow.location;
            }
            else if (ps == "pay") {
                $("#mainsection").hide();
                $("#reportsection").show();
                $("#Transactionsection").hide();
                $("#iframereport").show();
                document.getElementById('iframereport').src = "/stiReport/Index?form=PaymentsVouchergenerate&pid=" + data.jid + "&total=rp";

                //redirectWindow = window.open('/stiReport/Index?form=PaymentsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                //redirectWindow.location;
            }
        }
        setTimeout(SendingSMS(data.jid, ps, sms, mail), 1000)

    },
    error: function (data) {

        fail();
    }
});

}

function SendingSMS(jid, ps, sms, mail) {
    $.ajax({
        type: "get",
        url: '../stiReport/SendingMailRP',// url: "@Url.Action("SendingMailRP", "stiReport")",
        data: {
        jid: jid,
        ps: ps,
        sms: sms,
        mail: mail,
        },
    success: function (data) {
        $("#ckhsms").attr("checked", false);
        $("#ckhmail").attr("checked", false);
        $("#ckhshowreport").attr("checked", false);
    }
});


}

function btnconfirmOutCash() {

    $("#hdnButton").val("btnconfirmOutCash");
    $("#submitbuttons").find("button").attr("disabled", true);

    $("#confirmGeneral").modal("show");
}
function btnInwardbank() {
    $("#no6").trigger("click");
    var ioid = $("#hdnio").val();
    var JournalDetail = [];
    $("#tblInwardbank").find("tr").each(function () {
        if ($("#cmbReturnAccountsIB_" + rowid + "").val() != "0") {
            var CrAccount = "";
            var DrAccount = "";
            var Amount = 0;
            var TransactionType = 0;
            var rowid = $(this).attr("id").split('_')[1];
            var accountid = $("#cmbReturnAccountsIB_" + rowid + "").val();
            var receipt = Number($("#AddIB_" + rowid + "").val());
            var payment = Number($("#LessIB_" + rowid + "").val());
            var voucher = $("#txtVoucherIB_" + rowid + "").val();
            var mode = $("#cmbtransIB_" + rowid + "").val();
            var ReportNo = $("#txtrepnoIB_" + rowid + "").val();
            var RepartDate = $("#txtrepdtIB_" + rowid + "").val();
            var Monthlytax = $("#chkIB_" + rowid + "").is(":checked");
            var chequeno = "";
            if ($("#rdPayments").is(":checked")) {

                if ($("#ddlchkno_" + rowid + " :selected").text() != "Select Cheque") {
                    chequeno = $("#ddlchknoIB_" + rowid + " :selected").text() + "~d";
                }
            }
            else {
                chequeno = $("#txtchknoIB_" + rowid + "").val();
            }
            var chequedt = $("#txtchkdtIB_" + rowid + "").val();
            var Details = $("#PercentIB_" + rowid + "").val();
            var JournalDate = $("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));

            if (receipt == null || receipt == "") {
                Amount = payment;
                TransactionType = 1;
                DrAccount = accountid;

                if ($("#rdcash").is(":checked")) {
                    CrAccount = $("#ViewBagCash").val();
                }
                else if ($("#rdbank").is(":checked")) {
                    CrAccount = 4;
                }
            }
            else if (payment == null || payment == "") {
                Amount = receipt;
                TransactionType = 2;
                CrAccount = accountid;
                if ($("#rdcash").is(":checked")) {
                    DrAccount = $("#ViewBagCash").val();
                }
                else if ($("#rdbank").is(":checked")) {
                    DrAccount = 4;
                }
            }
            var Datadetails = {
                Amount: Amount,
                CrAccount: CrAccount,
                DrAccount: DrAccount,
                VoucherSystemId: voucher,
                JournalDate: JournalDate,
                Details: Details,
                Bank: mode,
                TransactionType: TransactionType,
                ChequeNo: chequeno,
                ChequeDate: chequedt,
                IOMasterId: ioid,
                ReportNo: ReportNo,
                RepartDate: RepartDate,
                Monthlytaxpurchase: Monthlytax,
            };

            JournalDetail.push(Datadetails);

        }
    });

    var jounal = {

        "JournalDetails": JournalDetail,
        "IOMasterId": ioid
        //"VoucherSystemId":voucher
    };

    $.ajax({
        url: '../ReceiptsPaymentsContra/Save',// url: "@Url.Action("Save", "ReceiptsPaymentsContra")",
        data:
    JSON.stringify(jounal),
    type: 'POST',
    contentType: 'application/json; charset=utf-8',
    success: function (data) {

        if (data.message == "ok") {
            //$(".blockUI").hide();
            //$(".blockUI blockOverlay").hide();
            //$(".blockUI blockMsg blockElement").hide();
            OpeningClosingBal();
            setTimeout(productgrid(), 2000);
            $("#tblInwardbank").html("");

            Inwardbank();
            notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
            var ps = "";
            var sms = "";
            var mail = "";
            if ($("#rdReceipts").is(":checked")) {
                ps = "rep";
            }
            else if ($("#rdPayments").is(":checked")) {
                ps = "pay";
            }
            if ($("#ckhsms").is(":checked")) {
                sms = "yes";
            }
            if ($("#ckhmail").is(":checked")) {
                mail = "yes";
            }
            if ($("#ckhshowreport").is(":checked")) {
                if (ps == "rep") {
                    $("#mainsection").hide();
                    $("#reportsection").show();
                    $("#Transactionsection").hide();
                    $("#iframereport").show();
                    document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVouchergenerate&pid=" + data.jid + "&total=rp";

                    //redirectWindow = window.open('/stiReport/Index?form=ReceiptsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                    //redirectWindow.location;
                }
                else if (ps == "pay") {
                    $("#mainsection").hide();
                    $("#reportsection").show();
                    $("#Transactionsection").hide();
                    $("#iframereport").show();
                    document.getElementById('iframereport').src = "/stiReport/Index?form=PaymentsVouchergenerate&pid=" + data.jid + "&total=rp";

                    //redirectWindow = window.open('/stiReport/Index?form=PaymentsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                    //redirectWindow.location;
                }
            }
            $.ajax({
                type: "get",
                url: '../stiReport/SendingMailRP',//  url: "@Url.Action("SendingMailRP", "stiReport")",
                data: {
                jid: data.jid,
                ps: ps,
                sms: sms,
                mail: mail,
                },
            success: function (data) {
                $("#ckhsms").attr("checked", false);
                $("#ckhmail").attr("checked", false);
                $("#ckhshowreport").attr("checked", false);
            }
        });
    }
},
error: function (data) {
    notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in submitting form");
}
});

}

$("#yes").click(function () {
    $("#no").trigger("click");
    $(".blockUI").show();
    $(".blockUI blockOverlay").show();
    $(".blockUI blockMsg blockElement").show();
    var id = $("#deletingid").val();
    $.ajax({
        type: "POST",
        url: '../ReceiptsandPayments/DeleteFromJournal',// url: "@Url.Action("DeleteFromJournal", "ReceiptsandPayments")",
        data: {
        id: id,
        },
    success: function (data) {
        if (data == "success") {
            $(".blockUI").hide();
            $(".blockUI blockOverlay").hide();
            $(".blockUI blockMsg blockElement").hide();
            notification("topright", "info", "fa fa-info-circle vd_blue", "Info Notification", "Record Deleted Successfully");
            OpeningClosingBal();
            setTimeout(productgrid(), 2000);
        }
        else {
            $(".blockUI").hide();
            $(".blockUI blockOverlay").hide();
            $(".blockUI blockMsg blockElement").hide();
            notification("topright", "info", "fa fa-times vd_red", "Error", "Error in Record Deletion");

        }

    }
});
});

function Deleteps(id) {
    $.ajax({
        type: "POST",
        url: '../ReceiptsPaymentsContra/IsFromOutstanding',// url: "@Url.Action("IsFromOutstanding", "ReceiptsPaymentsContra")",
        data: {
        id: id,
        },
    success: function (data) {
        if (data == "dependent") {
            $("#confirmmsg").html("Record has dependent transactions,Do you still want to delete this record..?");
            $("#confirm").modal("show");
            $("#deletingid").val(id);
        }
        if (data == "cash") {
            $("#confirmmsg").html("Cash transactions cannot be deleted,Do you still want to delete this record..?");
            $("#confirm").modal("show");
            $("#deletingid").val(id);
        }
        else {
            $("#confirmmsg").html("Are you sure to delete this record..?");
            $("#confirm").modal("show");
            $("#deletingid").val(id);
        }

    }
});





}
function Getps(id) {


    var crname= $("#tr_" + id + "").find("td:nth-child(2)").text();
    var crid = $("#tr_" + id + "").find("td:nth-child(2)").attr("id").split("_")[1];
    var drname = $("#tr_" + id + "").find("td:nth-child(3)").text();
    var drid =  $("#tr_" + id + "").find("td:nth-child(3)").attr("id").split("_")[1];
    var amount = $("#tr_" + id + "").find("td:nth-child(4)").text();
    var voucher = $("#tr_" + id + "").find("td:nth-child(5)").text();
    var date = $("#tr_" + id + "").find("td:nth-child(6)").text();
    //var bankname = $("#tr_" + id + "").find("td:nth-child(7)").text();
    //var bankid = $("#tr_" + id + "").find("td:nth-child(7)").attr("id").split("_")[1];

    // var cheque = $("#tr_" + id + "").find("td:nth-child(8)").text();
    var details = $("#tr_" + id + "").find("td:nth-child(9)").text();

    // var data = "crname=" + crname + ",crid=" + crid + ",drname=" + drname + ",drid=" + drid + ",amount=" + amount + ",voucher=" + voucher + ",date=" + date + ",details=" + details + "";

    //$("#tr_" + id + "").find("td:nth-child(2)").html("<select id='ddl_"+crid+"'></select>");
    $("#tr_" + id + "").find("td:nth-child(3)").html("<input type='text' onfocus='this.select()' class='typeahead' value='" + drname + "' id='ddl_" + drid + "'  autocomplete='off' data-provide='typeahead'/><input type='hidden' id='hdnddl_" + drid + "' />");
    $("#tr_" + id + "").find("td:nth-child(2)").html("<input type='text' onfocus='this.select()' class='typeahead' value='" + crname + "' id='ddl_" + crid + "'  autocomplete='off' data-provide='typeahead'/><input type='hidden' id='hdnddl_" + crid + "' />");
    $("#tr_" + id + "").find("td:nth-child(4)").html("<input type='text' onfocus='this.select()' value='" + amount + "'>");
    $("#tr_" + id + "").find("td:nth-child(5)").html("<input type='text' onfocus='this.select()' value='" + voucher + "'>");
    $("#tr_" + id + "").find("td:nth-child(6)").html("<input type='text' onfocus='this.select()' class='date' onfocus='this.select()' value='" + date + "'>");
    $("#tr_" + id + "").find("td:nth-child(9)").html("<input type='text' onfocus='this.select()' value='" + details + "'>");
    $("#btnhdnGet_" + id + "").addClass("hide");
    $("#btnhdnEdit_" + id + "").removeClass("hide");
    var ClassObjs = {};
    var ClassNames = [];

    $("#ddl_" + crid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'// url: '@Url.Action("GetCustomers", "PurchaseSalesOrder")'
                , cache: false
                , success: function (data) {

                    ClassObjs = {};
                    ClassNames = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames.push(item.Text);
                        ClassObjs[item.Text] = item.Value;
                    });

                    process(ClassNames);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdnddl_" + crid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });
    var ClassObjs2 = {};
    var ClassNames2 = [];

    $("#ddl_" + drid + "").typeahead({
        source: function (query, process) {

            $.ajax({
                url: '../Purchase_Sales/GetSubAccount'// url: '@Url.Action("GetCustomers", "PurchaseSalesOrder")'
                , cache: false
                , success: function (data) {

                    ClassObjs2 = {};
                    ClassNames2 = [];

                    _.each(data, function (item, ix, list) {
                        ClassNames2.push(item.Text);
                        ClassObjs2[item.Text] = item.Value;
                    });

                    process(ClassNames2);
                }
            });
        }
        , updater: function (selectedName) {

            $("#hdnddl_" + drid + "").val(ClassObjs[selectedName]);

            return selectedName;
        }
    });

  
}
function Refreshps(id) {
    var crname = $("#tr_" + id + "").find("td:nth-child(2) input[type='text'] ").val();//("#ddl_" + crid + " :selected").val();;//
    //var crname = "";
    //if (crid != undefined) {
    //    crname = $("#ddl_" + crid + "").text();
    //}
    //else {
    //    crname = $("#tr_" + id + "").find("td:nth-child(2)").text();
    //}
    //var drid = $("#tr_" + id + "").find("td:nth-child(3) select").val();//$("#tr_" + id + "").find("td:nth-child(3)").attr("id").split("_")[1];
    var drname = $("#tr_" + id + "").find("td:nth-child(3) input[type='text']").val();
    //if (drid != undefined) {
    //    drname= $("#ddl_" + drid + " :selected").text();
    //}
    //else {
    //    drname = $("#tr_" + id + "").find("td:nth-child(3)").text();

    //}
    var amount = $("#tr_" + id + "").find("td:nth-child(4)  input[type='text']").val();
    var voucher = $("#tr_" + id + "").find("td:nth-child(5)  input[type='text']").val();
    var date = $("#tr_" + id + "").find("td:nth-child(6)  input[type='text']").val();
    //var bankname = $("#tr_" + id + "").find("td:nth-child(7)").text();
    //var bankid = $("#tr_" + id + "").find("td:nth-child(7)").attr("id").split("_")[1];

    // var cheque = $("#tr_" + id + "").find("td:nth-child(8)").text();
    var details = $("#tr_" + id + "").find("td:nth-child(9)  input[type='text']").val();
    $("#tr_" + id + "").find("td:nth-child(2)").text(crname );
    $("#tr_" + id + "").find("td:nth-child(3)").text(drname);
    $("#tr_" + id + "").find("td:nth-child(4)").text( amount);
    $("#tr_" + id + "").find("td:nth-child(5)").text(voucher);
    $("#tr_" + id + "").find("td:nth-child(6)").text(date);
    $("#tr_" + id + "").find("td:nth-child(9)").text( details);
         
    //$("#CL_" + id + "").removeClass("hide");
    //$("#DL_" + id + "").removeClass("hide");
    //$("#DdL_" + id + "").removeClass("hide");
    //$("#AI_" + id + "").removeClass("hide");
    //$("#VL_" + id + "").removeClass("hide");
    //$("#JL_" + id + "").removeClass("hide");
    $("#btnhdnGet_" + id + "").removeClass("hide");

    //$("#CE_" + id + "").addClass("hide");
    //$("#DE_" + id + "").addClass("hide");
    //$("#DdE_" + id + "").addClass("hide");
    //$("#AE_" + id + "").addClass("hide");
    //$("#VE_" + id + "").addClass("hide");
    //$("#JE_" + id + "").addClass("hide");
    $("#btnhdnEdit_" + id + "").addClass("hide");
}
function Editps(id) {

    //var cr = $("#CE_" + id + "").find("select :selected").val();
    //var dr = $("#DE_" + id + "").find("select :selected").val();
    //var amount = $("#AE_" + id + "").find("input[type='text']").val();
    //var voucher = $("#VE_" + id + "").find("input[type='text']").val();
    //var dt = $("#JE_" + id + "").find("input[type='text']").val();
    //var details = $("#DdE_" + id + "").find("input[type='text']").val();
    var cr = $("#tr_" + id + "").find("td:nth-child(2) input[type='text']").val();
    var dr = $("#tr_" + id + "").find("td:nth-child(3) input[type='text']").val();
    var amount = $("#tr_" + id + "").find("td:nth-child(4)  input[type='text']").val();
    var voucher = $("#tr_" + id + "").find("td:nth-child(5)  input[type='text']").val();
    var dt = $("#tr_" + id + "").find("td:nth-child(6)  input[type='text']").val();
    var details = $("#tr_" + id + "").find("td:nth-child(9)  input[type='text']").val();
    var data = cr + "^" + dr + "^" + amount + "^" + voucher + "^" + dt + "^" + details + "^" + id;
    $.ajax({
        type: "POST",
        url: '../ReceiptsandPayments/EditJournal',//url: "@Url.Action("EditJournal", "ReceiptsandPayments")",
        data: {
        id: data,
        },
    success: function (data) {
        if (data == "success") {
            $("#psspinner2").hide();
            notification("topright", "info", "fa fa-info-circle vd_blue", "Info Notification", "Record updated Successfully");
            //setTimeout(productgrid(), 2000);
            $("#tr_" + id + "").find("td:nth-child(2) select").attr("id", "ddl_" + cr + "");
            $("#tr_" + id + "").find("td:nth-child(3) select").attr("id", "ddl_" + dr + "");
            Refreshps(id);
        }
        else if (data == "fail") {
            $("#psspinner2").hide();
            notification("topright", "info", "fa fa-times vd_red", "Error", "Error in Record updation");

        }
        else {
            if (data == "cr")
            {
                $("#psspinner2").hide();
                notification("topright", "notify", "fa fa-times vd_red", "Invalid Account", "Credit Account does not exists");
            }
            else if (data == "dr")
            {
                $("#psspinner2").hide();
                notification("topright", "notify", "fa fa-times vd_red", "Invalid Account", "Debit Account does not exists");
            }
        }

    }
});

}




function Deletepsadj(id) {

    $.ajax({
        type: "POST",
        url: '../ReceiptsandPayments/DeleteAdjustment',// url: "@Url.Action("IsFromOutstanding", "ReceiptsPaymentsContra")",
        data: {
            id: id,
        },
        success: function (data) {
            if (data == "success") {
                deleted();
                $("#tradj_" + id + "").remove();
            }
            else if (data == "fail") {
                fail();
            }
            

        }
    });





}
function Getpsadj(id) {


    var billno = $("#tradj_" + id + "").find("td:nth-child(2)").text();
    var drname = $("#tradj_" + id + "").find("td:nth-child(3)").text();
    var drid = 0;// $("#tr_" + id + "").find("td:nth-child(3)").attr("id").split("_")[1];
    var amount = $("#tradj_" + id + "").find("td:nth-child(4)").text();
  var details = $("#tradj_" + id + "").find("td:nth-child(5)").text();

   // $("#tr_" + id + "").find("td:nth-child(3)").html("<input type='text' onfocus='this.select()' class='typeahead' value='" + drname + "' id='ddl_" + drid + "'  autocomplete='off' data-provide='typeahead'/>");
    //$("#tr_" + id + "").find("td:nth-child(2)").html("<input type='text' onfocus='this.select()'  value='" + crname + "' id='ddl_" + crid + "'  autocomplete='off' data-provide='typeahead'/><input type='hidden' id='hdnddl_" + crid + "' />");
    $("#tradj_" + id + "").find("td:nth-child(4)").html("<input type='text' onfocus='this.select()' value='" + amount + "'>");
    $("#tradj_" + id + "").find("td:nth-child(5)").html("<input type='text' onfocus='this.select()' value='" + details + "'>");
    $("#btnhdnGetadj_" + id + "").addClass("hide");
    $("#btnhdnEditadj_" + id + "").removeClass("hide");
    
   
  

}
function Refreshpsadj(id) {
   // var billno = $("#tr_" + id + "").find("td:nth-child(2) input[type='text'] ").val();//("#ddl_" + crid + " :selected").val();;//
      //var drname = $("#tr_" + id + "").find("td:nth-child(3) input[type='text']").val();
   
    var amount = $("#tradj_" + id + "").find("td:nth-child(4)  input[type='text']").val();
   
    var details = $("#tradj_" + id + "").find("td:nth-child(5)  input[type='text']").val();
   // $("#tr_" + id + "").find("td:nth-child(2)").text(crname);
  //  $("#tr_" + id + "").find("td:nth-child(3)").text(drname);
    $("#tradj_" + id + "").find("td:nth-child(4)").text(amount);
 
    $("#tradj_" + id + "").find("td:nth-child(5)").text(details);

    $("#btnhdnGetadj_" + id + "").removeClass("hide");

    $("#btnhdnEditadj_" + id + "").addClass("hide");
}
function Editpsadj(id) {

    //var cr = $("#tr_" + id + "").find("td:nth-child(2) input[type='text']").val();
    //var dr = $("#tr_" + id + "").find("td:nth-child(3) input[type='text']").val();
    var amount = $("#tradj_" + id + "").find("td:nth-child(4)  input[type='text']").val();

    var details = $("#tradj_" + id + "").find("td:nth-child(5)  input[type='text']").val();
    var data =  amount + "^" + details + "^" + id;
    $.ajax({
        type: "POST",
        url: '../ReceiptsandPayments/EditAdjustment',//url: "@Url.Action("EditJournal", "ReceiptsandPayments")",
        data: {
            id: data,
        },
        success: function (data) {
            if (data == "success") {
                $("#psspinneradj").hide();
                notification("topright", "info", "fa fa-info-circle vd_blue", "Info Notification", "Record updated Successfully");
                //setTimeout(productgrid(), 2000);
                
                Refreshpsadj(id);
            }
            else if (data == "fail") {
                $("#psspinner2").hide();
                notification("topright", "info", "fa fa-times vd_red", "Error", "Error in Record updation");

            }
            else {
                if (data == "cr") {
                    $("#psspinner2").hide();
                    notification("topright", "notify", "fa fa-times vd_red", "Invalid Account", "Credit Account does not exists");
                }
                else if (data == "dr") {
                    $("#psspinner2").hide();
                    notification("topright", "notify", "fa fa-times vd_red", "Invalid Account", "Debit Account does not exists");
                }
            }

        }
    });

}





function productgrid() {
    $("#psspinner2").show();
    var mode = 0;
    if ($("#rdReceipts").is(":checked"))
    { mode = 2; } else if ($("#rdPayments").is(":checked"))
    { mode = 1; } else if ($("#rdContra").is(":checked"))
    { mode = 3; }
    var dt = $("#txtreturndt").val();
    $("#psspinner2").show();
    $.ajax({
        type: "get",
        url: '../ReceiptsPaymentsContra/GetGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
        data: {
        mode: mode,
        dt: dt,

        },
    success: function (data) {
        $("#bottomgrid").html(data);
        var cash = 0;
        var bank = 0;
        $("#tblProductGrid").find("tr").each(function () {

            var mode = $(this).find("td:nth-child(7)").text().trim();;
            if (mode == "Cash") {
                var amount = Number($(this).find("td:nth-child(4)").text());
                cash = cash + amount;
            }
            else {

                var amount = Number($(this).find("td:nth-child(4)").text());
                bank = bank + amount;
            }



        });
        $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");

        //$("#cashbankamount").html("Cash Payment: " + cash + " , Bank Payment : " + bank + "");
        $("#psspinner2").hide();

    }
});

}

function ClickContra(id) {
    var v = $(id).attr("id");
    if (v == "Contracr") {
        $("#Contracr").removeClass("btn btn-xs btn-success");
        $("#Contracr").text("Debitor Account");
        $("#Contracr").addClass("btn btn-xs btn-danger");
        $("#Contracr").attr("id", "Contradr");
        $("#hdncontra").val("Contradr");
    }
    if (v == "Contradr") {
        $("#Contradr").removeClass("btn btn-xs btn-danger");
        $("#Contradr").text("Creditor Account");
        $("#Contradr").addClass("btn btn-xs btn-success");
        $("#Contradr").attr("id", "Contracr");
        $("#hdncontra").val("Contracr");
    }
}
       
function GetAccountCrDr() {

    var accountid = $("#hdnAdjustmentId").val();
  
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetAdjustmentCRDR',// url: "@Url.Action("GetAdjustmentCRDR", "ReceiptsandPayments")",
        data: {

        accountid: accountid,

        },
    success: function (data) {
        var lbl = data.split("~")[0];
        var type = data.split("~")[1];
        $("#amountinfo").html(lbl);
        $("#hdnType").val(type);
    }
});

var mode = 0;
if ($("#rdReceipts").is(":checked")) {
    mode = 2;
}
else if ($("#rdPayments").is(":checked")) {
    mode = 1;
}

if ($("#toggleAdjustment").val() == "0") {
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/BillLists',//url: "@Url.Action("BillLists", "ReceiptsandPayments")",
        data: {
        mode: mode,
        accountid: accountid,

        },
    success: function (data) {
        var mydata = data.split("~")[0];
        var unbill = data.split("~")[1];
        $("#unbillpara").html(unbill);
        $("#chkbills").html(mydata);

    }
});

}
else {
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/BillListsAddless',//url: "@Url.Action("BillListsAddless", "ReceiptsandPayments")",
        data: {
        mode: mode,
        accountid: accountid,

        },
    success: function (data) {
        //var mydata = data.split("~")[0];
        //var unbill = data.split("~")[1];
        //$("#unbillpara").html(unbill);
        $("#chkbills").html(data);

    }
});

}





}






function btnGetIOBills2() {

    var amount = $("#txtamountAdjustments2").val();
    var Billlists = "";
    if (amount == "") {
        notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Provide Amount");
    }
    $("#chkbills2").find("input[type='checkbox']").each(function () {


        var id = $(this).attr("id");
        if ($("#" + id + "").is(":checked")) {
            Billlists = Billlists + $(this).val() + ",";
        }

    });
    if (Billlists == "") {
        notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Check Bills");
    }
    else if (amount == "") {
        notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Provide Amount");
    }

    else {
        $.ajax({
            type: "get",
            url: '../ReceiptsandPayments/GetBillsTable2',// url: "@Url.Action("GetBillsTable2", "ReceiptsandPayments")",
            data: {


            billlists: Billlists,
            amount: amount,
            },
        success: function (data) {
            //var tbl = data.split('~')[0];
            //var bal = data.split('~')[1];
            $("#tbodybills2").html(data);
            var totalamount = 0;
            $("#tbodybills2 tr").find("td:nth-child(2) input[type='text']").each(function (i, v) {

                totalamount = totalamount + Number($(v).val());
            });
            var balamount = Math.round(Number(amount) - totalamount, 2);
            if (balamount < 0) {
                $("#remainingbal2").html(" <h3  style='font-size:14px;font-weight:bold' class='vd_red'>Balance Amount :" + 0 + " Rs.</h3>");
                $("#PBalanceAdjustments").val(0);
            }
            else {
                $("#remainingbal2").html(" <h3  style='font-size:14px;font-weight:bold' class='vd_green'>Balance Amount :" + balamount + " Rs.</h3>");
                $("#PBalanceAdjustments").val(balamount);
            }

        }
    });

}

}
function btnGetIOBills() {

    var Billlists = "";
    var accountid = $("#hdnAdjustmentId").val();
    var amount = 0;//$("#txtamountAdjustments").val();
    var givenamt = 0;
    var type = $("#hdnType").val();
    var unbillamount = Number($("#unbillpara").text());

    //if (type == "cr") {
    //    var lbl = $("#amountinfo").find("label").html();
    //    lbl = lbl.split(":")[1];
    //    lbl = lbl.replace("Rs", "");
    //    alert(lbl);
    //    amount = Number($("#txtamountAdjustments").val()) + Number(lbl);
    //    alert(amount);
    //}
    //else {
    //givenamt = Number($("#txtamountAdjustments").val());
    amount = unbillamount;//+ givenamt;
    //}

    if ($("#toggleAdjustment").val() == "0") {

        $("#chkbills").find("input[type='checkbox']").each(function () {


            var id = $(this).attr("id");
            if ($("#" + id + "").is(":checked")) {
                Billlists = Billlists + id + ",";
            }

        });


        Billlists = (Billlists.slice(0, -1));

        if (Billlists == "") {
            notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Check Bills");
        }
        else if (amount == "") {
            notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Provide Amount");
        }
        else {
            $.ajax({
                type: "get",
                url: '../ReceiptsandPayments/GetBillsTable',//url: "@Url.Action("GetBillsTable", "ReceiptsandPayments")",
                data: {

                accountid: accountid,
                billlists: Billlists,
                amount: amount,
                },
            success: function (data) {
                //var tbl = data.split('~')[0];
                //var bal = data.split('~')[1];
                $("#tbodybills").html(data);
                var totalamount = 0;
                $("#tbodybills tr").find("td:nth-child(2) input[type='text']").each(function (i, v) {

                    totalamount = totalamount + Number($(v).val());
                });
                var balamount = Math.round(Number(amount) - totalamount, 2);
                if (balamount < 0) {
                    $("#remainingbal").html(" <h3  style='font-size:14px;font-weight:bold' class='vd_red'>Balance Amount :" + 0 + " Rs.</h3>");
                    $("#RBalanceAdjustments").val(0);
                }
                else {
                    $("#remainingbal").html(" <h3  style='font-size:14px;font-weight:bold' class='vd_green'>Balance Amount :" + balamount + " Rs.</h3>");
                    $("#RBalanceAdjustments").val(balamount);
                }

            }
        });
    }
}
else {


            var validcheckboxes = 0;
var billss = "";
$("#chkbills").find("input[type='checkbox']").each(function () {


    var id = $(this).attr("id");
    if ($("#" + id + "").is(":checked")) {
        validcheckboxes = validcheckboxes + 1;
    }

});
if (validcheckboxes > 1) {
    notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Select only one bill");

}
else {
    var ioid = 0;
    $("#chkbills").find("input[type='checkbox']").each(function () {
        var id = $(this).attr("id");
        if ($("#" + id + "").is(":checked")) {
            ioid = id;
            billss = billss + id + ",";
        }

    });

    if (billss == "") {
        notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Check Bills");
    }

    else {

        $.ajax({
            type: "get",
            url: '../ReceiptsandPayments/GetAddLessData',//url: "@Url.Action("GetAddLessData", "ReceiptsandPayments")",
            data: {

            io: ioid,

            },
        success: function (data) {
            //

            //$.fn.modal.Constructor.prototype.enforceFocus = function () { };
            var ps = data.split("!")[0].split("~")[0];
            var billno = data.split("!")[0].split("~")[1];
            var customer = data.split("!")[0].split("~")[2];
            var editeddata = data.split("!")[1];

            $("#lblps").html("<b class='vd_blue'>Purchase/Sales Type :</b> " + ps)
            $("#lblbillno").html("<b class='vd_green'>Bill NO : </b>" + billno)
            $("#lblcustomer").html("<b class='vd_red'>Customer Name : </b>" + customer)

            $("#hdnio").val(ioid);
            $("#Inwardcash").show();
            if (editeddata != "") {
                $("#tblInwardcash").html(editeddata);
                $("#tblInwardcash").find("tr").each(function () {
                    var id = $(this).attr("id").split("_")[1];

                    $("#txtrepdtIC_" + id + "").datepicker({
                        dateFormat: "dd/mm/yy",
                        defaultDate: new Date(),
                        minDate: $("#ViewBagFromDateRange").val(),
                        maxDate: $("#ViewBagToDateRange").val(),
                        yearRange: $("#ViewBagDateRange").val(),
                        changeMonth: true,
                        changeYear: true,
                        onClose: function (dateText, inst) {
                            var validDate = $.datepicker.formatDate("dd/mm/yy", $("#txtrepdtIC_" + id + "").datepicker('getDate'));
                            $("#txtrepdtIC_" + id + "").datepicker('setDate', validDate);
                        }
                    });
                });

            }
            else {
                AddInwardCash();
            }


        }
    });


}
}


}


}
function isNumberKey(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    //var charec = /[A]|[a]/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
function Validateinput(id) {

    var actualamt = $("#lblb_" + id + "").text();
    var ioamount = 0;
    if (actualamt.indexOf("(") > 0) {
        ioamount = Number(actualamt.split("(")[0]);

    }
    else {

        ioamount = Number(actualamt);
    }



    var textamount = Number($("#txtb_" + id + "").val());
    var amount = Number($("#txtamountAdjustments").val());
    if (textamount > ioamount) {
        notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Given amount is greater then Bill amount");
        $("#txtb_" + id + "").val(ioamount)

    }
    //else if (textamount > amount)
    //{
    //    notification("topright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Given amount is greater then Bill amount");
    //    $("#txtb_" + id + "").val(ioamount)

    //}
}
//here
function SaveAdjustments2() {

    var JournalDetail = [];
    var CrAccount = "";
    var DrAccount = "";
    var Amount = 0;
    var TransactionType = 0;


    var type = $("#hdnType").val();

    var accountid = $("#ViewBagCash").val();
    var mode = $("#cmbBankAdjustments2").val();
    var chequeno = "";
    var chequedt = "";
    if ($("#rdbankAdjustments2").is(":checked")) {
        chequeno = $("#chequeNo").val();
        chequedt = $("#ChequeDate").val();
    }

    var JournalDate = $("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));


    Amount = $("#txtamountAdjustments2").val();
    TransactionType = 1;
    DrAccount = -1;

    if ($("#rdcashAdjustments2").is(":checked")) {
        CrAccount = $("#ViewBagCash").val();
    }
    else if ($("#rdbankAdjustments2").is(":checked")) {
        CrAccount = mode;
    }
    var BillAmounts = "";

    $("#tbodybills2").find("tr").each(function () {
        var ii = $(this).attr("id").split("_")[1];
        var input = $("#txtb_" + ii + "").val();
        BillAmounts = BillAmounts + ii + "," + input + "!";
    });

    var Datadetails = {
        Amount: Amount,
        CrAccount: CrAccount,
        DrAccount: DrAccount,
        JournalDate: JournalDate,
        Bank: mode,
        TransactionType: TransactionType,
        ChequeNo: chequeno,
        ChequeDate: chequedt,

    };

    JournalDetail.push(Datadetails);




    var jounal = {

        //"JournalDetails": JournalDetail,
        "BillAmounts": BillAmounts,
        //"VoucherSystemId":voucher
    };

    $.ajax({
        url: '../ReceiptsPaymentsContra/SaveBill2',//url: "@Url.Action("SaveBill2", "ReceiptsPaymentsContra")",
        data:
    JSON.stringify(jounal),
    type: 'POST',
    contentType: 'application/json; charset=utf-8',
    success: function (data) {

        if (data.message == "ok") {
            OpeningClosingBal();
            setTimeout(productgrid(), 2000);
            $("#tbodybills2").html("");
            $("#cmbAdjustments2").val("");
            $("#amountinfo2").html("");
            $("#chkbills2").html("");
            $("#txtamountAdjustments2").val("");
            $("#remainingbal2").html("");
            $("#cmbBankAdjustments2").val("");
            $("#chequeNo2").val("");
            $("#ChequeDate2").val($("#ViewCurrentDate").val());
            $("#rdcashAdjustments2").attr("checked", true);
            canceladjustments();
            $("#cancelAdjustments2").trigger("click");
            $("#ckhAdjustments").attr("checked", true);
            notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
        }


    },
    error: function (data) {

        notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in submitting form");
    }
});


}
















function SaveAdjustments() {
   

    if ($("#toggleAdjustment").val() == "0") {
        var BillAmounts = "";

        $("#tbodybills").find("tr").each(function () {
            var ii = $(this).attr("id").split("_")[1];
            var input = Number($("#txtb_" + ii + "").val());
            var pending = ($("#remarkb_" + ii + "").val());;
            BillAmounts = BillAmounts + ii + "," + input + "," + pending + "!";
        });

      
        var jounal = {

            //"JournalDetails": JournalDetail,
            "BillAmounts": BillAmounts,
            //"VoucherSystemId":voucher
        };
        $.ajax({
            url: '../ReceiptsPaymentsContra/SaveBill',//url: "@Url.Action("SaveBill", "ReceiptsPaymentsContra")",
            data:
        JSON.stringify(jounal),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
           
            if (data.message == "ok") {
                OpeningClosingBal();
                setTimeout(productgrid(), 2000);
                $("#tbodybills").html("");
                $("#cmbAdjustments").val("");
                $("#amountinfo").html("");
                $("#chkbills").html("");
                $("#txtamountAdjustments").val("");
                $("#remainingbal").html("");
                $("#cmbBankAdjustments").val("");
                $("#chequeNo").val("");
                $("#ChequeDate").val($("#ViewCurrentDate").val());
                $("#rdcashAdjustments").attr("checked", true);
                canceladjustments();
                $("#cancelAdjustments").trigger("click");
                $("#ckhAdjustments").attr("checked", true);
                notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
                $("#cancelAdjustments").trigger("click");
            }


        },
        error: function (data) {

            notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in submitting form");
        }
    });
}
              
else {
    btnInwardcash();

}
}

function btnUncheck() {

    $("#chkbills").find("input[type='checkbox']").each(function () {

        $(this).attr("checked", false);

    });
}
function btnUncheck2() {

    $("#chkbills2").find("input[type='checkbox']").each(function () {

        $(this).attr("checked", false);

    });
}

function GetCustomerId(ioid) {
    $.ajax({
        type: "get",
        url: '../ReceiptsandPayments/GetCustomerId',//url: "@Url.Action("GetCustomerId", "ReceiptsandPayments")",
        data: {
        io: ioid,
        },
    success: function (data) {

    }
});

}

function ToggleAdjustment(name) {
    var togoler = $(name).attr("id");
    if (togoler == "Addlessbtn") {
        $("#toggleAdjustment").val("1");
        if ($("#hdnAdjustmentId").val() != "") {
            $("#divAdjust").hide();
            GetAccountCrDr()
            $("#divInward").show();

        }
        else {
            $("#divAdjust").hide();
            $("#divInward").show();

        }
        $("#Adjustmentbtn").show();
        $("#Addlessbtn").hide();
        $("#adjtitle").text("Add Less (Excess - short)");
    }
    else  {

        $("#toggleAdjustment").val("0");
        $("#divAdjust").show();
        $("#divInward").hide();
        $("#Adjustmentbtn").hide();
        $("#Addlessbtn").show();
        $("#adjtitle").text("Adjustments");

    }

}

function canceladjustments() {
    $("#ckhAdjustments").prop("checked", false);
    $("#cmbAdjustments").val("");
    $("#txtamountAdjustments").val("");
    $("#chkbills").html("");
    $("#tbodybills").html("");
    $("#remainingbal").html("");
    $("#cmbBankAdjustments").val("");
    $("#chequeNo").val("");
    $("#ChequeDate").val($("#ViewCurrentDate").val());
    $("#rdcashAdjustments").prop("checked", true);
    $('#Adjustments').modal('hide');

}

function OnCustomSubmit() {
    $("#nogeneral").trigger("click");
    if ($("#hdnButton").val() == "btnconfirmcash") {
        var vcount = 0;
        var JournalDetail = [];
        $("#tblreturnscash").find("tr").each(function () {
            if ($("#hdncmbReturnAccountsc_" + rowid + "").val() != 0) {

                var CrAccount = "";
                var DrAccount = "";

                var TransactionType = 0;
                var rowid = $(this).attr("id").split('_')[1];
                var accountid = $("#hdncmbReturnAccountsc_" + rowid + "").val();
                var Amount = Number($("#Receiptc_" + rowid + "").val());
                var ReportNo = $("#txtrepnoc_" + rowid + "").val();
                var RepartDate = $("#txtrepdtc_" + rowid + "").val();
                var Monthlytax = $("#chkc_" + rowid + "").is(":checked");
                if ($("#rdReceipts").is(":checked")) {

                    TransactionType = 2;
                    CrAccount = accountid;
                    if ($("#rdcash").is(":checked")) {
                        DrAccount = $("#ViewBagCash").val();
                    } else if ($("#rdbank").is(":checked")) {
                        DrAccount = 4;
                    }



                }
                else if ($("#rdPayments").is(":checked")) {

                    TransactionType = 1;
                    DrAccount = accountid;
                    if ($("#rdcash").is(":checked")) {
                        CrAccount = $("#ViewBagCash").val();
                    } else if ($("#rdbank").is(":checked")) {
                        CrAccount = 4;
                    }



                }
                else if ($("#rdContra").is(":checked")) {

                    if ($("#hdncontra").val() == "Contracr") {
                        TransactionType = 3;
                        CrAccount = $("#craccount").val();
                        DrAccount = accountid;
                    }
                    else if ($("#hdncontra").val() == "Contradr") {
                        TransactionType = 3;
                        DrAccount = $("#craccount").val();
                        CrAccount = accountid;
                    }

                }
                var voucher = $("#txtvoucherc_" + rowid + "").val();
                if (voucher == "") {

                    vcount++;
                }//txtdescc_1
                var Details = String($("#txtdescc_" + rowid + "").val());
                var JournalDate = $("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));
                var Datadetails = {
                    Amount: Amount,
                    CrAccount: CrAccount,
                    DrAccount: DrAccount,
                    VoucherSystemId: voucher,
                    JournalDate: JournalDate,
                    Details: Details,
                    TransactionType: TransactionType,
                    ReportNo: ReportNo,
                    RepartDate: RepartDate,
                    Monthlytaxpurchase: Monthlytax,

                };

                JournalDetail.push(Datadetails);

            }
        });
        // if (vcount == 0) {
        var journal = {

            "JournalDetails": JournalDetail
        };

        $.ajax({
            url: '../ReceiptsandPayments/Save',// url: "@Url.Action("Save", "ReceiptsandPayments")",
            data:
        JSON.stringify(journal),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.data == "Success") {
                var ps = "";
                var sms = "";
                var mail = "";
                if ($("#rdReceipts").is(":checked")) {
                    ps = "rep";
                }
                else if ($("#rdPayments").is(":checked")) {
                    ps = "pay";
                }
                if ($("#ckhsms").is(":checked")) {
                    sms = "yes";
                }
                if ($("#ckhmail").is(":checked")) {
                    mail = "yes";
                }
                if ($("#ckhshowreport").is(":checked")) {
                    if (ps == "rep") {
                        $("#mainsection").hide();
                        $("#reportsection").show();
                        $("#Transactionsection").hide();
                        $("#iframereport").show();
                        document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVouchergenerate&pid=" + data.jid + "&total=rp";

                        //redirectWindow = window.open('/stiReport/Index?form=ReceiptsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                        //redirectWindow.location;
                    }
                    else if (ps == "pay") {
                        $("#mainsection").hide();
                        $("#reportsection").show();
                        $("#Transactionsection").hide();
                        $("#iframereport").show();
                        document.getElementById('iframereport').src = "/stiReport/Index?form=PaymentsVouchergenerate&pid=" + data.jid + "&total=rp";

                        // redirectWindow = window.open('/stiReport/Index?form=PaymentsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                        // redirectWindow.location;
                    }
                }
               
            setTimeout(SendingSMS(data.jid, ps, sms, mail), 1000)

            notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
            //window.location.reload();
            OpeningClosingBal();
            setTimeout(productgrid()
                , 2000);
            // productgrid();
            $("#tblreturnscash").html("");
            PSReturnsCash();
        }
    else if (data.data == "fail") {
        notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in Record Submission , " + data.message + "");
    }
    },
    error: function (data) {
        //$(".blockUI").hide();
        //$(".blockUI blockOverlay").hide();
        //$(".blockUI blockMsg blockElement").hide();
        alert("Insertion failed ");
    }
});
}
else if ($("#hdnButton").val() == "btnconfirm") {
    var JournalDetail = [];
    var vcount = 0;
    $("#tblreturns").find("tr").each(function () {
        if ($("#hdncmbReturnAccounts_" + rowid + "").val() != 0) {

            var CrAccount = "";
            var DrAccount = "";

            var TransactionType = 0;
            var rowid = $(this).attr("id").split('_')[1];
            var accountid = $("#hdncmbReturnAccounts_" + rowid + "").val();
            var Amount = Number($("#Receipt_" + rowid + "").val());
            var mode = $("#cmbtrans_" + rowid + "").val();
            var ReportNo = $("#txtrepno_" + rowid + "").val();
            var RepartDate = $("#txtrepdt_" + rowid + "").val();
            var Monthlytax = $("#chk_" + rowid + "").is(":checked");
            if ($("#rdReceipts").is(":checked")) {

                TransactionType = 2;
                CrAccount = accountid;

                if ($("#rdcash").is(":checked")) {
                    DrAccount = $("#ViewBagCash").val();
                } else if ($("#rdbank").is(":checked")) {
                    DrAccount = mode;
                }


            }
            else if ($("#rdPayments").is(":checked")) {

                TransactionType = 1;
                DrAccount = accountid;

                if ($("#rdcash").is(":checked")) {
                    CrAccount = $("#ViewBagCash").val();
                } else if ($("#rdbank").is(":checked")) {
                    CrAccount = mode;
                }



            }
            else if ($("#rdContra").is(":checked")) {

                TransactionType = 3;
                CrAccount = $("#craccount").val();
                DrAccount = accountid;

            }

            var voucher = $("#txtvoucher_" + rowid + "").val();
            if (voucher == "") {
                vcount++;
            }
            var mode = $("#cmbtrans_" + rowid + "").val();
            var chequeno = "";
            if ($("#rdPayments").is(":checked")) {
                if ($("#ddlchkno_" + rowid + " :selected").text() != "Select Cheque") {
                    chequeno = $("#ddlchkno_" + rowid + " :selected").text() + "~d";
                }
                else {
                    chequeno = "";
                }
            }
            $("#txtchkno_" + rowid + "").val();
            var chequedt = $("#txtchkdt_" + rowid + "").val();
            var Details = String($("#txtdesc_" + rowid + "").val());
            var JournalDate = $("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));


            // //alert(date);
            // //alert(Amount + "," + CrAccount + "," + DrAccount + "," + voucher + "," + mode + "," + chequeno + "," + chequedt);
            var Datadetails = {
                Amount: Amount,
                CrAccount: CrAccount,
                DrAccount: DrAccount,
                VoucherSystemId: voucher,
                JournalDate: JournalDate,
                Details: Details,
                Bank: mode,
                TransactionType: TransactionType,
                ChequeNo: chequeno,
                ChequeDate: chequedt,
                ReportNo: ReportNo,
                RepartDate: RepartDate,
                Monthlytaxpurchase: Monthlytax,
            };

            JournalDetail.push(Datadetails);

        }
    });
    //if (vcount == 0) {
    var journal = {

        "JournalDetails": JournalDetail
    };

    $.ajax({
        url: '../ReceiptsandPayments/Save',// url: "@Url.Action("Save", "ReceiptsandPayments")",
        data:
    JSON.stringify(journal),
    type: 'POST',
    contentType: 'application/json; charset=utf-8',
    success: function (data) {
        if (data.data == "Success") {

            notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
            OpeningClosingBal();
            setTimeout(productgrid(), 2000);
            $("#tblreturns").html("");
            PSReturns()
            var ps = "";
            var sms = "";
            var mail = "";
            if ($("#rdReceipts").is(":checked")) {
                ps = "rep";
            }
            else if ($("#rdPayments").is(":checked")) {
                ps = "pay";
            }
            if ($("#ckhsms").is(":checked")) {
                sms = "yes";
            }
            if ($("#ckhmail").is(":checked")) {
                mail = "yes";
            }
            if ($("#ckhshowreport").is(":checked")) {
                if (ps == "rep") {
                    $("#mainsection").hide();
                    $("#reportsection").show();
                    $("#Transactionsection").hide();
                    $("#iframereport").show();
                    document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVouchergenerate&pid=" + data.jid + "&total=rp";

                    //redirectWindow = window.open('/stiReport/Index?form=ReceiptsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                    //redirectWindow.location;
                }
                else if (ps == "pay") {
                    $("#mainsection").hide();
                    $("#reportsection").show();
                    $("#Transactionsection").hide();
                    $("#iframereport").show();
                    document.getElementById('iframereport').src = "/stiReport/Index?form=PaymentsVouchergenerate&pid=" + data.jid + "&total=rp";

                    //redirectWindow = window.open('/stiReport/Index?form=PaymentsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                    // redirectWindow.location;
                }
            }
            $.ajax({
                type: "get",
                url: '../stiReport/SendingMailRP',// url: "@Url.Action("SendingMailRP", "stiReport")",
                data: {
                jid: data.jid,
                ps: ps,
                sms: sms,
                mail: mail,
                },
            success: function (data) {
                $("#ckhsms").attr("checked", false);
                $("#ckhmail").attr("checked", false);
                $("#ckhshowreport").attr("checked", false);
            }

        });
    }
else if (data.data == "fail") {
    notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in Record Submission , " + data.message + "");

}



},
error: function (data) {
    alert("Insertion failed ");
}
});
}
else if ($("#hdnButton").val() == "btnconfirmOutBank") {
    var JournalDetail = [];
    var vcount = 0;
    $("#tbloutstanding").find("tr").each(function () {
        if ($("#hdncmbReturnAccountsob_" + rowid + "").val() != 0) {

            var CrAccount = "";
            var DrAccount = "";

            var TransactionType = 0;
            var rowid = $(this).attr("id").split('_')[1];
            var accountid = $("#hdncmbReturnAccountsob_" + rowid + "").val();
            var Amount = Number($("#Receiptob_" + rowid + "").val());
            var mode = $("#cmbBankob_" + rowid + "").val();
            var ReportNo = $("#txtrepnoob_" + rowid + "").val();
            var RepartDate = $("#txtrepdtob_" + rowid + "").val();
            var Monthlytax = $("#chkob_" + rowid + "").is(":checked");
            var chequeno = "";
            var actualamount = Number($("#lblamtb_" + rowid + "").text());
            var pending = true;
            if (Amount == actualamount) {
                pending = false;

            }

            if ($("#rdReceipts").is(":checked")) {

                TransactionType = 2;
                CrAccount = accountid;
                if ($("#rdcash").is(":checked")) {
                    CrAccount = $("#ViewBagCash").val();
                } else if ($("#rdbank").is(":checked")) {
                    DrAccount = mode;
                }



            }
            else if ($("#rdPayments").is(":checked")) {

                TransactionType = 1;
                DrAccount = accountid;
                if ($("#rdcash").is(":checked")) {
                    CrAccount = $("#ViewBagCash").val();
                } else if ($("#rdbank").is(":checked")) {
                    CrAccount = mode;
                }
                if ($("#ddlchknoob_" + rowid + " :selected").text() != "Select Cheque") {
                    chequeno = $("#ddlchknoob_" + rowid + " :selected").text() + "~d";
                }

                else {
                    chequeno = $("#txtchequeob_" + rowid + "").val();
                }


            }
            else if ($("#rdContra").is(":checked")) {

                TransactionType = 3;
                CrAccount = $("#craccount").val();
                DrAccount = accountid;

            }

            var voucher = $("#txtvoucherob_" + rowid + "").val();
            if (voucher == "") {
                vcount++;
            }
            var mode = $("#cmbBankob_" + rowid + "").val();
            // var chequeno = $("#txtchequeob_" + rowid + "").val();
            var chequedt = $("#txtchequedtob_" + rowid + "").val();
            var Details = String($("#txtdescob_" + rowid + "").val());
            var JournalDate = $("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));
            var ioid = $("#lblioidob_" + rowid + "").text().trim();
            if (ioid == "-")
            {
                ioid = "0";
            }
            var Datadetails = {
                Amount: Amount,
                CrAccount: CrAccount,
                DrAccount: DrAccount,
                VoucherSystemId: voucher,
                JournalDate: JournalDate,
                Details: Details,
                Bank: mode,
                TransactionType: TransactionType,
                ChequeNo: chequeno,
                ChequeDate: chequedt,
                IOMasterId: ioid,
                ReportNo: ReportNo,
                RepartDate: RepartDate,
                Monthlytaxpurchase: Monthlytax,
                // BilPending: pending,
            };

            JournalDetail.push(Datadetails);

        }
    });
    // if (vcount == 0) {
    var jounal = {

        "JournalDetails": JournalDetail
    };

    $.ajax({
        url: '../ReceiptsPaymentsContra/SaveOutstandings',// url: "@Url.Action("SaveOutstandings", "ReceiptsandPayments")",
        data:
    JSON.stringify(jounal),
    type: 'POST',
    contentType: 'application/json; charset=utf-8',
    success: function (data) {
        if (data.data == "Success") {
            notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
            OpeningClosingBal();
            setTimeout(productgrid(), 2000);
            $("#tbloutstanding").html("");
            $("#extraoutstabding").hide();
            $("#extrareturnscash").show();
            $("#rdCash").prop("checked", true);
            //PSReturnsOutstangingCash();
            $("#tblreturnscash").html("");
            PSReturnsCash();
            $("#unbind").html("");
            $("#hdnUnbilledPannel").hide();
            $("#unbind2").html("");
            $("#hdnUnbilledPannel2").hide();
            var ps = "";
            var sms = "";
            var mail = "";
            if ($("#rdReceipts").is(":checked")) {
                ps = "rep";
            }
            else if ($("#rdPayments").is(":checked")) {
                ps = "pay";
            }
            if ($("#ckhsms").is(":checked")) {
                sms = "yes";
            }
            if ($("#ckhmail").is(":checked")) {
                mail = "yes";
            }
            if ($("#ckhshowreport").is(":checked")) {
                if (ps == "rep") {
                    $("#mainsection").hide();
                    $("#reportsection").show();
                    $("#Transactionsection").hide();
                    $("#iframereport").show();
                    document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVouchergenerate&pid=" + data.jid + "&total=rp";

                    //redirectWindow = window.open('/stiReport/Index?form=ReceiptsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                    //redirectWindow.location;
                }
                else if (ps == "pay") {
                    $("#mainsection").hide();
                    $("#reportsection").show();
                    $("#Transactionsection").hide();
                    $("#iframereport").show();
                    document.getElementById('iframereport').src = "/stiReport/Index?form=PaymentsVouchergenerate&pid=" + data.jid + "&total=rp";

                    // redirectWindow = window.open('/stiReport/Index?form=PaymentsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                    // redirectWindow.location;
                }
            }
            $.ajax({
                type: "get",
                url: '../stiReport/SendingMailRP',// url: "@Url.Action("SendingMailRP", "stiReport")",
                data: {
                jid: data.jid,
                ps: ps,
                sms: sms,
                mail: mail,
                },
            success: function (data) {
                $("#ckhsms").attr("checked", false);
                $("#ckhmail").attr("checked", false);
                $("#ckhshowreport").attr("checked", false);
            }
        });
    }
else if (data.data == "fail") {
    notification("topright", "notify", "fa fa-times vd_red", "Error", "Error in Record Submission , " + data.message + "");


}
    //window.location.reload();

},
error: function (data) {

    alert("Insertion failed ");
}
});

}
else if ($("#hdnButton").val() == "btnconfirmOutCash") {
    var unbill = $("#unbind").text();
    if (unbill != "") {
        $("#confirmOut").modal("show");
    }
    else {
        // $("#no5").trigger("click");
        //$(".blockUI").show();
        //$(".blockUI blockOverlay").show();
        //$(".blockUI blockMsg blockElement").show();
        var JournalDetail = [];
        var vcount = 0;
        $("#tbloutstandingcash").find("tr").each(function () {
            if ($("#hdncmbReturnAccountsoc_" + rowid + "").val() != 0) {

                var CrAccount = "";
                var DrAccount = "";

                var TransactionType = 0;
                var rowid = $(this).attr("id").split('_')[1];
                var accountid = $("#hdncmbReturnAccountsoc_" + rowid + "").val();
                var Amount = Number($("#Receiptoc_" + rowid + "").val());
                var BIllno = $("#lblbillnooc_" + rowid + "").text();
                var ioid = Number($("#lblioidoc_" + rowid + "").text());
                var ReportNo = $("#txtrepnooc_" + rowid + "").val();
                var RepartDate = $("#txtrepdtoc_" + rowid + "").val();//txtrepnoob_1
                var Monthlytax = $("#chkoc_" + rowid + "").is(":checked");
                var actualamount = Number($("#lblamtc_" + rowid + "").text());
                var Zaccount = Number($("#lblZAccountc_" + rowid + "").text());
                if (ioid == "-")
                {
                    ioid = 0;
                }
                var za = 0;
                if (Zaccount == 2) {
                    za = -1;
                }
                else {
                    za = Zaccount;
                }
                // alert(actualamount);
                var pending = false;
                //if (Amount != actualamount) {
                //    pending = true;

                //}
                //else {
                //    pending =false;
                //}
                //alert(Amount+","+actualamount+","+pending)
                if ($("#rdReceipts").is(":checked")) {

                    TransactionType = 2;
                    CrAccount = accountid;
                    if ($("#rdcash").is(":checked")) {
                        DrAccount = $("#ViewBagCash").val();
                    } else if ($("#rdbank").is(":checked")) {
                        DrAccount = 4;
                    }


                }
                else if ($("#rdPayments").is(":checked")) {

                    TransactionType = 1;
                    DrAccount = accountid;
                    if ($("#rdcash").is(":checked")) {
                        CrAccount = $("#ViewBagCash").val();
                    } else if ($("#rdbank").is(":checked")) {
                        CrAccount = 4;
                    }


                }
                else if ($("#rdContra").is(":checked")) {

                    TransactionType = 3;
                    CrAccount = $("#craccount").val();
                    DrAccount = accountid;

                }

                var voucher = $("#txtvoucheroc_" + rowid + "").val();
                if (voucher == "") {

                    vcount++;
                }

                var Details = String($("#txtdescoc_" + rowid + "").val());
                var JournalDate = $("#txtreturndt").val(); //$("#txtreturndt").val();//new Date(Date.parse($("#txtreturndt").val(),"dd/mm/yy"));

                var Datadetails = {
                    Amount: Amount,
                    CrAccount: CrAccount,
                    DrAccount: DrAccount,
                    VoucherSystemId: voucher,
                    JournalDate: JournalDate,
                    Details: Details,
                    IOMasterId: ioid,
                    ReportNo: ReportNo,
                    RepartDate: RepartDate,
                    Monthlytaxpurchase: Monthlytax,
                    TransactionType: TransactionType,
                    ZAccount: za,
                    // BilPending: pending,
                };

                JournalDetail.push(Datadetails);




            }

        });

        //if (vcount == 0) {
        var jounal = {

            "JournalDetails": JournalDetail
        };

        $.ajax({
            url: '../ReceiptsPaymentsContra/SaveOutstandings',// url: "@Url.Action("SaveOutstandings", "ReceiptsandPayments")",
            data:
        JSON.stringify(jounal),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.data == "Success") {
                $("#tbloutstandingcash").html("");
                //PSReturnsOutstangingCash();

                $("#extraoutstabdingcash").hide();
                $("#extrareturnscash").show();
                $("#tblreturnscash").html("");
                PSReturnsCash();
                $("#unbind").html("");
                $("#hdnUnbilledPannel").hide();
                $("#unbind2").html("");
                $("#hdnUnbilledPannel2").hide();
                $("#submitbuttons").html("<button class='btn btn-info' onclick='btnconfirmcash()'>Submit</button>");
                notification("topright", "success", "fa fa-check vd_green", "Success", "Record submitted successfully");
                OpeningClosingBal();
                setTimeout(productgrid(), 2000);
                var ps = "";
                var sms = "";
                var mail = "";
                if ($("#rdReceipts").is(":checked")) {
                    ps = "rep";
                }
                else if ($("#rdPayments").is(":checked")) {
                    ps = "pay";
                }
                if ($("#ckhsms").is(":checked")) {
                    sms = "yes";
                }
                if ($("#ckhmail").is(":checked")) {
                    mail = "yes";
                }
                if ($("#ckhshowreport").is(":checked")) {
                    if (ps == "rep") {
                        $("#mainsection").hide();
                        $("#reportsection").show();
                        $("#Transactionsection").hide();
                        $("#iframereport").show();
                        document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVouchergenerate&pid=" + data.jid + "&total=rp";

                        //redirectWindow = window.open('/stiReport/Index?form=ReceiptsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                        //redirectWindow.location;
                    }
                    else if (ps == "pay") {
                        $("#mainsection").hide();
                        $("#reportsection").show();
                        $("#Transactionsection").hide();
                        $("#iframereport").show();
                        document.getElementById('iframereport').src = "/stiReport/Index?form=PaymentsVouchergenerate&pid=" + data.jid + "&total=rp";

                        //redirectWindow = window.open('/stiReport/Index?form=PaymentsVouchergenerate&pid=' + data.jid + '&total=rp', '_blank');
                        // redirectWindow.location;
                    }
                }
                $.ajax({
                    type: "get",
                    url: '../stiReport/SendingMailRP',// url: "@Url.Action("SendingMailRP", "stiReport")",
                    data: {
                    jid: data.jid,
                    ps: ps,
                    sms: sms,
                    mail: mail,
                    },
                success: function (data) {
                    $("#ckhsms").attr("checked", false);
                    $("#ckhmail").attr("checked", false);
                    $("#ckhshowreport").attr("checked", false);
                }
            });
        }
    else if (data.data == "fail") {
        notification("topright", "notify", "fa fa-times vd_red", "Error", "Error : " + data.message + "");

    }
    },
    error: function (data) {

        alert("Insertion failed ");
    }
});

}

}
}


function ReceiptsChange() {
    if ($("#rdReceipts").is(":checked")) {
        $("#ckhAdjustments").attr("checked", false);
        //var ddl = $("select.mustprovide").val();
        //var textbox = $("input.mustprovide").val();
        //var ddltext = $("select.mustprovide :selected").text();
        if ($("#rdcash").is(":checked")) {
            $("#rdcash").trigger("change");
            //$("#cmbReturnAccountsc_1").prop("value",ddl);
            //$("#select2-cmbReturnAccountsc_1-container").text(ddltext);
            //$("#Receiptc_1").val(textbox);
        }
        else if ($("#rdbank").is(":checked")) {
            $("#rdbank").trigger("change");
            //$("#select2-cmbReturnAccounts_1-container").text(ddltext);
            //$("#cmbReturnAccounts_1").prop("value",ddl);
            //$("#Receipt_1").val(textbox);
        }
        $("#crsection").hide();
        $("#cashmode").show();
        $("#divoutstanding").show();
        $("#cmbps").val("0");
        $("#cmbbill").empty();
        $("#psspinner2").show();
        //$("#FromDate").val($("#ViewCurrentDate").val());
        // $("#ToDate").val($("#ViewCurrentDate").val());
        $("#tblreturns").find("tr").each(function () {
            var id = $(this).attr("id").split("_")[1];
            $("#tdmode_" + id + "").show();
            $("#tdchkno_" + id + "").show();
            $("#tdchkdt_" + id + "").show();
            $("#thmode").show();
        });


        var mode = 2;
        var dt = $("#txtreturndt").val();
        $.ajax({
            type: "get",
            url: '../ReceiptsPaymentsContra/GetGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
            data: {
            mode: mode,
            dt: dt,

            },
        success: function (data) {
            $("#bottomgrid").html(data);
            var cash = 0;
            var bank = 0;
            $("#tblProductGrid").find("tr").each(function () {

                var mode = $(this).find("td:nth-child(7)").text().trim();;
                if (mode == "Cash") {
                    var amount = Number($(this).find("td:nth-child(4)").text());
                    cash = cash + amount;
                }
                else {

                    var amount = Number($(this).find("td:nth-child(4)").text());
                    bank = bank + amount;
                }



            });
            $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");
            //$("#cashbankamount").html("Cash Payment: " + cash + " , Bank Payment : " + bank + "");
            $("#psspinner2").hide();
            $.ajax({
                type: "get",
                url: '../ReceiptsandPayments/GetPurchaseSales',// url: "@Url.Action("GetPurchaseSales", "ReceiptsandPayments")",
                data: {
                mode: 2,
                },
            success: function (data) {
                $.each(data, function () {
                    $("#cmbps").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                });
            }
        });

    }
});


}




}
function PaymentsChange() {
    $("#Addlesstab").show();
    $("#Generaltab").hide();
   // var ddl = $("select.mustprovide").val();
    if ($("#rdPayments").is(":checked")) {
        $("#ckhAdjustments").attr("checked", false);
        $("#psspinner2").show();
        $("#crsection").hide();
        $("#cashmode").show();
        $("#divoutstanding").show();
        $("#cmbps").val("0");
        $("#cmbbill").empty();
        //var textbox = $("input.mustprovide").val();
        //var ddltext = $("select.mustprovide :selected").text();
        if ($("#rdcash").is(":checked")) {
            $("#rdcash").trigger("change");
          
            //$("#cmbReturnAccountsc_1").prop("value", ddl);
            //$("#select2-cmbReturnAccountsc_1-container").text(ddltext);
            //$("#Receiptc_1").val(textbox);
        }
        else if ($("#rdbank").is(":checked")) {
            $("#rdbank").trigger("change");
           
            //$("#select2-cmbReturnAccounts_1-container").text(ddltext);
            //$("#cmbReturnAccounts_1").prop("value", ddl);
            //$("#Receipt_1").val(textbox);
        }
        //$("#FromDate").val($("#ViewCurrentDate").val());
        //$("#ToDate").val($("#ViewCurrentDate").val());
        $("#tblreturns").find("tr").each(function () {
            var id = $(this).attr("id").split("_")[1];

            $("#tdmode_" + id + "").show();
            $("#tdchkno_" + id + "").show();
            $("#tdchkdt_" + id + "").show();
            $("#thmode").show();
        });

        var mode = 1;
        var dt = $("#txtreturndt").val();
        $.ajax({
            type: "get",
            url: '../ReceiptsPaymentsContra/GetGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
            data: {
            mode: mode,
            dt: dt,

            },
        success: function (data) {
            $("#bottomgrid").html(data);
            var cash = 0;
            var bank = 0;
            $("#tblProductGrid").find("tr").each(function () {

                var mode = $(this).find("td:nth-child(7)").text().trim();;
                if (mode == "Cash") {
                    var amount = Number($(this).find("td:nth-child(4)").text());
                    cash = cash + amount;
                }
                else {

                    var amount = Number($(this).find("td:nth-child(4)").text());
                    bank = bank + amount;
                }



            });
            $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");

            //$("#cashbankamount").html("Cash Payment: " + cash + " , Bank Payment : " + bank + "");
            $("#psspinner2").hide();
            $("#cmbps").empty();
            $.ajax({
                type: "get",
                url: '../ReceiptsandPayments/GetPurchaseSales',// url: "@Url.Action("GetPurchaseSales", "ReceiptsandPayments")",
                data: {
                mode: 1,
                },
            success: function (data) {
                $.each(data, function () {
                    $("#cmbps").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                });
            }
        });

    }
});


}


}
function ContraChange() {
    $("#Addlesstab").show();
    $("#Generaltab").hide();
    if ($("#rdContra").is(":checked")) {
        $("#crsection").show();
        $("#cashmode").hide();
        $("#divoutstanding").hide();
        $("#tblreturnscash").empty();
          PSReturnsCash();
        //}
        $("#extrareturnscash").show();
        $("#extrareturns").hide();
        $("#submitbuttons").html("<button class='btn btn-danger' type='button'  onclick='btnconfirmcash()' >Submit</button>");
        $("#Inwardcash").hide();
        $("#Inwardbank").hide();
        $("#extraoutstabding").hide();
        $("#extraoutstabdingcash").hide();
        $("#extraoutstabding").hide();
        $("#extraoutstabdingcash").hide()

        $("#extrareturns").hide();

        $("#ckhInward").attr("checked", false);
        $("#lblps").text("")
        $("#lblbillno").text("")
        $("#lblcustomer").text("")
        var mode = 3;
        var dt = $("#txtreturndt").val();
        $("#psspinner2").show();
        $.ajax({
            type: "get",
            url: '../ReceiptsPaymentsContra/GetGrid',// url: "@Url.Action("GetGrid", "ReceiptsPaymentsContra")",
            data: {
            mode: mode,
            dt: dt,

            },
        success: function (data) {
            $("#bottomgrid").html(data);
            var cash = 0;
            var bank = 0;
            $("#tblProductGrid").find("tr").each(function () {

                var mode = $(this).find("td:nth-child(7)").text().trim();;
                if (mode == "Cash") {
                    var amount = Number($(this).find("td:nth-child(4)").text());
                    cash = cash + amount;
                }
                else {

                    var amount = Number($(this).find("td:nth-child(4)").text());
                    bank = bank + amount;
                }



            });
            $("#cashbankamount").html("<lable class='label vd_bg-blue vd_white'>Cash: " + cash + "</lable> <span><lable class='label vd_bg-green vd_white'>Bank: " + bank + "</lable></span>");
            //$("#cashbankamount").html("Cash Payment: " + cash + " , Bank Payment : " + bank + "");
            $("#psspinner2").hide();
        }
    });
}



}
function DeleteAddless(id) {
    if (confirm("Are you Sure to delete a record?")) {
        $.ajax({
            type: "get",
            url: '../ReceiptsPaymentsContra/DeleteAddless',// url: "@Url.Action("DeleteAddless", "ReceiptsPaymentsContra")",
            data: {
            id: id,
            },
        success: function (data) {
            if (data == "success") {
                var td = document.getElementById("D_" + id).parentNode.id;
                $("#" + td + "").remove();
                notification("topright", "info", "fa fa-check vd_green", "Success", "Record deleted successfully");

            }
            else if (data == "fail") {
                notification("topright", "notify", "fa fa-times vd_green", "Error", "Error in submitting form");

            }
        }
    });
}
}
function DeleteAddlessAck(id) {
    if (confirm("Are you Sure to delete a record?")) {
        $.ajax({
            type: "get",
            url: '../ReceiptsPaymentsContra/DeleteAddlessAck',// url: "@Url.Action("DeleteAddlessAck", "ReceiptsPaymentsContra")",
            data: {
            id: id,
            },
        success: function (data) {
            if (data == "success") {

                var td = document.getElementById("D_" + id).parentNode.id;
                $("#" + td + "").remove();
                notification("topright", "info", "fa fa-check vd_green", "Success", "Record deleted successfully");

            }
            else if (data == "fail") {
                notification("topright", "notify", "fa fa-times vd_green", "Error", "Error in submitting form");

            }
        }
    });
}
}
function AddAddlessAck(id) {
    $("#aa_" + id + "").remove();
    AddInwardCash();
}
function AddAddless(id) {
    $("#aa_" + id + "").remove();
    AddInwardCash();
}
function GroupPayment() {
    $("#mainsection").hide();
    $("#reportsection").show();
    $("#Transactionsection").hide();
    $("#iframereport").show();
    $("#reportname").val("GroupPayment");
    document.getElementById('iframereport').src = "/stiReport/Index?form=GroupPayment&pid=" + 0 + "&total=norp";

}
function CashBankBook() {
    var fromdt = $("#FromDate").val();
    var todt = $("#ToDate").val();
    var date = fromdt + "~" + todt;
    $("#mainsection").hide();
    $("#reportsection").show();
    $("#Transactionsection").hide();
    $("#iframereport").show();
    $("#reportname").val("CashBankBook");
    document.getElementById('iframereport').src = "/stiReport/Index?form=CashBankBook&pid=" + date + "&total=norp";

}

function GetTransactionDetails() {
    $("#Transactionsection").show();
    $("#iframereport").show();
    var id = $("#hdnCustomerId").val();
    $("#reportname").val("ReceiptsVouchergenerate");
    document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVouchergenerate&pid=" + id + "&total=rp";
}

function Voucher() {
    var date = $("#txtreturndt").val();
    if ($("#rdPayments").is(":checked")) {
        $("#mainsection").hide();
        $("#reportsection").show();
        $("#Transactionsection").hide();
        $("#iframereport").show();
        $("#reportname").val("PaymentsVoucher");
        document.getElementById('iframereport').src = "/stiReport/Index?form=PaymentsVoucher&pid=" + date + "&total=norp";


    }
    else if ($("#rdReceipts").is(":checked")) {
        $("#mainsection").hide();
        $("#reportsection").show();
        $("#Transactionsection").hide();
        $("#iframereport").show();
        $("#reportname").val("ReceiptsVoucher");
        document.getElementById('iframereport').src = "/stiReport/Index?form=ReceiptsVoucher&pid=" + date + "&total=norp";

    }

}

function CancelReport() {
    $("#mainsection").show();
    $("#reportsection").hide();


}

function TransactionVoucher() {
    $("#mainsection").hide();
    $("#reportsection").show();
    $("#Transactionsection").show();
    $("#iframereport").hide();

}
function EditReport() {
    var rpt = $("#reportname").val();
    $("#reportpanel").show();
    $("#datepanel").hide();
    $("#datapanel").hide();
    document.getElementById('iframereport').src = "/EditDynamicReports/Index1?reportname=" + rpt + "";

}

function ContinousVoucher() {
    var fromdt = $("#FromDate").val();
    var todt = $("#ToDate").val();
    var date = fromdt + "~" + todt;
    if ($("#rdPayments").is(":checked")) {
        $("#mainsection").hide();
        $("#reportsection").show();
        $("#reportname").val("ContinousPaymentsVoucher");
        document.getElementById('iframereport').src = "/stiReport/Index?form=ContinousPaymentsVoucher&pid=" + date + "&total=norp";
      
    }
    else if ($("#rdReceipts").is(":checked")) {
        $("#mainsection").hide();
        $("#reportsection").show();
  
    }
}


function Onsubmittaccount() {

    var PersonalAccountId = $("#PersonalAccountId").val();
    var AccountId = $("#AccountId").val();
    var Account = $("#Account").val();
    var NatureId = $("#NatureId").val();
    var IsPersonal = $("#chkpersonal").is(":checked"); 
    var Data = {
        "PersonalAccountId": PersonalAccountId,
        "AccountId": AccountId,
        "Account": Account,
        "NatureId": NatureId,
        "IsPersonal": IsPersonal
    }
    $.ajax({
        url: '../AccountNature/Savetb1',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.split("_")[0] == "success") {
                success();
                var no = 0;
                var nob = 0;
                if ($("#rdcash").is(":checked")) {
                    no = $("#tblreturnscash").find("tr:last").attr("id").split("_")[1];
                }
                else if ($("#rdbank").is(":checked")) {
                    nob = $("#tblreturns").find("tr:last").attr("id").split("_")[1];
                }
                setTimeout(function () {
                    $("#btnCancel").trigger("click");

                    $("#cmbReturnAccountsc_" + no + "").empty();
                            $.ajax({
                            type: "get",
                            url: '../ReceiptsPaymentsContra/selectedAccount',
                            data: {
                                Account: Account
                            },
                            success: function (data) {

                                $("#hdncmbReturnAccountsc_" + no + "").val(data);
                                $("#cmbReturnAccountsc_" + no + "").val(Account);
                                $("#hdncmbReturnAccounts_" + nob + "").val(data);
                                $("#cmbReturnAccounts_" + nob + "").val(Account);
                               // $("#select2-cmbReturnAccountsc_" + no + "-container").text(Account);
                               // $("#select2-cmbReturnAccountsc_" + no + "-container").attr("title", Account);

                            }
                        });
                    var ClassObjs = {};
                    var ClassNames = [];

                    $("#cmbReturnAccountsc_" + no + "").typeahead({
                        source: function (query, process) {

                            $.ajax({
                                url: '../Purchase_Sales/GetSubAccount'
                                , data: {
                                   
                                }
                                , cache: false
                                , success: function (data) {

                                    ClassObjs = {};
                                    ClassNames = [];

                                    _.each(data, function (item, ix, list) {
                                        ClassNames.push(item.Text);
                                        ClassObjs[item.Text] = item.Value;
                                    });

                                    process(ClassNames);
                                }
                            });
                        }
                        , updater: function (selectedName) {

                            $("#hdncmbReturnAccountsc_" + no + "").val(ClassObjs[selectedName]);

                            return selectedName;
                        }
                    });
                //    $.ajax({
                //        type: "get",
                //        url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
                //        data: {
                //        },
                //    success: function (data) {
                //        $.each(data, function () {
                //            $("#cmbReturnAccountsc_" + no + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

                //        });
                //        $.ajax({
                //            type: "get",
                //            url: '../ReceiptsPaymentsContra/selectedAccount',
                //            data: {
                //                Account: Account
                //            },
                //            success: function (data) {

                //                $("#cmbReturnAccountsc_" + no + "").val(data);
                             
                //                $("#select2-cmbReturnAccountsc_" + no + "-container").text(Account);
                //                $("#select2-cmbReturnAccountsc_" + no + "-container").attr("title", Account);

                //            }
                //        });


                //    }
                //});

               // $("#cmbReturnAccountsc_" + no + "").select2();

                //tblreturns
               // $("#cmbReturnAccountsc_" + nob + "").empty();
                var ClassObjs = {};
                var ClassNames = [];

                $("#cmbReturnAccounts_" + nob + "").typeahead({
                    source: function (query, process) {

                        $.ajax({
                            url: '../Purchase_Sales/GetSubAccount'
                            , data: {
                               
                            }
                            , cache: false
                            , success: function (data) {

                                ClassObjs = {};
                                ClassNames = [];

                                _.each(data, function (item, ix, list) {
                                    ClassNames.push(item.Text);
                                    ClassObjs[item.Text] = item.Value;
                                });

                                process(ClassNames);
                            }
                        });
                    }
                    , updater: function (selectedName) {

                        $("#hdncmbReturnAccounts_" + nob + "").val(ClassObjs[selectedName]);

                        return selectedName;
                    }
                });
            //    $.ajax({
            //        type: "get",
            //        url: '../Purchase_Sales/GetSubAccount',// url: "@Url.Action("GetSubAccount", "Purchase_Sales")",
            //        data: {
            //        },
            //    success: function (data) {
            //        $.each(data, function () {
            //            $("#cmbReturnAccounts_" + nob + "").append("<option value=" + this.Value + ">" + this.Text + "</option>");

            //        });
            //        $.ajax({
            //            type: "get",
            //            url: '../ReceiptsPaymentsContra/selectedAccount',
            //            data: {
            //                Account: Account
            //            },
            //            success: function (data) {

            //                $("#cmbReturnAccountsc_" + no + "").val(data);
            //                if ($("#cmbReturnAccountsc_" + no + "").val() == null) {
            //                    $("#cmbReturnAccountsc_" + no + "").val(data);


            //                };
            //                $("#select2-cmbReturnAccountsc_" + no + "-container").text(Account);
            //                $("#select2-cmbReturnAccountsc_" + no + "-container").attr("title", Account);

            //                $("#cmbReturnAccounts_" + nob + "").val(data);
            //                //alert($("#cmbReturnAccounts_" + nob + " :selected").val());
            //                $("#select2-cmbReturnAccounts_" + nob + "-container").text(Account);
            //                $("#select2-cmbReturnAccounts_" + nob + "-container").attr("title", Account);
            //            }
            //        });


            //    }
            //});


         


    //$("#cmbReturnAccounts_" + nob + "").select2();
}, 500);
}
else if (data == "alreadyexists") {
    $.ajax({
        type: "get",
        url: '../ReceiptsPaymentsContra/GetAccount_Nature',
        data: {
        Account: Account
        },
    success: function (data) {
        notification("topright", "info", "fa fa-exclamation-triangle vd_yellow", "Warning", "Account '" + Account + "' with Nature '" + data + "' already exists");

    }
});
}
else if (data == "fail") {
    fail();
}
}
});

}
