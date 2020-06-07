

function GetGrid() {
    $(".blockUI").show();
    $(".blockUI blockOverlay").show();
    $(".blockUI blockMsg blockElement").show();
    $("#progressbar").css("width", "0%");
    var intervalID = setInterval(updateProgress, 180);
    $.ajax({
        type: "get",
        url: '../UserDetails/GetGrid',//url: "@Url.Action("GetGrid", "UserDetails")",
        data: {

        },
    success: function (data) {
        $("#tbody").html(data);
                  

        $(".blockUI").hide();
        $(".blockUI blockOverlay").hide();
        $(".blockUI blockMsg blockElement").hide();
        // $("#progressbar").css("width", "100%");
        clearInterval(intervalID);
        $("#divprogress").hide();
    }


});
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



function NewRecord() {
    var url = '../UserDetails/CreateUser';
    $(location).attr('href', url);
}

function Delete(Id) {
    if (confirm("Are you Sure to delete a record?")) {
        $.ajax({
            type: "POST",
            url: '../UserDetails/DeleteUserDetails',// url: "@Url.Action("DeleteUserDetails", "UserDetails")",
            data: {
            id: Id,
            },
        success: function (data) {
            GetGrid();
            notification("topright", "info", "fa fa-info-circle vd_blue", "Info Notification", "Record Deleted Successfully");

        }
    });
}
}
function View(UserDetailsId) {
    var Id = UserDetailsId;
    $.ajax({
        type: "Post",
        url: '../UserDetails/View',// url: "@Url.Action("View", "UserDetails")",
        data: {

        Id: UserDetailsId,

        },
    success: function (data) {
        $("#ViewOrganisation").html(data);
        $('#View').modal('show');


    }

});


}
function rowClick(Id) {

    var url = '../UserDetails/EditUserDetails?id=' + Id;
    $(location).attr('href', url);

}

