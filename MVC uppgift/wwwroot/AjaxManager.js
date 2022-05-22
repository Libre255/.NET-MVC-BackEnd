function ShowPeopleList() {
    $.ajax({
        type: "GET",
        url: "/Ajax/ShowList/",
        success: function (jsReturnArgs) {

            $(".mainContent").html(jsReturnArgs); 
        },
        error: function (errorData) { console.log(errorData) }
    });
}

function ShowOnePerson() {
    var IdNumber = document.getElementById("detailsInput").value;
    $.ajax({
        type: "GET",
        url: "/Ajax/ShowPerson/",
        data: { IdNumber: IdNumber },
        success: function (PartialView) {

            $(".mainContent").html(PartialView); 
        },
        error: function (errorData) { console.log(errorData) }
    });
}

function DeletPersona() {
    var IdNumber = document.getElementById("detailsInput").value;
    console.log("A")
    $.ajax({
        type: "GET",
        url: "/Ajax/DeletPerson/",
        data: { IdNumber: IdNumber },
        success: function (PartialView) {

            $(".mainContent").html(PartialView);
        },
        error: function (errorData) { console.log(errorData) }
    });
}