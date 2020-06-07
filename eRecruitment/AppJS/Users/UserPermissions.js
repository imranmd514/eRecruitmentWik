function SelectAllMenus() {


    $('#SelectAll').change(function () {
        if ($('#SelectAll').is(":checked")) {
            //$('tbody tr td input[type="checkbox"]').each(function () {
            //    $(this).prop('checked', true);
            //});
           
            $("#Menus").find("input[type='checkbox']").prop("checked", true);
            $("#Menus").find("input[type='checkbox']").attr("checked", true);
        } else {
            //$('tbody tr td input[type="checkbox"]').each(function () {
            //    $(this).prop('checked', false);
            //});
            $("#Menus").find("input[type='checkbox']").prop("checked", false);
            $("#Menus").find("input[type='checkbox']").attr("checked", false);
        }
    });

}
function SelectRow(id) {

    if ($("#select_" + id).prop('checked')) {
        $('tbody tr td input[type="checkbox"]').each(function () {
            $(".row_" + id).prop('checked', true);
        });
    } else {
        $('tbody tr td input[type="checkbox"]').each(function () {
            $(".row_" + id).prop('checked', false);
        });
    }


}
function SelectColumn(id) {

    if ($("#column_" + id).prop('checked')) {
        $('tbody tr td input[type="checkbox"]').each(function () {
            $(".column_" + id).prop('checked', true);
        });
    } else {
        $('tbody tr td input[type="checkbox"]').each(function () {
            $(".column_" + id).prop('checked', false);
        });
    }


}