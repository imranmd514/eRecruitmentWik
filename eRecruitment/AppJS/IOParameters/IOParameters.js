function Delete(Id) {
    $("#deleteiopopup").modal("show");
    $("#hdnioid").val(Id);
}

function DeleteSelectediorecord()
{
    var Id = $("#hdnioid").val();
    $.ajax({
        type: "get",
        url: '../IOParameters/Delete',// url: "@Url.Action("Delete", "IOParameters")",
        data: {
            id: Id,
        },
        success: function (data) {
            if (data == "success") {
                LoadGrid();
                $("#closedeleteiopopup").trigger("click");
                deleted();
                Refresh();
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

function ManageParameter() {
    $("#ProductionProcess").modal("show");

}

function AssignParameter()
{

        var PSId = $("#cmbPSId :selected").val();
        var IOParameterMasterId = $("#cmbParameter").val();
        if ($("#cmbPSId").val() == 0) {
            required("Please select Product/Sales Type");
        }
        else if ($("#cmbParameter").val() == 0)
        { 
            required("Please select Parameter");
        }
        
        else

        {
            $.ajax({
                type: "Post",
                url: '../IOParameters/SaveIOParameter',//url: "@Url.Action("SaveIOParameter", "IOParameters")",
                data: {

                PSId: PSId,
                IOParameterMasterId: IOParameterMasterId,

                },
                success: function (data) {
                    success();
                    LoadGrid();
                    Refresh();
        }

    });
}



}

function LoadGrid()
{
    Refresh();
    $.ajax({
        type: "Post",
        url: '../IOParameters/GetPSIOGrid',//url: "@Url.Action("GetPSIOGrid", "IOParameters")",
        data: {

        },
        success: function (data) {
            $("#tbody").html(data);
            $("#cmbPSId").select2();
            $("#cmbParameter").select2();
            HideLoader();

            // alert("Data Inserted successfully");

        }

    });


}




function Add(id) {
    var paraid = Number($(id).attr("id").split('_')[0]);
    var pstypeid = Number($(id).attr("id").split('_')[1]);
    $.ajax({
        type: "get",
        url: '../IOParameters/GetBindingParameters',// url: "@Url.Action("GetBindingParameters", "IOParameters")",
        data: {
        paraid: paraid,
        pstypeid: pstypeid,
        },
    success: function (data) {
        $("#bindingdata").html(data);
        $("#myModel").modal("show");

    }

});

//bindingdata
}


function IOmasterList()
{
    $("#cmbParameter").empty();
    $.ajax({
        type: "get",
        url: '../IOParameters/GetIOParameters',//url: "@Url.Action("AssigningBindingParameters", "IOParameters")",
        data: {
          
        },
    success: function (data) {


        $.each(data, function () {
            $("#cmbParameter").append("<option value=" + this.Value + ">" + this.Text + "</option>");

        });
    }
});
}




function searchTabletbiop(inputVal) {
    var table = $('#TTable2');
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
function searchParamerter(valThis) {
    //var valThis = $(this).val();
    $('.myproducts>h3').each(function () {
        var text = $(this).text().toLowerCase();
        var id = $(this).attr("id");
        var divid = id.replace("h", "div");
        (text.indexOf(valThis) == 0) ? $("#" + divid).show() : $("#" + divid).hide();
    });
}

function Refresh()
{
    $("#cmbPSId").val("0");
    $("#cmbParameter").val("0");
    $("#box").val("");
}


function NatureChange(id) {
    var a = $(id).attr("id");
    if ($("#" + a + "").is(":checked") == true) {
        $("#cmbnature").show();
    }

}
function ChequeChange(id) {
    var a = $(id).attr("id");
    if ($("#" + a + "").is(":checked") == true) {
        $("#cmbnature").hide();
    }
}
function MPEChange(id) {
    var a = $(id).attr("id");
    if ($("#" + a + "").is(":checked") == true) {
        $("#cmbnature").hide();
    }
}

function Set() {
    var str = "";
    var paraid = $("#rdMPE").val();
    if ($("#rdMPE").is(":checked") == true) {
        str = "MEP";
    }
    else if ($("#rdCheque").is(":checked") == true) {
        str = "ChequeBook";
    }
    else if ($("#rdNature").is(":checked") == true) {
        str = $("#cmbnature :selected").val();
    }

    // alert(id + "," + str);
    $.ajax({
        type: "get",
        url: '../IOParameters/AssigningBindingParameters',//url: "@Url.Action("AssigningBindingParameters", "IOParameters")",
        data: {
        paraid: paraid,
        binding: str,
        },
    success: function (data) {
        if (data == "success") {
            success();
            $("#btnclose").trigger("click");
            LoadGrid();
            Refresh();



    }



}

});

}
function searchTable(inputVal) {
    var letter = $(inputVal).val();
    var tblid = $(inputVal).attr("id").split('_')[1];
    var table = $('#t_' + tblid + '');

    table.find('tr').each(function (index, row) {
        var allCells = $(row).find('td');
        if (allCells.length > 0) {
            var found = false;
            allCells.each(function (index, td) {
                var regExp = new RegExp(letter, 'i');
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



function searchPS(inputVal) {
    var ps = $(inputVal).val();
    // var table = $('#tbody');
    var found = false;
    $("#tbody h3").each(function (index, row) {
        var regExp = new RegExp(ps, 'i');
        if (regExp.test($(this).text())) {
            // alert($(this).text());
            found = true;
            return false;
        }
        if (found == true) {
            // alert("hiii");
        }
        else {

            // alert("no result");
        }
    });
}



function AddNewregister() {
    $("#hdnprocessentry").show();
    $("#btnUpdate").hide();
}


function ManageParameter() {

    $.ajax({
        type: "Post",
        url: '../IOParameters/GetRegister',//url: "@Url.Action("GetProcess", "ProductionProcess")",
        data: {

        },
        success: function (data) {
            $("#ProductionProcess").modal("show");
            $("#btnUpdate").hide();
            $("#hdnprocessentry").hide();
            $("#TTable2").html(data);


        }
    });


}
function ResetProcess() {
    $("#txtregister").val("");
    $("#txtDescription").val("");
    $("#prcsid").val("");
    $("#btnUpdate").hide();
    $("#btnSubmit").show();
}
function UpdateProcess() {
    if ($("#txtregister").val() == "") {
        required("Register required");
    }

    else {

        var reg = String($("#txtregister").val());
        var Descriptions = String($("#txtDescription").val());
        var regId = $("#prcsid").val();
        var Id = reg + '-' + Descriptions + '-' + regId ;
        $.ajax({
            type: "Post",
            url: '../IOParameters/Editreg',//url: "@Url.Action("Edit", "ProductionProcess")",
            data: {
                id: Id,
            },
            success: function (data) {
                ManageParameter();
                ResetProcess();
                success();
                IOmasterList();
            }
        });
    }




}

function EditRegister(Id) {

    $("#btnUpdate").show();
    $("#btnSubmit").hide();
    $("#hdnprocessentry").show();
    $.ajax({
        type: "Post",
        url: '../IOParameters/EditRegister', //url: "@Url.Action("EditProcess", "ProductionProcess")",// url: '../ProductAccount/SaveProductionSetting',
        data: {
            id: Id,
        },
        success: function (data) {
            $("#txtregister").val(data.split('~')[0]);
          $("#txtDescription").val(data.split('~')[1]);

            $("#prcsid").val(Id);


        }
    });
}
function SubmitProcess() {

    var reg = String($("#txtregister").val());
    var des = String($("#txtDescription").val());
    if (reg == "") {
        required("Provide Parameter");

    }
    else {
        $.ajax({
            type: "Get",
            url: '../IOParameters/SaveRegister', //url: "@Url.Action("InsertProcess", "ProductionProcess")",
            data: {
                reg: reg,
                des: des,
            },
            success: function (data) {
                String($("#txtregister").val(""));
                String($("#txtDescription").val(""));
                success();
                ManageParameter();
                IOmasterList();
                //window.location.reload();
                //  GetProcessDropDown();
            }
        });
    }



}

function DeleteRegister(Id) {

    var processId = Id;
    if (confirm("Are you Sure to delete a record?")) {

        $.ajax({
            type: "POST",
            url: '../IOParameters/DeleteRegister',//url: "@Url.Action("DeleteProcess", "ProductionProcess")",
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "fail") {

                    fail();
                }

                else if (data == "success") {
                    deleted();
                    ManageParameter();
                    IOmasterList();
                }
            }
        });

    }


}