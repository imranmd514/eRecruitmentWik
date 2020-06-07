
function tab2press() {
     //'AccountNature' = $("#controllername").val();
    LoadGridtb2('AccountNature', 4);


}
function tab3press() {
     //'AccountNature' = $("#controllername").val();
    LoadGridtb3('AccountNature', 4);


}
function tab1press() {
     //'AccountNature' = $("#controllername").val();
    LoadGridtb1('AccountNature', 4);


}
function tab4press() {
    LoadGroup()

}
function test(id) {
    if ($(id).is(":checked")) {
        $("#IsPersonal").attr("checked", true);
        $("#chkIsPersonal").attr("checked", true);
        $("#hiddenpanel").show();

    }
    else {

        $("#IsPersonal").attr("checked", false);
        $("#chkIsPersonal").attr("checked", false);
        $("#hiddenpanel").hide();
    }
}
function Onsubmittb1() {
    var result = RequiredFieldstb1();
    if (result == 0) {
        $("#savespinnertb1").show();
        var PersonalAccountId = $("#PersonalAccountId").val();
        var AccountId = $("#AccountId").val();
        var Account = $("#Account").val();
        var Description = $("#Description").val();
        var NatureId = $("#NatureId").val();
        var IsPersonal = $("#chkIsPersonal").is(":checked");
        var CellNo = $("#CellNo").val();
        var LandNo = $("#LandNo").val();
        var Fax = $("#Fax").val();
        var Email = $("#Email").val();
        var Address = $("#Address").val();
        var Landmark = $("#Landmark").val();
        var State = $("#State").val();
        var District = $("#District").val();
        var Mandal = $("#Mandal").val();
        var CityName = $("#CityName").val();
        var LocalityId = $("#LocalityId").val();
        var Balance = $("#Balance").val();
        var TINNO = $("#TINNO").val();
        var CSTNO = $("#CSTNO").val();
        var FGLNO = $("#FGLNO").val();
        var FCICode = $("#FCICode").val();
        var BiomatricID = $("#BiomatricID").val();
        var WorkingHours = $("#WorkingHours").val();
        var HalfDayWorking = $("#HalfDayWorking").val();
        var Data = {
            "PersonalAccountId": PersonalAccountId,
            "AccountId": AccountId,
            "Account": Account,
            "Description": Description,
            "NatureId": NatureId,
            "CellNo": CellNo,
            "LandNo": LandNo,
            "Fax": Fax,
            "Email": Email,
            "IsPersonal": IsPersonal,
            "Address": Address,
            "Landmark": Landmark,
            "State": State,
            "District": District,
            "Mandal": Mandal,
            "CityName": CityName,
            "LocalityId": LocalityId,
            "Balance": Balance,
            "TINNO": TINNO,
            "CSTNO": CSTNO,
            "FGLNO": FGLNO,
            "FCICode": FCICode,
            "BiomatricID": BiomatricID,
            "WorkingHours": WorkingHours,
            "HalfDayWorking": HalfDayWorking
        }
      //'AccountNature' = $("#controllername").val();
        Savetb1(Data, 'AccountNature');
    }

}



function Onsubmittb2() {
    var result = RequiredFieldstb2();
    if (result == 0) {
        $("#savespinnertb1").show();
        var Nature = $("#Nature").val();
        var NatureId = $("#ActNatureId").val();
        var NatureGroupId = $("#NatureGroupId").val();
        var Mode = $("#Mode").val();
        var NatureDescription = $("#NatureDescription").val();
        var Product = $("#Product").is(":checked");
        var Tax = $("#Tax").is(":checked");
        var Data = {
            "Nature": Nature,
            "NatureGroupId": NatureGroupId,
            "Mode": Mode,
            "ActNatureId": NatureId,
            "Product": Product,
            "Tax": Tax,
            "NatureDescription": NatureDescription
        }
        //'AccountNature' = $("#controllername").val();
        Savetb2(Data, 'AccountNature');
    }

}

function Onsubmittb3() {
    var result = RequiredFieldstb3();
    if (result == 0) {
        $("#savespinnertb2").show();
        var NGId = $("#NGId").val();
        var NatureGroup = $("#NatureGroup").val();
        var Description = $("#GroupDescription").val();
        var Data = {
            "NGId": NGId,
            "NatureGroup": NatureGroup,
            "GroupDescription": Description,

        }
     //'AccountNature' = $("#controllername").val();
        Savetb3(Data, 'AccountNature');

    }

}
