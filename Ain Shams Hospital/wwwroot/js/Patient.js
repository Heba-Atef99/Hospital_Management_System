$(document).ready(function () {

    //disable first option 

    $("#disablefirst option:first-child").attr("disabled", "disabled");


    $(".price").click(function () {
        $(".price").css("border", "none");
        $(this).css("border", "4px solid black");
    });

    //date time cannot submit with date before today

    var elem = document.getElementById("dateInput");
    var iso = new Date().toISOString();          // Gets today's date
    var minDate = iso.substring(0, iso.length - 8);
    elem.min = minDate;

   
    
});

window.onload = function () {

    //day cannot submit with day before today

    var iso = new Date().toISOString();
    var elemcc = document.getElementById("ExpiryDate");
    var mincc = iso.substring(0, iso.length - 14);
    elemcc.min = mincc;

}

$(function () {
    $('[data-toggle="popover"]').popover();

    $('#cvc').on('click', function () {
        if ($('.cvc-preview-container').hasClass('hide')) {
            $('.cvc-preview-container').removeClass('hide');
        } else {
            $('.cvc-preview-container').addClass('hide');
        }
    });

    $('.cvc-preview-container').on('click', function () {
        $(this).addClass('hide');
    });
});
