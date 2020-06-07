function tab2press() {
    LoadPSRegister();
    //$("#hiddensettings").hide();

}
function tab1press() {
    LoadGridtb1('PSTypeAndRegister', 2);


}


function Onsubmittb1() {
    var result = RequiredFieldstb1();
    if (result == 0) {
        $("#savespinnertb1").show();
        var PSId = $("#PSId").val();
        var PSType = $("#PSType").val();
        var ProcessId = $("#ProcessId").val();
        var AutoBillNo = $("#AutoBillNo").is(":checked");
        var SeparateBill = $("#SeparateBill").is(":checked");
        var Description = $("#Description").val();
        var Data = {
            "PSId": PSId,
            "PSType": PSType,
            "ProcessId": ProcessId,
            "AutoBillNo": AutoBillNo,
            "Description": Description,
            "SeparateBill": SeparateBill
        }
        Savetb1(Data, 'PSTypeAndRegister');
    }

}

function LoadPSRegister()
{
    $.ajax({
        type: "GET",
        url: '../PSTypeAndRegister/GetPSRegister',
        data: {
        },
        success: function (data) {
            $("#divregister").html(data);
           
        }
    });


}

function ChangeRegister()
{
    var id = $("#cmbregister").val();

    $.ajax({
        type: "GET",
        url: '../PSTypeAndRegister/GetPSRegisterGrid',
        data: {
            id:id,
        },
        success: function (data) {
            $("#psregistergrid").html(data);
            $("#loadertb2").hide();
            var registername = $("#cmbregister :selected").text();
            $("#registername").text(registername);

        }
    });
}

function AssignRegister()
{
    var regid = $("#cmbregister").val();
    var psid = $("#cmbPs").val();
    $.ajax({
        type: "GET",
        url: '../PSTypeAndRegister/AssignPsRegister',
        data: {
            regid: regid,
            psid:psid
        },
        success: function (data) {
            if (data == "success") {
                success();
                ChangeRegister();
                $("#cmbPs").val("");
            }
            else if (data = "fail")
            {
                fail();
            }
        }
    });


}

