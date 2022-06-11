function ShowPeopleList() {
    document.getElementById("detailsInput").value = ""
    $.ajax({
        type: "GET",
        url: "/Ajax/ShowList/",
        success: function (jsReturnArgs) {

            $(".mainContent").html(jsReturnArgs); 
        },
        error: function (errorData) { console.log(errorData) }
    });
}

function PersonDetails() {
    var IdNumber = document.getElementById("detailsInput").value;
    if (IdNumber !== "") {
        $.ajax({
            type: "GET",
            url: "/Ajax/PersonDetails/",
            data: { IdNumber: IdNumber },
            success: function (PartialView) {
                $(".mainContent").html(PartialView).find('.modal').modal('show'); 
            },
            error: function (errorData) { console.log(errorData) }
        });
    }
}

function DeletPerson() {

    var IdNumber = document.getElementById("detailsInput").value;
    $.ajax({
        type: "GET",
        url: "/Ajax/DeletPerson/",
        data: { IdNumber: IdNumber },
        success: function (PartialView) {

            $(".mainContent").html(PartialView).find('.modal').modal('show');
        },
        error: function (errorData) { console.log(errorData) }
    });
    document.getElementById("detailsInput").value = ""
}