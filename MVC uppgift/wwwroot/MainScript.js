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

console.log("dddd")