function LoadCuttings()
{
    HideLoader();

    $.ajax({
        type: "get",
        url: '../Settings/GetCuttings',
        //url: "@Url.Action("GetGridCuttings", "CustomCuttings")",
        data: {

        },
        success: function (data) {
            $("#tab1").html(data);
            GetGridCuttings();
           
            $("#CuttingId").select2();
            //$("#CuttingUnit").select2();
        }


    });
}

function Refeshddl()
{
    $("#CuttingId").empty();
    $.ajax({
        type: "get",
        url: '../Settings/GetCuttingslist',
        data: {
        },
    success: function (data) {
        $.each(data, function () {
            $("#CuttingId").append("<option value=" + this.Value + ">" + this.Text + "</option>");

        });
    }


});


}


function removebag(id)
{
    var i = $(id).attr("id");
    var d = i.replace("trr_", "tr_");
    $("#" + d + "").remove();
}
function Addbag()
{
   
    var unit = $("#txtbgunit").val();
    var val = $("#txtbgval").val();
    if (unit != "" && val != "") {
        $("#divisquantity").show();
        $("#tblbagcuttings").show();
        $("#tblmoisturecuttings").hide();
        $("#tbodymoisture").html("");
        var trlen = $("#tbodybag").find("tr").length;
        if (trlen == 0) {
            $("#tbodybag").html("<tr id='tr_1'><td>" + unit + "</td><td>" + val + "</td><td><i class='fa fa-trash append-icon vd_red' id='trr_1' onclick='removebag(this)' style='cursor:pointer' >Remove</i></td></tr>");
        }
        else {
            var rowid = trlen + 1;
            $("#tbodybag").append("<tr id='tr_" + rowid + "'><td>" + unit + "</td><td>" + val + "</td><td><i class='fa fa-trash  append-icon vd_red' id='trr_" + rowid + "' style='cursor:pointer' onclick='removebag(this)'>Remove</i></td></tr>");
        }
        $("#txtbgunit").val("");
        $("#txtbgval").val("");
    }
}

function Addmoisture()
{
   
    var percent = $("#txtpercent").val();
    var val = $("#txtMval").val();
    if (percent != "" && val != "") {
        $("#divisquantity").show();
        $("#tblbagcuttings").hide();
        $("#tblmoisturecuttings").show();
        $("#tbodybag").html("");
        var trlen = $("#tbodymoisture").find("tr").length;
        if (trlen == 0) {
            $("#tbodymoisture").html("<tr id='tr_1'><td>" + percent + "</td><td>" + val + "</td><td><i class='fa fa-trash  append-icon vd_red' id='trr_1' onclick='removebag(this)' style='cursor:pointer' >Remove</i></td></tr>");
        }
        else {
            var rowid = trlen + 1;
            $("#tbodymoisture").append("<tr id='tr_" + rowid + "'><td>" + percent + "</td><td>" + val + "</td><td><i class='fa fa-trash  append-icon vd_red' id='trr_" + rowid + "' onclick='removebag(this)' style='cursor:pointer' >Remove</i></td></tr>");
        }
        $("#txtpercent").val("");
        $("#txtMval").val("");
    }
}

function ChangeLabelMoisture(id)
{
    $("#inputMP_" + id + "").show();
    $("#displyMP_" + id + "").hide();
    $("#inputMV_" + id + "").show();
    $("#displyMV_" + id + "").hide();
    $("#editmoisture_" + id + "").show();
    $("#lblmoisture_" + id + "").hide();
}
function RefreshMoisture(id) {
    $("#inputMP_" + id + "").hide();
    $("#displyMP_" + id + "").show();
    $("#inputMV_" + id + "").hide();
    $("#displyMV_" + id + "").show();
    $("#editmoisture_" + id + "").hide();
    $("#lblmoisture_" + id + "").show();
    GetGridCuttings();
}
function ChangeLabelBag(id) {
    $("#inputUB_" + id + "").show();
    $("#displyUB_" + id + "").hide();
    $("#inputBV_" + id + "").show();
    $("#displyBV_" + id + "").hide();
    $("#inputBq_" + id + "").show();
    $("#displyBq_" + id + "").hide();
    $("#editbag_" + id + "").show();
    $("#lblbag_" + id + "").hide();
}
function RefreshBag(id) {
    $("#inputUB_" + id + "").hide();
    $("#displyUB_" + id + "").show();
    $("#inputBV_" + id + "").hide();
    $("#displyBV_" + id + "").show();
    $("#inputBq_" + id + "").hide();
    $("#displyBq_" + id + "").show();
    $("#editbag_" + id + "").hide();
    $("#lblbag_" + id + "").show();
    GetGridCuttings();
}
function ChangeLabelNormal(id) {
   
    $("#inputNV_" + id + "").show();
    $("#displyNV_" + id + "").hide();
    $("#inputNq_" + id + "").show();
    $("#displyNq_" + id + "").hide();
    $("#editnormal_" + id + "").show();
    $("#lblnormal_" + id + "").hide();
}
function RefreshNormal(id) {
   
    $("#inputNV_" + id + "").hide();
    $("#displyNV_" + id + "").show();
    $("#inputNq_" + id + "").hide();
    $("#displyNq_" + id + "").show();
    $("#editnormal_" + id + "").hide();
    $("#lblnormal_" + id + "").show();
    GetGridCuttings();
}

function EditMoisture(id)
{
    var cutid = id;
    var percent = $("#txtMP_" + id + "").val();
    var val = $("#txtMV_" + id + "").val();
    $.ajax({
        type: "get",
        url: '../CustomCuttings/EditMoistureCutting',
        //url: "@Url.Action("GetGridCuttings", "CustomCuttings")",
        data: {
            cutid: cutid,
            percent: percent,
            val: val
        },
        success: function (data) {
            if (data == "success") {
                GetGridCuttings();
            }
            else if (data == "fail") {
                fail();
            }

        }


    });
}
function EditBag(id) {
    var cutid = id;
    var bag = $("#chkBq_" + id + "").is(":checked");
    var val = $("#txtBV_" + id + "").val();
    var unit = $("#txtUB_" + id + "").val();
    $.ajax({
        type: "get",
        url: '../CustomCuttings/EditBagCutting',
        //url: "@Url.Action("GetGridCuttings", "CustomCuttings")",
        data: {
            cutid: cutid,
            unit: unit,
            val: val,
            isqty: bag
        },
        success: function (data) {
            if (data == "success") {
                GetGridCuttings();
            }
            else if (data == "fail") {
                fail();
            }

        }


    });
}
function EditNormal(id) {
    var cutid = id;
    var bag = $("#chkNq_" + id + "").is(":checked");
    var val = $("#txtNV_" + id + "").val();
    $.ajax({
        type: "get",
        url: '../CustomCuttings/EditNormalCutting',
        //url: "@Url.Action("GetGridCuttings", "CustomCuttings")",
        data: {
            cuttingid: cutid,
            val: val,
            isqty: bag
        },
        success: function (data) {
            if (data == "success") {
                GetGridCuttings();
            }
            else if (data == "fail")
            {
                fail();
            }
        }


    });
}

function CuttingChange()
{
    var id = $("#CuttingId :selected").text();
    if (id == "Bag Cutting" )
    {
        $("#othercutting").hide();
        $("#Moisturecutting").hide();
        $("#divbag").show();
        $("#Bagcutting").show();
        $("#divisquantity").hide();
        $("#chkbag").attr("checked", true);
        $("#chkbag").prop("checked", true);
        $("#tbodybag").html("");
        $("#tbodymoisture").html("");

    }
    else if (id == "Moisture Cutting" || id == "Gidde Cuttings")
    {
        $("#othercutting").hide();
        $("#Moisturecutting").show();
        $("#divbag").hide();
        $("#Bagcutting").hide();
        $("#divisquantity").hide();
        $("#chkbag").attr("checked", false);
        $("#tbodybag").html("");
        $("#tbodymoisture").html("");

    }
    else
    {
        $("#divisquantity").hide();
        $("#othercutting").show();
        $("#Moisturecutting").hide();
        $("#divbag").show();
        $("#Bagcutting").hide();
        $("#chkbag").attr("checked", false);
        $("#tbodybag").html("");
        $("#tbodymoisture").html("");

    }

}



function cancel() {
    ClearFields();
       
    }
function GetGridCuttings() {
    ShowLoader();
    var intervalID = setInterval(updateProgress, 180);
    $.ajax({
        type: "get",
        url: '../Settings/GetCuttingsGrid',
        //url: "@Url.Action("GetGridCuttings", "CustomCuttings")",
        data: {

        },
    success: function (data) {
        $("#tbody").html(data);
        //$("#scrollit").slimscroll({
        //    height: '100px'
        //    //width: '270px'
        //});
        HideLoader();
        // $("#progressbar").css("width", "100%");
        clearInterval(intervalID);
        $("#divprogress").hide();
    }


});
}




function Delete(Id) {
    if (confirm("Are you Sure to delete a record?")) {
        $.ajax({
            type: "POST",
            url: '../CustomCuttings/DeleteCustomCuttingsSettings',
           // url: "@Url.Action("DeleteCustomCuttingsSettings", "CustomCuttings")",
            data: {
            id: Id,
            },
        success: function (data) {
            if (data == "success") {
                GetGridCuttings();
                deleted();
                HideLoader();
            }
            else if (data == "fail")
            {
                fail();
                HideLoader();

            }
        }
    });
}
}
function searchTable(inputVal) {
    var table = $('#tbodycut');
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
function DeleteRowchild(id) {
    if (confirm("Are you Sure to delete a record?")) {
        var r = $(id).attr("id");
        var row = Number(r.split("_")[0]);
        var chilid = Number(r.split("_")[1]);
        $.ajax({
            type: "get",
            url: '../CustomCuttings/DeleteChild',
           // url: "@Url.Action("DeleteChild", "CustomCuttings")",
            data: {
            id: chilid
            },
        success: function (data) {
            if (data == "success") {
                deleted();

                $("#pre_" + row + "_"+chilid+"").remove();

            }
            else {
                fail();

            }
        }
    });
}
}

function OnMoistureSave()
{
    var data = "";
    var trlen = $("#tbodymoisture").find("tr").length;
    if (trlen != 0) {
        $("#tbodymoisture").find("tr").each(function () {
            var unit = $(this).find("td:nth-child(1)").text();
            var val = $(this).find("td:nth-child(2)").text();
            data = data + unit + "!" + val + "~";
        });
        var name = $("#CuttingId :selected").text();

        $.ajax({
            url: '../CustomCuttings/SaveMoistureCutting',
            // url: "@Url.Action("Save", "CustomCuttings")",
            data:
       {
           data: data,
           name:name
       },
            success: function (data) {
                if (data == "success") {

                    success();
                    CuttingChange();
                    $("#txtpercent").val("");
                    $("#txtMval").val("");
                   GetGridCuttings();
                }
                else if (data == "fail") {
                    $("#savespinner").hide();
                    fail();
                }
            },
            error: function (data) {
                if (data == "fail") {
                    $("#savespinner").hide();
                    fail();
                }
                //}

            }
        });

    }
    else {
        required("No rows to save");
    }
}
function OnBagSave()
{
    var isqty = $("#chkbag").is(":checked");
    var data = "";
    var trlen = $("#tbodybag").find("tr").length;
   if (trlen != 0) {
       $("#tbodybag").find("tr").each(function () {
           var unit = $(this).find("td:nth-child(1)").text();
           var val = $(this).find("td:nth-child(2)").text();
           data = data + unit + "!" + val + "~";
       });
       $.ajax({
           url: '../CustomCuttings/SaveBagCutting',
           // url: "@Url.Action("Save", "CustomCuttings")",
           data:
      {
          isqty: isqty,
          data: data,
      },
           success: function (data) {
               if (data == "success") {

                   success();
                   CuttingChange();
                   $("#txtbgunit").val("");
                   $("#txtbgval").val("");
                   $("#chkbag").prop("checked", false);
                   GetGridCuttings();
               }
               else if (data == "fail")
               {
                   $("#savespinner").hide();
                   fail();
               }

           },
           error: function (data) {
               if (data == "fail") {
                   $("#savespinner").hide();
                   fail();
               }
               //}

           }
       });

   }
   else {
       required("No rows to save");
   }
}

function OnSubmit() {

   
   if ($("#CuttingId").val() == "") {

        required("Select Cuttings");
    }
   
    else {

      
       var cuttingid = $("#CuttingId").val();
        var isqty = $("#chkbag").is(":checked");
        var val = $("#cutval").val();

       

        $.ajax({
            url: '../CustomCuttings/SaveNormalCutting',
           // url: "@Url.Action("Save", "CustomCuttings")",
            data:
       {
           cuttingid: cuttingid,
           isqty: isqty,
           val:val
      },
        success: function (data) {
            if (data== "success") {

                success();
                CuttingChange();
                $("#cutval").val("");
                $("#chkbag").prop("checked",false);
                GetGridCuttings();
            }
            else if (data == "fail") {
                $("#savespinner").hide();
                fail();
            }

        },
        error: function (data) {
            if (data == "fail") {
                $("#savespinner").hide();
                fail();
            }

            //}

        }
    });



}
}
function AddNewregister() {
    $("#hdnprocessentry").show();
    $("#btnUpdatecut").hide();
}
function ManageRegister() {
    $("#btnUpdatecut").hide();
    $.ajax({
        type: "Post",
        url: '../Settings/GetRegister',//url: "@Url.Action("GetProcess", "ProductionProcess")",
        data: {

        },
        success: function (data) {
            $("#ProductionProcess").modal("show");
            $("#btnUpdatecut").hide();
            $("#hdnprocessentry").hide();
            $("#TTable2").html(data);


        }
    });


}
function ResetProcess() {
    $("#txtregister").val("");
    $("#txtDescription").val("");
    $("#prcsid").val("");
    $("#btnUpdatecut").hide();
    $("#btnSubmitcut").show();
}
function UpdateProcess() {
    if ($("#txtregister").val() == "") {
        required("Parameter required");
    }

    else {

        var reg = String($("#txtregister").val());
        var Descriptions = String($("#txtDescription").val());
        var regId = $("#prcsid").val();
        var Id = reg + '-' + Descriptions + '-' + regId ;
        $.ajax({
            type: "Post",
            url: '../Settings/Editreg',//url: "@Url.Action("Edit", "ProductionProcess")",
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

    $("#btnUpdatecut").show();
    $("#btnSubmitcut").hide();
    $("#hdnprocessentry").show();
    $.ajax({
        type: "Post",
        url: '../Settings/EditRegister', //url: "@Url.Action("EditProcess", "ProductionProcess")",// url: '../ProductAccount/SaveProductionSetting',
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
        required("Provide Register");

    }
    else {
        $.ajax({
            type: "Get",
            url: '../Settings/SaveRegister', //url: "@Url.Action("InsertProcess", "ProductionProcess")",
            data: {
                reg: reg,
                des: des,
            },
            success: function (data) {
                String($("#txtregister").val(""));
                String($("#txtDescription").val(""));
                success();
                ManageRegister();
                Refeshddl();
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
            url: '../Settings/DeleteRegister',//url: "@Url.Action("DeleteProcess", "ProductionProcess")",
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