$('#filter-text').focus();
$(".breadcrumb").hide();
$("#masterfavrt").hide();
HideLoader();
// $("#mainheader").html("<h5 style='text-align:center'>Welcome to testing rice mill</h5>");
"use strict";

$(".vd_head-section clearfix").hide();
// init Isotope
var $container = $('.isotope').isotope({
    itemSelector: '.gallery-item ',
    layoutMode: 'fitRows'
});
	  
	
$('.myanchor').contextmenu({
    target: '#context-menu',
    before: function (e, element, target) {
        e.preventDefault();
        var target = e.target || e.srcElement;
        var i = 1;
        var testing = "";
        while (target && !target.id) {
            if (i == 1 ) {
                target = target.parentNode;
                testing = target;
	                 
                BeforeContextMenu(testing);
	                 
                break;
            }
	             

        }
	        
        return true;
    }
});


// User types in search box - call our search function and supply lower-case keyword as argument
$('#filter-text').bind('keyup', function() {
    var filterValue = this.value.toLowerCase();
    isotopeFilter();

});
	
	


document.onkeydown = function (e) {
    switch (e.keyCode) {

        case 38:
            moveUp();
            break;

        case 40:
            moveDown();
            break;
    }
};


function  BeforeContextMenu(testing)
{
	   
    var ss = testing;
    var len = ss.toString().split("/").length - 2;
    var mystring = ss.toString().split("/")[len];
    $.ajax({
        type: "get",
        url: '../FrontPage/Isalreadyexistsmenu',// url: "@Url.Action("Isalreadyexistsmenu", "FrontPage")",
        data: {
        str: mystring
        },
    success: function (data) {
        if (data == "0") {
            $("#addremove").text("Add to Favorite");
            $("#favrturl").val(testing);

            $("#AddOrRemove").val("0");
            $("#context-menu").show();
        }
        if (data == "-1") {
            $("#context-menu").hide();
            $("#AddOrRemove").val("");

        }
        else if (data == "1") {
            $("#favrturl").val(testing);
            $("#addremove").text("Remove From Favorite");
            $("#AddOrRemove").val("1");
            $("#context-menu").show();
        }
                   
    }


});

}

function moveUp() {
    //If nothing selected
    if ($(".selected").length == 0) {
        //alert("hii");
        $("#example").find(".gallery-item :first").addClass("success").focus();
    }

    //Check if there is another link above, if no, go to bottom
    if ($(".selected").prev("a").length > 0) {
        $(".selected").removeClass("success").prev("a").addClass("success").focus();
    } else {
        $(".selected").removeClass("selected");
        $("#example a:last-child").addClass("success").focus();
    }

}

function moveDown() {
    //If nothing selected
    if ($(".selected").length == 0) {
        $("#example .gallery-item").addClass("success").focus();
    }
    //Check if there is another link under, if no, go to top
    if ($(".selected").next("a").length > 0) {
        $(".selected").removeClass("success").next("a").addClass("success").focus();
    } else {
        $(".selected").removeClass("success");
        $("#example .gallery-item").next().addClass("success").focus();
    }
}

//Remove .selected style on click outside
$(document).on("blur", ".selected", function () {
    $(this).removeClass("success");
});












var filterFns = function() {		 
    var kwd = $('#filter-text').val().toLowerCase();
    var re = new RegExp(kwd, "gi");
    var name = $(this).find('.filter-name').text();
    return name.match( re );		  
}
	
	

function isotopeFilter(){

    $container.isotope({ filter: filterFns });	
}
	

	

function AddToFavrt() {
    var ar = $("#AddOrRemove").val();
    var id = $("#favrturl").val();
    var len = id.split("/").length - 2;
    var menu = id.split("/")[len];
    if (ar == 0)
    {
               
        $.ajax({
            type: "get",
            url: '../FrontPage/Addfavrt',//url: "@Url.Action("Addfavrt", "FrontPage")",
            data: {
            str: menu
            },
        success: function (data) {

            if (data == "success") {
                Loadfavrt();
            }
        }


    });
}
else if(ar==1)
{

    $.ajax({
        type: "get",
        url: '../FrontPage/favrtmenuid',// url: "@Url.Action("favrtmenuid", "FrontPage")",
        data: {
        str: menu
        },
    success: function (data) {

        $.ajax({
            type: "get",
            url: '../FrontPage/RemoveFavrt',//url: "@Url.Action("RemoveFavrt", "FrontPage")",
            data: {
            id: data
            },
        success: function (data) {

            if (data == "success") {
                Loadfavrt();
            }
        }


    });
                        
}


});
              
}
       
}

       

function HaveChildred(id)
{
    var menuid = Number($(id).attr("Id").split("_")[1]);
    var url = $("#h_" + menuid + "").val();
    $.ajax({
        type: "get",
        url: '../FrontPage/IsChildExists',// url: "@Url.Action("IsChildExists", "FrontPage")",
        data: {
        id: menuid
        },
    success: function (data) {
        valid = data;
        if (valid == "True") {
            GetSubchild(menuid)
        }
        else {

        }
    }


});
// return valid;
}

function GetSubchild(id) {
          
           
    $.ajax({
        type: "get",
        url: '../FrontPage/GetChilds',// url: "@Url.Action("GetChilds", "FrontPage")",
        data: {
            id: id
        },
        success: function (data) {

            $("#View").modal("show");
            $("#Viewsubmenu").html(data);
            $('.gallery-item').contextmenu({
                target: '#context-menu',
                before: function (e, element, target) {
                    e.preventDefault();
                    var target = e.target || e.srcElement;
                    var i = 1;
                    var testing = "";
                    while (target && !target.id) {
                        if (i == 1) {
                            target = target.parentNode;
                            testing = target;
                            $("#favrturl").val(testing);
                            break;
                        }


                    }

                    return true;
                }
            });

        }

    });
}

