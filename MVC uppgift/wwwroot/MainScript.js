$(function() {

    var modalDiv = $('#modelDiv');
    $('a[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            modalDiv.html(data);
            modalDiv.find('.modal').modal('show');
        })
    })

    
})

$(function () {

    var countriesModal = $('.CountriesCityBox');
    $('a[data-toggle="country-modal"]').click(function (event) {
        console.log("countrya")
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            countriesModal.html(data);
            countriesModal.find('.modal').modal('show');
        })
    })
})

