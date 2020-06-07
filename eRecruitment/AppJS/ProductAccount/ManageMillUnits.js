function UpdateProcess()
{
    if ($("#txtprocess").val() == "") {
        required("Mill unit required");
    }
           
    else {

        var prcs = String($("#txtprocess").val());
        var Descriptions = String($("#txtDescription").val());
        var processId = $("#prcsid").val();
        var Id = prcs + '-' + Descriptions + '-' + processId;
        $.ajax({
            type: "Post",
            url: '../ProductionProcess/Edit',//url: "@Url.Action("Edit", "ProductionProcess")",
            data: {
            id: Id,
            },
        success: function (data) {
            ManageProduction();
            GetProcessDropDown();
            success();
        }
    });
}




}

function SubmitProcess()
{

    var prcs = String($("#txtprocess").val());
    var Descriptions = String($("#txtDescription").val());
    if (prcs == "") {
        required("Provide Mill Unit");

    }
    else {
        var Id = prcs + '-' + Descriptions;
        $.ajax({
            type: "Get",
            url: '../ProductionProcess/InsertProcess', //url: "@Url.Action("InsertProcess", "ProductionProcess")",
            data: {
            id: Id,
            },
        success: function (data) {
            $("#txtprocess").val("");
            $("#txtDescription").val("");
            success();
            ManageProduction();
            //window.location.reload();
            GetProcessDropDown();
        }
    });
}



}

function ResetProcess()
{
    $("#txtprocess").val("");
    $("#txtDescription").val("");
    $("#prcsid").val("");
    $("#btnUpdate").hide();
    $("#btnSubmit").show();
}
function GetProcessDropDown() {
    $("#cmbProcess").empty();
    $.ajax({
        type: "Post",
        url: '../ProductionProcess/GetProductionProcessDropdown',// url: "@Url.Action("GetProductionProcessDropdown", "ProductionProcess")",
        data: {
        },
    success: function (data) {
        $.each(data, function () {

            $("#cmbProcess").append("<option value=" + this.Value + " selected>" + this.Text + "</option>");

        });
        //cmbProcess
    }
});
}
function ManageProduction()
{
    $.ajax({
        type: "Post",
        url: '../ProductionProcess/GetProcess',//url: "@Url.Action("GetProcess", "ProductionProcess")",
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
function AddNewProcess()
{
    $("#hdnprocessentry").show();


}
function DeleteProcess(Id) {

    var processId = Id;
    if (confirm("Are you Sure to delete a record?")) {

        $.ajax({
            type: "POST",
            url: '../ProductionProcess/DeleteProcess',//url: "@Url.Action("DeleteProcess", "ProductionProcess")",
            data: {
            id: Id,
            },
        success: function (data) {
            if (data == "depenent") {
                           
                notification("topright", "notify", "fa fa-times vd_red", "Warning", "Process have settings </br> Delete Anyway...! &nbsp;&nbsp;<button class='btn btn-success btn-xs' onclick='DeleteSettings(" + Id + ")' type='button'>Delete</button>");

            }
            else if (data == "dontdelete") {
                dependent();

            }
            else if (data == "success") {
                deleted();
                ManageProduction();
            }
        }
    });

}

                    
               
    
}
function EditProcess(Id) {
    $("#btnUpdate").show();
    $("#btnSubmit").hide();
    $("#hdnprocessentry").show();
    $.ajax({
        type: "Post",
        url: '../ProductionProcess/EditProcess', //url: "@Url.Action("EditProcess", "ProductionProcess")",// url: '../ProductAccount/SaveProductionSetting',
        data: {
        id: Id,
        },
    success: function (data) {
        $("#txtprocess").val(data.split('~')[0]);
        $("#txtDescription").val(data.split('~')[1]);
        $("#prcsid").val(Id);
        // alert(data.split('~')[0]);

    }
});


}



