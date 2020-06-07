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
    notification("topright", "success", "fa fa-check-circle vd_green", "Success Notification", "Record Submitted Successfully");

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

var stack_topleft = { "dir1": "down", "dir2": "right", "push": "bottom" };
var stack_topright = { "dir1": "down", "dir2": "left", "push": "bottom" };
var stack_bottomleft = { "dir1": "up", "dir2": "right", "push": "bottom" };
var stack_bottomright = { "dir1": "up", "dir2": "left", "push": "bottom" };


function notification(position, notif_type, icon_class, notif_title, notif_text) {
    var output_title, output_stack;
    if (notif_title == "") { output_title = ""; } else {
        output_title = '<h5><strong>' + notif_title + '</strong></h5>';
    };

    switch (position) {
        case 'topright': output_stack = stack_topright; break;
        case 'topleft': output_stack = stack_topleft; break;
        case 'bottomright': output_stack = stack_bottomright; break;
        case 'bottomleft': output_stack = stack_bottomleft; break;
    }


    $.pnotify({
        //				title: 'My Title',
        title_escape: true,
        text: '<div class="content-list content-image"><div class="list-wrapper mgtp-10 mgbt-xs-10"><div><div class="menu-icon"><i class="' + icon_class + '"></i></div> <div class="menu-text">' + output_title + '<p class="lh-sm">' + notif_text + '</p> </div></div></div></div>',
        cornerclass: '',
        type: notif_type,
        icon: 'false',
        width: '320px',
        closer_hover: false,
        sticker: true,
        opacity: 1,
        animation: {
            effect_in: 'shake',
            effect_out: 'fade'
        },
        addclass: 'stack-' + position,
        stack: output_stack

    });
}