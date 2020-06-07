//http://bitwalker.org/keys.js/examples.html
//$(document).keypress(function (e) {
//    //if (e.altKey) {
//    //    alert("hi");
//    //}
//    if (e.KeyCode == Keys.A && e.Alt) {
//        alert("hello");
//    }

//});
//$(document).bind('keydown ', function (event) {
//    if (event.which === 65 && (event.ctrlKey)) {
//        which.preventDefault();
//        alert('you pressed Alt+A');
//    }
//});


//$(document).keypress("c", function (e) {
//    alert("hii");
//    if (e.ctrlKey)
//        alert("Ctrl+C was pressed!!");
//});

//$(document).on('keydown', function (e) {
//    // You may replace `c` with whatever key you want
//    if (e.ctrlKey && (String.fromCharCode(e.which).toLowerCase() === 'c')) {
//        console.log("You pressed CTRL + C");
//    }
//});

$(document).ready(function () {
    // tablenavigate()
    //$("#mainsection").find('select').select2();
  
    function activaTab(tab) {
        $('.nav-tabs a[href="#' + tab + '"]').tab('show');
    };
   

    

    //$(document).on({
    //    mousehover: function () {
    //        trIndex = $(this).index() + 1;
    //        $("#tbodytb1").each(function (index) {
    //            $(this).find("tr:eq(" + trIndex + ")").each(function (index) {
    //                $(this).find("td :first").html();
    //                alert($(this).find("td :first").html());
    //            });
    //        });
    //    },
    //    //mouseleave: function () {
    //    //    trIndex = $(this).index() + 1;
    //    //    $("#tbodytb1").each(function (index) {
    //    //        $(this).find("tr:eq(" + trIndex + ")").each(function (index) {
    //    //            //$(this).find("td").removeClass("hover");
    //    //            alert($(this).find("td :first").html());
    //    //        });
    //    //    });
    //    //}
    //}
    //);
    //$("#tbodytb1").on("blur", function () {
    //    alert('mouseover works!!!!!!!!!');
    //});
    //$("#tbodytb1").find("tr").hover(function () {
    //    var valueOfTd = $(this).find('td:first-child').text();
    //    alert(valueOfTd); // Do here what you want with the value.
    //    //document.location.href = 'http://www.google.com/'+ valueOfTd;
    //});
});





$(document).keydown(function (e) {


   
});
//(function () {
//    // do some stuff
//    setInterval(populatesessions(), 60000);
//})();

function populatesessions()
{
    $.ajax({
        type: "get",
        url: '../Base/PopulateDropDownValues',
        data: {
        },
    success: function (data) {
       
    }
});

}


function selectedDeletedrow() {
    if (type == "tb1") {

        $("#tbodytb1").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            Deletetb1(id, hiddenController);
        });
    }
    else if (type == "tb2") {
        $("#tbodytb2").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            Deletetb2(id, hiddenController);
        });
    }
    else if (type == "tb3") {
        $("#tbodytb3").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            Deletetb3(id, hiddenController);
        });
    }
    else if (type == "tb4") {
        $("#tbodytb4").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            Deletetb4(id, hiddenController);
        });
    }
    else if (type == "tb5") {
        $("#tbodytb5").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            Deletetb5(id, hiddenController);
        });
    }
}
//rowClicktb1
function selectedEditedrow() {
    if (type == "tb1") {

        $("#tbodytb1").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];

            rowClicktb1(id, hiddenController);

            //rowClickslidetb1(id, hiddenController);
            $('#FormPaneltb1 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb1 :input[type!=hidden]:first').focus()
                $("#savespinnertb1").hide();
            }, 500);
        });
    }
    else if (type == "tb2") {
        $("#tbodytb2").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            rowClicktb2(id, hiddenController);
            // rowClickslidetb2(id, hiddenController);
            $('#FormPaneltb3 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb3 :input[type!=hidden]:first').focus()
                $("#savespinnertb3").hide();
            }, 500);

        });
    }
    else if (type == "tb3") {
        $("#tbodytb3").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            rowClicktb3(id, hiddenController);
            $('#FormPaneltb3 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb3 :input[type!=hidden]:first').focus()
                $("#savespinnertb3").hide();
            }, 500);
        });
    }
    else if (type == "tb4") {
        $("#tbodytb4").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            rowClicktb4(id, hiddenController);
            $('#FormPaneltb4 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb4 :input[type!=hidden]:first').focus()
                $("#savespinnertb4").hide();
            }, 500);
        });
    }
    else if (type == "tb5") {
        $("#tbodytb5").find("tr :hover").each(function () {
            var id = $(this).closest('tr').attr("id").split("_")[1];
            rowClicktb5(id, hiddenController);
            $('#FormPaneltb5 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb5 :input[type!=hidden]:first').focus()
                $("#savespinnertb5").hide();
            }, 500);
        });
    }
}


function ShortcutCancelFields() {
    $('input').blur();
    if (type == "tb1") {
        CancelFieldstb1();
        $('#slideout_innertb1').hide();
        $('#slideout_innertb1').css("width", "0px");
    }
    else if (type == "tb2") {
        CancelFieldstb2();
        $('#slideout_innertb2').hide();
        $('#slideout_innertb2').css("width", "0px");
    }
    else if (type == "tb3") {
        CancelFieldstb3();
    }
    else if (type == "tb4") {
        CancelFieldstb4();
    }
    else if (type == "tb4") {
        CancelFieldstb4();
    }

}
function ShortcutClearFields() {
    $('input').blur();
    if (type == "tb1") {
        ClearFieldstb1();
    }
    else if (type == "tb2") {
        ClearFieldstb2();
    }
    else if (type == "tb3") {
        ClearFieldstb3();
    }
    else if (type == "tb4") {
        ClearFieldstb3();
    }
    else if (type == "tb5") {
        ClearFieldstb3();
    }
}
function ShortcutNewRecord() {
    $('input').blur();
    if (type == "tb1") {
        NewRecordtb1();
        //NewRecordslidetb1();
        $('#FormPaneltb1 :input[type!=hidden]:first').attr("autofocus", "");
        setTimeout(function () {
            $('#FormPaneltb1 :input[type!=hidden]:first').focus()
            $("#savespinnertb1").hide();
            if (hiddenController == "AccountNature") {
                setTimeout(function () {
                    $('#FormPaneltb1 :input[type!=hidden]:first').focus()
                    $("#hiddenpanel").hide();
                    $("#savespinnertb1").hide();
                    $("#NatureId").select2();
                }, 700);
            }
        }, 500);
        $('.form-control').each(function (index, element) {
            $(this).select2({
                minimumResultsForSearch: -1
            });
        });
    }
    else if (type == "tb2") {
        NewRecordtb2();
        //NewRecordslidetb2();
        $('#FormPaneltb2 :input[type!=hidden]:first').attr("autofocus", "");
        setTimeout(function () {
            $('#FormPaneltb2 :input[type!=hidden]:first').focus()
            $("#savespinnertb2").hide();
        }, 500);
    }
    else if (type == "tb3") {
        NewRecordtb3();
        $('#FormPaneltb3 :input[type!=hidden]:first').attr("autofocus", "");
        setTimeout(function () {
            $('#FormPaneltb3 :input[type!=hidden]:first').focus()
            $("#savespinnertb3").hide();
        }, 500);
    }
    else if (type == "tb4") {
        NewRecordtb4();
        $('#FormPaneltb4 :input[type!=hidden]:first').attr("autofocus", "");
        setTimeout(function () {
            $('#FormPaneltb4 :input[type!=hidden]:first').focus()
            $("#savespinnertb4").hide();
        }, 500);
    }
    else if (type == "tb5") {
        NewRecordtb5();
        $('#FormPaneltb5 :input[type!=hidden]:first').attr("autofocus", "");
        setTimeout(function () {
            $('#FormPaneltb5 :input[type!=hidden]:first').focus()
            $("#savespinnertb5").hide();
        }, 500);
    }
}
function ShortcutSaveRecord() {
    $('input').blur();
    if (type == "tb1") {
        Onsubmittb1();
    }
    else if (type == "tb2") {
        Onsubmittb2();
    }
    else if (type == "tb3") {
        Onsubmittb3();
    }
    else if (type == "tb4") {
        Onsubmittb4();
    }
    else if (type == "tb5") {
        Onsubmittb5();
    }
}
function ShortcutDeleteRecord() {

}


var Hiddendata = [];

//alt+s for save
//alt+d for delete
//alt+r for reports
var hiddenController = "";
var type = "";
var totaltabs = 0;

function SortColumn(id) {

}


function ShowLoader() {
    $(".blockUI").show();
    $(".blockUI blockOverlay").show();
    $(".blockUI blockMsg blockElement").show();

}

function HideLoader() {

    $(".blockUI").hide();
    $(".blockUI blockOverlay").hide();
    $(".blockUI blockMsg blockElement").hide();

}
function HideNotifications() {

    $("#divsuccessmsg").hide();
    $("#diverrormsg").hide();
    $("#divwarningmsg").hide();
}
function success() {
    $(".ui-pnotify-closer").trigger("click");
    notification("bottomright", "success", "fa fa-check-circle vd_green", "Success Notification", "Record Submitted Successfully");

}
function deleted() {
    $(".ui-pnotify-closer").trigger("click");
    notification("bottomright", "success", "fa fa-check-circle vd_green", "Success Notification", "Record Deleted Successfully");

}
function fail() {
    $(".ui-pnotify-closer").trigger("click");
    notification("bottomright", "notify", "fa fa-exclamation-triangle vd_yellow", "Error", "Error in record submission");

}

function dependent() {
    $(".ui-pnotify-closer").trigger("click");
    notification("bottomright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Record has dependent Transactions");

}

function required(msg) {
    $(".ui-pnotify-closer").trigger("click");
    notification("bottomright", "notify", "fa fa-exclamation-triangle vd_yellow", "Field Required", msg);
}
function alreadyexists() {
    $(".ui-pnotify-closer").trigger("click");
    notification("bottomright", "notify", "fa fa-exclamation-triangle vd_yellow", "Warning", "Record already exists");


}

function RequiredFieldstb1() {
    var valid = 0;
    $("#FormPaneltb1").find(".form-control-required").each(function () {
        var id = $(this).attr("id");
        var req = $("#s" + id + "").attr("title");
        var msg = "Provide " + req;
        if ($(this).val() == "") {
            $(this).css("border-color", "red");
            $("#select2-" + id + "-container").css("border", "1px solid red");
            $("#s" + id + "").html(msg);
            valid++;
        }
        else {
            $(this).css("border-color", "");
            $("#select2-" + id + "-container").css("border", "none");
            $("#stb1" + id + "").html("");
        }

    });
    return valid;
}

function RequiredFieldstb2() {
    var valid = 0;
    $("#FormPaneltb2").find(".form-control-required").each(function () {
        var id = $(this).attr("id");
        var req = $("#s" + id + "").attr("title");
        var msg = "Provide " + req;
        if ($(this).val() == "") {
            $(this).css("border-color", "red");
            $("#select2-" + id + "-container").css("border", "1px solid red");
            $("#s" + id + "").html(msg);
            valid++;
        }
        else {
            $(this).css("border-color", "");
            $("#select2-" + id + "-container").css("border", "none");
            $("#stb2" + id + "").html("");
        }

    });
    return valid;
}
function RequiredFieldstb3() {
    var valid = 0;
    $("#FormPaneltb3").find(".form-control-required").each(function () {
        var id = $(this).attr("id");
       // alert($(this).val());
        var req = $("#s" + id + "").attr("title");
        var msg = "Provide " + req;
        if ($(this).val() == "") {
            $(this).css("border-color", "red");
            //select2-ClassId2-container
            $("#select2-" + id + "-container").css("border", "1px solid red");
            $("#s" + id + "").html(msg);
            valid++;
        }
        else {
            $(this).css("border-color", "");
            $("#select2-" + id + "-container").css("border", "none");
            $("#stb3" + id + "").html("");
        }

    });
    return valid;
}
function RequiredFieldstb5() {
    var valid = 0;
    $("#FormPaneltb5").find(".form-control-required").each(function () {
        var id = $(this).attr("id");
        var req = $("#s" + id + "").attr("title");
        var msg = "Provide " + req;
        if ($(this).val() == "") {
            $(this).css("border-color", "red");
            $("#select2-" + id + "-container").css("border", "1px solid red");
            $("#s" + id + "").html(msg);
            valid++;
        }
        else {
            $(this).css("border-color", "");
            $("#select2-" + id + "-container").css("border", "none");
            $("#stb5" + id + "").html("");
        }

    });
    return valid;
}
function RequiredFieldstb4() {
    var valid = 0;
    $("#FormPaneltb4").find(".form-control-required").each(function () {
        var id = $(this).attr("id");
        var req = $("#s" + id + "").attr("title");
        var msg = "Provide " + req;
        if ($(this).val() == "") {
            $(this).css("border-color", "red");
            $("#select2-" + id + "-container").css("border", "1px solid red");
            $("#s" + id + "").html(msg);
            valid++;
        }
        else {
            $(this).css("border-color", "");
            $("#select2-" + id + "-container").css("border", "none");
            $("#stb4" + id + "").html("");
        }

    });
    return valid;
}
function NewRecordtb1() {
    var controller = hiddenController;//$(id).attr("id");
    //if (controller.indexOf("1") != -1) {
    //    controller = controller.split("_")[1];
    //}

    $.ajax({
        url: '../' + controller + '/GetControlstb1',
        success: function (data) {
            $("#FormPaneltb1").html(data);
        }
    });
    $("#FormPaneltb1").show();
    $('#FormPaneltb1 :input[type!=hidden]:first').attr("autofocus", "");
    setTimeout(function () {
        $('#FormPaneltb1 :input[type!=hidden]:first').focus()
        $("#savespinnertb1").hide();
        if (hiddenController == "AccountNature") {
            setTimeout(function () {
                $('#FormPaneltb1 :input[type!=hidden]:first').focus()
                $("#hiddenpanel").hide();
                $("#savespinnertb1").hide();
                $("#NatureId").select2();
                $("#controllername").val(controller);
            }, 700);
        }
        $('#FormPaneltb1').find('select').each(function () {
            var ddlid = $(this).attr("id");
            $("#" + ddlid + "").select2();
        });
    }, 500);

    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    HideNotifications()

}


function NewRecordtb2() {
    var controller = hiddenController;//$(id).attr("id");
    //if (controller.indexOf("2") != -1) {
    //    controller = controller.split("_")[1];
    //}

    $.ajax({
        url: '../' + controller + '/GetControlstb2',
        success: function (data) {
            $("#FormPaneltb2").html(data);
        }
    });
    $("#FormPaneltb2").show();
    $('#FormPaneltb2 :input[type!=hidden]:first').attr("autofocus", "");
    setTimeout(function () {
        $('#FormPaneltb2 :input[type!=hidden]:first').focus()
        $("#savespinnertb2").hide();
        $('#FormPaneltb2').find('select').each(function () {
            var ddlid = $(this).attr("id");
            $("#" + ddlid + "").select2();
        });
    }, 500);
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('.form-control-required').each(function (index, element) {
        $(this).select2({
            minimumResultsForSearch: -1
        });
    });
    HideNotifications()
}

function NewRecordtb3() {
    var controller = hiddenController;//$(id).attr("id");
    //if (controller.indexOf("2") != -1) {
    //    controller = controller.split("_")[1];
    //}

    $.ajax({
        url: '../' + controller + '/GetControlstb3',
        success: function (data) {
            $("#FormPaneltb3").html(data);
        }
    });
    $("#FormPaneltb3").show();
    $('#FormPaneltb3 :input[type!=hidden]:first').attr("autofocus", "");
    setTimeout(function () {
        $('#FormPaneltb3 :input[type!=hidden]:first').focus()
        $("#savespinnertb3").hide();
        $('#FormPaneltb3').find('select').each(function () {
            var ddlid = $(this).attr("id");
            $("#" + ddlid + "").select2();
        });
    }, 500);
    $('.form-control-required').each(function (index, element) {
        $(this).select2({
            minimumResultsForSearch: -1
        });
    });
    $("#tbodytb3").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });

    HideNotifications()
}

function NewRecordtb4() {
    var controller = hiddenController;//$(id).attr("id");
    //if (controller.indexOf("2") != -1) {
    //    controller = controller.split("_")[1];
    //}

    $.ajax({
        url: '../' + controller + '/GetControlstb4',
        success: function (data) {
            $("#FormPaneltb4").html(data);
        }
    });
    $("#FormPaneltb4").show();
    $('#FormPaneltb4 :input[type!=hidden]:first').attr("autofocus", "");
    setTimeout(function () {
        $('#FormPaneltb4 :input[type!=hidden]:first').focus()
        $("#savespinnertb4").hide();
        $('#FormPaneltb4').find('select').each(function () {
            var ddlid = $(this).attr("id");
            $("#" + ddlid + "").select2();
        });
    }, 500);
    $('.form-control-required').each(function (index, element) {
        $(this).select2({
            minimumResultsForSearch: -1
        });
    });
    $("#tbodytb4").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });

    HideNotifications()
}
function NewRecordtb5() {
    var controller = hiddenController;//$(id).attr("id");
    //if (controller.indexOf("2") != -1) {
    //    controller = controller.split("_")[1];
    //}

    $.ajax({
        url: '../' + controller + '/GetControlstb5',
        success: function (data) {
            $("#FormPaneltb5").html(data);
        }
    });
    $("#FormPaneltb5").show();
    $('#FormPaneltb5 :input[type!=hidden]:first').attr("autofocus", "");
    setTimeout(function () {
        $('#FormPaneltb5 :input[type!=hidden]:first').focus()
        $("#savespinnertb5").hide();
        $('#FormPaneltb5').find('select').each(function () {
            var ddlid = $(this).attr("id");
            $("#" + ddlid + "").select2();
        });
    }, 500);
    $('.form-control-required').each(function (index, element) {
        $(this).select2({
            minimumResultsForSearch: -1
        });
    });
    $("#tbodytb5").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });

    HideNotifications()
}
function NewRecordslidetb2() {
    //$('#slideout').css("right", "500px");
    //$('#slideout_inner').css("right", "300px");
    $('#slideout_innertb2').show();
    $('#slideout_innertb2').css("width", "600px");
    //var controller = $(id).attr("id");
    var controller = hiddenController;//$(id).attr("id");
    //if (controller.indexOf("2") != -1) {
    //    controller = controller.split("_")[1];
    //}

    $.ajax({
        url: '../' + controller + '/GetControlstb2',
        success: function (data) {
            $("#FormPaneltb2").html(data);
        }
    });
    $("#FormPaneltb2").show();
    $('#FormPaneltb2 :input[type!=hidden]:first').attr("autofocus", "");
    setTimeout(function () {

        $('#FormPaneltb2 :input[type!=hidden]:first').focus()
        $("#savespinnertb2").hide();

    }, 500);
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });

    HideNotifications()
}

function Reporttb2(id) {
    var form = $(id).attr("id").split("_")[1];
    $("#tb2form").hide();
    $("#tb2report").show();
    //stiReport/Index?form=ReceiptsVouchergenerate&pid=' + data.jid + '&total=rp'
    document.getElementById('iframereporttb2').src = "/stiReport/Index?form=" + form + "&pid=''&total=norp";

}
function Reporttb1(id) {
    var form = $(id).attr("id").split("_")[1];
    $("#tb1form").hide();
    $("#tb1report").show();
    document.getElementById('iframereporttb1').src = "/stiReport/Index?form=" + form + "&pid=''&total=norp";


}
function Reporttb3(id) {
    var form = $(id).attr("id").split("_")[1];
    $("#tb1form").hide();
    $("#tb1report").show();
    document.getElementById('iframereporttb3').src = "/stiReport/Index?form=" + form + "&pid=''&total=norp";


}
function tb1CancelReport() {
    $("#tb1form").show();
    $("#tb1report").hide();
}
function tb2CancelReport() {
    $("#tb2form").show();
    $("#tb2report").hide();
}
function tb3CancelReport() {
    $("#tb3form").show();
    $("#tb3report").hide();
}
function NewRecordslidetb1() {
    //$('#slideout').css("right", "500px");
    //$('#slideout_inner').css("right", "300px");
    $('#slideout_innertb1').show();
    $('#slideout_innertb1').css("width", "600px");
    //var controller = $(id).attr("id");
    var controller = hiddenController;//$(id).attr("id");
    //if (controller.indexOf("1") != -1) {
    //    controller = controller.split("_")[1];
    //}

    $.ajax({
        url: '../' + controller + '/GetControlstb1',
        success: function (data) {
            $("#FormPaneltb1").html(data);
        }
    });
    $("#FormPaneltb1").show();
    $('#FormPaneltb1 :input[type!=hidden]:first').attr("autofocus", "");
    setTimeout(function () {
        $('#FormPaneltb1 :input[type!=hidden]:first').focus()
        $("#savespinnertb1").hide();
        if (controller == "PersonalAccount") {
            $("#hiddenpanel").hide();

        }
    }, 500);
    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb1_", "");
        $("#tb1_" + thisid + "").removeClass("danger");
    });

    HideNotifications()

}




function LoadGridtb1(controller, tottbs) {
    $("#loadertb1").show();
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Gettabletb1',
        data: {
        },
        success: function (data) {
            $("#gridtb1").html(data);
            HideLoader();
            $("#loadertb1").hide();
        }
    });
    hiddenController = controller;
    $("#controllername").val(controller);
    type = "tb1";
    totaltabs = tottbs;
}


function LoadGridtb2(controller, tottbs) {
    $("#loadertb2").show();

    $.ajax({
        type: "GET",
        url: '../' + controller + '/Gettabletb2',
        data: {
        },
        success: function (data) {
            $("#gridtb2").html(data);
            HideLoader();
            $("#loadertb2").hide();
            hiddenController = controller;
            type = "tb2";
            totaltabs = tottbs;
        }
    });
}

function LoadGridtb3(controller, tottbs) {
    $("#loadertb3").show();

    $.ajax({
        type: "GET",
        url: '../' + controller + '/Gettabletb3',
        data: {
        },
        success: function (data) {
            $("#gridtb3").html(data);
            HideLoader();
            $("#loadertb3").hide();
            hiddenController = controller;
            type = "tb3";
            totaltabs = tottbs;
        }
    });
}
function LoadGridtb4(controller, tottbs) {
    $("#loadertb4").show();

    $.ajax({
        type: "GET",
        url: '../' + controller + '/Gettabletb4',
        data: {
        },
        success: function (data) {
           
            $("#gridtb4").html(data);
            HideLoader();
            $("#loadertb4").hide();
            hiddenController = controller;
            type = "tb4";
            totaltabs = tottbs;
        }
    });
}
function LoadGridtb5(controller, tottbs) {
    $("#loadertb5").show();

    $.ajax({
        type: "GET",
        url: '../' + controller + '/Gettabletb5',
        data: {
        },
        success: function (data) {

            $("#gridtb5").html(data);
            HideLoader();
            $("#loadertb5").hide();
            hiddenController = controller;
            type = "tb5";
            totaltabs = tottbs;
        }
    });
}
function CancelFieldstb2() {
    $("#FormPaneltb2").each(function () {
        $(this).find("input[type=text],input[type=hidden], textarea").val("");
        $(this).find('select').val("");
        $(this).find("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $(this).find("span[class*='vd_red mandatory']").html("");
        $("#stb2" + id + "").html("");
    });
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('#FormPaneltb2 :input[type!=hidden]:first').attr("autofocus", "");
    $("#FormPaneltb2").hide();
    $("#loadertb2").hide();
    $("#savespinnertb2").hide();
    HideNotifications()
}

function CancelFieldstb1() {
    $("#FormPaneltb1").each(function () {
        $(this).find("input[type=text],input[type=hidden], textarea").val("");
        $(this).find('select').val("");
        $(this).find("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb1" + id + "").html("");
    });
    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('#FormPaneltb1 :input[type!=hidden]:first').attr("autofocus", "");
    $("#FormPaneltb1").hide();
    $("#loadertb1").hide();
    $("#savespinnertb1").hide();
    HideNotifications()
}


function CancelFieldstb3() {
    $("#FormPaneltb3").each(function () {
        $(this).find("input[type=text],input[type=hidden], textarea").val("");
        $(this).find('select').val("");
        $(this).find("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb3" + id + "").html("");
    });
    $("#tbodytb3").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('#FormPaneltb3 :input[type!=hidden]:first').attr("autofocus", "");
    $("#FormPaneltb3").hide();
    $("#loadertb3").hide();
    $("#savespinnertb3").hide();
    HideNotifications()
}
function CancelFieldstb4() {
    $("#FormPaneltb4").each(function () {
        $(this).find("input[type=text],input[type=hidden], textarea").val("");
        $(this).find('select').val("");
        $(this).find("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb4" + id + "").html("");
    });
    $("#tbodytb4").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('#FormPaneltb4 :input[type!=hidden]:first').attr("autofocus", "");
    $("#FormPaneltb4").hide();
    $("#loadertb4").hide();
    $("#savespinnertb4").hide();
    HideNotifications()
}
function CancelFieldstb5() {
    $("#FormPaneltb5").each(function () {
        $(this).find("input[type=text],input[type=hidden], textarea").val("");
        $(this).find('select').val("");
        $(this).find("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb5" + id + "").html("");
    });
    $("#tbodytb5").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('#FormPaneltb5 :input[type!=hidden]:first').attr("autofocus", "");
    $("#FormPaneltb5").hide();
    $("#loadertb5").hide();
    $("#savespinnertb5").hide();
    HideNotifications()
}
function ClearFieldstb1() {
    $("#FormPaneltb1").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
       // $('select').val("");
        $('select').each(function () {
            var selectid = ($(this).attr("id"));
            $(this).val("");
            $("#select2-" + selectid + "-container").text("Select");
        });
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $(".select2-selection__rendered").css("border", "none");
        $("#stb1" + id + "").html("");
    });
    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    setTimeout(function () {
        $('#FormPaneltb1 :input[type!=hidden]:first').focus()
        $("#savespinnertb1").hide();
    }, 500);
    HideNotifications()
    // NewRecord()

}


function ClearFieldstb2() {
    $("#FormPaneltb2").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
       
        $('select').each(function () {
            var selectid = ($(this).attr("id"));
            $(this).val("");
            $("#select2-" + selectid + "-container").text("Select");
        });
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $(".select2-selection__rendered").css("border", "none");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb2" + id + "").html("");
    });
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    setTimeout(function () {
        $('#FormPaneltb2 :input[type!=hidden]:first').focus()
        $("#savespinnertb2").hide();
    }, 500);
    HideNotifications()
    // NewRecord()

}
function ClearFieldstb3() {
    $("#FormPaneltb3").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
       // $('select').val("");
        $('select').each(function () {
            var selectid = ($(this).attr("id"));
            $(this).val("");
           $("#select2-" + selectid + "-container").text("Select");
        });
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
  
        $(this).find(".form-control-required").css("border-color", "");
        $(".select2-selection__rendered").css("border", "none");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb3" + id + "").html("");
    });
    $("#tbodytb3").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    setTimeout(function () {
        $('#FormPaneltb3 :input[type!=hidden]:first').focus()
        $("#savespinnertb3").hide();
    }, 500);
    HideNotifications()
    // NewRecord()

}
function ClearFieldstb5() {
    $("#FormPaneltb5").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
        $('select').val("");
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $(".select2-selection__rendered").css("border", "none");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb5" + id + "").html("");
    });
    $("#tbodytb5").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    setTimeout(function () {
        $('#FormPaneltb5 :input[type!=hidden]:first').focus()
        $("#savespinnertb5").hide();
    }, 500);
    HideNotifications()
    // NewRecord()

}
function ClearFieldstb4() {
    $("#FormPaneltb4").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
        $('select').val("");
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $(".select2-selection__rendered").css("border", "none");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb4" + id + "").html("");
    });
    $("#tbodytb4").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    setTimeout(function () {
        $('#FormPaneltb4 :input[type!=hidden]:first').focus()
        $("#savespinnertb4").hide();
    }, 500);
    HideNotifications()
    // NewRecord()

}
function CancelFieldsslidetb1() {
    $("#FormPaneltb1").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
        $('select').val("");
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb1" + id + "").html("");
    });
    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('#FormPaneltb1 :input[type!=hidden]:first').attr("autofocus", "");
    $("#FormPaneltb1").hide();
    $("#loadertb1").hide();
    $("#savespinnertb1").hide();
    $('#slideout_innertb1').hide();
    $('#slideout_innertb1').css("width", "0px");
    HideNotifications()
}
function CancelFieldsslidetb2() {
    $("#FormPaneltb2").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
        $('select').val("");
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb2" + id + "").html("");
    });
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    $('#FormPaneltb2 :input[type!=hidden]:first').attr("autofocus", "");
    $("#FormPaneltb2").hide();
    $("#loadertb2").hide();
    $("#savespinnertb2").hide();
    $('#slideout_innertb2').hide();
    $('#slideout_innertb2').css("width", "0px");
    HideNotifications()
}

function ClearFieldsslidetb1() {
    $("#FormPaneltb1").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
        $('select').val("");
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb1" + id + "").html("");
    });
    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    //NewRecordslide()
    HideNotifications()
}

function ClearFieldsslidetb2() {
    $("#FormPaneltb2").each(function () {
        $("input[type=text],input[type=hidden], textarea").val("");
        $('select').val("");
        $("input[type=checkbox]").attr("checked", false);
        var id = $(this).find(".form-control-required").attr("id");
        $(this).find(".form-control-required").css("border-color", "");
        $("span[class*='vd_red mandatory']").html("");
        $("#stb2" + id + "").html("");
    });
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        $("#" + thisid + "").removeClass("danger");
    });
    //NewRecordslide()
    HideNotifications()
}


var value = 0;
function updateProgress() {
    //$("#progressbar").progressbar("option", "value");
    if (value < 100) {
        $("#progressbar").css("width", value + 1 + "%");
        // $("#lblStatus").text((value + 1).toString() + "%");
        value++;
    }
}


function searchTabletb1(inputVal) {
    var table = $('#tbodytb1');
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

function searchTabletb2(inputVal) {
    var table = $('#tbodytb2');
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
function searchTabletb3(inputVal) {
    var table = $('#tbodytb3');
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
function searchTabletb4(inputVal) {
    var table = $('#tbodytb4');
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
function searchTabletb5(inputVal) {
    var table = $('#tbodytb5');
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

function limitedTextcount(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    var maxlength = 50;
    var thislength = $(evt.target).val().length;
    //alert(thislength);
    //var charec = /[A]|[a]/;
    if (maxlength <= thislength) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

function validate(id) {
    var newid = $(id).attr("id");
    var elem = document.getElementById(newid);
    var intervalId;

    var trimText = function () {
        elem.value = elem.value.substring(0, 50);
    }

    elem.onfocus = function () {
        intervalId = setInterval(trimText, 500);
    }

    elem.onblur = function () {
        clearInterval(intervalId);
        trimText();
    }
}



function DeleteSelectedrecord() {
    var Id = $("#DeleteSelectedrecordId").val().split("_")[0];
    var controller = $("#DeleteSelectedrecordId").val().split("_")[1];
    var deletetype = $("#Deletetype").val();
    if (deletetype == "tb1") {
        $("#loadertb1").show();
        $.ajax({
            type: "POST",
            url: '../' + controller + '/Deletetb1',
            data: {
                id: Id,
            },
            success: function (data) {
             
                if (data == "success") {

                    deleted();
                    HideNotifications()
                    $("#loadertb1").hide();
                    LoadGridtb1(controller, 5);
                    setTimeout(function () {
                        HideNotifications()

                    }, 500);
                    $("#closedeletepopup").trigger("click");
                }
                else if (data == "dependent") {

                    dependent();
                    $("#loadertb1").hide();
                }
                else if (data == "fail") {
                    fail();

                    $("#loadertb1").hide();
                }
               
            }
        });

    }
    else if (deletetype == "tb2") {
        $("#loadertb2").show();

        $.ajax({
            type: "POST",
            url: '../' + controller + '/Deletetb2',
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "success") {

                    deleted();
                    $("#loadertb2").hide();
                    HideNotifications()

                    LoadGridtb2(controller,5);
                    $("#tb2_" + Id + "").remove();
                    setTimeout(function () {
                        HideNotifications()

                    }, 500);
                    $("#closedeletepopup").trigger("click");
                }
                else if (data == "dependent") {

                    dependent();
                    $("#loadertb2").hide();
                }
                else if (data == "fail") {
                    fail();

                    $("#loadertb2").hide();
                }
            }
        });

    }
    else if (deletetype == "tb3") {
        $("#loadertb3").show();

        $.ajax({
            type: "POST",
            url: '../' + controller + '/Deletetb3',
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "success") {

                    deleted();
                    HideNotifications()
                    $("#loadertb3").hide();
                    $("#tb3_" + Id + "").remove();
                   LoadGridtb3(controller,5)
                    setTimeout(function () {
                        HideNotifications()

                    }, 500);
                    $("#closedeletepopup").trigger("click");
                }
                else if (data == "dependent") {

                    dependent();
                    $("#loadertb3").hide();
                }
                else if (data == "fail") {
                    fail();

                    $("#loadertb3").hide();
                }
            }
        });

    }
    else if (deletetype == "tb4") {
        $("#loadertb4").show();

        $.ajax({
            type: "POST",
            url: '../' + controller + '/Deletetb4',
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "success") {

                    deleted();
                    HideNotifications()
                    $("#loadertb4").hide();
                    $("#tb4_" + Id + "").remove();
                     LoadGridtb4(controller,5)
                    setTimeout(function () {
                        HideNotifications()

                    }, 500);
                    $("#closedeletepopup").trigger("click");
                }
                else if (data == "dependent") {

                    dependent();
                    $("#loadertb4").hide();
                }
                else if (data == "fail") {
                    fail();

                    $("#loadertb4").hide();
                }
            }
        });

    }
    else if (deletetype == "tb5") {
        $("#loadertb5").show();

        $.ajax({
            type: "POST",
            url: '../' + controller + '/Deletetb5',
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "success") {

                    deleted();
                    HideNotifications()
                    $("#loadertb5").hide();
                    $("#tb5_" + Id + "").remove();
                    LoadGridtb5(controller,5)
                    setTimeout(function () {
                        HideNotifications()

                    }, 500);
                    $("#closedeletepopup").trigger("click");
                }
                else if (data == "dependent") {

                    dependent();
                    $("#loadertb5").hide();
                }
                else if (data == "fail") {
                    fail();

                    $("#loadertb5").hide();
                }
            }
        });

    }
    else if (deletetype == "tb") {
        $("#loader").show();

        $.ajax({
            type: "POST",
            url: '../' + controller + '/Delete',
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "success") {

                    deleted();
                    $("#loader").hide();
                    HideNotifications()

                    LoadGrid(controller);
                  // $("#tb2_" + Id + "").remove();
                    setTimeout(function () {
                        HideNotifications()

                    }, 500);
                    $("#closedeletepopup").trigger("click");
                }
                else if (data == "dependent") {

                    dependent();
                    $("#loader").hide();
                }
                else if (data == "fail") {
                    fail();

                    $("#loader").hide();
                }
            }
        });

    }
    else if (deletetype == "productunit") {

        $.ajax({
            type: "POST",
            url: '../AssignProductUnits/Delete',
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "success") {
                    success();
                    NatureChange();
                 
                    //GetProductUnits($("#productunitid").val())
                    $("#cmbUnits").val("0");
                    $("#closedeletepopup").trigger("click");
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
    else if (deletetype == "psregister") {

        $.ajax({
            type: "POST",
            url: '../PSTypeAndRegister/Deletetb2',
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "success") {
                    deleted();
                    ChangeRegister();
                    $("#closedeletepopup").trigger("click");
                }
                else if (data == "dependent") {
                    dependent();
                }
                else if (data == "faile") {
                    fail();
                }
            }

        });



    }

}


function Delete(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("tb");
    //shortcut.add("Y", function () {
    if ($('#deletepopup').is(':visible')) {
        DeleteSelectedrecord();
    }


    //});
    //shortcut.add("N", function () {
    if ($('#deletepopup').is(':visible')) {
        $("#closedeletepopup").trigger("click");
    }

    //});
}

function Deletetb1(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("tb1");
    //shortcut.add("Y", function () {
        if ($('#deletepopup').is(':visible')) {
            DeleteSelectedrecord();
        }


    //});
    //shortcut.add("N", function () {
        if ($('#deletepopup').is(':visible')) {
            $("#closedeletepopup").trigger("click");
        }

    //});
}

function Deletetb2(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("tb2");
    //shortcut.add("Y", function () {
        if ($('#deletepopup').is(':visible')) {
            DeleteSelectedrecord();
        }


    //});
    //shortcut.add("N", function () {
        if ($('#deletepopup').is(':visible')) {
            $("#closedeletepopup").trigger("click");
        }

   // });

}
function Deletetb3(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("tb3");
    //shortcut.add("Y", function () {
        if ($('#deletepopup').is(':visible')) {
            DeleteSelectedrecord();
        }


    //});
    //shortcut.add("N", function () {
        if ($('#deletepopup').is(':visible')) {
            $("#closedeletepopup").trigger("click");
        }

    //});

}
function Deletetb5(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("tb5");
    //shortcut.add("Y", function () {
        if ($('#deletepopup').is(':visible')) {
            DeleteSelectedrecord();
        }


    //});
    //shortcut.add("N", function () {
        if ($('#deletepopup').is(':visible')) {
            $("#closedeletepopup").trigger("click");
        }

   // });

}
function Deletetb4(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("tb4");
    //shortcut.add("Y", function () {
        if ($('#deletepopup').is(':visible')) {
            DeleteSelectedrecord();
        }


    //});
    //shortcut.add("N", function () {
        if ($('#deletepopup').is(':visible')) {
            $("#closedeletepopup").trigger("click");
        }

    //});

}
function Deletetb5(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("tb5");
    //shortcut.add("Y", function () {
    if ($('#deletepopup').is(':visible')) {
        DeleteSelectedrecord();
    }


    //});
    //shortcut.add("N", function () {
    if ($('#deletepopup').is(':visible')) {
        $("#closedeletepopup").trigger("click");
    }

    //});

}
function Deleteother(Id, controller) {
    $("#deletepopup").modal("show");
    $("#DeleteSelectedrecordId").val(Id + "_" + controller);
    $("#Deletetype").val("psregister");
    shortcut.add("Y", function () {
        if ($('#deletepopup').is(':visible')) {
            DeleteSelectedrecord();
        }


    });
    shortcut.add("N", function () {
        if ($('#deletepopup').is(':visible')) {
            $("#closedeletepopup").trigger("click");
        }

    });

}


function rowClicktb1(Id, controller) {
   
    //if(controller.val)
    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb1_", "");
        if (thisid != Id) {
            $("#tb1_" + thisid + "").removeClass("danger");
        }
    });
    $("#tb1_" + Id + "").addClass("danger");
    setTimeout(function () {
        $("#savespinnertb1").hide();

    }, 500);
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Edittb1?id=' + Id,
        data: {
        },
        success: function (data) {
            $("#FormPaneltb1").show();
            $("#FormPaneltb1").html(data);
            $("#controllername").val(controller);
            // $("#loader").hide();
            $('#FormPaneltb1 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb1 :input[type!=hidden]:first').focus()
                $("#savespinnertb1").hide();
                $('#FormPaneltb1').find('select').each(function () {
                    var ddlid = $(this).attr("id");
                    $("#" + ddlid + "").select2();
                });
            }, 500);
        }
    });

    $("#back-top").trigger("click");
    HideNotifications()
}

function rowClicktb2(Id, controller) {
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb2_", "");
        if (thisid != Id) {
            $("#tb2_" + thisid + "").removeClass("danger");
        }
    });
    $("#tb2_" + Id + "").addClass("danger");
    setTimeout(function () {
        $("#savespinnertb2").hide();
    }, 500);
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Edittb2?id=' + Id,
        data: {
        },
        success: function (data) {
            $("#FormPaneltb2").show();
            $("#FormPaneltb2").html(data);
            // $("#loader").hide();
            $('#FormPaneltb2 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb2 :input[type!=hidden]:first').focus()
                $("#savespinnertb2").hide();
                $('#FormPaneltb2').find('select').each(function () {
                    var ddlid = $(this).attr("id");
                    $("#" + ddlid + "").select2();
                });
            }, 500);
        }
    });
    $("#back-top").trigger("click");
    HideNotifications()
}

function rowClicktb3(Id, controller) {
    $("#tbodytb3").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb3_", "");
        if (thisid != Id) {
            $("#tb3_" + thisid + "").removeClass("danger");
        }
    });
    $("#tb3_" + Id + "").addClass("danger");
    setTimeout(function () {
        $("#savespinnertb3").hide();
    }, 500);
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Edittb3?id=' + Id,
        data: {
        },
        success: function (data) {
            $("#FormPaneltb3").show();
            $("#FormPaneltb3").html(data);
            // $("#loader").hide();
            $('#FormPaneltb3 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb3 :input[type!=hidden]:first').focus()
                $("#savespinnertb3").hide();
                $('#FormPaneltb3').find('select').each(function () {
                    var ddlid = $(this).attr("id");
                    $("#" + ddlid + "").select2();
                });
            }, 500);
        }
    });
    $("#back-top").trigger("click");
    HideNotifications()
}
function rowClicktb4(Id, controller) {
    $("#tbodytb4").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb4_", "");
        if (thisid != Id) {
            $("#tb4_" + thisid + "").removeClass("danger");
        }
    });
    $("#tb4_" + Id + "").addClass("danger");
    setTimeout(function () {
        $("#savespinnertb4").hide();
    }, 500);
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Edittb4?id=' + Id,
        data: {
        },
        success: function (data) {
            $("#FormPaneltb4").show();
            $("#FormPaneltb4").html(data);
            // $("#loader").hide();
            $('#FormPaneltb4 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb4 :input[type!=hidden]:first').focus()
                $("#savespinnertb4").hide();
                $('#FormPaneltb4').find('select').each(function () {
                    var ddlid = $(this).attr("id");
                    $("#" + ddlid + "").select2();
                });
            }, 500);
        }
    });
    $("#back-top").trigger("click");
    HideNotifications()
}
function rowClicktb5(Id, controller) {
    $("#tbodytb5").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb5_", "");
        if (thisid != Id) {
            $("#tb5_" + thisid + "").removeClass("danger");
        }
    });
    $("#tb5_" + Id + "").addClass("danger");
    setTimeout(function () {
        $("#savespinnertb5").hide();
    }, 500);
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Edittb5?id=' + Id,
        data: {
        },
        success: function (data) {
            $("#FormPaneltb5").show();
            $("#FormPaneltb5").html(data);
            // $("#loader").hide();
            $('#FormPaneltb5 :input[type!=hidden]:first').attr("autofocus", "");
            setTimeout(function () {
                $('#FormPaneltb5 :input[type!=hidden]:first').focus()
                $("#savespinnertb5").hide();
                $('#FormPaneltb5').find('select').each(function () {
                    var ddlid = $(this).attr("id");
                    $("#" + ddlid + "").select2();
                });
            }, 500);
        }
    });
    $("#back-top").trigger("click");
    HideNotifications()
}
function rowClickslidetb1(Id, controller) {
    $('#slideout_innertb1').show();
    $('#slideout_innertb1').css("width", "600px");
    $("#tbodytb1").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb1_", "");
        if (thisid != Id) {
            $("#tb1_" + thisid + "").removeClass("danger");
        }
    });
    $("#tb1_" + Id + "").addClass("danger");
    setTimeout(function () {
        $("#savespinnertb1").hide();
    }, 500);
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Edittb1?id=' + Id,
        data: {
        },
        success: function (data) {
            $("#FormPaneltb1").show();
            $("#FormPaneltb1").html(data);
            // $("#loader").hide();
        }
    });
    if (controller == "PersonalAccount") {
        setTimeout(function () {
            $("#chkIsMaterial").trigger("change");
            $('#FormPaneltb1').find('select').each(function () {
                var ddlid = $(this).attr("id");
                $("#" + ddlid + "").select2();
            });
        }, 500);
    }
    $("#back-top").trigger("click");
    HideNotifications()
}


function rowClickslidetb2(Id, controller) {
    $('#slideout_innertb2').show();
    $('#slideout_innertb2').css("width", "600px");
    $("#tbodytb2").find("tr").each(function () {
        var thisid = $(this).attr("id");
        thisid = thisid.replace("tb2_", "");
        if (thisid != Id) {
            $("#tb2_" + thisid + "").removeClass("danger");
        }
    });
    $("#" + Id + "").addClass("danger");
    setTimeout(function () {
        $("#savespinnertb2").hide();
    }, 500);
    $.ajax({
        type: "GET",
        url: '../' + controller + '/Edittb2?id=' + Id,
        data: {
        },
        success: function (data) {
            $("#FormPaneltb2").show();
            $("#FormPaneltb2").html(data);
            // $("#loader").hide();
        }
    });
    $("#back-top").trigger("click");
    HideNotifications()
}


function GetResulttbl(id, controller) {
    if (id != 0) {
        $.ajax({
            url: '../' + controller + '/GetResulttbl?id=' + id,
            data: {
            },

            success: function (data) {
              
                $("#tb1_" + id + "").remove();
                $("#tbodytb1").prepend(data);
            }
        });
    }
}
function GetResulttb2(id, controller) {
    if (id != 0) {
        $.ajax({
            url: '../' + controller + '/GetResulttb2?id=' + id,
            data: {
            },

            success: function (data) {

                $("#tb2_" + id + "").remove();
                $("#tbodytb2").prepend(data);
            }
        });
    }
}
function GetResulttb3(id, controller) {
    if (id != 0) {
        $.ajax({
            url: '../' + controller + '/GetResulttb3?id=' + id,
            data: {
            },

            success: function (data) {

                $("#tb3_" + id + "").remove();
                $("#tbodytb3").prepend(data);
            }
        });
    }
}
function GetResulttb5(id, controller) {
    if (id != 0) {
        $.ajax({
            url: '../' + controller + '/GetResulttb5?id=' + id,
            data: {
            },

            success: function (data) {

                $("#tb5_" + id + "").remove();
                $("#tbodytb5").prepend(data);
            }
        });
    }
}
function GetResulttb4(id, controller) {
    if (id != 0) {
        $.ajax({
            url: '../' + controller + '/GetResulttb4?id=' + id,
            data: {
            },

            success: function (data) {

                $("#tb4_" + id + "").remove();
                $("#tbodytb4").prepend(data);
            }
        });
    }
}
function Savetb1(Data, controller) {
   
    $.ajax({
        url: '../' + controller + '/Savetb1',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
           
            //alert(data.split('~')[1]);
            //$("#tb1_" + data.split('~')[0] + "").remove();
            //$("#tbodytb1").html(data.split('~')[1]);
            var result = data.split("_")[0];
            var id = data.split("_")[1];
            if (result == "success") {
                success();
               
                 LoadGridtb1(controller); 
                //else {
                //    GetResulttbl(id, controller);
                //}
               
               
                //
                setTimeout(function () {
                    $('#FormPaneltb1 :input[type!=hidden]:first').focus()
                    $("#savespinnertb1").hide();
                    ClearFieldstb1();
                    CancelFieldstb1();
                    CancelFieldsslidetb1();
                    //alert(controller);
                    //$("#controllername").val(controller);
                    //hiddenController = controller;
                }, 500);
            }
            else if (result == "alreadyexists") {
                alreadyexists();
            }
            else if (result == "fail") {
                fail();
            }
            else if (result == "dependent") {
                dependent();
            }
        }
    });
}

function Savetb2(Data, controller) {
    $.ajax({
        url: '../' + controller + '/Savetb2',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = data.split("_")[0];
            var id = data.split("_")[1];

            if (result == "success") {
                success();
               // GetResulttb2(id, controller);
                //if (controller == "AllBills")
                { LoadGridtb2(controller); }
                //else {
                //    GetResulttb2(id, controller);
                //}
                //LoadGridtb2(controller);
                setTimeout(function () {
                    $('#FormPaneltb2 :input[type!=hidden]:first').focus()
                    $("#savespinnertb2").hide();
                    ClearFieldstb2();
                    CancelFieldstb2();
                    CancelFieldsslidetb2();

                }, 500);
            }
            else if (result == "alreadyexists") {
                alreadyexists();

            }
            else if (result == "fail") {
                fail();

            }
            else if (result == "dependent") {
                dependent();
            }
        }
    });
}

function Savetb3(Data, controller) {
    $.ajax({
        url: '../' + controller + '/Savetb3',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = data.split("_")[0];
            var id = data.split("_")[1];

            if (result == "success") {
                success();
                //GetResulttb3(id, controller);
                //if (controller == "AllBills")
                { LoadGridtb3(controller); }
                //else {
                //    GetResulttb3(id, controller);
                //}
                setTimeout(function () {
                    $('#FormPaneltb3 :input[type!=hidden]:first').focus()
                    $("#savespinnertb3").hide();
                    ClearFieldstb3();
                    CancelFieldstb3();
                }, 500);
            }
            else if (result == "alreadyexists") {
                alreadyexists();

            }
            else if (result == "fail") {
                fail();

            }
            else if (result == "dependent") {
                dependent();
            }
        }
    });
}
function Savetb4(Data, controller) {
    $.ajax({
        url: '../' + controller + '/Savetb4',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = data.split("_")[0];
            var id = data.split("_")[1];

            if (result == "success") {
                success();
                //GetResulttb3(id, controller);
                //if (controller == "AllBills")
                { LoadGridtb4(controller); }
                //else {
                //    GetResulttb3(id, controller);
                //}
                setTimeout(function () {
                    $('#FormPaneltb4 :input[type!=hidden]:first').focus()
                    $("#savespinnertb4").hide();
                    ClearFieldstb4();
                    CancelFieldstb4();
                }, 500);
            }
            else if (result == "alreadyexists") {
                alreadyexists();

            }
            else if (result == "fail") {
                fail();

            }
            else if (result == "dependent") {
                dependent();
            }
        }
    });
}
function Savetb5(Data, controller) {
    $.ajax({
        url: '../' + controller + '/Savetb5',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = data.split("_")[0];
            var id = data.split("_")[1];

            if (result == "success") {
                success();
                //GetResulttb3(id, controller);
                //if (controller == "AllBills")
                { LoadGridtb5(controller); }
                //else {
                //    GetResulttb3(id, controller);
                //}
                setTimeout(function () {
                    $('#FormPaneltb5 :input[type!=hidden]:first').focus()
                    $("#savespinnertb5").hide();
                    ClearFieldstb5();
                    CancelFieldstb5();
                }, 500);
            }
            else if (result == "alreadyexists") {
                alreadyexists();

            }
            else if (result == "fail") {
                fail();

            }
            else if (result == "dependent") {
                dependent();
            }
        }
    });
}
function isNumberKey(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[.]|[0-9]|\./;
    //var charec = /[A]|[a]/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

function LoadGroup() {
    $.ajax({
        type: "GET",
        url: '../AccountNature/Getsortingtabletb1',
        data: {
        },
        success: function (data) {
            $("#groupsort").html(data);
        }
    });
}

function LoadNature() {
    $.ajax({
        type: "GET",
        url: '../AccountNature/Getsortingtabletb2',
        data: {
        },
        success: function (data) {
            $("#naturesort").html(data);
        }
    });
}


function searchTableGroup(inputVal) {
    var table = $('#tbodytb2Group');
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

function searchTableNature(inputVal) {
    var table = $('#tbodytb1Nature');
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



function SaveGroupSorting() {
    GroupSortingList = [];

    $("#tbodytb2Group").find("tr :input[type='text']").each(function () {
        var id = Number($(this).attr("id").split("_")[1]);
        var value = Number($(this).val());
        var list =
            {
                GroupId: id,
                SortId: value

            };

        GroupSortingList.push(list);

    });

    var Data = {
        "GroupSortingList": GroupSortingList
    };

    $.ajax({
        url: '../AccountNature/SaveGroupSorting',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data == "success") {
                success();


            }

            else if (data == "fail") {
                fail();

            }
        }
    });



}
function SaveNatureSorting() {

    NatureSortingList = [];

    $("#tbodytb1Nature").find("tr :input[type='text']").each(function () {
        var id = Number($(this).attr("id").split("_")[1]);
        var value = Number($(this).val());
        var list =
            {
                NatureId: id,
                SortId: value

            };

        NatureSortingList.push(list);

    });

    var Data = {
        "NatureSortingList": NatureSortingList
    };

    $.ajax({
        url: '../AccountNature/SaveNatureSorting',
        data:
    JSON.stringify(Data),
        type: 'POST',
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data == "success") {
                success();


            }

            else if (data == "fail") {
                fail();

            }
        }
    });


}