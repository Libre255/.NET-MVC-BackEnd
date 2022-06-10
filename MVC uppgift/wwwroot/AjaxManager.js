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
    console.log(IdNumber)
    if (IdNumber !== "") {
        $.ajax({
            type: "GET",
            url: "/Ajax/PersonDetails/",
            data: { IdNumber: IdNumber },
            success: function (PartialView) {

                $(".mainContent").html(PartialView); 
            },
            error: function (errorData) { console.log(errorData) }
        });
        console.log("Worksss")
    }
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
    document.getElementById("detailsInput").value = ""
}