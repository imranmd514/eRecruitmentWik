function AddNewregister()
{
    $("#hdnprocessentry").show();
    $("#btnUpdate").hide();
}


function ManageRegister() {

    $.ajax({
        type: "Post",
        url: '../PSTypeAndRegister/GetRegister',//url: "@Url.Action("GetProcess", "ProductionProcess")",
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
    $("#txtfilename").val("");
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
        var filename = $("#txtfilename").val();
        var Id = reg + '-' + Descriptions + '-' + regId+"-"+filename;
        $.ajax({
            type: "Post",
            url: '../PSTypeAndRegister/Editreg',//url: "@Url.Action("Edit", "ProductionProcess")",
            data: {
                id: Id,
            },
            success: function (data) {
                ManageRegister();
                ResetProcess();
                success();
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
        url: '../PSTypeAndRegister/EditRegister', //url: "@Url.Action("EditProcess", "ProductionProcess")",// url: '../ProductAccount/SaveProductionSetting',
        data: {
            id: Id,
        },
        success: function (data) {
            $("#txtregister").val(data.split('~')[0]);
            $("#txtfilename").val(data.split('~')[1]);
            $("#txtDescription").val(data.split('~')[2]);

            $("#prcsid").val(Id);


        }
    });
}
function SubmitProcess() {

    var reg = String($("#txtregister").val());
    var des = String($("#txtDescription").val());
    var filename = $("#txtfilename").val();
    if (reg == "") {
        required("Provide Register");

    }
    else {
        $.ajax({
            type: "Get",
            url: '../PSTypeAndRegister/SaveRegister', //url: "@Url.Action("InsertProcess", "ProductionProcess")",
            data: {
                reg: reg,
                des: des,
                filename: filename,
            },
            success: function (data) {
                String($("#txtregister").val(""));
             String($("#txtDescription").val(""));
               $("#txtfilename").val("");
                success();
                ManageRegister();
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
            url: '../PSTypeAndRegister/DeleteRegister',//url: "@Url.Action("DeleteProcess", "ProductionProcess")",
            data: {
                id: Id,
            },
            success: function (data) {
                if (data == "fail") {

                    fail();
                }
              
                else if (data == "success") {
                    deleted();
                    ManageRegister();
                }
            }
        });

    }


}

